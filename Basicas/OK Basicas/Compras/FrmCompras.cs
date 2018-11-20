using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmCompras : Form
    {
        Administrativo data;
        public FrmCompras()
        {
            InitializeComponent();
            data = new Administrativo();
            Load += Frm_Load;
            BarraAcciones.Text = "Compras";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += Frmcompras_KeyDown;
            gridControl1.KeyDown += gridControl1_KeyDown;
            btnNuevo.Click += btnNuevo_Click;
            btnNuevoGasto.Click += btnNuevoGasto_Click;
            btnBuscar.Click += btnBuscar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnImprimir.Click += btnImprimir_Click;
            btnVer.Click += btnVer_Click;
            btnRetencionISLR.Click += btnRetencionISLR_Click;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            txtFiltro.Items.AddRange(new string[] { "HOY", "AYER", "ESTE MES", "MES ANTERIOR", "TODAS" });
            txtTipoDocumento.Items.AddRange(new string[] { "COMPRA", "NOTA CREDITO COMPRA", "NOTA DEBITO COMPRA"});
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }

        void btnRetencionISLR_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            Compra registro = (Compra)this.bs.Current;
            RetencionesISLR retenciones = new RetencionesISLR();
            retenciones.LoadIdCompra(registro.ID);
            if (retenciones.current.ID != null)
            {
                if (MessageBox.Show("Esta compra ya tiene retencion ISLR aplicada, desea imprimirla", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    FrmReportes reportes = new FrmReportes();
                    reportes.Seniat_ImprimirRetencionISLR(retenciones.current);
                    return;
                }
                else
                {
                    return;
                }
            }
        }

        void btnNuevoGasto_Click(object sender, EventArgs e)
        {
            using (FrmComprasItemGasto f = new FrmComprasItemGasto())
            {
                f.data = data;
                f.Incluir();
                if(f.DialogResult== System.Windows.Forms.DialogResult.OK)
                   Busqueda();
            }
           
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            if (bs.Current == null)
                return;
            using (FrmReportes f = new FrmReportes())
            {
                f.Compras((Compra)bs.Current);
            }
        }
        void Frmcompras_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Insert:
                    btnNuevo.PerformClick();
                    break;
            }
        }
        void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
        }
        void btnVer_Click(object sender, EventArgs e)
        {
            if (bs.Current == null)
                return;
            Compra current = (Compra)bs.Current;
            if (current.DocumentosProductos.Count == 0)
            {
                using (FrmComprasItemGasto f = new FrmComprasItemGasto())
                {
                    f.IdDocumento = current.ID;
                    f.Ver();
                }
            }
            else
            {
                using (FrmComprasItem f = new FrmComprasItem())
                {
                    f.ID = current.ID;
                    f.Ver();
                }
            }
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmComprasItem f = new FrmComprasItem())
            {
                f.data = data;
                f.Incluir();
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                    Busqueda();
            }
        }
        private void Busqueda()
        {
            var lista = data.GetDocumentos(txtBuscar.Text ,txtTipoDocumento.Text,txtFiltro.Text);
            bs.DataSource = lista.Where(x => x.Estatus == "CERRADA");
            bs.ResetBindings(true);
            gridView1.BestFitColumns();
        }
        private void EliminarRegistro()
        {
            Compra item = (Compra)bs.Current;
            if (item == null)
                return;
            if (item.Tipo != "COMPRA")
                return;
            if (MessageBox.Show("Esta seguro de anular esta Compra", "Atencion", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;
            data.EliminarCompra((Compra)bs.Current);
            Busqueda();
        }
        #region Eventos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                switch (e.KeyCode)
                {
                    case Keys.Insert:
                        btnNuevo.PerformClick();
                        break;
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
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
