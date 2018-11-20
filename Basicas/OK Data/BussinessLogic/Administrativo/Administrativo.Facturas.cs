using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        // Facturas
        public Factura FindFactura(string id)
        {
            return data.FacturaRepository.Find(id);
        }
        public Factura FindFacturaByNumero(string numero)
        {
            return data.FacturaRepository.dbSet.Where(x => x.Numero == numero).FirstOrDefault();
        }
        public Factura CrearFactura(Documento doc)
        {
            Factura retorno = new Factura();
            retorno.Anulado = false;
            retorno.CedulaRif = doc.CedulaRif;
            retorno.Email = doc.Email;
            retorno.Telefonos = doc.Telefonos;
            retorno.RazonSocial = doc.RazonSocial;
            retorno.Comentarios = doc.Comentarios;
            retorno.Descuentos = doc.Descuentos;
            retorno.Direccion = doc.Direccion;
            retorno.Fecha = DateTime.Today;
            foreach (var item in doc.DocumentosProductos)
            {
                DocumentosProducto detalle = new DocumentosProducto()
                {

                    Cantidad = item.Cantidad,
                    Salida = item.Cantidad,
                    Codigo = item.Codigo,
                    Costo = item.Costo,
                    Descripcion = item.Descripcion,
                    Departamento = item.Departamento,
                    ProductoID = item.ProductoID,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Fecha = DateTime.Today,
                    LlevaInventario = item.LlevaInventario
                };
                detalle.CalcularItemFactura();
                retorno.DocumentosProductos.Add(detalle);
            }
            retorno.Calcular();
            return retorno;
        }
        public string ActualizarFactura(Factura factura, bool guardarAhora)
        {
            if (data.FacturaRepository.Find(factura.ID) == null)
                data.FacturaRepository.Insert(factura);
            else
                data.FacturaRepository.Update(factura);
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string GuardarFactura(Factura factura, string Estatus, bool guardarAhora)
        {
           // factura.Tipo = "FACTURA";
            factura.Vence = factura.Fecha.AddDays(0);
            factura.Estatus = Estatus;
            if (Estatus == "FACTURA ABIERTA")
            {
                factura.Numero = GetContador("FACTURA ABIERTA");
            }
            //factura.Calcular();
            string result = ValidarDocumento(factura);
            if (result != null)
                return result;
            if (data.FacturaRepository.Find(factura.ID) == null)
                data.FacturaRepository.Insert(factura);
            else
                data.FacturaRepository.Update(factura);
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string ProcesarFactura(Factura factura,Pago pago,bool actualizarCliente)
        {
            string result;
            factura.Ano = factura.Fecha.Year;
            factura.Mes = factura.Fecha.Month;
            factura.Tipo = "FACTURA";
            result = ValidarDocumento(factura);
            if (result != null)
                return result;
            if (actualizarCliente)
            {
                result = PrepararCliente(factura);
                if (result != null)
                    return result;
            }
            result = GuardarFactura(factura, "CERRADA",false);
            if (result != null)
                return result;
            prepararPago(factura, pago);
            ProcesarInventarios(factura,false);
            if (factura.Saldo > 0)
            {
                result = EscribirCuentaxCobrar(factura);
                if (result != null)
                    return result;
                factura.Tercero.FacturasPendientes = factura.Tercero.FacturasPendientes.GetValueOrDefault() + 1;
                factura.Tercero.SaldoPendiente = factura.Tercero.SaldoPendiente.GetValueOrDefault() + factura.Saldo;
            }
            if (result != null)
                return result;
            result = EscribirLibroDeVentas(factura);
            if (result != null)
                return result;
            result = EscribirLibroInventarios(factura,false);
            if (result != null)
                return result;
            return data.Save();
        }

        private void prepararPago(Factura factura, Pago pago)
        {
            pago.Concepto = string.Format("PAGO {0} {1}", factura.Tipo, factura.Numero);
            pago.Fecha = DateTime.Today;
            pago.Hora = DateTime.Now;
            pago.Numero = GetContador("Numero Pago");
            pago.TipoDocumento = factura.Tipo;
            pago.Documento = factura;
            data.PagoRepository.Insert(pago);
            factura.Saldo = factura.MontoTotal.GetValueOrDefault() - pago.MontoPagado.GetValueOrDefault();
            factura.Saldo = factura.Saldo + pago.Credito.GetValueOrDefault();
            if (factura.Saldo < 0)
            {
                factura.Saldo = 0;
            }
        }
        private string GuardarPago(Pago pago)
        {
            if (!data.IsValid(pago))
            {
                return data.ValidationErrors(pago);
            }
            data.PagoRepository.Insert(pago);
            return null;
        }
        public IQueryable<Factura> GetQueryableFacturas()
        {
            return data.FacturaRepository.GetAsQueryable("Pagos");
        }
        public Factura[] GetAllFacturas(string texto, string status = null)
        {
            var query = data.FacturaRepository.GetAsQueryable("");
                query = query.Where(x => x.Tipo == "FACTURA");
            if(string.IsNullOrEmpty(texto))
            {
                query = query.Where(d => d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto));
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(d => d.Estatus == status);
            }
            query = query.OrderBy(d => d.Numero);
            return query.ToArray();
        }
        public Factura[] GetAllFacturasAbiertas(string texto, string status = null)
        {
            var query = data.FacturaRepository.GetAsQueryable("");
            query = query.Where(x => x.Tipo == "FACTURA ABIERTA");
            if (string.IsNullOrEmpty(texto))
            {
                query = query.Where(d => d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto));
            }
            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(d => d.Estatus == status);
            }
            query = query.OrderBy(d => d.Numero);
            return query.ToArray();
        }
        // Notas Credito
        public Documento CrearNotaCredito(Factura doc)
        {
            NotaDeCredito retorno = new NotaDeCredito();
            retorno.Anulado = false;
            retorno.CedulaRif = doc.CedulaRif;
            retorno.Email = doc.Email;
            retorno.Telefonos = doc.Telefonos;
            retorno.RazonSocial = doc.RazonSocial;
            retorno.Comentarios = doc.Comentarios;
            retorno.Descuentos = doc.Descuentos;
            retorno.Direccion = doc.Direccion;
            retorno.Fecha = DateTime.Today;
            foreach (var item in doc.DocumentosProductos)
            {
                DocumentosProducto detalle = new DocumentosProducto()
                {
                    Cantidad = item.Cantidad,
                    Salida = item.Cantidad,
                    Codigo = item.Codigo,
                    Costo = item.Costo,
                    Descripcion = item.Descripcion,
                    Departamento = item.Departamento,
                    ProductoID = item.ProductoID,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Fecha = DateTime.Today,
                    LlevaInventario = item.LlevaInventario
                };
                detalle.CalcularItemFactura();
                retorno.DocumentosProductos.Add(detalle);
            }
            retorno.Calcular();
            return retorno;
        }

    }
}
