using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmBancosTransferencia : Form
    {
        public Tercero proveedor = new Tercero();
        public BancosMovimiento registro = new BancosMovimiento();
        public MaestroDeCuenta cuenta = new MaestroDeCuenta();
        public String concepto = "";
        public double? monto = 0;
        public string cheque = "";
        Administrativo data;
        public Banco banco;
        public FrmBancosTransferencia()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmBancosTransferencia_Load);
        }
        void  FrmBancosTransferencia_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
       }
        public void RegistrarPago()
        {
            registro = new BancosMovimiento();
            registro.Beneficiario = proveedor.RazonSocial;
            registro.CedulaRif = proveedor.CedulaRif;
            registro.Concepto = concepto;
            registro.Debito = monto;
            registro.Ejecutado = false;
            registro.Fecha = DateTime.Today;
            registro.UsuarioID = OK.usuario.ID;
            registro.Tipo = "TRANSFERENCIA";
            registro.UltimaEdicion = DateTime.Now;
            if (cuenta != null)
                LeerCuenta();
            // pendiente
            // this.BeneficiarioTextEdit.Properties.Items.AddRange();
            this.DebitoTextEdit.Enabled = false;
            this.CedulaRifTextEdit.Enabled = false;
            this.FechaTextEdit.Enabled = false;
            this.ConceptoTextEdit.Enabled = false;
            this.bancosMovimientoBindingSource.DataSource = registro;
            this.bancosMovimientoBindingSource.ResetBindings(true);
            this.ShowDialog();
        }
        #region Cuenta
        void CodigoCuenta_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            MaestroDeCuenta[] T = data.GetAllMaestroCuenta(Texto);
            switch (T.Length)
            {
                case 0:
                    break;
                case 1:
                    cuenta = T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarCuentas(Texto);
                    if (F.registro != null)
                    {
                        cuenta = (MaestroDeCuenta)F.registro;
                    }
                    break;
            }
            LeerCuenta();
        }
        private void LeerCuenta()
        {
            this.CodigoCuenta.Text = cuenta.Codigo;
            this.DescripcionCuentaTextEdit.Text = cuenta.Descripcion;
            this.bancosMovimientoBindingSource.ResetCurrentItem();
        }
        void btnCodigoCuenta_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarCuentas("");
            if (F.registro != null)
            {
                cuenta = (MaestroDeCuenta)F.registro;
            }
            LeerCuenta();
        }
        #endregion
        private void Limpiar()
        {
            registro = new BancosMovimiento();
            if (banco != null)
            {
                registro.Fecha = DateTime.Today;
                this.cuentaBancaria.Enabled = false;
                this.cuentaBancaria.Text = banco.Cuenta;
            }
            if (!string.IsNullOrEmpty( concepto ))
            {
                registro.Concepto = concepto;
                this.ConceptoTextEdit.Enabled = false;
                this.ConceptoTextEdit.Text = registro.Concepto;
            }
            registro.Tipo = "TRANSFERENCIA";
            if (monto.GetValueOrDefault(0) > 0)
            {
                registro.Debito = monto;
                this.DebitoTextEdit.Enabled = false;
            }
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            if (registro == null)
            {
                Limpiar();
            }
            else
            {
                if (string.IsNullOrEmpty(this.cuentaBancaria.Text))
                {
                    if (registro.Banco != null)
                    {
                        if (registro.Banco.Cuenta != null)
                        {
                            this.cuentaBancaria.Text = registro.Banco.Cuenta;
                        }
                    }
                }
            }
            this.bancosMovimientoBindingSource.DataSource = registro;
            this.bancosMovimientoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                bancosMovimientoBindingSource.EndEdit();
                registro = (BancosMovimiento)bancosMovimientoBindingSource.Current;
                if (!Guardar())
                    return;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al guardar los datos \n{0}\n{1}", ex.Source, ex.Message), "Atencion", MessageBoxButtons.OK);
            }
        }
        private bool Guardar()
        {
            this.cheque = this.NumeroTextEdit.Text;
            data.GuardarCambios();
            return true;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.bancosMovimientoBindingSource.ResetCurrentItem();
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
        public void Ver()
        {
            Enlazar();
            this.datos.Enabled = false;
            this.ShowDialog();
        }
    }
}
