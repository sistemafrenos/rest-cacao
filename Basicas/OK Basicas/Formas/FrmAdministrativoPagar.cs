using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.Formas;

namespace HK
{
    public partial class FrmAdministrativoPagar : Form
    {
        public Pago caja = new Pago();
        public bool creditoHabilitado = true;
        public bool fechaHabilitada = false;
        public bool emitirFactura = true;
      //  Banco banco;
        public FrmAdministrativoPagar()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmPagar_Load);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmPagar_KeyDown);

            this.btnEfectivo.Click += new EventHandler(Efectivo_Click);
            this.EfectivoTextEdit.Enter += new EventHandler(Editor_Enter);
            this.EfectivoTextEdit.Validating += new CancelEventHandler(EfectivoTextEdit_Validating);

            this.btnCheque.Click += new EventHandler(Cheque_Click);
            this.ChequeTextEdit.Enter += new EventHandler(Editor_Enter);
            this.ChequeTextEdit.Validating += new CancelEventHandler(ChequeTextEdit_Validating);

            this.btnCestaTicket.Click += new EventHandler(CestaTicket_Click);
            this.CestaTicketTextEdit.Enter += new EventHandler(Editor_Enter);
            this.CestaTicketTextEdit.Validating += new CancelEventHandler(CestaTicketTextEdit_Validating);

            this.btnTarjetaCredito.Click += new EventHandler(TarjetaCredito_Click);
            this.TarjetaCreditoCalcEdit.Enter += new EventHandler(Editor_Enter);
            this.TarjetaCreditoCalcEdit.Validating += new CancelEventHandler(TarjetaCreditoCalcEdit_Validating);

            this.btnTarjetaDebito.Click += new EventHandler(TarjetaDebito_Click);
            this.TarjetaDebitoCalcEdit.Enter += new EventHandler(Editor_Enter);
            this.TarjetaDebitoCalcEdit.Validating += new CancelEventHandler(TarjetaDebitoCalcEdit_Validating);

            this.btnTransferencia.Click += new EventHandler(Transferencia_Click);
            this.TransferenciaCalcEdit.Enter += new EventHandler(Editor_Enter);
            this.TransferenciaCalcEdit.Validating += new CancelEventHandler(Transferencia_Validating);

            this.btnDeposito.Click += new EventHandler(Deposito_Click);
            this.DepositoCalcEdit.Enter += new EventHandler(Editor_Enter);
            this.DepositoCalcEdit.Validating += new CancelEventHandler(Deposito_Validating);
          //  this.BancoDestinoComboBoxEdit.Properties.Items.AddRange(FactoryBancos.getCuentasBancarias());
            this.KeyPreview = true;

        }

        public void Pagar()
        {
            caja.Totalizar();
            if (!caja.Fecha.HasValue)
                caja.Fecha = DateTime.Today;
            this.cajaBindingSource.DataSource = caja;
            this.cajaBindingSource.ResetBindings(true);
            MostrarTotales();
            if (!fechaHabilitada)
            {
                txtFechaPago.Properties.AppearanceDisabled.BackColor = Color.Khaki;
                txtFechaPago.Enabled = false;
            }
            this.ShowDialog();
        }
        private void MostrarTotales()
        {
            this.MontoTotalTextEdit.Value = (decimal)caja.MontoPagar.GetValueOrDefault(0);
            this.CambioTextEdit.Value = (decimal)caja.Cambio.GetValueOrDefault(0);
            this.SaldoTextEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
        }

        void CestaTicket_Click(object sender, EventArgs e)
        {
            PagarCestaTicket();
        }
        void Cheque_Click(object sender, EventArgs e)
        {
            PagarCheque();
        }
        void Efectivo_Click(object sender, EventArgs e)
        {
            PagarEfectivo();
        }
        void TarjetaCredito_Click(object sender, EventArgs e)
        {
            PagarTarjetaCredito();
        }
        void TarjetaDebito_Click(object sender, EventArgs e)
        {
            PagarTarjetaDebito();
        }
        void Deposito_Click(object sender, EventArgs e)
        {
            PagarDeposito();
        }
        void Transferencia_Click(object sender, EventArgs e)
        {
            PagarTransferencia();
        }

        void TarjetaDebitoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.TarjetaDebito = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void TarjetaCreditoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.TarjetaCredito = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void CestaTicketTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.CestaTicket = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void ChequeTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.Cheque = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void EfectivoTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.Efectivo = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void Transferencia_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.Transferencia = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void Deposito_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.Deposito = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void Credito_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.Credito = (double)editor.Value;
            caja.Totalizar();
            MostrarTotales();
        }
        void Editor_Enter(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            caja.Totalizar();
            editor.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            editor.SelectAll();
            this.cajaBindingSource.EndEdit();
            caja.Totalizar();
        }
        void FrmPagar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F3:
                    emitirFactura = !emitirFactura;
                    e.Handled = true;
                    break;
                case Keys.F4:
                    PagarEfectivo();
                    e.Handled = true;
                    break;
                case Keys.F5:
                    PagarTarjetaCredito();
                    e.Handled = true;
                    break;
                case Keys.F6:
                    PagarTarjetaDebito();
                    e.Handled = true;
                    break;
                case Keys.F7:
                    PagarCestaTicket();
                    e.Handled = true;
                    break;
                case Keys.F8:
                    PagarCheque();
                    e.Handled = true;
                    break;
                case Keys.F9:
                    PagarTransferencia();
                    e.Handled = true;
                    break;
                case Keys.F10:
                    PagarDeposito();
                    e.Handled = true;
                    break;
            }
        }
        private void PagarCheque()
        {
            LimpiarPagos();
            ChequeTextEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            ChequeTextEdit.SelectAll();
            this.ChequeTextEdit.Focus();
        }
        private void PagarTransferencia()
        {
            LimpiarPagos();
            TransferenciaCalcEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            TransferenciaCalcEdit.SelectAll();
            this.TransferenciaCalcEdit.Focus();
        }
        private void PagarDeposito()
        {
            LimpiarPagos();
            DepositoCalcEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            DepositoCalcEdit.SelectAll();
            this.DepositoCalcEdit.Focus();
        }
        private void PagarCestaTicket()
        {
            LimpiarPagos();
            CestaTicketTextEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            CestaTicketTextEdit.SelectAll();
            this.CestaTicketTextEdit.Focus();
        }
        private void PagarTarjetaCredito()
        {
            LimpiarPagos();
            TarjetaCreditoCalcEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            this.TarjetaCreditoCalcEdit.SelectAll();
            this.TarjetaCreditoCalcEdit.Focus();
        }
        private void PagarTarjetaDebito()
        {
            LimpiarPagos();
            TarjetaDebitoCalcEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            this.TarjetaDebitoCalcEdit.SelectAll();
            this.TarjetaDebitoCalcEdit.Focus();
        }

        private void PagarEfectivo()
        {
            LimpiarPagos();
            EfectivoTextEdit.Value = (decimal)caja.Saldo.GetValueOrDefault(0);
            EfectivoTextEdit.SelectAll();
            this.EfectivoTextEdit.Focus();
        }
        private void LimpiarPagos()
        {
            double? MontoPagar = caja.MontoPagar;
            DateTime? Fecha = caja.Fecha;
            caja = new Pago();
            caja.MontoPagar = MontoPagar;
            caja.Fecha = Fecha;
            caja.Totalizar();
            this.cajaBindingSource.DataSource = caja;
            this.cajaBindingSource.ResetBindings(true);
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarPagos();
            caja.Totalizar();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            cajaBindingSource.EndEdit();
            caja.Totalizar();

            if (caja.Efectivo.HasValue)
            {
                if (caja.Cambio.GetValueOrDefault(0) > caja.Efectivo.GetValueOrDefault(0))
                {
                    MessageBox.Show("El cambio no puede ser mayor al monto en efectivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                caja.Efectivo = caja.Efectivo.GetValueOrDefault(0) - caja.Cambio.GetValueOrDefault(0);
            }
            if (caja.Saldo.GetValueOrDefault(0) > 0)
            {
                caja.Credito = caja.Saldo;
            }
            if ((caja.Deposito.GetValueOrDefault(0) + caja.Transferencia.GetValueOrDefault(0)) > 0 && BancoDestinoComboBoxEdit.Properties.Items.Count > 0)
            {
                    string cuenta = "";
                    if (BancoDestinoComboBoxEdit.Text.Length >= 20)
                    {
                        BancoDestinoComboBoxEdit.Text = BancoDestinoComboBoxEdit.Text.Substring(0, 20);
                        cuenta = BancoDestinoComboBoxEdit.Text.Substring(0, 20);
                    }
                 //   bancos.LoadCuenta(cuenta);
                    //if (banco == null)
                    //{
                    //    MessageBox.Show("Si registra un pago en deposito o transferencia debe indicar el banco destino", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    return;
                    //}
                    BancoDestinoComboBoxEdit.Text = cuenta;
                    BancosMovimiento item = new BancosMovimiento();
                    item.Concepto = "PAGO FACTURAS";
                    item.Credito = caja.Transferencia.GetValueOrDefault(0) + caja.Deposito.GetValueOrDefault(0);
                    item.Fecha = caja.Fecha;
                    item.Numero = this.NumeroDepositoTextEdit.Text;
                    item.Tipo = "DEPOSITO";
                    item.Numero = caja.NumeroCheque + caja.NumeroDeposito + caja.NumeroTransferencia;
                    caja.BancoDestino = cuenta;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        void FrmPagar_Load(object sender, EventArgs e)
        {
            LimpiarPagos();
        }
    }
}
