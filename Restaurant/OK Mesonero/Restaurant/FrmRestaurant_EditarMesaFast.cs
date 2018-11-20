using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;
using HK.Fiscales;
using HK.Formas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK
{
    public partial class FrmRestaurant_EditarMesaFast : Form
    {
        private bool esProductos = false;
        private double cantidad;
        private Producto[] productoCache;
        private List<Button> cantidades = new List<Button>();
        private Pago pago;
        private Restaurant data;
        private MesasAbierta mesaAbierta;
        private Usuario usuarioTemporal;
        private Producto grupo;
        private MesasAbiertasProducto ultimoProducto;
        public FrmRestaurant_EditarMesaFast()
        {
            InitializeComponent();
            Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Editar(string mesaCodigo, Producto[] productoCache) {
            cantidad = 1;
            
            pago = new Pago();
            data = new Restaurant();
            this.productoCache = productoCache;
            mesaAbierta = data.GetByCodigoMesaAbierta(mesaCodigo);
            mesaAbierta.Totalizar();
            txtMesa.Text = mesaAbierta.CodigoMesa;
            usuarioTemporal = OK.DeepCopy(OK.usuario);
            mesasAbiertaBindingSource.DataSource = mesaAbierta;
            mesasAbiertaBindingSource.ResetCurrentItem();
            mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x => x.Anulado != true).ToList();
            mesasAbiertasProductoBindingSource.ResetBindings(false);
            Application.DoEvents();
            cantidades.AddRange(new Button[] { cantidad0, cantidad1, cantidad2, cantidad3, cantidad4 });
            foreach (Button b in cantidades)
            {
                b.Click += new EventHandler(cantidad_Click);
            }
            cantidad5.Click += cantidad5_Click;
            btnSeniat.Click += btnSeniat_Click;
            CargarGrupos();
            this.layoutProductos.Click += layoutProductos_Click;
            if (data.RestaurantConfig.PedirMesonero)
            {
                using (var x = new FrmRestaurant_PedirMesonero())
                {
                    x.ShowDialog();
                    if (x.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        mesaAbierta.MesoneroID = x.mesonero.ID;
                        mesaAbierta.Mesonero = x.mesonero.Nombre;
                    }
                    else
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        return;
                    }
                    usuarioTemporal.PuedeAnularMesa = x.mesonero.PuedeAnularMesa;
                    usuarioTemporal.PuedeCambiarMesa = x.mesonero.PuedeCambiarMesa;
                    usuarioTemporal.PuedeCambiarPrecios = x.mesonero.PuedeCambiarPrecios;
                    usuarioTemporal.PuedeDarConsumoInterno = x.mesonero.PuedeDarConsumoInterno;
                    usuarioTemporal.PuedeDarCreditos = x.mesonero.PuedeDarCreditos;
                    usuarioTemporal.PuedeDividirCuentas = x.mesonero.PuedeDividirCuentas;
                    usuarioTemporal.PuedeLiberarMesa = x.mesonero.PuedeLiberarMesa;
                    usuarioTemporal.PuedePedirCorteDeCuenta = x.mesonero.PuedePedirCorteDeCuenta;
                    usuarioTemporal.PuedeRegistrarPago = x.mesonero.PuedeRegistrarPago;
                    usuarioTemporal.PuedeSepararCuentas = x.mesonero.PuedeSepararCuentas;
                    usuarioTemporal.PuedeEliminarPlatos = x.mesonero.AnularPlatos.GetValueOrDefault();
                    
                }
            }
            btnLiberar.Visible = usuarioTemporal.PuedeLiberarMesa.GetValueOrDefault(false);
            btnCambioMesa.Visible = usuarioTemporal.PuedeCambiarMesa.GetValueOrDefault(false);
            btnSeparar.Visible = usuarioTemporal.PuedeSepararCuentas.GetValueOrDefault(false);
            btnPagos.Visible = usuarioTemporal.PuedeRegistrarPago.GetValueOrDefault(false);
            btnImprimir.Visible = usuarioTemporal.PuedePedirCorteDeCuenta.GetValueOrDefault(false);
            if (mesaAbierta.EsNuevo == true)
            {
                btnSeparar.Visible = false;
                btnCambioMesa.Visible = false;
            }
            toolStripMesonero.Text = mesaAbierta.Mesonero;
            KeyPreview = true;
            //Application.DoEvents();
            KeyDown += new KeyEventHandler(FrmCaja_KeyDown);
            gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            btnSeparar.Click += new EventHandler(btnSeparar_Click);
            btnCambioMesa.Click += new EventHandler(btnCambioMesa_Click);
            btnImprimir.Click += new EventHandler(btnImprimir_Click);
            btnPagos.Click += new EventHandler(Pagos_Click);
            btnGuardar.Click += new EventHandler(btnGuardar_Click);
            btnCancelar.Click += new EventHandler(btnCancelar_Click);
            btnLiberar.Click += btnLiberar_Click;
            CedulaRifButtonEdit.ButtonClick += CedulaRifButtonEdit_ButtonClick;
            CedulaRifButtonEdit.Validating += CedulaRifButtonEdit_Validating;
            txtProducto.Validating += new CancelEventHandler(txtProducto_Validating);
            txtProducto.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtProducto_ButtonClick);
            //   txtMonto.Text = mesaAbierta.MontoTotal.GetValueOrDefault().ToString("N2");
            gridControl1.DoubleClick += gridControl1_DoubleClick;
            if (mesaAbierta.Bloqueada.GetValueOrDefault(false))
            {
                BloquearMesa();
            }
            ultimoProducto = null;
            // txtProducto.Focus();
            this.ShowDialog();
        }
        void cantidad5_Click(object sender, EventArgs e)
        {
            cantidad = 0.5;
        }
        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(CedulaRifButtonEdit.Text);
            if (Empresa != null)
            {
                mesaAbierta.CedulaRif = Basicas.CedulaRif(CedulaRifButtonEdit.Text);
                mesaAbierta.RazonSocial = Empresa;
                this.mesasAbiertaBindingSource.ResetCurrentItem();
            }
        }
        void layoutProductos_Click(object sender, EventArgs e)
        {
            if (esProductos)
            {
                var item = (Producto)this.productosBs.Current;
                if (item.Descripcion == "<< = Volver")
                {
                    CargarGrupos();
                }
                else
                {
                    AgregarItem(item);
                    Cargarproductos(grupo);
                }
            }
            else
            {
                grupo=((Producto)this.productosBs.Current);
                Cargarproductos(grupo);
            }
        }
        void btnLiberar_Click(object sender, EventArgs e)
        {
            mesaAbierta.Bloqueada = false;
            string result = data.GuardarMesaAbierta(mesaAbierta);
            if (result != null)
            {
                MessageBox.Show(result, "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void BloquearMesa()
        {
            btnLiberar.Visible = usuarioTemporal.PuedeLiberarMesa.GetValueOrDefault(true);
            this.btnGuardar.Enabled = false;
            this.btnCambioMesa.Enabled = false;
            this.btnSeparar.Enabled = false;
            txtProducto.Enabled = false;
        }
        #region Terceros
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            if (F.registro != null)
            {
                Leercliente((Tercero)F.registro);
                mesasAbiertaBindingSource.ResetCurrentItem();
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            mesasAbiertaBindingSource.EndEdit();
            Tercero[] T = data.GetAllClientes(CedulaRifButtonEdit.Text);
            switch (T.Length)
            {
                case 0:
                    mesaAbierta.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    mesaAbierta.RazonSocial = "";
                    mesaAbierta.Direccion = OK.SystemParameters.Ciudad;
                    mesaAbierta.TipoPrecio = "PRECIO 1";
                    break;
                case 1:
                    Leercliente(T[0]);
                    break;
                default:
                    using (var F = new FrmBuscarEntidades())
                    {
                        F.BuscarClientes(Texto);
                        Leercliente((Tercero)F.registro);
                    }
                    break;
            }
            mesasAbiertaBindingSource.ResetCurrentItem();
        }
        private void Leercliente(Tercero cliente)
        {
            if (cliente == null)
                cliente = new Tercero();
            mesaAbierta.CedulaRif = Basicas.CedulaRif(cliente.CedulaRif);
            mesaAbierta.RazonSocial = cliente.RazonSocial;
            mesaAbierta.Direccion = string.IsNullOrEmpty(cliente.Direccion) ? OK.SystemParameters.Ciudad : cliente.Direccion;
            mesaAbierta.Telefonos = cliente.Telefonos;
            mesaAbierta.Email = cliente.Email;
            mesaAbierta.TipoPrecio = cliente.TipoPrecio == null ? "PRECIO 1" : cliente.TipoPrecio;
        }
        #endregion
        private void btnCambioMesa_Click(object sender, EventArgs e)
        {
            using(var f = new FrmRestaurant_CambioDeMesa() )
            {
                var mesaAbierta = ((MesasAbierta)mesasAbiertaBindingSource.Current);
                f.CodigoMesa = mesaAbierta.CodigoMesa;
                f.ShowDialog();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }
        private void btnSeparar_Click(object sender, EventArgs e)
        {
            Guardar();
            var f = new FrmRestaurant_SepararCuentas() { codigoMesa = mesaAbierta.CodigoMesa };
            f.ShowDialog();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            doImprimir();
        }
        private void doImprimir(bool conMontos = false)
        {
            try
            {
                mesaAbierta.Bloqueada = true;
                var x = new RestaurantConfig();
                if (x.ImpresoraComandas == "FISCAL")
                {
                    IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
                    if (data.RestaurantConfig.IncluirMontoEnCorteCuenta)
                        Fiscal.ImprimeCorte(mesaAbierta);
                    else
                        if (!conMontos)
                            Fiscal.ImprimeCorteSinMontos(mesaAbierta);
                        else
                            Fiscal.ImprimeCorte(mesaAbierta);
                }
                else
                {
                    IFiscal Fiscal = new FiscalTickera("");
                    if (data.RestaurantConfig.IncluirMontoEnCorteCuenta)
                        Fiscal.ImprimeCorte(mesaAbierta);
                    else
                        if(!conMontos)
                          Fiscal.ImprimeCorteSinMontos(mesaAbierta);
                        else
                            Fiscal.ImprimeCorte(mesaAbierta);
                }
                mesaAbierta.NumeroImpresiones = mesaAbierta.NumeroImpresiones.GetValueOrDefault() + 1;
                Guardar();
                //mesaAbierta.Bloqueada = true;
                //Guardar();
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Guardar()
        {
            if (data.RestaurantConfig.ImpresoraComandas != "NINGUNA")
            {
                BasicasRestaurant.ImprimirComanda(data,mesaAbierta);
            }
            var error = data.GuardarMesaAbierta(mesaAbierta);
            if (error != null)
            {
                MessageBox.Show(string.Format("Datos no guardados {0}", error), "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmCaja_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    var ultimo = mesaAbierta.MesasAbiertasProductos.LastOrDefault();
                    if (ultimo != null)
                    {
                        if (ultimo.NumeroComanda == null)
                        {
                            mesaAbierta.MesasAbiertasProductos.Remove(ultimo);
                        }
                    }
                    mesaAbierta.Totalizar();
                    mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x=>x.Anulado!=true).ToList();
                    e.Handled = true;
                    break;
                case Keys.F8:
                    if (usuarioTemporal.PuedeDarConsumoInterno.GetValueOrDefault(false) == false)
                    {
                        MessageBox.Show("Este usuario no puede dar RP", "Atencion", MessageBoxButtons.OK);
                    }
                    else
                    {
                        var item = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
                        var producto = data.FindPlato(item.ProductoID);
                        if (producto != null)
                        {
                            if (producto.ActivoRP != true)
                            {
                                MessageBox.Show("No se puede hacer RP de este producto", "Atencion", MessageBoxButtons.OK);
                            }
                            else
                            {
                                ConsumoInterno();
                            }
                        }
                    }
                    e.Handled = true;
                    break;
                case Keys.F10:
                    if(usuarioTemporal.PuedePedirCorteDeCuenta.GetValueOrDefault(false))
                       btnImprimir.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F11:
                    if (usuarioTemporal.PuedePedirCorteDeCuenta.GetValueOrDefault(false))
                    {
                        doImprimir(true);
                    }
                    e.Handled = true;
                    break;
                case Keys.F12:
                    btnGuardar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F4:
                    if(usuarioTemporal.PuedeRegistrarPago.GetValueOrDefault(false))
                       btnPagos.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        private void ConsumoInterno()
        {
            var item = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
            item.Alerta = true;
            item.Comentario = "RP";
            item.Precio = 0;
            item.Calcular();
            mesaAbierta.Totalizar();
           // txtMonto.Text = mesaAbierta.MontoTotal.Value.ToString("N2");
            mesasAbiertaBindingSource.ResetCurrentItem();
            this.mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.ToList();
        }
        private void Pagos_Click(object sender, EventArgs e)
        {
            data = new Restaurant();
            MesasCerrada cerrada;
            mesasAbiertaBindingSource.EndEdit();
            mesasAbiertasProductoBindingSource.EndEdit();
            try
            {
                string fallas = null;
                Factura factura;
                mesaAbierta.Totalizar();
                fallas = data.ValidarMesaAbierta(mesaAbierta);
                if (fallas != null)
                {
                    MessageBox.Show(fallas);
                    return;
                }
                //Guardar();
                if (string.IsNullOrEmpty(mesaAbierta.CedulaRif) || string.IsNullOrEmpty(mesaAbierta.RazonSocial))
                {
                    mesaAbierta.CedulaRif = "V000000000";
                    mesaAbierta.RazonSocial = "CONTADO";
                }
                pago = new Pago();
                pago.Tipo = "FACTURA";
                mesaAbierta.Totalizar();
                pago.MontoPagar = mesaAbierta.MontoTotal;
                cerrada = data.CreateMesaCerrada(mesaAbierta);
                factura = data.CreateFactura(cerrada);
                FrmPuntoDeVentasPagar pagos = new FrmPuntoDeVentasPagar() 
                { 
                    pago = pago,
                    cliente = new Tercero(),
                    factura = factura,
                };
                pagos.ShowDialog();
                if (pagos.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
                pago = pagos.pago;
                cerrada.CedulaRif = pagos.cliente.CedulaRif;
                cerrada.RazonSocial = pagos.cliente.RazonSocial;
                cerrada.Direccion = pagos.cliente.Direccion;
                factura.CedulaRif = cerrada.CedulaRif;
                factura.RazonSocial = cerrada.RazonSocial;
                factura.Direccion = cerrada.Direccion;
                fallas = data.ValidarMesaCerrada(cerrada);
                if (fallas != null) {
                    MessageBox.Show(fallas);
                    return;
                }
                fallas = data.ValidarDocumento(factura);
                if (fallas != null)
                {
                    MessageBox.Show(fallas);
                    return;
                }
                fallas = data.ValidarMesaCerrada(cerrada);
                if (pago.MontoPagado < factura.MontoTotal)
                {
                    pago.Efectivo = pago.Efectivo.GetValueOrDefault() + (factura.MontoTotal - pago.MontoPagado);
                    pago.Totalizar();
                }
                if (pago.Tipo == "ANULAR")
                {
                    cerrada.Tipo = "ANULADA";
                    cerrada.MesasCerradasProductos.Clear();
                }
                
                if (pago.Tipo == "FACTURA")
                {
                    IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
                    try
                    {
                        Fiscal.ImprimeFactura(factura,pago);
                    }
                    catch (Exception x)
                    {  
                        Basicas.ManejarError(x);
                        return;
                    }
                    cerrada.Tipo = "FACTURA";
                    var errorGuardar =data.ProcesarFacturaRestaurant(factura,pago);
                    if (errorGuardar != null)
                        throw new Exception(errorGuardar);
                }
                else
                {
                    factura.Numero = Administrativo.GetContador("TICKET");
                }
                cerrada.Efectivo = pago.Efectivo;
                cerrada.TarjetaCR = pago.TarjetaCredito;
                cerrada.TarjetaDB = pago.TarjetaDebito;
                cerrada.CestaTickets = pago.CestaTicket;
                cerrada.Saldo = factura.Saldo;
                cerrada.Factura = factura.Numero;
                data.InsertMesaCerrada(cerrada);
                data.EliminarMesaAbierta(mesaAbierta);
                data.GuardarCambios();
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void txtProducto_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.TextEdit)sender;
            var Texto = Editor.Text;
            Editor.Text = string.Empty;
            var Producto = new Producto();
            var F = new FrmBuscarEntidades();

            F.BuscarProductosVentas(Texto);
            if (F.registro != null)
            {
                Producto = (Producto)F.registro;
                AgregarItem(Producto);
            }
            else
            {
                return;
            }
        }
        private void txtProducto_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.TextEdit)sender;
            if (!Editor.IsModified)
            {
                return;
            }
            if (string.IsNullOrEmpty(Editor.Text))
            {
                return;
            }
            var Producto = new Producto();
            var Texto = Editor.Text;
            Editor.Text = string.Empty;
            var T = data.GetAllProductosVentas(Texto,null);
            switch (T.Length)
            {
                case 0:
                    return;
                case 1:
                    Producto = T[0];
                    break;
                default:
                    var F = new FrmBuscarEntidades();
                    F.BuscarProductosVentas(Texto);
                    if (F.registro != null)
                    {
                        Producto = (Producto)F.registro;
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
            AgregarItem(Producto);
        }
        private void cantidad_Click(object sender, EventArgs e)
        {
            var item = (Button)sender;
            foreach (Button c in cantidades)
            {
                item.Font = new Font("Verdana", 9, c != item ? FontStyle.Regular : FontStyle.Bold);
            }
            cantidad = Convert.ToInt16(item.Text);
        }
        private void AgregarItem(Producto Producto)
        {
            if (mesaAbierta.Bloqueada.GetValueOrDefault(false))
                return;
            var item = new MesasAbiertasProducto();
            switch (mesaAbierta.TipoPrecio)
            {
                case "PRECIO 2":
                    item.Precio = Producto.Precio2;
                    break;
                case "PRECIO 3":
                    item.Precio = Producto.Precio3;
                    break;
                default:
                    item.Precio = Producto.Precio;
                    break;
            }
            if (Producto.UsaContornos.GetValueOrDefault() || Producto.EsCompuesto.GetValueOrDefault())
            {
                FrmRestaurant_PedirContornos f = new FrmRestaurant_PedirContornos()
                {        
                    producto = Producto,
                    LlevaTermino = Producto.LlevaTermino.GetValueOrDefault() 
                };
                f.ShowDialog();
                if(f.DialogResult == System.Windows.Forms.DialogResult.OK  )
                {
                    item.Comentario =  f.Contornos;
                }
            }
            item.Descripcion = Producto.Descripcion;
            item.TasaIva = Producto.TasaIva;
            item.PrecioConIva = item.Precio + (item.Precio * item.TasaIva / 100);
            item.Cantidad = cantidad;
            item.Codigo = Producto.Codigo;
            item.Departamento = Producto.Departamento;
            item.ProductoID = Producto.ID;
            item.TasaIva = Producto.TasaIva;
            item.Total = item.PrecioConIva.GetValueOrDefault(0) * cantidad;
            item.Costo = Producto.Costo.GetValueOrDefault(0) * cantidad;
            item.EnviarComanda = Producto.ImpresionComanda;
            item.LlevaInventario = Producto.LlevaInventario.GetValueOrDefault();
           // item.MesasAbierta = mesaAbierta;
            ultimoProducto = item;
            if (item.Departamento == "COMENTARIOS")
            {
                item.Cantidad =null;
                item.Total = null;
                item.Total = null;
                ultimoProducto = null;
            }
            mesaAbierta.MesasAbiertasProductos.Add(item);
            mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x=>x.Anulado!=true).ToList();
            mesasAbiertasProductoBindingSource.ResetBindings(true);
            mesaAbierta.Totalizar();
           // txtMonto.Text = mesaAbierta.MontoTotal.Value.ToString("N2");
            mesasAbiertaBindingSource.ResetCurrentItem();
            cantidad = 1;
        }
        private void Cargarproductos(Producto producto)
        {
            esProductos = true;
            var items  = new List<Producto>();
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Descripcion = "<< = Volver" });
            items.AddRange(productoCache.Where(x => x.Departamento == producto.Descripcion).ToArray());
            items.Add(new Producto() { Codigo = "COMENTARIO", Descripcion = "** ENTRADAS **", Departamento = "COMENTARIOS", ImpresionComanda = "COCINA" });
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Codigo = "COMENTARIO", Descripcion = "** SEGUNDO PLATO **", Departamento = "COMENTARIOS", ImpresionComanda = "COCINA" });
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Codigo = "COMENTARIO", Descripcion = "** PARA LLEVAR **", Departamento = "COMENTARIOS", ImpresionComanda = ultimoProducto!=null? ultimoProducto.EnviarComanda: "COCINA" });
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Codigo = "COMENTARIO", Descripcion = "** SALE CON PIZZA **", Departamento = "COMENTARIOS", ImpresionComanda = "COCINA" });
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Codigo = "COMENTARIO", Descripcion = "** SALE CON COCINA **", Departamento = "COMENTARIOS", ImpresionComanda = "PIZZA" });
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Codigo = "COMENTARIO", Descripcion = "** SALE CON COMIDA **", Departamento = "COMENTARIOS", ImpresionComanda = "BARRA" });
            items.Add(new Producto() { ID = Guid.NewGuid().ToString(), Codigo = "COMENTARIO", Descripcion = "** NO SALE **", Departamento = "COMENTARIOS", ImpresionComanda = "COCINA" });

            productosBs.DataSource = items;
            productosBs.ResetBindings(false);
        }
        private void CargarGrupos()
        {
            esProductos = false;
            List<Producto> grupos = new List<Producto>();
            if (productoCache == null)
            {
                productoCache = data.GetAllPlatos("", null);
            }
            var items = productoCache.Select(x => x.Departamento).Distinct().ToList();
            foreach (var item in items)
            {
                grupos.Add(new Producto() { Descripcion=item });
            }
            productosBs.DataSource = grupos.OrderBy(x => x.Departamento).ToList();
            productosBs.ResetBindings(false);
            //Cargarproductos((Producto)this.gruposBs.Current);
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (mesasAbiertasProductoBindingSource.Current == null)
                return;
            if (e.KeyCode == Keys.Return)
                if (usuarioTemporal.PuedeCambiarPrecios.GetValueOrDefault())
                {
                    EditarItem();
                }

            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Back)
                {
                    if (gridView1.IsFocusedView)
                    {
                        var i = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
                        if (i.NumeroComanda == null)
                        {
                            mesaAbierta.MesasAbiertasProductos.Remove(i);
                        }
                        else
                        {
                          //  if (usuarioTemporal.PuedeEliminarPlatos)
                          //  {
                                i.Anulado = true;
                          //  }
                        }
                        mesaAbierta.Totalizar();
                        mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x => x.Anulado != true).ToList();
                        mesasAbiertasProductoBindingSource.ResetBindings(true);
                    }
                    e.Handled = true;
                }
            }
            mesaAbierta.Totalizar();
           // txtMonto.Text = mesaAbierta.MontoTotal.Value.ToString("N2");
            mesasAbiertaBindingSource.ResetCurrentItem();
        }
        private void EditarItem()
        {
            var item = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
            var f = new FrmRestaurant_ItemEdicion() { registroDetalle = item };
            f.Modificar(mesaAbierta.TipoPrecio);
            mesaAbierta.Totalizar();
           // txtMonto.Text = mesaAbierta.MontoTotal.Value.ToString("N2");
            mesasAbiertaBindingSource.ResetCurrentItem();
        }
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            var item = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
            if (item == null)
            {
                AgregarItems();
            }
            else
            {
                EditarItem();
            }
        }
        private void AgregarItems()
        {
            do
            {
                var f = new FrmVentasItemEdicion() { data = data, tipoPrecio = "PRECIO 1" };
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos;
                mesasAbiertasProductoBindingSource.ResetBindings(true);
                mesaAbierta.Totalizar();
            }
            while (true);
        }
    }
}
