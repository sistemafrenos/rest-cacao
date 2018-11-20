using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmCajaChica : Form
    {
       // DatosEntities db = new DatosEntities(OK.CadenaConexion);
        List<CajaChica> Lista = new List<CajaChica>();
        public FrmCajaChica()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCajasChica_Load);
        }
        void  FrmCajasChica_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            btnRegistrarPagos.Click += new EventHandler(btnRegistrarPagos_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnRecuperarPagos.Click += new EventHandler(btnRecuperarPagos_Click);
            #region grid
            gridView1.OptionsLayout.Columns.Reset();
            gridControl1.ForceInitialize();
            gridView1.OptionsLayout.Columns.Reset();
            //if (System.IO.File.Exists(string.Format(Application.StartupPath + "\\Layouts\\CajasChica{0}.XML", Basicas.parametros.Empresa)))
            //{
            //    this.gridControl1.DefaultView.RestoreLayoutFromXml(string.Format(Application.StartupPath + "\\Layouts\\CajasChica{0}.XML", Basicas.parametros.Empresa), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            //else
            //{
            //    this.gridControl1.DefaultView.RestoreLayoutFromXml(Application.StartupPath + "\\Layouts\\CajasChica.XML", DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}

            #endregion
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }

        void btnRecuperarPagos_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarCajaChica();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                //db = new DatosEntities(OK.CadenaConexion);
                //Lista = (from p in db.CajasChicas
                //         where p.NumeroCheque == ((BancosMovimiento)f.registro).Numero
                //         select p).ToList();
                this.bs.DataSource = Lista;
                this.bs.ResetBindings(true);
                this.btnRegistrarPagos.Enabled = false;
            }
            else
            {
                Busqueda();
            }
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.ReporteCajaChica(Lista);
        }

        private void Busqueda()
        {
            //db = new DatosEntities(OK.CadenaConexion);
            //Lista = (from p in db.CajasChicas
            //         where (p.Saldo > 0 || p.NumeroCheque == null)
            //         orderby p.Fecha
            //         select p).ToList();
            foreach (var x in Lista)
            {
                x.Monto = Basicas.Round(x.Monto);
            }
            this.bs.DataSource = Lista;
            this.bs.ResetBindings(true);
            this.btnRegistrarPagos.Enabled = true;
            this.gridView1.BestFitColumns();
        }

        void btnRegistrarPagos_Click(object sender, EventArgs e)
        {
            FrmBancosCheque f = new FrmBancosCheque();
            f.monto = Lista.Sum(x => x.Monto).GetValueOrDefault(0);
            f.concepto = "CAJA CHICA";
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in Lista)
                {
                    item.MovimientoBancoID = f.registro.ID;
                    item.NumeroCheque = f.registro.Numero;
                    item.Saldo = 0;
                }
                //db.SaveChanges();
                Busqueda();
            }
        }
    }
}
