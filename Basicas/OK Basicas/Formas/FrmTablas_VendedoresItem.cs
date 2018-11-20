using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmTablas_VendedoresItem : Form
    {
        public Administrativo data;
        Vendedor vendedor;
        public FrmTablas_VendedoresItem()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmItem_Load);
        }

        void FrmItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.CedulaRifTextEdit.Validating += new CancelEventHandler(CedulaRifTextEdit_Validating);
        }

        void CedulaRifTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit Editor = (DevExpress.XtraEditors.TextEdit)sender;
            if (!Editor.IsModified)
                return;
            Editor.Text = Basicas.CedulaRif(Editor.Text);
            this.vendedoreBindingSource.EndEdit();
        }
        private void Limpiar()
        {
            vendedor = new Vendedor();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar(string id)
        {
            vendedor = data.FindVendedor(id);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            this.vendedoreBindingSource.DataSource = vendedor;
            this.vendedoreBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            vendedoreBindingSource.EndEdit();
            string resultado = data.GuardarVendedor((Vendedor)vendedoreBindingSource.Current, true);
            if (resultado != null)
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.vendedoreBindingSource.ResetCurrentItem();
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
    }
}
