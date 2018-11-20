using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.Clases
{
    public class FactoryDrivers
    {
        public static List<string> getDrivers()
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.Terceros
                        orderby p.RazonSocial
                        where p.Categoria!= null && p.Categoria !="DESINCORPORADO"
                        select p.RazonSocial;
                return q.ToList();
            }
        }

        public static List<Tercero> getItems(string texto)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.Terceros
                        orderby p.RazonSocial
                        where (p.Codigo == texto || p.CedulaRif.Contains(texto) || p.RazonSocial.Contains(texto) || p.Driver.Contains(texto) || texto.Length == 0) && p.Categoria != null
                        select p;
                return q.ToList();
            }
        }

        public static List<Tercero> getItems(DatosEntities db, string texto)
        {
            var q = from p in db.Terceros
                    orderby p.RazonSocial
                    where (p.Codigo == texto || p.CedulaRif.Contains(texto) || p.RazonSocial.Contains(texto) || p.Driver.Contains(texto) || texto.Length == 0) && p.Categoria!=null
                    select p;
            return q.ToList();
        }

        public static Tercero Item(string codigo)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.Terceros
                        where p.IdTercero == codigo
                        select p;
                return q.FirstOrDefault();
            }
        }
        public static Tercero ItemxId(string idTercero)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.Terceros
                        where p.IdTercero == idTercero
                        select p;
                return q.FirstOrDefault();
            }
        }
        public static Tercero ItemxId(DatosEntities db, string idVendedor)
        {
            var q = from p in db.Terceros
                    where p.IdTercero == idVendedor
                    select p;
            return q.FirstOrDefault();
        }
        public static Tercero Item(DatosEntities db, string codigo)
        {
            var q = from p in db.Terceros
                    where p.Codigo == codigo
                    select p;
            return q.FirstOrDefault();
        }
    }
}
