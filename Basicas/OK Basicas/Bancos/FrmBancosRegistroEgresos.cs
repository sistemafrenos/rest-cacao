using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmBancosRegistroEgresos : Form
    {
        public Banco banco = null;
        public MaestroDeCuenta cuenta = null;
        public Tercero proveedor = null;
        public DateTime desde = DateTime.Today;
        public DateTime hasta = DateTime.Today;
        Administrativo data;
        public FrmBancosRegistroEgresos()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmBancosRegistroEgresos_Load);
        }

        void FrmBancosRegistroEgresos_Load(object sender, EventArgs e)
        {
            this.txtDesde.DateTime = desde;
            this.txtHasta.DateTime = hasta;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.CodigoCuenta.ButtonClick += CodigoCuenta_ButtonClick;
            this.CodigoCuenta.Validating += new CancelEventHandler(CodigoCuenta_Validating);
        }
        #region Tercero
        private void LeerProveedor()
        {
            Beneficiario.Text = proveedor == null ? null : proveedor.RazonSocial;
        }
        #endregion
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
        void FrmLapso_KeyDown(object sender, KeyEventArgs e)
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
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            this.desde = txtDesde.DateTime;
            this.hasta = txtHasta.DateTime;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
