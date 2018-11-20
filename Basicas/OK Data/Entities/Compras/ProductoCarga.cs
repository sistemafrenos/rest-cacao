using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class ProductoCarga : Documento
    {
        public ProductoCarga()
        {
            Fecha = DateTime.Today;
            Hora = DateTime.Now;
            Tipo = "CARGA";
        }
    }
}
