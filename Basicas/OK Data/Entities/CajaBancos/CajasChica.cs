namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public class CajaChica : Entity
    {
        [MaxLength(40)]
        public string DocumentoID { set; get; }
        [MaxLength(40)]
        public string MovimientoBancoID { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        [MaxLength(20)]
        public string Numero { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Es requerida la razon social")]
        public string RazonSocial { get; set; }
        [MaxLength(100)]
        [Required(ErrorMessage = "Es requerido el concepto")]
        public string Concepto { get; set; }
        public Nullable<double> Monto { get; set; }
        public Nullable<double> Saldo { get; set; }
        [MaxLength(40)]
        public string NumeroCheque { get; set; }
    }
}
