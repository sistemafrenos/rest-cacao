using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    [Serializable]
    public class Factura : Documento
    {
        public Factura()
        {
            TipoPrecio = "PRECIO 1";
            Estatus = "ABIERTA";
        }
        public string categoria { set; get; }
        [NotMapped]
        public double? MontoServicio { set; get; }
        [NotMapped]
        public double? Efectivo { set; get; }
        [NotMapped]
        public double? Cheque { set; get; }
        [NotMapped]
        public double? TarjetaCredito { set; get; }
        [NotMapped]
        public double? TarjetaDebito { set; get; }
        [NotMapped]
        public double? Credito { set; get; }

    }
}
