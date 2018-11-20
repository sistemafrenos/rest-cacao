namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class ProductosCompuesto : Entity
    {
        [MaxLength(40)]
        public string InsumoID { get; set; }
        [MaxLength(40)]
        public string Codigo { set; get; }
        [MaxLength(150)]
        public string Descripcion { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<double> TotalCosto { get; set; }
        public virtual Producto Producto { get; set; }

        public void Calcular()
        {
            TotalCosto = Costo * Cantidad;
        }
    }
}
