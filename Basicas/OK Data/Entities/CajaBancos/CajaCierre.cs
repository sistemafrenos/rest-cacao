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
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public class CierreCaja : Entity
    {
        public Nullable<int> NumeroLote { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public Nullable<DateTime> Hora { get; set; }
        public Nullable<double> Efectivo { get; set; }
        public Nullable<double> Cheque { get; set; }
        public Nullable<double> Banesco { get; set; }
        public Nullable<double> Banesco2 { get; set; }
        public Nullable<double> Mercantil { get; set; }
        public Nullable<double> Corpbanca { get; set; }
        public Nullable<double> Tarjetas { get; set; }
        public Nullable<double> DepositosTransferencias { get; set; }
        public Nullable<double> Creditos { get; set; }
        public Nullable<double> Otros { get; set; }
        public Nullable<double> Gastos { get; set; }
        public Nullable<double> Vales { get; set; }
        public Nullable<double> Retenciones { get; set; }
        public Nullable<double> CreditosCobrados { get; set; }
        public Nullable<double> TotalCaja { get; set; }
        public Nullable<double> CantidadFacturas { get; set; }
        public Nullable<double> CantidadFacturasCredito { get; set; }
        public Nullable<double> ComisionMesoneros { get; set; }
        public Nullable<double> Propinas { get; set; }
    }
}
