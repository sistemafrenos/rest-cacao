using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmSeniat_LibroCompras : Form
    {
        int Mes = 0;
        int Ano = 0;
        Administrativo data;
        LibroCompra[] libro;
        public FrmSeniat_LibroCompras()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmLibroCompras_Load);
            BarraAcciones.Text = "LibroCompras";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmLibroCompras_Load(object sender, EventArgs e)
        {
            #region EventosPantalla
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnCargar.Click += new EventHandler(btnBuscar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnProcesarLibro.Click += new EventHandler(btnProcesarLibro_Click);
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

        void btnProcesarLibro_Click(object sender, EventArgs e)
        {
            Ano = int.Parse(txtAno.Text);
            Mes = int.Parse(txtMes.Text);
            this.Cursor = Cursors.WaitCursor;
            this.btnProcesarLibro.Text = "Actualizando...!";
            Application.DoEvents();
            object result = Jacksonsoft.WaitWindow.Show(this.WorkerMethod, "Actualizando Libro de Ventas");
            this.Cursor = Cursors.Default;
            this.btnProcesarLibro.Text = "Procesar Libro";
            Busqueda();
        }
        private void WorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            try
            {
                data.EscribirLibroDeCompras(Mes, Ano);
            }
            catch (Exception x)
            {
                OK.ManejarException(x);
            }
            if (e.Arguments.Count > 0)
            {
                e.Result = e.Arguments[0].ToString();
            }
            else
            {
                e.Result = "Ok";
            }
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
        void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        #endregion
        private void Imprimir()
        {
            FrmReportes f = new FrmReportes();
            f.Seniat_LibroDeCompras(libro, string.Format("Mes {0} Ano {1}", txtMes.Text, txtAno.Text));
            f = null;
        }
        private void Busqueda()
        {
            Mes = Convert.ToInt16(txtMes.Text);
            Ano = Convert.ToInt16(txtAno.Text);
            libro = data.GetByMesLibroCompra(Mes, Ano);
            this.bs.DataSource = libro;
            this.bs.ResetBindings(true);
            this.gridView1.BestFitColumns();
        }
        private void AgregarRegistro()
        {
            FrmSeniat_LibroComprasItem F;
            do
            {
                F = new FrmSeniat_LibroComprasItem();
                F.Incluir(txtMes.Text, txtAno.Text);
                if (F.DialogResult == DialogResult.OK)
                {
                    F.registro.Calcular();
                    data.GuardarLibroCompra((LibroCompra)F.registro,true);
                    Busqueda();
                }
            }
            while (F.DialogResult != System.Windows.Forms.DialogResult.Cancel);
        }
        private void EditarRegistro()
        {
            FrmSeniat_LibroComprasItem F = new FrmSeniat_LibroComprasItem();
            LibroCompra registro = (LibroCompra)this.bs.Current;
            if (registro == null)
                return;
            F.registro = registro;
            F.registro.Mes = Convert.ToInt16(txtMes.Text);
            F.registro.Ano = Convert.ToInt16(txtAno.Text);
            F.Modificar();
            if (F.DialogResult == DialogResult.OK)
            {
                F.registro.Calcular();
                data.GuardarLibroCompra((LibroCompra)F.registro, true);
            }
            Busqueda();
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                LibroCompra Registro = (LibroCompra)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    data.EliminarLibroDeCompras(Registro);
                    Busqueda();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
        }
    }
}

