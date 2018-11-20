using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmLapsoVendedor : Form
    {
        public bool pedirFechas = true;
        public DateTime desde { set; get; }
        public DateTime hasta { set; get; }
        public Vendedor vendedor = new Vendedor();
        Administrativo data;
        public FrmLapsoVendedor()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmLapso_Load);
        }
        void FrmLapso_Load(object sender, EventArgs e)
        {
            desde = DateTime.Today.AddDays(-30);
            hasta = DateTime.Today;
            this.txtDesde.DateTime = desde;
            this.txtHasta.DateTime = hasta;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            txtVendedor.Properties.ValidateOnEnterKey = true;
            this.txtVendedor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtVendedor_ButtonClick);
            this.txtVendedor.Validating += new CancelEventHandler(txtVendedor_Validating);
            if (pedirFechas == false)
            {
                itemDesde.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                itemHasta.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        #region Vendedores

        void txtVendedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarVendedores("");
            LeerVendedor((Vendedor)F.registro);
        }
        void txtVendedor_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            Vendedor[] T = data.GetAllVendedores(txtVendedor.Text);
            switch (T.Length)
            {
                case 0:
                    LeerVendedor(null);
                    break;
                case 1:
                    LeerVendedor(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarVendedores(Texto);
                    LeerVendedor((Vendedor)F.registro);
                    break;
            }
        }
        private void LeerVendedor(Vendedor vendedor)
        {
            if (vendedor == null)
                vendedor = new Vendedor();
            this.vendedor = vendedor;
            txtVendedor.Text =  vendedor.Nombre;
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
