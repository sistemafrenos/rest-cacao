namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class MesasCerrada : Entity
    {
        public MesasCerrada()
        {
            MesasCerradasProductos = new HashSet<MesasCerradasProducto>();
        }
        [MaxLength(40)]
        public string DocumentoID { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        public Nullable<int> NumeroLote { set; get; }
        public Nullable<DateTime> Fecha { get; set; }
        public Nullable<int> NumeroImpresiones { get; set; }
        [MaxLength(10)]
        public string Factura { get; set; }
        [MaxLength(10)]
        public string TipoPrecio { get; set; }
        [MaxLength(20)]
        public string CodigoMesa { get; set; }
        [MaxLength(40)]
        public string Ubicacion { get; set; }
        public bool? CobraServicio { get; set; }
        [MaxLength(100)]
        public string Mesonero { get; set; }
        public Nullable<int> Personas { get; set; }
        public Nullable<DateTime> Apertura { get; set; }
        public Nullable<DateTime> Cierre { get; set; }
        public Nullable<double> MontoGravable { get; set; }
        public Nullable<double> MontoExento { get; set; }
        public Nullable<double> MontoIva { get; set; }
        public Nullable<double> MontoTotal { get; set; }
        public Nullable<double> Descuentos { get; set; }
        public Nullable<double> MontoServicio { get; set; }
        [MaxLength(150)]
        public string Comentarios { get; set; }
        [MaxLength(10)]
        public string CedulaRif { get; set; }
        [MaxLength(150)]
        public string RazonSocial { get; set; }
        [MaxLength(150)]
        public string Direccion { get; set; }
        [MaxLength(40)]
        public string Telefonos { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Tipo { get; set; }
        public Nullable<double> Efectivo { get; set; }
        public Nullable<double> Cheque { get; set; }
        public Nullable<double> TarjetaCR { get; set; }
        public Nullable<double> TarjetaDB { get; set; }
        public Nullable<double> CestaTickets { get; set; }
        public Nullable<double> Saldo { get; set; }

        public virtual ICollection<MesasCerradasProducto> MesasCerradasProductos { get; set; }
        public void Totalizar()
        {
            var productos = MesasCerradasProductos.Where(x => x.Anulado != true);
            this.MontoExento = productos.Where(x => x.TasaIva.GetValueOrDefault(0) == 0).Sum(x => x.Cantidad * x.Precio);
            this.MontoGravable = productos.Where(x => x.TasaIva.GetValueOrDefault(0) > 0).Sum(x => x.Cantidad * x.Precio);
            this.MontoIva = productos.Where(x => x.TasaIva.GetValueOrDefault(0) > 0).Sum(x => x.Cantidad * x.Precio * x.TasaIva / 100);
            this.MontoServicio = this.CobraServicio == true ? this.MontoGravable * 0.1 : 0;
            this.MontoTotal = (double)Decimal.Round((decimal)(
            this.MontoExento.GetValueOrDefault(0)
            + this.MontoGravable.GetValueOrDefault(0)
            + this.MontoIva.GetValueOrDefault(0)
            - this.Descuentos.GetValueOrDefault(0)), 2);
        }
    }
}
