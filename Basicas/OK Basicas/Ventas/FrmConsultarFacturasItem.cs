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
    public partial class FrmConsultarFacturasItem : Form
    {
        Administrativo data;
        public string IdDocumento = null;
        Factura factura;
        public FrmConsultarFacturasItem()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmFacturasItem_Load);
            if (data == null)
                data = new Administrativo();
        }

        void FrmFacturasItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmFacturasItem_KeyDown);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void FrmFacturasItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        public void Ver()
        {
            factura = data.FindFactura(IdDocumento);
            facturaBindingSource.DataSource = factura;
            facturaBindingSource.ResetBindings(true);
            facturaProductoBindingSource.DataSource = factura.DocumentosProductos;
            facturaProductoBindingSource.ResetBindings(true);
            this.ShowDialog();
        }

        private void FrmFacturasItem_Load_1(object sender, EventArgs e)
        {

        }
    }

}