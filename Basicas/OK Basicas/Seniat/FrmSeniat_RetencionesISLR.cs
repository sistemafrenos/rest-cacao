using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmSeniat_RetencionesISLR : Form
    {
        BussinessLogic.RetencionesISLR retenciones;
        List<RetencionISLR> lista = new List<RetencionISLR>();
        public FrmSeniat_RetencionesISLR()
        {
            InitializeComponent();
            retenciones = new BussinessLogic.RetencionesISLR();
            this.Load += new EventHandler(FrmRencionesISLR_Load);
            BarraAcciones.Text = "RetencionesISLR";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmRencionesISLR_Load(object sender, EventArgs e)
        {
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnNuevo.Click += new EventHandler(btnNuevo_Click);
            this.btnEditar.Click += new EventHandler(btnEditar_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnRelacionRetenciones.Click += new EventHandler(btnRelacionRetenciones_Click);
            this.txtAño.Text = DateTime.Today.Year.ToString();
            this.txtMes.Text = DateTime.Today.Month.ToString("00");
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }

        void btnRelacionRetenciones_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Seniat_RelacionRetencionesISLR();
            f = null;
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            RetencionISLR registro = (RetencionISLR)this.bs.Current;
            if (registro == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Seniat_ImprimirRetencionISLR(registro);
            f = null;
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
            int ano, mes;
            int.TryParse(txtAño.Text,out ano);
            int.TryParse(txtMes.Text,out mes);
            lista = retenciones.GetMes(ano,mes);
            this.bs.DataSource = lista;
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
            FrmSeniat_RetencionesISLRItem F = new FrmSeniat_RetencionesISLRItem();
            F.Incluir(txtMes.Text, txtAño.Text);
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda();
            }
        }
        private void EditarRegistro()
        {
            FrmSeniat_RetencionesISLRItem F = new FrmSeniat_RetencionesISLRItem();
            F.Modificar();
            if (F.DialogResult == DialogResult.OK)
            {
                Busqueda();
            }
        }
        private void EliminarRegistro()
        {
            if (this.gridView1.IsFocusedView)
            {
                RetencionISLR Registro = (RetencionISLR)this.bs.Current;
                if (Registro == null)
                    return;
                if (MessageBox.Show("Esta seguro de eliminar este registro", "Atencion", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    return;
                }
                try
                {
                    Busqueda();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
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
