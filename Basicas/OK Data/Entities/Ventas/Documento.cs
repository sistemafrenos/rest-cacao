
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HK.BussinessLogic;

namespace HK
{
    public partial class Documento : Entity
    {
        private double? mTasaIva;
        private double? mTasaIvaB;
        public Documento()
        {
            Hora = DateTime.Now;
            Fecha = DateTime.Today;
            Vence = Fecha;
            Ano = DateTime.Today.Year;
            Mes = DateTime.Today.Month;
            Pagos = new HashSet<Pago>();
            DocumentosProductos = new HashSet<DocumentosProducto>();
        }
        public Nullable<bool> Anulado { set; get; }
        public Nullable<bool> CajaChica { set; get; }
        public DateTime Fecha { get; set; }
        public DateTime Vence { get; set; }
        public DateTime Hora { get; set; }
        public Nullable<int> Mes { set; get; }
        public Nullable<int> Ano { set; get; }
        [MaxLength(20)]
        public string Tipo { get; set; }
        [MaxLength(20)]
        public string Estatus { get; set; }
        [MaxLength(20)]
        public string Numero { get; set; }
        [MaxLength(20)]
        public string NumeroOrden { get; set; }
        [MaxLength(20)]
        public string NumeroControl { get; set; }
        [MaxLength(10)]
        public string NumeroZ { get; set; }
        [MaxLength(20)]
        public string TipoPrecio { set; get; }
        [MaxLength(20)]
        public string MaquinaFiscal { get; set; }
        [Required(ErrorMessage = "Es requerida la cedula/rif")]
        [MaxLength(10, ErrorMessage = "La Descripcion Debe tener  10 caracteres")]
        public string CedulaRif { get; set; }
        [Required(ErrorMessage = "Es requerida la razon social")]
        [MaxLength(150, ErrorMessage = "La razon social Debe tener hasta 150 caracteres")]
        public string RazonSocial { get; set; }
        public string Direccion { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        [MaxLength(40)]
        public string Telefonos { get; set; }
        public Nullable<double> MontoSinDerechoCredito { get; set; }
        public Nullable<double> MontoExento { get; set; }
        public Nullable<double> MontoImpuestosLicores { get; set; }
        public Nullable<double> MontoGravable { get; set; }
        public Nullable<double> MontoGravableB { get; set; }
        public double? TasaIva
        {
            set
            { mTasaIva = value; }
            get
            {
                if (mTasaIva == null)
                {
                    mTasaIva = OK.SystemParameters.TasaIva;
                }
                return mTasaIva;
            }
        }
        public double? TasaIvaB
        {
            set
            { mTasaIvaB = value; }
            get
            {
                if (mTasaIvaB == null)
                {
                    mTasaIvaB = OK.SystemParameters.TasaIvaB;
                }
                return mTasaIvaB;
            }
        }
        public Nullable<double> MontoIva { get; set; }
        public Nullable<double> MontoIvaB { get; set; }
        public Nullable<double> Descuentos { get; set; }
        public Nullable<double> MontoTotal { get; set; }
        public Nullable<double> Saldo { get; set; }
        [MaxLength(20)]
        public string CodigoVendedor { get; set; }
        [MaxLength(150)]
        public string Vendedor { get; set; }
        [MaxLength(250)]
        public string Comentarios { get; set; }
        public Nullable<bool> LibroVentas { set; get; }
        public Nullable<bool> LibroCompras { set; get; }
        public Nullable<bool> LibroInventarios { set; get; }
        [MaxLength(20)]
        public string CodigoCuenta { get; set; }
        [MaxLength(150)]
        public string DescripcionCuenta { get; set; }
        [MaxLength(40)]
        public string ComprobanteRetencionIVA { get; set; }
        [MaxLength(40)]
        public string ComprobanteRetencionISLR { get; set; }
        public Nullable<double> DescuentoProntoPago { set; get; }
        public Nullable<bool> Inventarios { get; set; }
        [MaxLength(20)]
        public string DocumentoAfectado { get; set; }
        [MaxLength(20)]
        public string Referencia { get; set; }
        [MaxLength(20)]
        public string DocumentoAfectadoID { set; get;}
        public Nullable<double> BaseImponible { get; set; }
        public Nullable<double> MontoSujetoRetencion { get; set; }
        public Nullable<double> PorcentajeRetencion { get; set; }
        public Nullable<double> Sustraendo { get; set; }
        public Nullable<double> MontoRetenido { get; set; }
        public Nullable<DateTime> FechaComprobante { set; get; }
        [MaxLength(20)]
        public string NotaCredito { set; get; }
        [MaxLength(20)]
        public string NotaDebito { set; get; }


        public virtual Tercero Tercero { get; set; }

        public virtual ICollection<DocumentosProducto> DocumentosProductos { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }

        public virtual void Calcular()
        {
            MontoExento = DocumentosProductos.Where(x => x.TasaIva.GetValueOrDefault(0) == 0).Sum(x => x.Cantidad * x.Precio);
            MontoGravable = DocumentosProductos.Where(x => x.TasaIva.Equals(TasaIva)).Sum(x => x.Cantidad * x.Precio);
            MontoGravableB = DocumentosProductos.Where(x => x.TasaIva.Equals(TasaIvaB)).Sum(x => x.Cantidad * x.Precio);

            Totalizar();
        }
        public void Totalizar()
        {
            double tasaIva = OK.SystemParameters.TasaIva.GetValueOrDefault();
            foreach (var item in this.DocumentosProductos.Where(x => x.TasaIva > 0))
            {
                item.TasaIva = tasaIva;
                item.PrecioConIva = (double)Decimal.Round((decimal)(item.Precio + (item.Precio * tasaIva / 100)), 2);
                item.Total = item.PrecioConIva * item.Cantidad;
            }
            this.MontoExento = this.DocumentosProductos.Where(x => x.TasaIva.GetValueOrDefault(0) == 0).Sum(x => x.Cantidad * x.Precio);
            this.MontoGravable = this.DocumentosProductos.Where(x => x.TasaIva.GetValueOrDefault(0) > 0).Sum(x => x.Cantidad * x.Precio);
            this.MontoIva = this.DocumentosProductos.Where(x => x.TasaIva.GetValueOrDefault(0) > 0).Sum(x => x.Cantidad * x.Precio * x.TasaIva / 100);
            this.MontoTotal = (double)Decimal.Round((decimal)(
            this.MontoExento.GetValueOrDefault(0)
            + this.MontoGravable.GetValueOrDefault(0)
            + this.MontoIva.GetValueOrDefault(0)
            - this.Descuentos.GetValueOrDefault(0)), 2);
        }
    }
}
