using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Fiscales;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmConsultarFacturas : Form
    {
        Factura[] Lista;
        public Administrativo data;
        public FrmConsultarFacturas()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmFacturas_Load);
            BarraAcciones.Text = "ConsultarFacturas";
            ValidarToolStrip(new object[] { BarraAcciones });
        }
        private void ValidarToolStrip(object[] toolStrips)
        {
            foreach (ToolStrip toolStrip in toolStrips)
            {
                foreach (var item in toolStrip.Items)
                {
                    System.Reflection.PropertyInfo caption = item.GetType().GetProperty("Text");
                    if (caption.GetValue(item, null) != null)
                    {
                        string Texto = string.Format("[{0}.{1}]", toolStrip.Text, caption.GetValue(item, null));
                        if (OK.usuario.disabled.Contains(Texto))
                        {
                            ((ToolStripItem)item).Visible = false;
                        }
                    }
                }
            }
        }
        void FrmFacturas_Load(object sender, EventArgs e)
        {
            Busqueda();
            Buscar.Click += new EventHandler(Buscar_Click);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            VerFactura.Click += new EventHandler(VerFactura_Click);
            Eliminar.Click += new EventHandler(Eliminar_Click);
            txtBuscar.KeyDown += new KeyEventHandler(txtBuscar_KeyDown);
            Duplicar.Click += new EventHandler(Duplicar_Click);
            btnMail.Click += new EventHandler(btnMail_Click);
            btnReporteFacturas.Click += new EventHandler(btnReporteFacturas_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            gridView1.OptionsLayout.Columns.Reset();
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
        }

        void btnMail_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Administrativo_Facturas(Lista, txtFiltro.Text, true);
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        void btnReporteFacturas_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Administrativo_Facturas(Lista, txtFiltro.Text, false);
        }
        void VerFactura_Click(object sender, EventArgs e)
        {
            if (this.bs.Current == null)
                return;
            Factura documento = (Factura)this.bs.Current;
            FrmConsultarFacturasItem f = new FrmConsultarFacturasItem() { IdDocumento = documento.ID };
            f.Ver();
        }
        private void Busqueda()
        {
            var consulta = data.GetQueryableFacturas();
            switch (txtFiltro.Text)
            {
                case "HOY":
                    consulta = (from x in consulta
                               where x.Fecha==DateTime.Today
                              select x);
                    break;
                case "AYER":
                    consulta = (from x in consulta
                                where x.Fecha == DateTime.Today.AddDays(-1)
                                select x);
                    break;
                case "ESTE MES":
                    consulta = (from x in consulta
                                where x.Fecha.Month == DateTime.Today.Month
                                && x.Fecha.Year== DateTime.Today.Year
                                select x);
                    break;
                case "TODAS":
                    break;

            }
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
               consulta = (from x in consulta
                            where x.RazonSocial.Contains(txtBuscar.Text) 
                           select x);
            }
            switch ( txtBuscar.Text )
            {
                case "TICKET":
                    Lista = (from x in consulta
                             where x.Tipo == "TICKET"
                             select x).ToArray();
                    break;
                case "TODOS":
                    break;
                default:
                    Lista = (from x in consulta
                             where x.Tipo == "FACTURA" 
                             select x).ToArray();
                    break;
            }
            foreach (var item in Lista)
            {
                var pago = item.Pagos.FirstOrDefault();
                if (pago != null)
                {
                    item.Efectivo = pago.Efectivo;
                    item.TarjetaCredito = pago.TarjetaCredito;
                    item.TarjetaDebito = pago.TarjetaDebito;
                    item.Credito = pago.Credito;
                    item.Cheque = pago.Cheque;
                }
            }
            this.bs.DataSource = Lista;
            this.bs.ResetBindings(true);
        }
        private void DuplicarRegistro()
        {
            if (this.bs.Current == null)
                return;
            Factura documento = (Factura)this.bs.Current;
            try
            {
                IFiscal Fiscal = new Fiscales.FiscalWindows("");
                Fiscal.ImprimeFacturaCopia(documento);
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
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
            Fiscal.ImprimeNotaCredito(devolucion, pago);
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
                    case Keys.Return:
                        VerFactura.PerformClick();
                        break;
                    case Keys.Delete:
                        Eliminar.PerformClick();
                        break;
                    case Keys.Subtract:
                        Eliminar.PerformClick();
                        break;
                    case Keys.P:
                        Duplicar.PerformClick();
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
        private void Duplicar_Click(object sender, EventArgs e)
        {
            DuplicarRegistro();
        }
        #endregion
    }
}
