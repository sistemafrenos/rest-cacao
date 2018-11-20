using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant
    {
        private DatosEntities db;
        private LibroVenta CrearItemLibroDeVentasExtra(Documento factura)
        {
            LibroVenta current;
            if (string.IsNullOrEmpty(factura.Numero))
                return null;
            current = new LibroVenta();
            current.Ano = factura.Fecha.Year;
            current.CedulaRif = factura.CedulaRif;
            current.Fecha = factura.Fecha;
            current.FacturaID = factura.ID;
            current.IvaRetenido = null;
            current.Mes = factura.Fecha.Month;
            current.Comprobante = null;
            current.FacturaAfectada = factura.DocumentoAfectado;
            current.MontoTotal = factura.MontoTotal;
            current.NumeroZ = factura.NumeroZ;
            current.RazonSocial = factura.RazonSocial;
            current.MaquinaFiscal = factura.MaquinaFiscal;
            current.Factura = factura.Numero;
            current.MontoExento = factura.MontoExento;
            if (factura.CedulaRif[0] == 'V' || factura.CedulaRif[0] == 'E')
            {
                current.MontoGravableNoContribuyentes = factura.MontoGravable;
                current.MontoIvaNoContribuyentes = factura.MontoIva;
                current.TasaIvaNoContribuyentes = factura.TasaIva;
            }
            else
            {
                current.MontoGravableContribuyentes = factura.MontoGravable;
                current.MontoIvaContribuyentes = factura.MontoIva;
                current.TasaIvaContribuyentes = factura.TasaIva;
            }
            if (factura.Tipo == "FACTURA")
            {
                current.TipoOperacion = "01";

            }
            else
            {
                current.TipoOperacion = "02";
                current.MontoExento = current.MontoExento * -1;
                current.MontoGravableContribuyentes = current.MontoGravableContribuyentes * -1;
                current.MontoIvaContribuyentes = current.MontoIvaContribuyentes * -1;
                current.TasaIvaContribuyentes = current.TasaIvaContribuyentes * -1;
                current.MontoGravableNoContribuyentes = current.MontoGravableNoContribuyentes * -1;
                current.MontoIvaNoContribuyentes = current.MontoIvaNoContribuyentes * -1;
                current.TasaIvaNoContribuyentes = current.TasaIvaNoContribuyentes * -1;
                current.MontoTotal = current.MontoTotal * -1;
                current.Factura = null;
                current.NotaCredito = factura.Numero;
            }
            return current;
        }
        public string ProcesarFacturaRestaurant(Factura factura, Pago _pago)
        {
            db = new DatosEntities();
            string result;
            factura.Ano = factura.Fecha.Year;
            factura.Mes = factura.Fecha.Month;
            factura.Tipo = "FACTURA";
            factura.Estatus = "CERRADA";
            result = ValidarDocumento(factura);
            if (result != null)
                return result;
            Tercero cliente = (from x in db.Terceros
                               where  x.CedulaRif == factura.CedulaRif
                               select x).FirstOrDefault();
            if (cliente == null)
            {
                cliente = new Tercero();
                cliente.EsNuevo = true;
                cliente.Tipo = "CLIENTE";
                cliente.Activo = true;
                cliente.TipoPrecio = "PRECIO 1";
            }
            else 
            {
                cliente.EsNuevo = false;
            }
            cliente.CedulaRif = factura.CedulaRif;
            cliente.RazonSocial = factura.RazonSocial;
            cliente.Direccion = factura.Direccion;
            if (!cliente.EsNuevo)
            {
                db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                db.Terceros.Add(cliente);
            }
            _pago.Fecha = factura.Fecha;
            _pago.Concepto = "FACTURA:" + factura.Numero;
            _pago.Documento = factura;
            _pago.Numero = factura.Numero;
            _pago.TipoDocumento = "FACTURA";
            db.Pagos.Add( OK.DeepCopy(_pago));
            db.LibroVentas.Add( CrearItemLibroDeVentas(factura));
            try
            {
                int registros = db.SaveChanges();
            }
            catch (Exception x)
            {
               var s =  OK.ManejarException(x);
               return s;
            }
            return null;
        }
    }
}
