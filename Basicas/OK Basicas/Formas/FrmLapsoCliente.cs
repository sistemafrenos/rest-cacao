using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmLapsoCliente : Form
    {
        public bool pedirFechas = true;
        public DateTime desde { set; get; }
        public DateTime hasta { set; get; }
        Administrativo data;
        public Tercero cliente;
        public FrmLapsoCliente()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmLapsoTercero_Load);
        }
        void FrmLapsoTercero_Load(object sender, EventArgs e)
        {
            this.txtDesde.DateTime = DateTime.Today;
            this.txtHasta.DateTime = DateTime.Today;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.CedulaRifButtonEdit.ButtonClick+=CedulaRifButtonEdit_ButtonClick;
            this.CedulaRifButtonEdit.Validating+=CedulaRifButtonEdit_Validating;
            if (pedirFechas == false)
            {
                itemDesde.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                itemHasta.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
        }
        #region Clientes
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            if (F.registro != null)
            {
                Leercliente((Tercero)F.registro);
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            Tercero[] T = data.GetAllClientes(Texto);
            switch (T.Length)
            {
                case 0:
                    CedulaRifButtonEdit.Text = null;                    break;
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
        }
        private void Leercliente(Tercero cliente)
        {
            if (cliente != null)
            {
                CedulaRifButtonEdit.Text = cliente.RazonSocial;
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
            this.desde = txtDesde.DateTime;
            this.hasta = txtHasta.DateTime;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}

