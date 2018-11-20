using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HK
{   
    public static class TerceroTable
    { 
        public static Tercero[] GetAllClientes(string texto)
        {
            DatosEntities db = new DatosEntities();
            var consulta = db.Terceros.Where(d => d.Tipo == "CLIENTE");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto))
                            select d);
            }
            return consulta.OrderBy(d => d.RazonSocial).ToArray();
        }
    }
}
