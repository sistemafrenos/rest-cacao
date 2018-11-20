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

namespace HK.Formas
{

    public partial class FrmAdministrativo_InventarioMensual : Form
    {
        DateTime fecha = DateTime.Today;
        DatosEntities db = new DatosEntities(OK.CadenaConexion);
        List<ReportViews.ProductosMovimientos> Lista = new List<ReportViews.ProductosMovimientos>();
        int Mes = 0;
        int Año = 0;
        int dia = 0;
        public FrmAdministrativo_InventarioMensual()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmAdministrativoInventarioDiario_Load);
        }

        void FrmAdministrativoInventarioDiario_Load(object sender, EventArgs e)
        {
            #region EventosPantalla
            this.btnCargar.Click += new EventHandler(btnCargar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            #endregion
            dia = DateTime.Today.Day;
            Mes = DateTime.Today.Month;
            Año = DateTime.Today.Year;
            this.txtAño.Text = Año.ToString("0000");
            this.txtMes.Text = Mes.ToString("00");
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
        }
        void btnCargar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            if (!DateTime.TryParse(string.Format("{0}/{1}/{2}", txtAño.Text, txtMes.Text, "01"), out fecha))
            {
                MessageBox.Show("Fecha Erronea");
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            object result = Jacksonsoft.WaitWindow.Show(this.WorkerMethod, "Actualizando Movimientos de Inventarios");
            this.Cursor = Cursors.Default;
            this.bs.DataSource = Lista;
        }
        private void WorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            /// Pendiente
          //  Lista = FactoryLibroInventarios.InventarioMensual(fecha);
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
        void btnImprimir_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
        #endregion
        private void Imprimir()
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_InventarioMensual(Lista, string.Format("Mes {0} Año {1}", txtMes.Text, txtAño.Text));
            f = null;
        }
    }
}
