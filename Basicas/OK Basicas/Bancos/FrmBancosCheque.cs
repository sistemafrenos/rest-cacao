using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.Utilitatios;

namespace HK.Formas
{
    public partial class FrmBancosCheque : Form
    {
        public Tercero proveedor = new Tercero();
        public BancosMovimiento registro = new BancosMovimiento();
        public MaestroDeCuenta cuenta = new MaestroDeCuenta();
        public String concepto = "";
        public double? monto = 0;
        public string cheque = "";
        Administrativo data;
        public Banco banco;
        public FrmBancosCheque()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmClientesItem_Load);
        }
        void FrmClientesItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.CodigoCuenta.ButtonClick+=CodigoCuenta_ButtonClick;
            this.CodigoCuenta.Validating += new CancelEventHandler(CodigoCuenta_Validating);
            this.DebitoTextEdit.Validated += new EventHandler(DebitoTextEdit_Validated);
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (registro.ID == null)
                {
                    bancosMovimientoBindingSource.EndEdit();
                    registro = (BancosMovimiento)bancosMovimientoBindingSource.Current;
                    // registro.Banco = banco;
                    registro.Numero = this.NumeroTextEdit.Text;
                    if (!Guardar())
                        return;
                }
                FrmReportes f = new FrmReportes();
                f.Banco_ImprimirCH(registro);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos \n" + ex.Source + "\n" + ex.Message, "Atencion", MessageBoxButtons.OK);
            }

        }
        public void RegistrarPago()
        {
            registro = new BancosMovimiento();
            registro.ComprobanteRetencion = comprobanteRetencion;
            registro.Beneficiario = proveedor.RazonSocial;
            registro.CedulaRif = proveedor.CedulaRif;
            registro.Concepto = concepto;
            registro.Debito = monto;
            registro.Ejecutado = false;
            registro.Fecha = DateTime.Today;
            registro.UsuarioID = OK.usuario.ID;
            PasarLetras();
            registro.Tipo = "CHEQUE";
            registro.UltimaEdicion = DateTime.Now;
            if (cuenta != null)
                LeerCuenta(cuenta);
            // Pendientes
            // this.BeneficiarioTextEdit.Properties.Items.AddRange();
            this.MontoEnLetrasTextEdit.Enabled = false;
            this.DebitoTextEdit.Enabled = false;
            this.CedulaRifTextEdit.Enabled = false;
            //   this.FechaTextEdit.Enabled = false;
            this.ConceptoTextEdit.Enabled = false;
            this.bancosMovimientoBindingSource.DataSource = registro;
            //    registro.IdMovimientoBanco = FactoryContadores.GetMax("IdMovimientoBanco");
            this.bancosMovimientoBindingSource.ResetBindings(true);
            this.ShowDialog();
        }
        void DebitoTextEdit_Validated(object sender, EventArgs e)
        {
            PasarLetras();
        }
        private void PasarLetras()
        {
            if (registro.Debito == null)
            {
                registro.MontoEnLetras = "";
                return;
            }
            Numalet let = new Numalet();
            registro.MontoEnLetras = let.ToCustomCardinal((decimal)registro.Debito);
            bancosMovimientoBindingSource.ResetCurrentItem();
        }
        #region Cuentas
        private void CodigoCuenta_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
            {
                return;
            }
            var T = data.GetAllMaestroCuenta(Editor.Text);
            switch (T.Length)
            {
                case 0:
                    LeerCuenta(new MaestroDeCuenta());
                    break;
                case 1:
                    LeerCuenta(T[0]);
                    break;
                default:
                    using (var F = new FrmBuscarEntidades())
                    {
                        F.BuscarCuentas(Editor.Text);
                        LeerCuenta(new MaestroDeCuenta());
                        if (F.registro != null)
                        {
                            LeerCuenta((MaestroDeCuenta)F.registro);
                        }
                    }
                    break;
            }
        }
        void CodigoCuenta_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var F = new FrmBuscarEntidades())
            {
                F.BuscarCuentas(string.Empty);
                if (F.registro != null)
                {
                    LeerCuenta((MaestroDeCuenta)F.registro);
                }
            }
        }
        private void LeerCuenta(MaestroDeCuenta cuenta)
        {
            CodigoCuenta.Text = cuenta.Codigo;
        }
        #endregion
        private void Limpiar()
        {
            registro = new BancosMovimiento();
            registro.Fecha = DateTime.Today;
            if (banco.ID != null)
            {
                this.cuentaBancaria.Enabled = false;
                this.cuentaBancaria.Text = banco.Cuenta;
            }
            if (!string.IsNullOrEmpty( concepto ))
            {
                registro.Concepto = concepto;
                this.ConceptoTextEdit.Enabled = false;
                this.ConceptoTextEdit.Text = registro.Concepto;
            }
            registro.Tipo = "CHEQUE";
            if (monto.GetValueOrDefault(0) > 0)
            {
                registro.Debito = monto;
                Numalet let = new Numalet();
                registro.MontoEnLetras = let.ToCustomCardinal((decimal)registro.Debito);
                this.DebitoTextEdit.Enabled = false;
                this.MontoEnLetrasTextEdit.Enabled = false;
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
            bancosMovimientoBindingSource.EndEdit();
            registro = (BancosMovimiento)bancosMovimientoBindingSource.Current;
            if (!Guardar())
                return;
            this.DialogResult = DialogResult.OK;
        }
        private bool Guardar()
        {
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
        public string comprobanteRetencion { get; set; }
    }
}
