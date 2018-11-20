using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HK;

namespace HK.Clases
{
    public class FactoryLibroCompras
    {
        public static List<LibroCompra> getItems(int mes, int ano)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.LibroCompras
                        orderby p.Fecha
                        where p.Mes == mes && p.AÃ±
                ;
                o == aÃ±
                ;
                o
                select;
                p;
                return q.ToList();
            }
        }
        public static List<LibroCompra> getItems(DatosEntities db, int mes, int aÃ±
        )
        {
            var q = from p in db.LibroCompras
                    orderby p.Fecha
                    where p.Mes == mes && p.AÃ±
            ;
            o == aÃ±
            ;
            o
            select;
            p;
            return q.ToList();
        }
        public static LibroCompra Item(string IdLibroCompras)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.LibroCompras
                        where p.IdLibroCompras == IdLibroCompras
                        select p;
                return q.FirstOrDefault();
            }
        }
        public static LibroCompra Item(DatosEntities db, string IdLibroCompras)
        {
            var q = from p in db.LibroCompras
                    where p.IdLibroCompras == IdLibroCompras
                    select p;
            return q.FirstOrDefault();
        }
        public static void EscribirItem(Documento factura)
        {
            if (factura.LibroCompras.GetValueOrDefault(false) == false)
                return;
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                try
                {
                    LibroCompra item = new LibroCompra();
                    item.AÃ ±
                    o = factura.AÃ±
                    ;
                    o;
                    item.CedulaRif = factura.CedulaRif;
                    item.Fecha = factura.Fecha;
                    item.Mes = factura.Mes;
                    item.MontoExento = Basicas.Round(factura.MontoExento);
                    item.MontoGravable = Basicas.Round(factura.MontoGravable);
                    item.MontoIva = Basicas.Round( factura.MontoIva);
                    item.TasaIva = factura.TasaIva;
                    item.MontoTotal = Basicas.Round( factura.MontoTotal);
                    item.Numero = factura.Numero;
                    item.NumeroControl = factura.NumeroControl;
                    item.RazonSocial = factura.RazonSocial;
                    item.AsignarID();
                    item.MontoGravableB = factura.MontoGravableB;
                    item.MontoIvaB = Basicas.Round( factura.MontoIvaB);
                    item.TasaIvaB = Basicas.Round( factura.TasaIvaB);
                    item.IdDocumento = factura.IdDocumento;
                    db.LibroCompras.Add(item);
                    var compra = FactoryCompras.Item(db, factura.IdDocumento);
                    compra.LibroCompras = true;
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
            }
        }
        public static void BorrarItem(Documento compra)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                try
                {
                    LibroCompra item = (from p in db.LibroCompras
                                        where p.Numero == compra.Numero && p.CedulaRif == compra.CedulaRif
                                        select p).FirstOrDefault();
                    if (item != null)
                    {
                        db.LibroCompras.Remove(item);
                        db.SaveChanges();
                    }
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
            }
        }
        public  static bool Existe(Documento item)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var x = (from p in db.LibroCompras
                         where p.Numero == item.Numero && p.CedulaRif == item.CedulaRif
                         select p).FirstOrDefault();
                if (x == null)
                    return false;
                return true;
            }
        }

        internal static void EliminarItem(Documento item)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var items = (from p in db.LibroCompras
                             where p.IdDocumento == item.IdDocumento
                             select p).ToList();
                foreach (var x in items)
                {
                    db.LibroCompras.Remove(x);
                }
                db.SaveChanges();
            }
        }

        internal static void EscribirItem(TercerosMovimiento registro)
        {
            Documento factura = FactoryCompras.Item(registro.IdDocumento);
            if (factura == null)
                return;
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                try
                {
                    LibroCompra item = new LibroCompra();
                    item.AÃ ±
                    o = registro.Fecha.Value.Year;
                    item.CedulaRif = factura.CedulaRif;
                    item.Fecha = registro.Fecha.Value;
                    item.Mes = registro.Fecha.Value.Month;
                    item.MontoExento = registro.MontoSinDerechoCreditoFiscal;
                    item.MontoGravable = registro.MontoGravable;
                    item.MontoIva = registro.MontoIva;
                    item.TasaIva = registro.TasaIva;
                    item.MontoTotal = registro.Credito == null ? registro.Debito : registro.Credito;
                    item.Numero = factura.Numero;
                    item.NumeroControl = registro.NumeroControl;
                    item.RazonSocial = factura.RazonSocial;
                    item.AsignarID();
                    item.IdDocumento = factura.IdDocumento;
                    db.LibroCompras.Add(item);
                    var compra = FactoryCompras.Item(db, factura.IdDocumento);
                    compra.LibroCompras = true;
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
            }
        }
    }
}
