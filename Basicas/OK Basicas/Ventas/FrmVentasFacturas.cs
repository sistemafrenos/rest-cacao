using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;
using HK.Fiscales;

namespace HK.Formas
{
    public partial class FrmVentasFacturas : Form
    {
        Administrativo data;
        public FrmVentasFacturas()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += FrmVentasFacturas_Load;
        }

        void FrmVentasFacturas_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmFacturas_KeyDown);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            btnNuevo.Click += new EventHandler(btnNuevo_Click);
            btnBuscar.Click += new EventHandler(btnBuscar_Click);
            btnEliminar.Click += new EventHandler(btnEliminar_Click);
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            btnVer.Click += new EventHandler(btnVer_Click);
            btnEmail.Click += new EventHandler(btnEmail_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            this.txtFiltro.Items.AddRange(new string[] { "HOY", "AYER", "ESTE MES", "MES ANTERIOR", "TODAS" });
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            Busqueda();
        }

        void btnEmail_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Factura((Factura)this.bs.Current, true);
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Factura((Factura)this.bs.Current, false);
        }
        void FrmFacturas_KeyDown(object sender, KeyEventArgs e)
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
            if (this.bs.Current == null)
                return;
            Documento documento = (Documento)this.bs.Current;
            if (documento.Tipo == "FACTURA")
            {
                FrmVentasFacturasItem f = new FrmVentasFacturasItem() { data = data };
                f.IdFactura = ((Factura)this.bs.Current).ID;
                f.Ver();
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                    Busqueda();
            }
        }
        void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmVentasFacturasItem f = new FrmVentasFacturasItem() { data = data };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }
        private void Busqueda()
        {
            this.bs.DataSource = data.GetDocumentos(txtBuscar.Text, txtTipoDocumento.Text, txtFiltro.Text);
            this.bs.ResetBindings(true);
         //   gridView1.BestFitColumns();
        }
        private void EliminarRegistro()
        {
            Factura item;
            try
            {
                 item = (Factura)this.bs.Current;
            }
            catch 
            { 
                return;
            }
            if (item == null)
                return;
            if (item.Tipo == "NOTA CREDITO")
            {
                MessageBox.Show("Esta no puede ser anulada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (item.Anulado == true && item.Tipo == "FACTURA")
            {
                MessageBox.Show("Esta factura ya ha sido anulada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("Esta seguro de anular esta Factura", "Atencion", MessageBoxButtons.YesNo) != System.Windows.Forms.DialogResult.Yes)
                return;
            Pago pago = data.AnularPagoIdDocumento(item.ID);
            NotaDeCredito devolucion = data.CrearNotaDeCredito(item);
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ImprimeNotaCredito(devolucion,pago);
            data.ProcesarNotaCredito(item,devolucion);
            data = new Administrativo();
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
