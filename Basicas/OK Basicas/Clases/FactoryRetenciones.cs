using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HK.Clases;

namespace HK.Clases
{
    public class FactoryRetenciones
    {
        public static List<Retencion> getItems(string texto)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var mitems = from x in db.Retenciones
                             orderby x.NumeroComprobante
                             where (x.NumeroComprobante.Contains(texto) || x.NumeroDocumento.Contains(texto) || x.NombreRazonSocial.Contains(texto) || texto.Length == 0)
                             select x;
                return mitems.ToList();
            }
        }
        public static List<Retencion> getItems(DatosEntities db, string texto)
        {
            var mitems = from x in db.Retenciones
                         orderby x.NumeroComprobante
                         where (x.NumeroComprobante.Contains(texto) || x.NumeroDocumento.Contains(texto) || x.NombreRazonSocial.Contains(texto) || texto.Length == 0)
                         select x;
            return mitems.ToList();
        }
        public static Retencion Item(string id)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var item = (from x in db.Retenciones
                            where (x.Id == id)
                            select x).FirstOrDefault();
                return item;
            }
        }
        public static Retencion Item(DatosEntities db, string id)
        {
            var item = (from x in db.Retenciones
                        where (x.Id == id)
                        select x).FirstOrDefault();
            return item;
        }
        public static List<Retencion> Retencion(string NumeroComprobante)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var retencion = from item in db.Retenciones
                                where item.NumeroComprobante == NumeroComprobante
                                select item;
                return retencion.ToList();
            }
        }
        public static List<Retencion> Item(Documento registro)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var retencion = from item in db.Retenciones
                                where item.IdDocumento == registro.IdDocumento
                                select item;
                return retencion.ToList();
            }
        }
        public static List<Retencion> Item(Retencion registro)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var retencion = from item in db.Retenciones
                                where item.NumeroComprobante == registro.NumeroComprobante
                                select item;
                return retencion.ToList();
            }
        }

    }
}
