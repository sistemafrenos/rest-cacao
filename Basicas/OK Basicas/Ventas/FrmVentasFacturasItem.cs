using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.Fiscales;

namespace HK.Formas
{

    public partial class FrmVentasFacturasItem : Form
    {
        private string estado = null;
        public object frmPadre = null;
        public string IdFactura { set; get; }
        public Administrativo data;
        Factura factura;
        Pago pago;
        public FrmVentasFacturasItem()
        {
            InitializeComponent();
            this.KeyPreview = true;
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmNotasEntregasItem_Load);
        }
        void FrmNotasEntregasItem_Load(object sender, EventArgs e)
        {
            #region ManejoGrid
            if (estado !="VER")
            {
                this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
                this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            }
            //gridControl1.ForceInitialize();
            //gridView1.OptionsLayout.Columns.Reset();
            //if (System.IO.File.Exists(string.Format(Application.StartupPath + "\\Layouts\\NotasEntregasItem{0}.XML", OK.SystemParameters.Empresa)))
            //{
            //    this.gridControl1.DefaultView.RestoreLayoutFromXml(string.Format(Application.StartupPath + "\\Layouts\\NotasEntregasItem{0}.XML", OK.SystemParameters.Empresa), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            //else
            //{
            //    this.gridControl1.DefaultView.RestoreLayoutFromXml(Application.StartupPath + "\\Layouts\\NotasEntregasItem.XML", DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            #endregion
            #region Eventos
            if (estado != "VER")
            {
                this.Email.Click += new EventHandler(Email_Click);
                this.Imprimir.Click += new EventHandler(Imprimir_Click);
                this.CedulaRifButtonEdit.Validating += new CancelEventHandler(CedulaRifButtonEdit_Validating);
                this.CedulaRifButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CedulaRifButtonEdit_ButtonClick);
                this.CedulaRifButtonEdit.Properties.ValidateOnEnterKey = true;
                this.globalBolivares.Validating += new CancelEventHandler(globalBolivares_Validating);
                this.btnSeniat.Click += new EventHandler(btnSeniat_Click);
                this.btnAgregar.Click += new EventHandler(btnAgregar_Click);
                this.Aceptar.Click += new EventHandler(Aceptar_Click);
                this.btnActualizarPrecios.Click += new EventHandler(ActualizarPrecios_Click);
                this.CargarDoc.Click += new EventHandler(CargarDoc_Click);
                this.txtVendedor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtVendedor_ButtonClick);
                this.txtVendedor.Validating += new CancelEventHandler(txtVendedor_Validating);
                this.DejarEspera.Click += new EventHandler(DejarEspera_Click);
                this.RecuperarEspera.Click += new EventHandler(RecuperarEspera_Click);
            }
            else
            {
                this.btnAgregar.Enabled = false;
                this.btnActualizarPrecios.Enabled = false;
                this.DejarEspera.Enabled = false;
                this.RecuperarEspera.Enabled = false;
                this.CargarDoc.Enabled = false;
                this.Aceptar.Enabled = false;
            }
            this.KeyDown += new KeyEventHandler(FrmCotizacionItem_KeyDown);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            #endregion
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.CenterToScreen();
        }

        void RecuperarEspera_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarAbiertas();
            if (f.registro != null)
            {
                factura = data.FindFactura(((Factura)f.registro).ID);
                Enlazar();
            }
        }
        void DejarEspera_Click(object sender, EventArgs e)
        {
            facturaBindingSource.EndEdit();
            factura.Totalizar();
            factura.Tipo = "FACTURA ABIERTA";
            string result = data.ValidarDocumento(factura);
            if (result != null)
            {
                MessageBox.Show(result, "Atencion", MessageBoxButtons.OK);
                return;
            }
            data.GuardarFactura(factura, "FACTURA ABIERTA", true);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(Basicas.CedulaRif(CedulaRifButtonEdit.Text));
            if (Empresa != null)
            {
                factura.CedulaRif = Basicas.CedulaRif(CedulaRifButtonEdit.Text);
                factura.RazonSocial = Empresa;
                this.facturaBindingSource.ResetCurrentItem();
            }
        }
        void ActualizarPrecios_Click(object sender, EventArgs e)
        {
            data.ActualizarPrecios(factura);
            Enlazar();
        }
        void Imprimir_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Factura(factura, false);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        void Email_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Factura(factura, true);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        void FrmCotizacionItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (estado != "VER")
                    {
                        btnAgregar.PerformClick();
                    }
                    break;
                case Keys.Escape:
                    if (this.Aceptar.Enabled == true && factura.MontoTotal.GetValueOrDefault(0) > 0)
                    {
                        if (MessageBox.Show("Esta seguro de salir", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Cancelar.PerformClick();
                            e.Handled = true;
                        }
                    }
                    else
                    {
                        Cancelar.PerformClick();
                        e.Handled = true;
                    }
                    break;
                case Keys.F12:
                    if (estado != "VER")
                    {
                        this.Aceptar.PerformClick();
                        e.Handled = true;
                    }
                    break;
            }
        }
        void btnAgregar_Click(object sender, EventArgs e)
        {
            do
            {
                FrmVentasItemEdicion f = new FrmVentasItemEdicion() { tipoPrecio = factura.TipoPrecio };
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                factura.DocumentosProductos.Add(f.registroDetalle);
                this.notaEntregaProductoBindingSource.DataSource = factura.DocumentosProductos.ToList();
                this.notaEntregaProductoBindingSource.ResetBindings(true);
                factura.Calcular();
                this.facturaBindingSource.ResetCurrentItem();
            }
            while (true);
        }
        #region Vendedores

        void txtVendedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarVendedores("");
            LeerVendedor((Vendedor)F.registro);
        }
        void txtVendedor_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.facturaBindingSource.EndEdit();
            Vendedor[] T = data.GetAllVendedores(txtVendedor.Text);
            switch (T.Length)
            {
                case 0:
                    LeerVendedor(null);
                    break;
                case 1:
                    LeerVendedor(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarVendedores(Texto);
                    LeerVendedor((Vendedor)F.registro);
                    break;
            }
        }
        private void LeerVendedor(Vendedor vendedor)
        {
            if (vendedor == null)
                vendedor = new Vendedor();
            factura.CodigoVendedor = vendedor.Codigo;
            factura.Vendedor = vendedor.Nombre;
            this.facturaBindingSource.ResetCurrentItem();
        }

        #endregion
        #region Clientes
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            if (F.registro != null)
            {
                Leercliente((Tercero)F.registro);
                this.facturaBindingSource.ResetCurrentItem();
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.facturaBindingSource.EndEdit();
            Tercero[] T = data.GetAllClientes(Texto);
            switch (T.Length)
            {
                case 0:
                    factura.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    factura.RazonSocial = "";
                    factura.Direccion = OK.SystemParameters.Ciudad;
                    factura.TipoPrecio = "PRECIO 1";
                    break;
                case 1:
                    Leercliente(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarClientes(Texto);
                    if (F.registro != null)
                    {
                        Leercliente((Tercero)F.registro);
                    }
                    break;
            }
            this.facturaBindingSource.ResetCurrentItem();
        }
        private void Leercliente(Tercero cliente)
        {
            if (cliente != null)
            {
                factura.CedulaRif = Basicas.CedulaRif(cliente.CedulaRif);
                factura.RazonSocial = cliente.RazonSocial;
                factura.Direccion = string.IsNullOrEmpty(cliente.Direccion) ? OK.SystemParameters.Ciudad : cliente.Direccion;
                factura.Email = cliente.Email;
                factura.Telefonos = cliente.Telefonos;
                factura.TipoPrecio = cliente.TipoPrecio == null ? "PRECIO 1" : cliente.TipoPrecio;
            }
        }
        #endregion
        private void Limpiar()
        {
            factura = new Factura();
            pago = new Pago();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Ver()
        {
            estado = "VER";
            factura = data.FindFactura(IdFactura);
            Enlazar();
            Encabezado.Enabled = false;
            this.ShowDialog();
        }
        public void Modificar()
        {
            factura = data.FindFactura(IdFactura);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {

            this.facturaBindingSource.DataSource = factura;
            this.facturaBindingSource.ResetBindings(true);
            this.notaEntregaProductoBindingSource.DataSource = factura.DocumentosProductos.ToList();
            this.notaEntregaProductoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        void CargarDoc_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarFacturas("");
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            factura = data.CloneDocumento((Factura)f.registro);
            factura.Fecha = DateTime.Today;
            factura.Hora = DateTime.Now;
            Enlazar();
        }
        void btnRecuperar_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarFacturas("CERRADA");
            if (f.registro != null)
            {
                factura = data.FindFactura(((Factura)f.registro).ID);
                Enlazar();
            }
        }
        private bool Guardar()
        {
            if (factura.Estatus == "CERRADO")
                return true;
            facturaBindingSource.EndEdit();
            factura.Totalizar();
            factura.Tipo = "FACTURA";
            Tercero cliente = new Tercero();
            Pago pago = new Pago();
            factura.Totalizar();
            pago.MontoPagar = factura.MontoTotal;
            FrmPuntoDeVentasPagar f = new FrmPuntoDeVentasPagar() 
            { 
               cliente = cliente ,
                pago = this.pago
            };
            f.ShowDialog();
            factura.CedulaRif = f.cliente.CedulaRif;
            factura.RazonSocial = f.cliente.RazonSocial;
            factura.Direccion = f.cliente.Direccion;
            pago = f.pago;
            this.facturaBindingSource.ResetCurrentItem();
            Application.DoEvents();
            string result = data.ValidarDocumento(factura);
            if (result != null)
            {
                MessageBox.Show(result, "Atencion", MessageBoxButtons.OK);
                return false;
            }
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return false;
            if (pago.Cambio > 0)
                MessageBox.Show(string.Format("El Cambio es:\n {0}", factura.MontoTotal - pago.MontoPagado), "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (pago.Credito > 0)
            {
                factura.Saldo = pago.Credito;
            }
            try
            {
                if (factura.Tipo == "FACTURA")
                {
                    using (IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal())
                    {
                        Fiscal.ImprimeFactura(factura, pago);
                        Fiscal.CerrarPuerto();
                    }
                }
                if (data.PuntoVentaConfig.ImpresoraOrdenDespacho != "NINGUNA")
                {
                    if (data.PuntoVentaConfig.PedirNumeroOrden)
                    {
                        FrmPedirNumeroOrden orden = new FrmPedirNumeroOrden();
                        orden.cambio = pago.Cambio.GetValueOrDefault(0);
                        orden.ShowDialog();
                        factura.NumeroOrden = orden.numeroOrden;
                    }
                    using (IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal(data.PuntoVentaConfig.ImpresoraOrdenDespacho))
                    {
                        Fiscal.ImprimeOrdenDespacho(factura);
                        Fiscal.CerrarPuerto();
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(OK.ManejarException(x), "Error al imprimir factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string retorno = data.ProcesarFactura(factura,pago, true);
            if (retorno != null)
            {
                MessageBox.Show(retorno);
                return false;
            }
            Limpiar();
            Enlazar();
            return true;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.facturaBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        void globalBolivares_Validating(object sender, CancelEventArgs e)
        {
            this.facturaBindingSource.EndEdit();
            factura.Calcular();
            this.facturaBindingSource.ResetCurrentItem();
        }
        #region ManejoDocumentoProductos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                EditarItem();
            }

            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Back)
                {
                    if (this.gridView1.IsFocusedView)
                    {
                        DocumentosProducto i = (DocumentosProducto)this.notaEntregaProductoBindingSource.Current;
                        factura.DocumentosProductos.Remove(i);
                        this.notaEntregaProductoBindingSource.DataSource = factura.DocumentosProductos.ToList();
                        this.notaEntregaProductoBindingSource.ResetBindings(true);
                        factura.Calcular();
                        this.facturaBindingSource.ResetCurrentItem();
                    }
                    e.Handled = true;
                }
            }

        }
        private void EditarItem()
        {
            DocumentosProducto detalle = (DocumentosProducto)this.notaEntregaProductoBindingSource.Current;
            if (detalle == null)
                return;
            FrmVentasItemEdicion f = new FrmVentasItemEdicion() { registroDetalle = detalle, tipoPrecio= factura.TipoPrecio };
            f.Modificar();
            factura.Calcular();
            this.facturaBindingSource.ResetCurrentItem();
        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DocumentosProducto item = (DocumentosProducto)this.notaEntregaProductoBindingSource.Current;
            if (item == null)
                btnAgregar.PerformClick();
            else
                EditarItem();
        }
        #endregion
        internal void CargarCotizacion(Cotizacion cotizacion)
        {
            factura = data.CrearFactura(cotizacion);
            Enlazar();
            this.ShowDialog();
        }
        internal void CargarNotaEntrega(NotaEntrega notasEntrega)
        {
            factura = data.CrearFactura(notasEntrega);
            Enlazar();
            this.ShowDialog();
        }
    }
}

