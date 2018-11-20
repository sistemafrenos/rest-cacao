using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic.Restaurant;

namespace HK
{
    public partial class FrmBuscarEntidadesRestaurant : Form
    {
        public string Status;
        public object registro = null;
        public object items;
        private string Texto = "";
        private string myLayout = "";
        Restaurant data;
        public FrmBuscarEntidadesRestaurant()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmBuscarEntidadesRestaurant_Load);
        }

        void FrmBuscarEntidadesRestaurant_Load(object sender, EventArgs e)
        {
            data = new Restaurant();
            this.txtFiltro.Text = "TODOS";
            this.txtBuscar.Text = Texto;
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.Buscar.Click += new EventHandler(txtBuscar_Click);
            this.Imprimir.Click += new EventHandler(Imprimir_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            Busqueda();
        }
        void txtBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        public void BuscarMesoneros(string s)
        {
            Texto = s;
            myLayout = "MESONEROS";
            this.ShowDialog();
        }
        public void BuscarMesas(string s)
        {
            Texto = s;
            myLayout = "MESAS";
            this.ShowDialog();
        }
        public void BuscarMesasDisponibles(string s)
        {
            Texto = s;
            myLayout = "MESAS DISPONIBLES";
            this.ShowDialog();
        }
        public void BuscarPlatos(string s)
        {
            myLayout = "PLATOS";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarCotizaciones(string s)
        {
            myLayout = "COTIZACIONES";
            Texto = s;
            this.ShowDialog();
        }
        public void BuscarAbiertas()
        {
            myLayout = "ABIERTAS";
            Texto = null;
            this.ShowDialog();
        }
        public void BuscarInsumos(string Texto)
        {
            myLayout = "INSUMOS";
            Texto = null;
            this.ShowDialog();
        }
        private void Busqueda()
        {
            Texto = this.txtBuscar.Text;
            switch (myLayout.ToUpper())
            {  
                case "MESONEROS":
                    this.bindingSource.DataSource = data.GetAllMesoneros(Texto);
                    break;
                case "MESAS":
                    this.bindingSource.DataSource = data.GetAllMesas(Texto);
                    break;
                case "PLATOS":
                    this.bindingSource.DataSource = data.GetAllProductosVentas(Texto, null);
                    break;
                case "MESAS DISPONIBLES":
                    this.bindingSource.DataSource = data.GetAllMesas(Texto);
                    break;
                case "ABIERTAS":
                    this.bindingSource.DataSource = data.GetAllFacturasAbiertas(txtBuscar.Text, "FACTURA ABIERTA");
                    break;
                case "INSUMOS":
                    this.bindingSource.DataSource = data.GetAllInsumos(Texto);
                    break;
            }
            if (this.bindingSource.Count > 0)
            {
                this.txtBuscar.Focus();
            }
            else
            {
                this.gridView1.Focus();
            }
            this.gridControl1.DataSource = this.bindingSource;
            gridControl1.ForceInitialize();
            gridView1.OptionsLayout.Columns.Reset();
            this.gridControl1.DefaultView.RestoreLayoutFromXml(String.Format("{0}\\{1}.XML", data.SistemaConfig.DirectorioListas, myLayout), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    Eliminar();
                    e.Handled = true;
                    break;
                case Keys.Return:
                    Seleccionar();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    Cancelar();
                    e.Handled = true;
                    break;
                case Keys.F2:
                    txtBuscar.Focus();
                    e.Handled = true;
                    break;
                case Keys.F3:
                    gridView1.Focus();
                    e.Handled = true;
                    break;
            }
        }
        private void Seleccionar()
        {
            if (this.bindingSource.Current != null)
            {
                this.DialogResult = DialogResult.OK;
                registro = this.bindingSource.Current;
                this.Close();
            }
        }
        private void Eliminar()
        {
            if (this.bindingSource.Current != null)
            {
                this.DialogResult = DialogResult.Abort;
                registro = this.bindingSource.Current;
                this.Close();
            }
        }
        private void Cancelar()
        {
            this.DialogResult = DialogResult.Cancel;
            registro = null;
            this.Close();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busqueda();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Cancelar();
            }
        }
        private void Imprimir_Click(object sender, EventArgs e)
        {
            this.gridControl1.ShowPrintPreview();
        }
    }
}

