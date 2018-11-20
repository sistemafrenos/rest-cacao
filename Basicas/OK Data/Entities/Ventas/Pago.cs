namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class Pago : Entity
    {
        public Nullable<int> NumeroLote { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public Nullable<DateTime> Hora { get; set; }
        [MaxLength(40)]
        public string Tipo { get; set; }
        [MaxLength(20)]
        public string Numero { get; set; }
        [MaxLength(100)]
        public string Concepto { get; set; }
        public Nullable<double> Efectivo { get; set; }
        public Nullable<double> Cheque { get; set; }
        public Nullable<double> TarjetaCredito { get; set; }
        public Nullable<double> TarjetaDebito { get; set; }
        public Nullable<double> CestaTicket { get; set; }
        public Nullable<double> Transferencia { get; set; }
        public Nullable<double> RetencionISLR { get; set; }
        public Nullable<double> RetencionIVA { get; set; }
        [MaxLength(20)]
        public string NumeroCheque { get; set; }
        [MaxLength(40)]
        public string BancoCheque { get; set; }
        [MaxLength(20)]
        public string NumeroTransferencia { get; set; }
        [MaxLength(20)]
        public string ComprobanteRetencionIVA { get; set; }
        [MaxLength(40)]
        public string MovimientoBancoID { get; set; }
        public Nullable<double> RetencionImpuestoMun { get; set; }
        public Nullable<double> Deposito { get; set; }
        public Nullable<double> NumeroDeposito { get; set; }
        [MaxLength(40)]
        public string BancoDestino { get; set; }
        public Nullable<double> Cambio { get; set; }
        public string TipoDocumento { get; set; }
        public Nullable<double> Credito { get; set; }

        public Nullable<double> ComisionPunto { get; set; }
        public Nullable<double> NetoDepositar { get; set; }
        /// <summary>
        /// Logs
        /// </summary>
        public Nullable<DateTime> UltimaEdicion { get; set; }
        [MaxLength(40)]
        public string UsuarioID { get; set; }

        public virtual Documento Documento { get; set; }


        [NotMapped]
        public double? Saldo { set; get; }
        [NotMapped]
        public double? MontoPagado { set; get; }
        [NotMapped]
        public double? MontoPagar { set; get; }

        public void Totalizar()
        {
            this.MontoPagado = this.CestaTicket.GetValueOrDefault(0) +
            this.Cheque.GetValueOrDefault(0) +
            this.Credito.GetValueOrDefault(0) +
            this.Deposito.GetValueOrDefault(0) +
            this.Efectivo.GetValueOrDefault(0) +
            this.TarjetaCredito.GetValueOrDefault(0) +
            this.TarjetaDebito.GetValueOrDefault(0) +
            this.CestaTicket.GetValueOrDefault(0) +
            this.Transferencia.GetValueOrDefault(0);
            Saldo = MontoPagar - MontoPagado;
            if (Saldo < 0)
            {
                Saldo = 0;
                Cambio = Saldo * -1;
            }
            Cambio = MontoPagado.GetValueOrDefault(0) - MontoPagar.GetValueOrDefault(0);
            if (Cambio < 0)
            {
                Cambio = 0;
            }

        }
        public string Detalles()
        {
            string detalles = "";
            if (this.CestaTicket.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("C.T.:{0}", this.CestaTicket.GetValueOrDefault(0).ToString("n2"));
            }
            if (this.Cheque.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("CH:{0} Banco {1} Nro. {2}", this.Cheque.GetValueOrDefault(0).ToString("n2"), this.BancoCheque, this.NumeroCheque);
            }
            if (this.Credito.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("CR:{0}", this.Credito.GetValueOrDefault(0).ToString("n2"));
            }
            if (this.Deposito.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("DP:{0} Banco {1} Nro. {2}", this.Deposito.GetValueOrDefault(0).ToString("n2"), this.BancoDestino, this.NumeroDeposito);
            }
            if (this.Efectivo.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("EF:{0}", this.Efectivo.GetValueOrDefault(0).ToString("n2"));
            }
            if (this.TarjetaCredito.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("TC:{0}", this.TarjetaCredito.GetValueOrDefault(0).ToString("n2"));
            }
            if (this.TarjetaDebito.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("TD:{0}", this.TarjetaDebito.GetValueOrDefault(0).ToString("n2"));
            }
            if (this.Transferencia.GetValueOrDefault(0) > 0)
            {
                detalles = detalles + string.Format("TR:{0} Banco {1} Nro. {2}", this.Transferencia.GetValueOrDefault(0).ToString("n2"), this.BancoDestino, this.NumeroDeposito);
            }
            return detalles;
        }
    }
}

