using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class ProductoDescarga : Documento
    {
        public ProductoDescarga()
        {
            Fecha = DateTime.Today;
            Hora = DateTime.Now;
            Tipo = "DESCARGA";
        }
    }
}
