using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_Productos : Form
    {
        Administrativo data;
        public FrmTablas_Productos()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmProductos_Load);
        }

        void FrmProductos_Load(object sender, EventArgs e)
        {
            this.btnSalidas.Click += btnSalidas_Click;
            this.btnEntradas.Click += btnEntradas_Click;
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnCopiar.Click += new EventHandler(btnCopiar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnMovimientos.Click += new EventHandler(btnMovimientos_Click);
            btnCalcularExistencias.Click += btnCalcularExistencias_Click;
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.btnAjustePrecios.Click += new EventHandler(btnAjustePrecios_Click);
            this.txtBuscar.Validating += new CancelEventHandler(txtBuscar_Validating);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda(false);
            Basicas.AsegurarToolStrip(new object[] { this.BarraAcciones });
        }
        void btnCalcularExistencias_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.btnCalcularExistencias.Text = "Calculando...!";
            Application.DoEvents();
            object result = Jacksonsoft.WaitWindow.Show(this.WorkerMethod, "Actualizando Movimientos de Inventarios");
            this.Cursor = Cursors.Default;
            Busqueda(true);
            this.btnCalcularExistencias.Text = "Calcular Existencias";

        }
        private void WorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            Administrativo data = new Administrativo();
            data.ProductosCalcularExistencias();
            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                e.Result = "Ok";
            }
        }
        void btnSalidas_Click(object sender, EventArgs e)
        {
            do
            {
                FrmTablas_ProductosDescargar f = new FrmTablas_ProductosDescargar();
                f.data = data;
                f.Incluir();
                Busqueda(false);
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            while (true);
        }
        void btnEntradas_Click(object sender, EventArgs e)
        {
            do
            {
                FrmTablas_ProductosCargar f = new FrmTablas_ProductosCargar();
                f.data = data;
                f.Incluir();
                Busqueda(false);
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
            }
            while (true);
        }
        void btnAjustePrecios_Click(object sender, EventArgs e)
        {
            FrmTablas_ProductosAjustePrecios f = new FrmTablas_ProductosAjustePrecios();
            f.ShowDialog();
            Busqueda(true);
        }
        void btnMovimientos_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmTablas_ProductosMovimientos f = new FrmTablas_ProductosMovimientos() { producto = (Producto)this.bs.Current };
            f.ShowDialog();
        }
        void btnCopiar_Click(object sender, EventArgs e)
        {
            CopiarRegistro();
            Busqueda(false);
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_ListadoProductos(data.GetAllProductos(txtBuscar.Text));
            f = null;
        }
        void txtBuscar_Validating(object sender, CancelEventArgs e)
        {
            Busqueda(false);
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda(false);
        }
        void btnEditar_Click(object sender, EventArgs e)
        {
            EditarRegistro();
            Busqueda(false);
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
            Busqueda(false);
        }
        private void Busqueda(bool reset)
        {
            if (reset)
                data = new Administrativo();
            this.bs.DataSource = data.GetAllProductos(txtBuscar.Text);
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
            FrmTablas_ProductosItem F;
            do
            {
                F = new FrmTablas_ProductosItem();
                F.data = data;
                F.Incluir(null);
                if (F.DialogResult == DialogResult.OK)
                {
                    Busqueda(false);
                }
            }
            while (F.DialogResult == System.Windows.Forms.DialogResult.OK);
        }
        private void EditarRegistro()
        {
            if (this.bs.Current == null)
                return;
            FrmTablas_ProductosItem F = new FrmTablas_ProductosItem();
            F.data = data;
            F.Modificar(((Producto)this.bs.Current).ID);
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda(false);
            }
        }
        private void CopiarRegistro()
        {
            if (this.bs.Current == null)
                return;
            FrmTablas_ProductosItem F = new FrmTablas_ProductosItem();
            F.data = data;
            F.Copiar((Producto)this.bs.Current);
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda(false);
            }
        }
        private void EliminarRegistro()
        {
            if (this.bs.Current == null)
                return;
            if (this.gridView1.IsFocusedView)
            {
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                data.EliminarProducto((Producto)this.bs.Current,true);
                Busqueda(false);
            }
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
