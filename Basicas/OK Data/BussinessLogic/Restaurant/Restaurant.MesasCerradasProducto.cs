using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public partial class MesasCerradasProducto
    {
        [NotMapped]
        public double? Iva { set; get; }
        public void Calcular()
        {
            double? MontoExento = this.TasaIva.GetValueOrDefault(0) == 0 ? this.Precio * this.Cantidad : 0;
            double? MontoGravable = this.TasaIva.GetValueOrDefault(0) > 0 ? this.Precio * this.Cantidad : 0;
            this.PrecioConIva = this.TasaIva.GetValueOrDefault(0) > 0 ? this.Precio + (this.Precio * this.TasaIva / 100) : this.Precio;
            this.Iva = MontoGravable.GetValueOrDefault(0) > 0 ? MontoGravable * this.TasaIva.GetValueOrDefault(0) / 100 : 0;
            this.Total = MontoGravable + MontoExento + this.Iva;
        }
    }
}
