using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class NotaEntrega : Documento
    {
        public NotaEntrega()
        {
            TipoPrecio = "PRECIO 1";
            Estatus = "POR FACTURAR";
        }
    }
}
