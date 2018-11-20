using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmVentasNotasEntrega : Form
    {
        Administrativo data;
        public FrmVentasNotasEntrega()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmNotasEntrega_Load);
        }
        void FrmNotasEntrega_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmNotasEntregas_KeyDown);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnEditar.Click += new EventHandler(btnEditar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            btnEmail.Click += new EventHandler(btnEmail_Click);
            btnFactura.Click += new EventHandler(btnFactura_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.txtFiltro.Items.AddRange(new string[] { "HOY", "AYER", "ESTE MES", "MES ANTERIOR", "TODAS"});
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }
        void btnFactura_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            NotaEntrega item = (NotaEntrega)bs.Current;
            FrmVentasFacturasItem f = new FrmVentasFacturasItem();
            f.CargarNotaEntrega(item);
            item = data.FindNotaDeEntrega(item.ID);
            item.Estatus = "FACTURADO";
            string result = data.GuardarNotaDeEntrega(item);
            if (result != null)
                MessageBox.Show(result);
        }
        void btnEmail_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_NotaEntrega((NotaEntrega)this.bs.Current, true);
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_NotaEntrega((NotaEntrega)this.bs.Current, false);
        }
        void FrmNotasEntregas_KeyDown(object sender, KeyEventArgs e)
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
        void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmVentasNotasEntregasItem f = new FrmVentasNotasEntregasItem()
            { 
                data = data,
                IdNotaEntrega = ((Documento)this.bs.Current).ID
            };
            f.Modificar();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmVentasNotasEntregasItem f = new FrmVentasNotasEntregasItem() { data = data };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        private void Busqueda()
        {
            this.bs.DataSource = data.GetDocumentos(txtBuscar.Text, "NOTA ENTREGA", txtFiltro.Text);
            gridView1.BestFitColumns();
        }
        private void EliminarRegistro()
        {
            NotaEntrega item = (NotaEntrega)this.bs.Current;
            if (item == null)
                return;
            if (MessageBox.Show("Esta seguro de eliminar esta Documento", "Atencion", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;
            data.EliminarNotaEntrega(item,true);
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
                        btnEditar.PerformClick();
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
