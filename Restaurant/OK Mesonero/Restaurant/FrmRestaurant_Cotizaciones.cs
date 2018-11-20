using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmRestaurant_Cotizaciones : Form
    {
        Restaurant data;
        public FrmRestaurant_Cotizaciones()
        {
            InitializeComponent();
            data = new Restaurant();
            this.Load += new EventHandler(FrmCotizaciones_Load);
        }
        void FrmCotizaciones_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmCotizaciones_KeyDown);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            btnEmail.Click += new EventHandler(btnEmail_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.txtFiltro.Items.AddRange(new string[] { "HOY", "AYER", "ESTE MES", "MES ANTERIOR", "TODAS" });
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
            Busqueda();
        }
        void btnEmail_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_Cotizacion((Cotizacion)this.bs.Current, true);
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_Cotizacion((Cotizacion)this.bs.Current, false);
        }
        void FrmCotizaciones_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    btnNuevo.PerformClick();
                    break;
            }
        }
        void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmRestaurant_CotizacionesItem f = new FrmRestaurant_CotizacionesItem() { IdCotizacion = ((Cotizacion)this.bs.Current).ID };
            f.Modificar();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmRestaurant_CotizacionesItem f = new FrmRestaurant_CotizacionesItem();
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        private void Busqueda()
        {
            this.bs.DataSource = data.GetDocumentos(txtBuscar.Text,"COTIZACION", txtFiltro.Text);
            this.bs.ResetBindings(true);
            gridView1.BestFitColumns();
        }
        private void EliminarRegistro()
        {
            Cotizacion item = (Cotizacion)this.bs.Current;
            if (item == null)
                return;
            if (MessageBox.Show("Esta seguro de eliminar esta Cotizacion", "Atencion", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;
            data.EliminarCotizacion(item,true);
            Busqueda();
        }
        #region Eventos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        btnNuevo.PerformClick();
                        break;
                    case Keys.Return:
                        btnEditar.PerformClick();
                        break;
                    case Keys.Delete:
                        btnEliminar.PerformClick();
                        break;
                    case Keys.Subtract:
                        btnEliminar.PerformClick();
                        break;
                }
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busqueda();
            }
        }
        #endregion
    }
}
