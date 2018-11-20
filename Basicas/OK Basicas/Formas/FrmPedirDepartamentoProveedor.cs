using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmPedirDepartamentoProveedor : Form
    {
        public bool PedirProveedor = false;
        public bool PedirDepartamento = false;
        public Tercero proveedor = null;
        public string Departamento = null;
        Administrativo data;
        public FrmPedirDepartamentoProveedor()
        {
            InitializeComponent();
            data = new Administrativo();
            proveedor = new Tercero();
            this.Load += new EventHandler(FrmPedirProveedor_Load);
        }

        void  FrmPedirProveedor_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            CedulaRifButtonEdit.Properties.ValidateOnEnterKey = true;
            CedulaRifButtonEdit.ButtonClick+=CedulaRifButtonEdit_ButtonClick;
            CedulaRifButtonEdit.Validating += CedulaRifButtonEdit_Validating;
            this.txtDepartamento.Properties.Items.AddRange(data.GetGruposCompras());
            itemProveedor.Visibility = PedirProveedor == true ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            ItemDepartamento.Visibility = PedirDepartamento == true ? DevExpress.XtraLayout.Utils.LayoutVisibility.Always : DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }
        #region Proveedores
        void CedulaRifButtonEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            Tercero[] T = data.GetAllProveedores(Texto);
            switch (T.Length)
            {
                case 0:
                    CedulaRifButtonEdit.Text = "";;
                    break;
                case 1:
                    LeerProveedor(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProveedores(Texto);
                    if (F.registro != null)
                    {
                        LeerProveedor((Tercero)F.registro);
                    }
                    break;
            }
        }
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarProveedores("");
            if (F.registro != null)
            {
                LeerProveedor((Tercero)F.registro);
            }
        }
        private void LeerProveedor(Tercero proveedor)
        {
            if (proveedor != null)
            {
                CedulaRifButtonEdit.Text = proveedor.RazonSocial;
            }
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
            proveedor.RazonSocial = CedulaRifButtonEdit.Text;
            Departamento = txtDepartamento.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
