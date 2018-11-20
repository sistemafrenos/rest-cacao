using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmCuentasxPagarDetalles : Form
    {
        public string IdProveedor;
        TercerosMovimiento[] lista;
        Administrativo data;
        Tercero proveedor;
        Compra compra;
        public FrmCuentasxPagarDetalles()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            proveedor = new Tercero();
            this.Load += new EventHandler(FrmCuentasxPagarDetalles_Load);
        }
        void btnAplicarProntoPago_Click(object sender, EventArgs e)
        {
            FrmCuentasxPagarAplicarProntoPago f = new FrmCuentasxPagarAplicarProntoPago();
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            //compras.Load(movimiento.DocumentoID);
            //if (compra.ID == null)
            //{
            //    MessageBox.Show("Este movimiento no es una compra registrada", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (movimiento.DescuentoProntoPago.GetValueOrDefault(0) <= 0)
            {
                MessageBox.Show("Esta factura no tiene descuento pronto pago", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            f.registro = movimiento;
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Busqueda();
        }
        void FrmCuentasxPagarDetalles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }
        void FrmCuentasxPagarDetalles_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            this.KeyDown += new KeyEventHandler(FrmCuentasxPagarDetalles_KeyDown);
            this.btnRegistrarPagos.Click += new EventHandler(btnRegistrarPagos_Click);
            this.btnAplicarProntoPago.Click += new EventHandler(btnAplicarProntoPago_Click);
            this.btnVerDocumento.Click += new EventHandler(btnVerDocumento_Click);
            this.gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
            this.btnAnular.Click += new EventHandler(btnAnular_Click);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
            Basicas.AsegurarToolStrip(new object[] { BarraAcciones });
            Busqueda();
        }
        void btnAnular_Click(object sender, EventArgs e)
        {
            if (this.gridView1.IsFocusedView)
            {
                TercerosMovimiento Registro = (TercerosMovimiento)this.bs.Current;
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
        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            PagarHoy();
        }
        private void PagarHoy()
        {
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            movimiento.PagarHoy = movimiento.Saldo;
            this.bs.ResetCurrentItem();
        }

        void btnRegistrarPagos_Click(object sender, EventArgs e)
        {
            this.bs.EndEdit();
            FrmCuentasxPagarRegistrarPago f = new FrmCuentasxPagarRegistrarPago();
            List<TercerosMovimiento> pagarHoy = lista.Where(x => x.PagarHoy > 0).ToList();
            TercerosMovimiento movimiento = new TercerosMovimiento();
            movimiento.PagarHoy = 0;
            movimiento.Concepto = "Pago/Abono Fact  ";
            foreach (var item in pagarHoy)
            {
                if (item.PagarHoy > item.Saldo)
                    item.PagarHoy = item.Saldo;
                movimiento.PagarHoy += item.PagarHoy.Value;
                movimiento.Concepto += "#" + item.Numero;
            }
            if (movimiento.PagarHoy == 0)
            {
                MessageBox.Show("Debe Escribir el monto a pagar hoy");
                return;
            }
            movimiento.Fecha = DateTime.Today;
            movimiento.Cuenta = pagarHoy.ElementAt(0).Cuenta;
            movimiento.DescripcionCuenta = pagarHoy.ElementAt(0).DescripcionCuenta;
            movimiento.Credito = movimiento.PagarHoy;
            movimiento.Tipo = "PAGO";
            f.movimiento = movimiento;
            f.RegistrarPago();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in lista)
                {

                    if (item.PagarHoy.GetValueOrDefault(0) > 0)
                    {
                        item.Saldo = item.Saldo.GetValueOrDefault(0) - item.PagarHoy.GetValueOrDefault(0);
                        if (item.Saldo < 0)
                        {
                            item.Saldo = 0;
                        }
                    }
                }
                //movimiento.Numero = FactoryContadores.GetContador("PagoProveedor");
                //movimiento.AsignarID();
                //if (movimiento.FormaDePago == "CHEQUE" || movimiento.FormaDePago == "TARJETA DB" || movimiento.FormaDePago == "TRANSFERENCIA" || movimiento.FormaDePago == "LOTE TRANSFERENCIA")
                //{
                //    FactoryBancos.RegistrarPago(movimiento);
                //}
                //db.TercerosMovimientos.Add(movimiento);
                //foreach (var item in pagarHoy)
                //{
                //    item.Saldo = item.Saldo.GetValueOrDefault(0) - item.PagarHoy.GetValueOrDefault(0);
                //    if (item.Saldo < 0)
                //        item.Saldo = 0;
                //}
                //try
                //{
                //    db.SaveChanges();
                //}
                //catch (Exception x)
                //{
                //    Basicas.ManejarError(x);
                //}
                this.Close();
            }
        }
        void btnVerDocumento_Click(object sender, EventArgs e)
        {
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            if (movimiento.Tipo == "COMPRA")
            {
                compra = data.FindCompra(movimiento.DocumentoID);
                if (compra.DocumentosProductos.Count > 0)
                {
                    FrmComprasItem f = new FrmComprasItem();
                    f.ID = compra.ID;
                    f.Ver();
                }
                else
                {
                    FrmComprasItemGasto f = new FrmComprasItemGasto();
                    f.IdDocumento = compra.ID;
                    f.Ver();
                }
            }
        }
        private void Busqueda()
        {
            lista = data.GetCxPProveedor( proveedor);
            foreach (var item in lista)
            {
                item.PagarHoy = null;
            }
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
            this.txtNombreProveedor.Text = proveedor.RazonSocial;
            this.gridView1.BestFitColumns();
        }
    }
}
