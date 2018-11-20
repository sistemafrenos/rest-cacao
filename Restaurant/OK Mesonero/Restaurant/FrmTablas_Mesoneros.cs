using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmTablas_Mesoneros : Form
    {
        Restaurant restaurant;
        Mesonero[] lista;
        public FrmTablas_Mesoneros()
        {
            InitializeComponent();
            restaurant = new Restaurant();
            Load += Frm_Load;
            BarraAcciones.Text = "Mesoneros";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += Frm_KeyDown;
            gridControl1.KeyDown += gridControl1_KeyDown;
            gridControl1.DoubleClick += gridControl1_DoubleClick;
            btnNuevo.Click += btnNuevo_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnBuscar.Click += btnBuscar_Click;
            txtBuscar.Validating += txtBuscar_Validating;
            btnImprimir.Click += btnImprimir_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            Height = Screen.PrimaryScreen.Bounds.Height - 100;
            Width = Screen.PrimaryScreen.Bounds.Width - 50;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            CenterToScreen();
            Busqueda();
        }
        void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    btnNuevo.PerformClick();
                    break;
                default: break;
            }
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            using (var f = new FrmReportes())
            {
                f.Tablas_Mesoneros(lista);
            }
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
        private void Busqueda()
        {
            Enlazar();
        }
        private void Enlazar()
        {
            lista = restaurant.GetAllMesoneros(txtBuscar.Text);
            bs.DataSource = lista;
            bs.ResetBindings(true);
            gridView1.BestFitColumns();
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
                using (FrmTablas_MesonerosItem F = new FrmTablas_MesonerosItem()
                { restaurant = restaurant })
                {
                    F.Incluir();
                    if (F.DialogResult != DialogResult.OK)
                        return;
                }
                Busqueda();
            }
            while (true);
        }
        private void EditarRegistro()
        {
            if (bs.Current == null)
                return;
            using (FrmTablas_MesonerosItem F = new FrmTablas_MesonerosItem())
            {
                F.restaurant = restaurant;
                F.Modificar(((Mesonero)bs.Current).ID);
            }
            Busqueda();
        }
        private void EliminarRegistro()
        {
            if (gridView1.IsFocusedView)
            {
                if (bs.Current == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                string result = restaurant.EliminarMesonero((Mesonero)bs.Current,true);
                if(result!=null)
                    MessageBox.Show(result);
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
