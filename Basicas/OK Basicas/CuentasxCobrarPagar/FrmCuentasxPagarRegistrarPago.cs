using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmCuentasxPagarRegistrarPago : Form
    {
        private Banco banco = null;
        public Tercero proveedor = new Tercero();
        public TercerosMovimiento movimiento = new TercerosMovimiento();
        public MaestroDeCuenta cuenta = new MaestroDeCuenta();
        public Administrativo data;
        public FrmCuentasxPagarRegistrarPago()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmCuentasxPagarRegistrarPago_Load);
        }

        void FrmCuentasxPagarRegistrarPago_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.FormaDePagoComboBoxEdit.Properties.Items.AddRange(new object[] { "EFECTIVO", "CHEQUE", "TRANSFERENCIA", "TARJETA DB", "LOTE TRANSFERENCIA" });
            this.CuentaBancariaButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CuentaBancariaButtonEdit_ButtonClick);
      //      this.BeneficiarioTextEdit.Properties.Items.AddRange(proveedores.Beneficiarios());
            this.BeneficiarioTextEdit.Validating += new CancelEventHandler(BeneficiarioTextEdit_Validating);
        }

        void BeneficiarioTextEdit_Validating(object sender, CancelEventArgs e)
        {
            if (BeneficiarioTextEdit.Text == proveedor.RazonSocial)
            {
                movimiento.CedulaRifBeneficiario = proveedor.CedulaRif;
            }
            else
            {
                movimiento.CedulaRifBeneficiario = proveedor.ContactoCedulaRif;
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.proveedoresMovimientoBindingSource.EndEdit();
                if (cuenta == null)
                {
                    throw new Exception("Error debe especificar la cuenta de egresos");
                }
                if ( "CHEQUE/TRANFERENCIA/TARJETA DB/LOTE TRANSFERENCIA".Contains(movimiento.FormaDePago))
                {
                    if (banco == null)
                    {
                        throw new Exception("Error debe especificar la cuenta bancaria");
                    }
                    if (string.IsNullOrEmpty(NumeroPagoTextEdit.Text))
                    {
                        throw new Exception("El Numero del pago es obligatorio");
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Basicas.ManejarError(ex);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
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
            }
        }
        public void RegistrarPago()
        {
            movimiento.FormaDePago = "CHEQUE";
            this.proveedoresMovimientoBindingSource.DataSource = movimiento;
            this.proveedoresMovimientoBindingSource.ResetBindings(true);
            this.ShowDialog();
        }
        #region CuentaBancaria
        void CuentaBancariaButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarBancos("");
            banco = (Banco)F.registro;
            LeerBanco();
        }
        private void LeerBanco()
        {
            if (banco == null)
            {
                CuentaBancariaButtonEdit.Text = "";
            }
            else
            {
                this.CuentaBancariaButtonEdit.Text = banco.Cuenta;
            }
        }
        #endregion
        #region Tercero
        private void LeerProveedor()
        {
            movimiento.CedulaRifBeneficiario = proveedor.CedulaRif;
            movimiento.Beneficiario = proveedor.RazonSocial;
        }
        #endregion
    }
}
