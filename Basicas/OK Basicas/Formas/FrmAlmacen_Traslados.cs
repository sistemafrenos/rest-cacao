using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK;

namespace HK.Formas
{
    public partial class FrmAlmacen_Traslados : Form
    {
        DatosEntities db = new DatosEntities(OK.CadenaConexion);
        List<Traslado> Lista = new List<Traslado>();
        public FrmAlmacen_Traslados()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmTraslados_Load);
            this.FormClosed += new FormClosedEventHandler(FrmTraslados_FormClosed);
        }
        void FrmTraslados_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Pantallas.Traslados= null;
        }
        void FrmTraslados_Load(object sender, EventArgs e)
        {
            Buscar.Click += new EventHandler(Buscar_Click);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnVer.Click += new EventHandler(btnVer_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.txtFiltro.Items.AddRange(new string[] { "ESTE MES", "MES ANTERIOR", "TODAS" });
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            Traslado registro = (Traslado)this.bs.Current;
            f.Traslados(registro);
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        void btnVer_Click(object sender, EventArgs e)
        {
            Traslado registro = (Traslado)this.bs.Current;
            if (registro == null)
                return;
            FrmAlmacen_TrasladosItem f = new FrmAlmacen_TrasladosItem();
            f.registro = registro;
            f.Ver();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmAlmacen_TrasladosItem f = new FrmAlmacen_TrasladosItem();
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Busqueda();
            }
        }
        private void Busqueda()
        {
            db = new DatosEntities(OK.CadenaConexion);
            int mes = DateTime.Today.Month;
            int año = DateTime.Today.Year;
            switch (txtFiltro.Text)
            {
                case "TODAS":
                    Lista = (from p in db.Traslados
                             where ( p.Comentarios.Contains(txtBuscar.Text) || txtBuscar.Text.Length == 0 ) 
                            orderby p.Fecha
                            select p).ToList();
                    break;
                case "MES ANTERIOR":
                    if (DateTime.Today.Month == 1)
                    {
                        mes = 12;
                        año = año--;
                    }
                    Lista = (from p in db.Traslados
                             where (p.Comentarios.Contains(txtBuscar.Text) || txtBuscar.Text.Length == 0) && p.Fecha.Value.Month==mes && p.Fecha.Value.Year==año
                             orderby p.Fecha descending
                             select p).ToList();
                    break;
                case "ESTE MES":
                    Lista = (from p in db.Traslados
                             where (p.Comentarios.Contains(txtBuscar.Text) || txtBuscar.Text.Length == 0) && p.Fecha.Value.Month == mes && p.Fecha.Value.Year == año
                             orderby p.Fecha descending
                             select p).ToList();
                    break;
            }
            this.bs.DataSource = Lista;
            this.bs.ResetBindings(true);
            this.gridView1.BestFitColumns();
        }
        private void EliminarRegistro()
        {
            if (this.bs.Current == null)
                return;
            Traslado documento = (Traslado)this.bs.Current;
            if (MessageBox.Show("Esta seguro de eliminar este Traslado", "Atencion", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;
            try
            {
                db.Traslados.Remove(documento);
                db.SaveChanges();
                Busqueda();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
        }
        #region Eventos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Return:
                        btnVer.PerformClick();
                        break;
                    case Keys.Delete:
                        btnEliminar.PerformClick();
                        break;
                    case Keys.Subtract:
                        btnEliminar.PerformClick();
                        break;
                }
            }
        }
        private void Buscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Eliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busqueda();
            }
        }
        #endregion
    }
}
