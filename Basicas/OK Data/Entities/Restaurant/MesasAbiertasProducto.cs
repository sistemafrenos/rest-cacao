namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class MesasAbiertasProducto : Entity
    {
        [MaxLength(40)]
        [Required(ErrorMessage = "Producto invalido")]
        public string ProductoID { get; set; }
        [MaxLength(40)]
        [Required(ErrorMessage = "Es requerido el codigo del producto")]
        public string Codigo { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Es requerido la descripcion del producto")]
        public string Descripcion { get; set; }
        public Nullable<double> Cantidad { get; set; }
        public Nullable<double> Precio { get; set; }
        public Nullable<double> TasaIva { get; set; }
        public Nullable<double> PrecioConIva { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> Costo { get; set; }
        [MaxLength(40)]
        public string EnviarComanda { get; set; }
        [MaxLength(150)]
        public string Departamento { get; set; }
        [MaxLength(150)]
        public string Comentario { get; set; }
        [MaxLength(100)]
        public string Mesonero { get; set; }
        public Nullable<System.DateTime> Hora { get; set; }
        [MaxLength(10)]
        public string NumeroComanda { get; set; }
        public Nullable<bool> Alerta { get; set; }
        public Nullable<bool> Anulado { get; set; }
        public Nullable<double> TotalBase { get; set; }
        public Boolean LlevaInventario { set; get; }
        double? Iva { get; set; }
        public virtual MesasAbierta MesasAbierta { get; set; }

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
