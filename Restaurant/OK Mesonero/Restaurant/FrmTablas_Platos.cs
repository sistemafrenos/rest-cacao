using HK.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_Platos : Form
    {
        Restaurant data;
        public FrmTablas_Platos()
        {
            InitializeComponent();
            if (data == null)
                data = new Restaurant();
            this.Load += new EventHandler(FrmProductos_Load);
            BarraAcciones.Text = "PLatos";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }

        public string filtro;
        void FrmProductos_Load(object sender, EventArgs e)
        {
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.txtBuscar.Validating += new CancelEventHandler(txtBuscar_Validating);
            this.btnImprimir.Click += btnImprimir_Click;
          //  this.btnEtiquetas.Click += btnEtiquetas_Click;
            btnPlatosIngredientes.Click += btnPlatosIngredientes_Click;
            this.btnCopiar.Click += new EventHandler(btnCopiar_Click);
            this.btnAjustePrecios.Click += new EventHandler(btnAjustePrecios_Click);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }

        void btnPlatosIngredientes_Click(object sender, EventArgs e)
        {
            using (var f = new FrmRestaurant_Reportes())
            {
                f.Restaurant_PlatosIngredientes();
            }
        }
        void btnAjustePrecios_Click(object sender, EventArgs e)
        {
            FrmTablas_ProductosAjustePrecios f = new FrmTablas_ProductosAjustePrecios();
            f.ShowDialog();
            Busqueda();
        }
        void btnCopiar_Click(object sender, EventArgs e)
        {
            CopiarRegistro();
            Busqueda();
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_Platos(data.GetAllPlatos(txtBuscar.Text,null));
            f = null;
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
            Busqueda();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
            Busqueda();
        }
        private void Busqueda()
        {
            data = new Restaurant();
            this.bs.DataSource = data.GetAllProductosSoloVentas(txtBuscar.Text,null);
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
                using (var F = new FrmTablas_PlatosItem())
                {
                    F.Incluir();
                    if (F.DialogResult == DialogResult.OK)
                        Busqueda();
                    else
                        return;
                }
            }
            while (true);
        }
        private void EditarRegistro()
        {
            if (this.bs.Current == null)
                return;
            using (var F = new FrmTablas_PlatosItem())
            {
                F.Modificar(((Producto)this.bs.Current).ID);
                if (F.DialogResult == DialogResult.OK)
                    Busqueda();
            }
        }
        private void CopiarRegistro()
        {
            if (this.bs.Current == null)
                return;
            FrmTablas_PlatosItem F = new FrmTablas_PlatosItem();
            F.Copiar(data.CloneProducto((Producto)this.bs.Current));
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda();
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
                data.EliminarPlato((Producto)this.bs.Current, true);
                Busqueda();
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
