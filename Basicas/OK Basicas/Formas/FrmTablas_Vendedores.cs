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
    public partial class FrmTablas_Vendedores : Form
    {
        Administrativo data;
        Vendedor[] Lista;
        public string filtro;
        public FrmTablas_Vendedores()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmVendedores_Load);
        }
        void FrmVendedores_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmVendedores_KeyDown);
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.txtBuscar.Validating += new CancelEventHandler(txtBuscar_Validating);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnResumenxLapso.Click += new EventHandler(btnResumenxLapso_Click);
            this.btnVentasxLapso.Click += new EventHandler(btnVentasxLapso_Click);
            this.btncxcVendedor.Click += new EventHandler(btncxcVendedor_Click);
            this.btnResumenCxCVendedor.Click += new EventHandler(btnResumenCxCVendedor_Click);
            this.txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
            Busqueda();
            this.CenterToScreen();
        }
        void btnResumenxLapso_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.ResumenxLapsoVendedor();
        }
        void btnResumenCxCVendedor_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxC_ReporteCuentasxCobrarVendedor();
        }
        void btncxcVendedor_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxC_EstadoDeCuentaVendedor();
        }
        void btnVentasxVendedor_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.VentasxLapsoVendedor();
        }

        void btnVentasxLapso_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.VentasxLapsoVendedor();
        }
        void FrmVendedores_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    btnNuevo.PerformClick();
                    break;
            }
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.ListadoVendedores(Lista);
            f = null;
        }
        void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnBuscar.PerformClick();
        }
        void txtBuscar_Validating(object sender, CancelEventArgs e)
        {
            Busqueda();
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }
        private void Buscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            Lista = data.GetAllVendedores(txtBuscar.Text);
            this.bs.DataSource = Lista;
            this.bs.ResetBindings(true);
            this.gridView1.BestFitColumns();
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Return)
                {
                    EditarRegistro();
                }
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
                {
                    EliminarRegistro();
                }
                if (e.KeyCode == Keys.Insert)
                {
                    AgregarRegistro();
                }
            }
        }
        private void AgregarRegistro()
        {
            do
            {
                FrmTablas_VendedoresItem F = new FrmTablas_VendedoresItem();
                F.data = data;
                F.Incluir();
                if (F.DialogResult != DialogResult.OK)
                    return;
                Busqueda();
            }
            while (true);
        }
        private void EditarRegistro()
        {
            FrmTablas_VendedoresItem F = new FrmTablas_VendedoresItem();
            Vendedor registro = (Vendedor)this.bs.Current;
            if (registro == null)
                return;
            F.data = data;
            F.Modificar(registro.ID);
            Busqueda();
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                Vendedor Registro = (Vendedor)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    string result = data.EliminarVendedor((Vendedor)this.bs.Current,true);
                    if (result != null)
                        MessageBox.Show(result);
                    Busqueda();
                }
            }
        }
        private void Nuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            EditarRegistro();
        }
    }
}
