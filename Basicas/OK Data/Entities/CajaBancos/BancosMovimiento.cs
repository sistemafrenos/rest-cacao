namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public class BancosMovimiento : Entity
    {
        public Nullable<DateTime> Fecha { get; set; }
        [MaxLength(20)]
        public string Tipo { get; set; }
        [Required(ErrorMessage = "Es requerido el numero")]
        [MaxLength(20)]
        public string Numero { get; set; }
        [MaxLength(100)]
        public string Concepto { get; set; }
        public Nullable<double> Debito { get; set; }
        public Nullable<double> Credito { get; set; }
        public Nullable<bool> Conciliado { get; set; }
        public Nullable<bool> Ejecutado { get; set; }
        [MaxLength(20)]
        public string PlanCuenta { get; set; }
        [MaxLength(150)]
        public string Beneficiario { get; set; }
        [MaxLength(10)]
        public string CedulaRif { get; set; }
        [MaxLength(150)]
        public string MontoEnLetras { get; set; }
        [MaxLength(100)]
        public string DescripcionCuenta { get; set; }
        [MaxLength(20)]
        public string ComprobanteRetencion { get; set; }
        /// <summary>
        /// Logs
        /// </summary>
        public Nullable<DateTime> UltimaEdicion { get; set; }
        [MaxLength(40)]
        public string UsuarioID { get; set; }
        /// <summary>
        /// Campos virtuales
        /// </summary>
        public Nullable<double> Saldo { get; set; }

        public virtual Banco Banco { get; set; }
    }
}
