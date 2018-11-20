using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.Clases
{
    public class FactoryEventos
    {
        public static List<Evento> getEventos()
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.Eventos
                        where p.Dia == DateTime.Today
                        orderby p.Fecha descending
                        select p;
                return q.ToList();
            }
        }
        public static List<Evento> getEventos(DatosEntities db)
        {
            var q = from p in db.Eventos
                    where p.Dia == DateTime.Today
                    orderby p.Fecha descending
                    select p;
            return q.ToList();
        }

    }
}
