using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmCuentasxCobrar : Form
    {
        Administrativo data = new Administrativo();
        Tercero[] lista;
        public FrmCuentasxCobrar()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCuentasxCobrar_Load);
            BarraAcciones.Text = "CuentasxCobrar";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmCuentasxCobrar_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnMovimientos.Click += new EventHandler(btnMovimientos_Click);
            this.btnActualizarSaldos.Click += new EventHandler(btnActualizarSaldos_Click);
            this.btnEstadoDeCuenta.Click += new EventHandler(btnEstadoDeCuenta_Click);
            this.btnDetallesyPago.Click += new EventHandler(btnDetallesyPago_Click);
            this.btnResumenCxC.Click += new EventHandler(btnResumenCxC_Click);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
            this.CenterToScreen();
            DoActualizar();
            Busqueda();
        }

        void btnDetallesyPago_Click(object sender, EventArgs e)
        {
            EditarRegistro();
        }
        void btnResumenCxC_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxC_ResumenCuentasxCobrar();
        }
        void btnEstadoDeCuenta_Click(object sender, EventArgs e)
        {
            Tercero cliente = (Tercero)this.bs.Current;
            if (cliente == null)
                return;
            FrmReportes f = new FrmReportes();
            f.CxC_EstadoDeCuentaTercero(cliente, false);
        }
        void btnActualizarSaldos_Click(object sender, EventArgs e)
        {
            DoActualizar();
            Busqueda();
        }

        private void DoActualizar()
        {
            this.Cursor = Cursors.WaitCursor;
            this.btnActualizarSaldos.Text = "Actualizando...!";
            Application.DoEvents();
            object result = Jacksonsoft.WaitWindow.Show(this.WorkerMethod, "Actualizando Saldos de Clientes");
            this.Cursor = Cursors.Default;
            this.btnActualizarSaldos.Text = "Actualizar Saldos";
            data.GuardarCambios();
        }
        private void WorkerMethod(object sender, Jacksonsoft.WaitWindowEventArgs e)
        {
            if (lista == null)
               lista = data.GetAllClientes(txtBuscar.Text);
            var items = lista;
            foreach (var item in items)
            {
                if (item.TercerosMovimientos.Count() > 0)
                {
                    data.ClienteActualizarSaldos(item);
                }
                else
                {
                    item.SaldoPendiente = 0;
                    item.FacturasPendientes = 0;
                }
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
        void btnMovimientos_Click(object sender, EventArgs e)
        {
            FrmCuentasxCobrarMovimientos f = new FrmCuentasxCobrarMovimientos();
            Tercero cliente = (Tercero)this.bs.Current;
            if (cliente == null)
                return;
            f.cliente = cliente;
            f.ShowDialog();
        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            EditarRegistro();
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }
        private void Busqueda()
        {
            switch (txtFiltro.Text.ToUpper())
            {
                case "CON SALDO PENDIENTE":
                    lista = data.GetAllClientes(txtBuscar.Text).Where(x => x.SaldoPendiente > 0).ToArray();
                    break;
                default:
                    lista = data.GetAllClientes(txtBuscar.Text);
                    break;
            }
            Enlazar();
            this.gridView1.BestFitColumns();
        }
        private void Enlazar()
        {
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Return)
                {
                    EditarRegistro();
                    e.Handled = true;
                }
            }
        }
        private void EditarRegistro()
        {
            Tercero cliente = (Tercero)this.bs.Current;
            if (cliente == null)
                return;
            FrmCuentasxCobrarDetalles f = new FrmCuentasxCobrarDetalles() { IdTercero = cliente.ID, data = data };
            f.ShowDialog();
            cliente = data.FindCliente(cliente.ID);
            cliente.FacturasPendientes = cliente.TercerosMovimientos.Where(x => (x.Saldo > 0) && (x.Tipo == "FACTURA" || x.Tipo == "NOTA DEBITO") ).Count();
            cliente.SaldoPendiente = cliente.TercerosMovimientos.Where(x => (x.Saldo > 0) && (x.Tipo == "FACTURA" || x.Tipo == "NOTA DEBITO")).Sum(x => x.Saldo);
            Busqueda();
        }
    }
}
