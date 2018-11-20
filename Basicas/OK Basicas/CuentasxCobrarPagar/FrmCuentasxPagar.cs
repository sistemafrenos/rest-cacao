using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmCuentasxPagar : Form
    {
        Administrativo data;
        Tercero[] lista;
        public FrmCuentasxPagar()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmCuentasxPagar_Load);
            BarraAcciones.Text = "CuentasxPagar";
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
        }
        void FrmCuentasxPagar_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.btnMovimientos.Click += new EventHandler(btnMovimientos_Click);
            this.btnActualizarSaldos.Click += new EventHandler(btnActualizarSaldos_Click);
            this.btnEstadoDeCuenta.Click += new EventHandler(btnEstadoDeCuenta_Click);
            this.btnResumenCxP.Click += new EventHandler(btnResumenCxP_Click);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            data = new Administrativo();
            Busqueda();
        }

        void btnResumenCxP_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.CxP_Resumen();
        }
        void btnEstadoDeCuenta_Click(object sender, EventArgs e)
        {
            Tercero proveedor = (Tercero)this.bs.Current;
            if (proveedor == null)
                return;
            FrmReportes f = new FrmReportes();
            f.EstadoDeCuentaProveedor(proveedor, false);
        }
        void btnActualizarSaldos_Click(object sender, EventArgs e)
        {
            // Pendiente Actualizar saldos
            Busqueda();
        }

        void btnMovimientos_Click(object sender, EventArgs e)
        {
            FrmCuentasxPagarMovimientos f = new FrmCuentasxPagarMovimientos();
            Tercero proveedor = (Tercero)this.bs.Current;
            if (proveedor == null)
                return;
            f.proveedor = proveedor;
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
                    lista = data.GetAllProveedores(txtBuscar.Text);
                    break;
                default:
                    lista = data.GetAllProveedores(txtBuscar.Text);
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
            Tercero proveedor = (Tercero)this.bs.Current;
            if (proveedor == null)
                return;
            FrmCuentasxPagarDetalles f = new FrmCuentasxPagarDetalles();
            f.IdProveedor = proveedor.ID;
            f.ShowDialog();
            proveedor = data.FindProveedor(proveedor.ID);
            proveedor.FacturasPendientes = proveedor.TercerosMovimientos.Where(x => x.Saldo > 0).Count();
            proveedor.SaldoPendiente = proveedor.TercerosMovimientos.Where(x => x.Saldo > 0).Sum(x => x.Saldo);
            Busqueda();
        }
    }
}
