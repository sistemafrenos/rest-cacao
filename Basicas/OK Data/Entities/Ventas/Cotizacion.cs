using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class Cotizacion : Documento
    {
        public Cotizacion()
        {
            TipoPrecio = "PRECIO 1";
        }
    }
}
