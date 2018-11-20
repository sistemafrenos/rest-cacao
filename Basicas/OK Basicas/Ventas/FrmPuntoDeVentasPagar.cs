using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmPuntoDeVentasPagar : Form
    {
        private double? montoPagar = 0;
        public Pago pago { set; get; }
        public Tercero cliente { set; get; }
        public Factura factura { set; get; }
        public FrmPuntoDeVentasPagar()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmPagar_Load);
        }
        void CestaTicket_Click(object sender, EventArgs e)
        {
            PagarCestaTicket();
        }
        void TarjetaCR_Click(object sender, EventArgs e)
        {
            PagarTarjetaCR();
        }
        void TarjetaDB_Click(object sender, EventArgs e)
        {
            PagarTarjetaDB();
        }
        void Efectivo_Click(object sender, EventArgs e)
        {
            PagarEfectivo();
        }
        void Cheque_Click(object sender, EventArgs e)
        {
            PagarCheque();
        }
        void tarjetaCRTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            pago.TarjetaCredito = (double)editor.Value;
            Totalizar();
        }
        void tarjetaDBTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            pago.TarjetaDebito = (double)editor.Value;
            Totalizar();
        }
        void cestaTicketTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            pago.CestaTicket = (double)editor.Value;
            Totalizar();
        }
        void EfectivoTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            pago.Efectivo = (double)editor.Value;
            Totalizar();
        }
        void ChequeTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            pago.Cheque = (double)editor.Value;
            Totalizar();
        }
        void Editor_Enter(object sender, EventArgs e)
        {
            this.montoPagar = factura.MontoTotal;
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            editor.Value = (decimal)pago.Saldo;
            editor.SelectAll();
            Totalizar();
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
                case Keys.F4:
                    PagarEfectivo();
                    e.Handled = true;
                    break;
                case Keys.F5:
                    PagarTarjetaCR();
                    e.Handled = true;
                    break;
                case Keys.F6:
                    PagarTarjetaDB();
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
                    if (OK.usuario.PuedeDarCreditos.GetValueOrDefault(false) != true)
                        return;
                    Cheque.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F10:
                    if (OK.usuario.PuedeDarConsumoInterno.GetValueOrDefault(false) != true)
                        return;
                    PagarConsumoInterno();
                    e.Handled = true;
                    break;
                case Keys.F11:
                    if (OK.usuario.PuedeAnularMesa.GetValueOrDefault(false) != true)
                        return;
                    AnularFactura();
                    e.Handled = true;
                    break;
            }
        }
        private double CalcularTasaIva()
        {
            var mTasa = OK.SystemParameters.TasaIva.GetValueOrDefault();
            return mTasa;
        }
        private void PagarCestaTicket()
        {
            LimpiarPagos();
            pago.CestaTicket = 1;
            factura.Totalizar();
            pago.MontoPagar = factura.MontoTotal;
            pago.CestaTicket = factura.MontoTotal;
            Totalizar();            
        }
        private void PagarTarjetaCR()
        {
            LimpiarPagos();
            pago.TarjetaCredito = 1;
            factura.Totalizar();
            pago.MontoPagar = factura.MontoTotal;
            pago.TarjetaCredito = factura.MontoTotal;
            Totalizar();
        }
        private void PagarCheque()
        {
            factura.Totalizar();
            this.montoPagar = factura.MontoTotal;
            LimpiarPagos();
            pago.Cheque = pago.MontoPagar;
            chequeTextEdit.SelectAll();
            this.chequeTextEdit.Focus();
            Totalizar();
        }
        private void PagarTarjetaDB()
        {
            LimpiarPagos();
            pago.TarjetaDebito = 1;
            factura.Totalizar();
            pago.MontoPagar = factura.MontoTotal;
            pago.TarjetaDebito = factura.MontoTotal;
            Totalizar();
        }
        private void PagarEfectivo()
        {
            factura.Totalizar();
            this.montoPagar = factura.MontoTotal;
            LimpiarPagos();
            pago.Efectivo = pago.MontoPagar;
            EfectivoTextEdit.SelectAll();
            this.EfectivoTextEdit.Focus();
            Totalizar();
        }
        private void PagarConsumoInterno()
        {
            factura.Totalizar();
            this.montoPagar = factura.MontoTotal;
            Totalizar();
            pago.Tipo = "CONSUMO INTERNO";
            Aceptar.PerformClick();
        }
        private void AnularFactura()
        {
            factura.Totalizar();
            this.montoPagar = factura.MontoTotal;
            Totalizar();
            pago.Tipo = "ANULAR";
            Aceptar.PerformClick();
        }
        void Credito_Click(object sender, EventArgs e)
        {
            if (OK.usuario.PuedeDarCreditos.GetValueOrDefault(false) != true)
                return;
            factura.Totalizar();
            this.montoPagar = factura.MontoTotal;
            LimpiarPagos();
            pago.Credito = pago.MontoPagar;
            Totalizar();
            Aceptar.PerformClick();
        }
        private void LimpiarPagos()
        {
            pago = new Pago();
            pago.Tipo = "FACTURA";
            pago.MontoPagar = montoPagar;
            Totalizar();
            this.bs.DataSource = cliente;
            this.bs.ResetCurrentItem();
            this.cajaBindingSource.DataSource = pago;
            this.cajaBindingSource.ResetCurrentItem();
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            LimpiarPagos();
            bs.CancelEdit();
            factura.Totalizar();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        private void Totalizar()
        {
            cajaBindingSource.EndEdit();
            pago.Totalizar();
            MontoTotalTextEdit.Text = pago.MontoPagar.Value.ToString("n2");
            SaldoTextEdit.Text = pago.Saldo.Value.ToString("N2");
            CambioTextEdit.Text = pago.Cambio.Value.ToString("N2");
            this.cajaBindingSource.ResetCurrentItem();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            cajaBindingSource.EndEdit();
            bs.EndEdit();
            Totalizar();
            if (pago.Saldo > 0.1)
            {
                MessageBox.Show("El monto del pago esta imcompleto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(cliente.CedulaRif) || string.IsNullOrEmpty(cliente.RazonSocial) || cliente.CedulaRif == Basicas.CedulaRif("0"))
            {
                var r = MessageBox.Show("Desea emitir la factura sin los datos del cliente", "Atencion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (r)
                {
                    case DialogResult.Yes:
                        cliente.CedulaRif = Basicas.CedulaRif("0");
                        cliente.RazonSocial = "CONTADO";
                        break;
                    case DialogResult.No:
                        pago.Tipo = "CONSUMO INTERNO";
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            if (pago.Efectivo.HasValue)
            {
                if (pago.Cambio.GetValueOrDefault(0) > pago.Efectivo.GetValueOrDefault(0))
                {
                    MessageBox.Show("El cambio no puede ser mayor al monto en efectivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                pago.Efectivo = pago.Efectivo.GetValueOrDefault(0) - pago.Cambio.GetValueOrDefault(0);
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        void FrmPagar_Load(object sender, EventArgs e)
        {
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmPagar_KeyDown);
            this.EfectivoTextEdit.Enter += new EventHandler(Editor_Enter);
            this.cestaTicketTextEdit.Enter += new EventHandler(Editor_Enter);
            this.tarjetaCRTextEdit.Enter += new EventHandler(Editor_Enter);
            this.tarjetaDBTextEdit.Enter += new EventHandler(Editor_Enter);
            this.EfectivoTextEdit.Validating += new CancelEventHandler(EfectivoTextEdit_Validating);
            this.cestaTicketTextEdit.Validating += new CancelEventHandler(cestaTicketTextEdit_Validating);
            this.tarjetaDBTextEdit.Validating += new CancelEventHandler(tarjetaDBTextEdit_Validating);
            this.tarjetaCRTextEdit.Validating += new CancelEventHandler(tarjetaCRTextEdit_Validating);
            this.Efectivo.Click += new EventHandler(Efectivo_Click);
            this.CestaTicket.Click += new EventHandler(CestaTicket_Click);
            this.TarjetaCR.Click += new EventHandler(TarjetaCR_Click);
            this.TarjetaDB.Click += new EventHandler(TarjetaDB_Click);
            this.Cheque.Click += new EventHandler(Cheque_Click);
            this.Credito.Click += new EventHandler(Credito_Click);
            this.btnSeniat.Click += new EventHandler(btnSeniat_Click);
            this.btnAnular.Click += new EventHandler(btnAnular_Click);
            CedulaRifButtonEdit.Validating += CedulaRifButtonEdit_Validating;
            CedulaRifButtonEdit.ButtonClick += CedulaRifButtonEdit_ButtonClick;
            this.KeyPreview = true;
            montoPagar = factura.MontoTotal;
            LimpiarPagos();
            this.bs.DataSource = cliente;
            this.bs.ResetBindings(true);
            this.cajaBindingSource.DataSource = pago;
            this.cajaBindingSource.ResetBindings(true);
        }

        void btnAnular_Click(object sender, EventArgs e)
        {
            if (OK.usuario.PuedeAnularMesa.GetValueOrDefault(false) != true)
                return;
            AnularFactura();
        }
        #region Terceros
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            if (F.registro != null)
            {
                Leercliente((Tercero)F.registro);
                this.bs.ResetCurrentItem();
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.bs.EndEdit();
            Tercero[] T = TerceroTable.GetAllClientes(Texto);
            switch (T.Length)
            {
                case 0:
                    cliente.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    cliente.RazonSocial = "";
                    cliente.Direccion = OK.SystemParameters.Ciudad;
                    cliente.TipoPrecio = "PRECIO 1";
                    break;
                case 1:
                    Leercliente(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarClientes(Texto);
                    if (F.registro != null)
                    {
                        Leercliente((Tercero)F.registro);
                    }
                    break;
            }
            this.bs.DataSource = cliente;
            bs.ResetCurrentItem();
        }
        private void Leercliente(Tercero x)
        {
            if (cliente != null)
            {
                cliente.CedulaRif = Basicas.CedulaRif(x.CedulaRif);
                cliente.RazonSocial = x.RazonSocial;
                cliente.Direccion = string.IsNullOrEmpty(x.Direccion) ? OK.SystemParameters.Ciudad : x.Direccion;
                cliente.Email = x.Email;
                cliente.Telefonos = x.Telefonos;
                cliente.TipoPrecio = x.TipoPrecio == null ? "PRECIO 1" : x.TipoPrecio;
            }
            this.bs.DataSource = cliente;
        }
        #endregion
        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(CedulaRifButtonEdit.Text);
            if (Empresa != null)
            {
                cliente.CedulaRif = Basicas.CedulaRif(CedulaRifButtonEdit.Text);
                cliente.RazonSocial = Empresa;
                this.bs.ResetCurrentItem();
            }
        }
    }
}
