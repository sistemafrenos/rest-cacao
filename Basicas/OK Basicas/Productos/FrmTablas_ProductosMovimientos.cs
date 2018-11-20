using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_ProductosMovimientos : Form
    {
        public Producto producto;
        ProductosMovimientos[] lista;
        public Administrativo data;
        public FrmTablas_ProductosMovimientos()
        {

            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmTablas_ProductosMovimientos_KeyDown);
            this.Load += new EventHandler(FrmProductosMovimientos_Load);
            if (data == null)
                data = new Administrativo();
        }

        void FrmTablas_ProductosMovimientos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void FrmProductosMovimientos_Load(object sender, EventArgs e)
        {
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.btnFiltrar.Click += new EventHandler(btnFiltrar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.desde.DateTime = DateTime.Today.AddDays(-30);
            this.hasta.DateTime = DateTime.Today;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
            Busqueda();
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_ProductosMovimientos(lista.ToArray(), producto);
        }
        void btnFiltrar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            lista = data.MovimientosProductosLapso(desde.DateTime, hasta.DateTime, producto.ID);
            this.productosMovimientoBindingSource.DataSource = lista;
            this.productosMovimientoBindingSource.ResetBindings(true);
            this.gridView1.BestFitColumns();
        }
    }
}
