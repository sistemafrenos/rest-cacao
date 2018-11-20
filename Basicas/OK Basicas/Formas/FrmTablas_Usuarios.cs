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
    public partial class FrmTablas_Usuarios : Form
    {
        public DevExpress.XtraBars.Ribbon.RibbonControl my_ribbon { set; get; }
        Administrativo data;
        Usuario usuario;
        Usuario[] Lista;
        public string filtro;
        public FrmTablas_Usuarios()
        {
            InitializeComponent();
            data = new Administrativo();
            usuario = new Usuario();
            this.Load += new EventHandler(FrmUsuarios_Load);
            BarraAcciones.Text = "Usuarios";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmUsuarios_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmUsuarios_KeyDown);
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.txtBuscar.Validating += new CancelEventHandler(txtBuscar_Validating);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.CenterToScreen();
            Busqueda();
        }
        void FrmUsuarios_KeyDown(object sender, KeyEventArgs e)
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
            f.Tablas_Usuarios(Lista);
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
            Lista = data.GetAllUsuarios(this.txtBuscar.Text);
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
                FrmTablas_UsuariosItem F = new FrmTablas_UsuariosItem();
                F.MyRibbon = this.my_ribbon;
                F.Incluir();
                if (F.DialogResult != DialogResult.OK)
                    return;
                Busqueda();
            }
            while (true);
        }
        private void EditarRegistro()
        {
            FrmTablas_UsuariosItem F = new FrmTablas_UsuariosItem();
            Usuario registro = (Usuario)this.bs.Current;
            if (registro == null)
                return;
            F.MyRibbon = this.my_ribbon;
            F.Modificar(registro.ID);
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda();
            }
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                Usuario Registro = (Usuario)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                data.EliminarUsuario(Registro,true);
                Busqueda();
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
