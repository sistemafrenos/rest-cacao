using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmCuentasxCobrarMovimientos : Form
    {
        public Tercero cliente = new Tercero();
        private TercerosMovimiento[] lista;
        Administrativo data;
        public FrmCuentasxCobrarMovimientos()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmCuentasxCobrarMovimientos_Load);
        }
        void FrmCuentasxCobrarMovimientos_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmCuentasxCobrarMovimientos_KeyDown);
            this.desde.DateTime = DateTime.Today.AddDays(-30);
            this.hasta.DateTime = DateTime.Today;
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnVer.Click += new EventHandler(btnVer_Click);
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.comboBoxClientes.Properties.Items.Add(cliente.RazonSocial);
            this.comboBoxClientes.Properties.Items.Add("TODOS");
            this.comboBoxClientes.Text = cliente.RazonSocial;
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxC_ReporteCuentasxCobrarMovimientos(cliente, lista);
        }
        void FrmCuentasxCobrarMovimientos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.btnCancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Return:
                    if (this.gridControl1.Focused)
                    {
                        this.btnVer.PerformClick();
                        e.Handled = true;
                    }
                    break;
            }
        }
        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void btnVer_Click(object sender, EventArgs e)
        {
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            //using (var db = new DatosEntities(OK.CadenaConexion))
            //{
            //    switch (movimiento.Tipo)
            //    {
            //        case "FACTURA":
            //            FrmConsultarFacturasItem f = new FrmConsultarFacturasItem() { IdDocumento = movimiento.IdDocumento };
            //            f.Ver();
            //            break;
            //        case "NOTA CREDITO":
            //            FrmNotaCreditoCliente nota = new FrmNotaCreditoCliente();
            //            nota.IdDocumento = movimiento.IdDocumento;
            //            nota.Ver();
            //            break;
            //        case "NOTA DEBITO":
            //            FrmNotaDebitoCliente notaDebito = new FrmNotaDebitoCliente();
            //            notaDebito.IdDocumento = movimiento.IdDocumento;
            //            notaDebito.Ver();
            //            break;
            //        case "RETENCION IVA":
            //            FrmRetencionIvaCliente retencion = new FrmRetencionIvaCliente();
            //            retencion.IdDocumento = movimiento.IdDocumento;
            //            retencion.Ver();
            //            break;
            //        case "PAGO":
            //            if (movimiento != null)
            //            {
            //                BussinesLogic.Cajas cajas = new BussinesLogic.Cajas();
            //                cajas.Load(movimiento.IdCaja);
            //                cajas.current.Numero = movimiento.Numero;
            //                Fiscales.Fiscal fiscal = new Fiscales.Fiscal();
            //                fiscal.ImprimirReciboCobro(cajas.current);
            //            }
            //            break;
            //    }
            //}
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            lista = data.ClienteMovimientosxLapso(cliente,this.desde.DateTime, this.hasta.DateTime,comboBoxClientes.Text);
            if (!string.IsNullOrEmpty(txtBuscar.Text))
            {
                lista = lista.Where(x => x.Comentarios != null).ToArray();
                lista = lista.Where(x => x.Comentarios.Contains(txtBuscar.Text)).ToArray();
            }
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
        }
    }
}

