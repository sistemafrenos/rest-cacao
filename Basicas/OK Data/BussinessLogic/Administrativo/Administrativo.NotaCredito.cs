using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public NotaDeCredito FindNotaDeCredito(string id)
        {
            return data.NotaCreditoRepository.Find(id);
        }
        public void EliminarNotaDeCredito(NotaDeCredito doc, bool eliminarAhora)
        {
            data.NotaCreditoRepository.Delete(doc);
            if (eliminarAhora)
            {
                data.Save();
            }
        }
        public NotaDeCredito[] GetAllNotaDeCredito(string texto)
        {
            var consulta = data.NotaCreditoRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto) || d.Numero == texto)
                            select d);
            }
            consulta = consulta.Where(d => d.Tipo == "NOTA CREDITO");
            return consulta.OrderBy(d => d.Fecha).ToArray();
        }
        public string GuardarNotaDeCredito(NotaDeCredito doc, bool guardarAhora)
        {
            doc.Tipo = "NOTA CREDITO";
            doc.Vence = doc.Fecha.AddDays(0);
            doc.Numero = GetContador("NOTA CREDITO");
            doc.Calcular();
            string result = ValidarDocumento(doc);
            if (result != null)
                return result;
            result = PrepararCliente(doc);
            if (result != null)
                return result;
            if (data.NotaCreditoRepository.Find(doc.ID) == null)
                data.NotaCreditoRepository.Insert(doc);
            else
                data.NotaCreditoRepository.Update(doc);
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public NotaDeCredito CrearNotaDeCredito(Factura doc)
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
            retorno.DocumentoAfectado = doc.Numero;
            foreach (var item in doc.DocumentosProductos)
            {
                DocumentosProducto detalle = new DocumentosProducto()
                {
                    Cantidad = item.Cantidad,
                    Codigo = item.Codigo,
                    Costo = item.Costo,
                    Descripcion = item.Descripcion,
                    Departamento = item.Departamento,
                    ProductoID = item.ProductoID,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Fecha = DateTime.Today,
                    Entrada = item.Salida,
                    LlevaInventario = item.LlevaInventario,
                    CostoNeto = item.CostoNeto,
                    Comentario = item.Comentario,
                    CodigoProveedor = item.CodigoProveedor,
                    Presentacion = item.Presentacion,
                    UnidadesxEmpaque = item.UnidadesxEmpaque
                };
                detalle.Calcular();
                retorno.DocumentosProductos.Add(detalle);
            }
            doc.Saldo = 0;
            doc.Anulado = true;
            doc.Estatus = "ANULADO";
            retorno.Calcular();
            retorno.Saldo = 0;
            return retorno;
        }
        public string ProcesarNotaCredito(Factura item, NotaDeCredito notaDeCredito)
        {
            notaDeCredito.Ano = notaDeCredito.Fecha.Year;
            notaDeCredito.Mes = notaDeCredito.Fecha.Month;
            notaDeCredito.Tipo = "NOTA CREDITO";
            if (notaDeCredito.Numero== null)
            {
                notaDeCredito.Numero = GetContador("NOTA CREDITO");
            }
            string result = ValidarDocumento(notaDeCredito);
            if (result != null)
                return result;
            result = GuardarNotaDeCredito(notaDeCredito,false);
            if (result != null)
                return result;
            ProcesarInventarios(notaDeCredito,false);
            if (result != null)
                return result;
            result = EscribirCuentaxCobrar(notaDeCredito);
            if (result != null)
                return result;
            item.Saldo = 0;
            item.Anulado = true;
            item.Estatus = "ANULADO";
            data.FacturaRepository.Update(item);
            var cxp = data.TerceroMovimientosRepository.GetFirst(x => x.DocumentoID == item.ID);
            if (cxp != null)
            {
                cxp.Saldo = 0;
                data.TerceroMovimientosRepository.Update(cxp);
            }
            notaDeCredito.Tercero.FacturasPendientes = notaDeCredito.Tercero.FacturasPendientes.GetValueOrDefault() - 1;
            notaDeCredito.Tercero.SaldoPendiente = notaDeCredito.Tercero.SaldoPendiente.GetValueOrDefault() - notaDeCredito.MontoTotal;
            result = EscribirLibroDeVentas((Documento)notaDeCredito);
            if (result != null)
                return result;
            result = EscribirLibroInventarios(notaDeCredito,false);
            if (result != null)
                return result;
            return data.Save();
        }
    }
}
