namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class MesasCerradasProducto:Entity
    {
        [MaxLength(40)]
        public string ProductoID { get; set; }
        [MaxLength(20)]
        public string Codigo { get; set; }
        [MaxLength(150)]
        public string Descripcion { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<double> TasaIva { get; set; }
        public Nullable<double> PrecioConIva { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> Costo { get; set; }
        [MaxLength(100)]
        public string Departamento { get; set; }
        [MaxLength(100)]
        public string Mesonero { get; set; }
        public Nullable<DateTime> Hora { get; set; }
        public string NumeroComanda { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public Boolean LlevaInventario { set; get; }

        public Nullable<int> NumeroLote { get; set; }

        public virtual MesasCerrada MesasCerrada { get; set; }
    }
}
