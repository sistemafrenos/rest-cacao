//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class Tercero : Entity
    {
        public Tercero(string Tipo)
        {
            Activo = true;
            DiasCredito = 0;
            this.Tipo = Tipo;
            this.Estatus = "NUEVO";
            TipoPrecio = "PRECIO 1";

            this.TercerosMovimientos = new HashSet<TercerosMovimiento>();
        }
        public Tercero()
        {
            this.TercerosMovimientos = new HashSet<TercerosMovimiento>();
        }
        [MaxLength(40)]
        public string Codigo { get; set; }
        [MaxLength(20)]
        public string Tipo { get; set; }
        [MaxLength(20)]
        public string Estatus { get; set; }
        [MaxLength(40)]
        public string Categoria { get; set; }
        [Required(ErrorMessage = "Es requerida la cedula o rif")]
        [MaxLength(10, ErrorMessage = "La cedula o rif debe tener 10 caracteres")]
        public string CedulaRif { get; set; }
        [Required(ErrorMessage = "Es requerida la razon social")]
        [MaxLength(150, ErrorMessage = "La razon social Debe tener hasta 150 caracteres")]
        public string RazonSocial { get; set; }
        [MaxLength(150)]
        public string Direccion { get; set; }
        public Nullable<int> DiasCredito { get; set; }
        public Nullable<double> LimiteCredito { get; set; }
        [MaxLength(40)]
        public string Telefonos { get; set; }
        [MaxLength(150)]
        public string Contacto { get; set; }
        [MaxLength(40)]
        public string Email { get; set; }
        public Nullable<double> PorcentajeRetencionIVA { get; set; }
        public Nullable<double> PorcentajeDescuento { get; set; }
        [MaxLength(150)]
        public string Comentarios { get; set; }
        [MaxLength(20)]
        public string TipoPrecio { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<double> SaldoPendiente { get; set; }
        public Nullable<int> FacturasPendientes { get; set; }
        public Nullable<double> Anticipos { get; set; }
        [MaxLength(140)]
        public string CodigoVendedor { get; set; }
        [MaxLength(150)]
        public string Vendedor { get; set; }
        [MaxLength(40)]
        public string VendedorEmail { get; set; }
        [MaxLength(40)]
        public string VendedorTelefonos { get; set; }
        [MaxLength(100)]
        public string Banco { set; get; }
        [MaxLength(20)]
        public string NumeroCuenta { set; get; }
        public Nullable<bool> PrestaServicios { set; get; }
        [MaxLength(10)]
        public string ContactoCedulaRif { set; get; }

        public virtual ICollection<TercerosMovimiento> TercerosMovimientos { get; set; }
    }
}