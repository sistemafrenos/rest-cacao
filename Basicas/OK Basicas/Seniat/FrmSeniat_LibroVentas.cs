using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmSeniat_LibroVentas : Form
    {
        Administrativo data;
        LibroVenta[] Lista;
        int mes;
        int ano;
        public FrmSeniat_LibroVentas()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmLibroVentas_Load);
            BarraAcciones.Text = "LibroVentas";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmLibroVentas_Load(object sender, EventArgs e)
        {
            #region EventosPantalla
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnCargar.Click += new EventHandler(btnBuscar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnImprimirResumido.Click += new EventHandler(btnImprimirResumido_Click);
            this.btnPorNumeroZ.Click += new EventHandler(btnPorNumeroZ_Click);
            this.btnProcesarLibro.Click += new EventHandler(btnProcesarLibro_Click);
            #endregion
            data = new Administrativo();
            this.txtAño.Text = DateTime.Today.Year.ToString();
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
            ano = int.Parse(txtAño.Text);
            mes = int.Parse(txtMes.Text);
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
                data.EscribirLibroDeVentas(mes, ano);
                data.GuardarCambios();
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
        void btnPorNumeroZ_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Seniat_LibroDeVentasDiario(Lista, string.Format("Mes {0} Año {1}",txtMes.Text,txtAño.Text));
        }
        void btnImprimirResumido_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Seniat_LibroDeVentasResumido();
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
            f.Seniat_LibroDeVentas(Lista, string.Format("Mes {0} Año {1}", txtMes.Text, txtAño.Text));
            f = null;
        }
        private void Busqueda()
        {
            int mes = Convert.ToInt32(txtMes.Text);
            int año = Convert.ToInt32(txtAño.Text);
            Lista = data.GetByMesLibroVentas(mes, año);
            this.bs.DataSource = Lista;
            this.bs.ResetBindings(true);
            this.gridView1.BestFitColumns();
        }
        private void AgregarRegistro()
        {
            FrmSeniat_LibroVentasItem F;
            do
            {
                F = new FrmSeniat_LibroVentasItem();
                F.data = data;
                F.Incluir(txtMes.Text, txtAño.Text);
                if (F.DialogResult == DialogResult.OK)
                {
                    data.GuardarLibroVenta(F.registro, true);
                    Busqueda();
                }
            }
            while (F.DialogResult != System.Windows.Forms.DialogResult.Cancel);
        }
        private void EditarRegistro()
        {
            FrmSeniat_LibroVentasItem F = new FrmSeniat_LibroVentasItem();
            LibroVenta registro = (LibroVenta)this.bs.Current;
            if (registro == null)
                return;
            F.data = data;
            F.registro = registro;
            F.registro.Mes = Convert.ToInt16(txtMes.Text);
            F.registro.Ano = Convert.ToInt16(txtAño.Text);
            F.Modificar();
            if (F.DialogResult == DialogResult.OK)
            {
                data.GuardarLibroVenta(F.registro, true);
            }
            Busqueda();
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                LibroVenta Registro = (LibroVenta)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    data.EliminarLibroVenta((LibroVenta)this.bs.Current, true);
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
