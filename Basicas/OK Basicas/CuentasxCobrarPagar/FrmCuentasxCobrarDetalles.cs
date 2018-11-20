using HK.BussinessLogic;
using HK.Fiscales;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmCuentasxCobrarDetalles : Form
    {
        public string IdTercero;
        Tercero Cliente;
        TercerosMovimiento[] lista;
        public Administrativo data;
        public FrmCuentasxCobrarDetalles()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmCuentasxCobrarDetalles_Load);
        }
        void FrmCuentasxCobrarDetalles_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }
        void FrmCuentasxCobrarDetalles_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmCuentasxCobrarDetalles_KeyDown);
            this.btnRegistrarPagos.Click += new EventHandler(btnRegistrarPagos_Click);
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
            Busqueda();
            this.CenterToScreen();
        }

        void btnRegistrarPagos_Click(object sender, EventArgs e)
        {
            Factura factura = new Factura();
            this.bs.EndEdit();
            double montoCobrar = 0;
            string concepto = "CH PAGO/ABONO FACT";
            foreach (var item in lista)
            {

                if (item.PagarHoy.GetValueOrDefault(0) > 0)
                {
                    if (item.PagarHoy > item.Saldo)
                        item.PagarHoy = item.Saldo;
                    montoCobrar += item.PagarHoy.Value;
                    concepto += "#" + item.Numero;
                }
            }
            if (montoCobrar == 0)
            {
                MessageBox.Show("Debe Escribir el monto a pagar hoy");
                return;
            }
            factura.MontoTotal = montoCobrar;
            factura.Comentarios = concepto;
            Pago caja = new Pago() { Fecha = DateTime.Today, MontoPagar = montoCobrar };
            FrmAdministrativoPagar pago = new FrmAdministrativoPagar()
            { fechaHabilitada = true, creditoHabilitado = false, caja = caja };
            pago.Pagar();
            caja = pago.caja;
            int facturasPagar = 0;
            if (pago.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                foreach (var item in lista)
                {

                    if (item.PagarHoy.GetValueOrDefault(0) > 0)
                    {
                        facturasPagar++;
                        if (facturasPagar == 1)
                        {
                            caja.Numero = item.Numero;
                        }
                        item.Saldo = item.Saldo.GetValueOrDefault(0) - item.PagarHoy.GetValueOrDefault(0);
                        if (item.Saldo < 0)
                        {
                            item.Saldo = 0;
                        }
                    }
                }
                IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
                TercerosMovimiento recibo = new TercerosMovimiento() { 
                    Comentarios = caja.Detalles(), Concepto = concepto, Credito = montoCobrar, Fecha = caja.Fecha 
                    };
                recibo.Saldo = null;
                recibo.Tipo = "PAGO";
                recibo.CodigoVendedor =
                recibo.Vendedor = Cliente.Vendedor;
                recibo.CajaID = caja.ID;
                recibo.Tercero = Cliente;
                caja.TipoDocumento = "CXC";
                caja.Hora = DateTime.Now;
                caja.Tipo = "COBRO";
                caja.Concepto = String.Format("{0}\n{1}", recibo.Concepto, recibo.Comentarios);
                caja.Numero = recibo.Numero;
                data.GuardarCambios();
                this.Close();
            }
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
                    Cliente.TercerosMovimientos.Remove(Registro);
                    data.GuardarCambios();
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
            if (movimiento.Tipo == "FACTURA" || movimiento.Tipo == "NOTA DEBITO")
            {
                movimiento.PagarHoy = movimiento.Saldo;
                this.bs.ResetCurrentItem();
            }
        }

        void btnVerDocumento_Click(object sender, EventArgs e)
        {
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            switch (movimiento.Tipo)
            {
                case "FACTURA":
                    FrmConsultarFacturasItem f = new FrmConsultarFacturasItem()
                    { IdDocumento = movimiento.DocumentoID };
                    f.Ver();
                    break;
                case "NOTA CREDITO":
                    FrmNotaCreditoCliente nota = new FrmNotaCreditoCliente();
                    nota.IdDocumento = movimiento.DocumentoID;
                    nota.Ver();
                    break;
                case "NOTA DEBITO":
                    FrmNotaCreditoCliente notaDebito = new FrmNotaCreditoCliente();
                    notaDebito.IdDocumento = movimiento.DocumentoID;
                    notaDebito.Ver();
                    break;
                case "RETENCION IVA":
                    FrmRetencionIvaCliente retencion = new FrmRetencionIvaCliente();
                    retencion.IdDocumento = movimiento.DocumentoID;
                    retencion.Ver();
                    break;
            }
        }
        private void Busqueda()
        {
            Cliente = data.FindCliente(IdTercero);
            lista = data.ClienteDocumentosPendientes(Cliente);
            foreach (var item in lista)
            {
                item.PagarHoy = null;
            }
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
            this.txtNombreProveedor.Text = Cliente.RazonSocial;
            this.gridView1.BestFitColumns();
        }
    }
}

