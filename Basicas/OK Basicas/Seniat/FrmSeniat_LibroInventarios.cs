using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmSeniat_LibroInventarios : Form
    {
        Administrativo data;
        LibroInventario[] lista;
        public FrmSeniat_LibroInventarios()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmLibroInventarios_Load);
            BarraAcciones.Text = "LibroInventarios";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmLibroInventarios_Load(object sender, EventArgs e)
        {
            #region EventosPantalla
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnCargar.Click += new EventHandler(btnBuscar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            #endregion
            this.txtAno.Text = DateTime.Today.Year.ToString();
            this.txtMes.Text = DateTime.Today.Month.ToString();
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();

        }

        #region ManejoDePantalla
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            EditarRegistro();
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
        void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        #endregion
        private void Imprimir()
        {
            FrmReportes f = new FrmReportes();
            f.Seniat_LibroDeInventarios(lista, string.Format("Mes {0} Ano {1}", txtMes.Text, txtAno.Text));
            f = null;
        }
        private void Busqueda()
        {
            lista = data.GetByMesLibroInventario(Convert.ToInt16(txtMes.Text), Convert.ToInt16(txtAno.Text));
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
            this.gridView1.BestFitColumns();
        }
        private void AgregarRegistro()
        {
            FrmSeniat_LibroInventariosItem F;
            do
            {
                F = new FrmSeniat_LibroInventariosItem();
                F.data = data;
                F.Incluir();
                if (F.DialogResult == DialogResult.OK)
                {
                    DateTime.Parse(string.Format("{0}/{1}/{2}","01",txtMes.Text,txtAno.Text));
                    F.registro.Mes = Convert.ToInt16(txtMes.Text);
                    F.registro.Ano = Convert.ToInt16(txtAno.Text);
                    F.registro.Calcular();
                    data.GuardarLibroInventario(F.registro, true);
                    Busqueda();
                }
            }
            while (F.DialogResult != System.Windows.Forms.DialogResult.Cancel);
        }
        private void EditarRegistro()
        {
            FrmSeniat_LibroInventariosItem F = new FrmSeniat_LibroInventariosItem();
            LibroInventario registro = (LibroInventario)this.bs.Current;
            if (registro == null)
                return;
            F.registro = registro;
            F.Modificar();
            if (F.DialogResult == DialogResult.OK)
            {
                data.GuardarLibroInventario(F.registro, true);
            }
            Busqueda();
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                LibroInventario Registro = (LibroInventario)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    data.EliminarLibroInventario(Registro,true);
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }
    }
}
