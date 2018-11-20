    using HK.Formas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK
{
    public partial class FrmRestaurant_EditarMesa : Form
    {
        private int pagina;
        private int cantidad;
        public string mesaCodigo;
        private string grupoActivo = null;

        private List<Button> grupos = new List<Button>();
        private List<Button> productos = new List<Button>();
        private List<Button> cantidades = new List<Button>();

        private HK.BussinessLogic.MesasAbiertas mesasAbiertas;
        public BussinessLogic.RestaurantBussinessLogic restaurant;
        private MesasAbierta mesaAbierta= new MesasAbierta();
        public FrmRestaurant_EditarMesa()
        {
            InitializeComponent();
            mesasAbiertaBindingSource.DataSource = mesaAbierta;
            Load += new EventHandler(Form1_Load);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            pagina = 0;
            cantidad = 1;
            txtMesa.Text = mesaCodigo;
            mesasAbiertas = new BussinessLogic.MesasAbiertas();
            mesaAbierta = restaurant.GetByCodigoMesaAbierta(mesaCodigo);
            mesasAbiertaBindingSource.DataSource = mesaAbierta;
            mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x => x.Anulado != true).ToList();
            mesaAbierta.Totalizar();
            cantidades.AddRange(new Button[] { cantidad0, cantidad1, cantidad2, cantidad3, cantidad4, cantidad5 });
            grupos.AddRange(new Button[] { grupo1, grupo2, grupo3, grupo4, grupo5, grupo6, grupo7, grupo8, grupo9,
            grupo10, grupo11, grupo12, grupo13, grupo14, grupo15, grupo16, grupo17, grupo18 });
            productos.AddRange(new Button[] { Producto1, Producto2, Producto3, Producto4, Producto5, Producto6, Producto7, Producto8, Producto9,
            Producto10, Producto11, Producto12, Producto13, Producto14, Producto15, Producto16, Producto17, Producto18, Producto19,
            Producto20, Producto21, Producto22, Producto23, Producto24, Producto25, Producto26, Producto27, Producto28, Producto29,
            Producto30, Producto31, Producto32, Producto33, Producto34, Producto35, Producto36, Producto37, Producto38, Producto39,
            Producto40, Producto41, Producto42 });
            foreach (Button b in cantidades)
            {
                b.Click += new EventHandler(cantidad_Click);
            }
            foreach (Button b in grupos)
            {
                b.Visible = false;
                b.Click += new EventHandler(grupo_Click);
            }
            foreach (Button b in productos)
            {
                b.Visible = false;
                b.Click += new EventHandler(Producto_Click);
            }
            btnSeparar.Visible = false;
            btnPagos.Visible = false;
            btnLiberar.Visible = false;
            btnCambioMesa.Visible = false;
            btnImprimir.Visible = false;
            if (restaurant.RestaurantConfig.PedirMesonero)
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
                    btnCambioMesa.Visible = x.mesonero.CambioMesa.GetValueOrDefault(false);
                    btnImprimir.Visible =x.mesonero.ImprimirCuenta.GetValueOrDefault(false);
                }
            }
            else
            {
                btnCambioMesa.Visible = OK.usuario.PuedeCambiarMesa.GetValueOrDefault(false);
                btnSeparar.Visible =  OK.usuario.PuedeSepararCuentas.GetValueOrDefault(false);
                btnPagos.Visible = OK.usuario.PuedeRegistrarPago.GetValueOrDefault(false);
                btnImprimir.Visible = OK.usuario.PuedePedirCorteDeCuenta.GetValueOrDefault(false);
            }
            toolStripMesonero.Text = mesaAbierta.Mesonero;
            KeyPreview = true;
            CargarGrupos();
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
            gridControl1.DoubleClick+=gridControl1_DoubleClick;
            btnMas.Click += new EventHandler(btnMas_Click);
            if (mesaAbierta.Bloqueada.GetValueOrDefault(false))
            {
                BloquearMesa();
            }
            txtProducto.Focus();
        }
        void btnLiberar_Click(object sender, EventArgs e)
        {
            mesaAbierta.Bloqueada = false;
            mesasAbiertas.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void BloquearMesa()
        {
            btnLiberar.Visible = OK.usuario.PuedeLiberarMesa.GetValueOrDefault(true);
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
            List<Tercero> T = mesasAbiertas.GetTerceros(Texto);
            switch (T.Count)
            {
                case 0:
                    mesaAbierta.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    mesaAbierta.RazonSocial = "";
                    mesaAbierta.Direccion = OK.Parametros.Ciudad;
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
            mesaAbierta.Direccion = string.IsNullOrEmpty(cliente.Direccion) ? OK.Parametros.Ciudad : cliente.Direccion;
            mesaAbierta.TipoPrecio = cliente.TipoPrecio == null ? "PRECIO 1" : cliente.TipoPrecio;
        }
        #endregion
        private void btnCambioMesa_Click(object sender, EventArgs e)
        {
            Guardar();
            using(var f = new FrmRestaurant_CambioDeMesa() )
            {
                var id = ((MesasAbierta)mesasAbiertaBindingSource.Current).ID;
                f.IdMesa = id;
                f.ShowDialog();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };
        }
        private void btnSeparar_Click(object sender, EventArgs e)
        {
            Guardar();
            var f = new FrmRestaurant_SepararCuentas() { IdMesa = mesaAbierta.ID };
            f.ShowDialog();
            Close();
        }
        private void btnMas_Click(object sender, EventArgs e)
        {
            Cargarproductos();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                Guardar();
                var ticket = new Fiscales.Fiscal();
                ticket.ImprimeCorteSinMontos(mesaAbierta);
                Guardar();
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
            mesaAbierta.Totalizar();
            if (restaurant.RestaurantConfig.ImpresoraComandas != "NINGUNA")
            {
                Basicas.ImprimirComanda(restaurant,mesaAbierta);
            }
            mesasAbiertas.Save();
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
                case Keys.F10:
                    if(OK.usuario.PuedePedirCorteDeCuenta.GetValueOrDefault(false))
                       btnImprimir.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    btnGuardar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F4:
                    if(OK.usuario.PuedeRegistrarPago.GetValueOrDefault(false))
                       btnPagos.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        private void Pagos_Click(object sender, EventArgs e)
        {
            MesasCerrada cerrada;
            mesasAbiertaBindingSource.EndEdit();
            mesasAbiertasProductoBindingSource.EndEdit();
            try
            {
                Factura factura;
                mesaAbierta.Totalizar();
                Guardar();
                cerrada = restaurant.CreateMesaCerrada(mesaAbierta);
                    factura =restaurant.CreateFactura(cerrada);
                    FrmPuntoDeVentasPagar pagos = new FrmPuntoDeVentasPagar() 
                    { 
                        factura = factura
                    };
                    pagos.ShowDialog();
                    if (pagos.DialogResult != System.Windows.Forms.DialogResult.OK)
                        return;                    
                    if (factura.Pagos.Tipo == "FACTURA")
                    {
                        factura.Tipo = "FACTURA";
                        var fiscal = new Fiscales.Fiscal();
                        fiscal.ImprimeFactura(factura);

                    }
                    if (factura.Pagos.Tipo == "CONSUMO INTERNO")
                    {
                        factura.Tipo = "TICKET";
                        factura.Fecha = DateTime.Today;
                    }
                    factura.Estatus = "CERRADA";
                    cerrada.Tipo = factura.Tipo;
                    cerrada.CedulaRif = factura.CedulaRif;
                    cerrada.RazonSocial = factura.RazonSocial;
                    cerrada.DocumentoID = factura.ID;
                    factura.Pagos.NumeroLote = cerrada.NumeroLote;                    
                    if (factura.Pagos.Tipo == "ANULAR")
                    {
                        cerrada.Tipo = "ANULADA";
                        cerrada.MesasCerradasProductos.Clear();
                    }
                    else
                    {
                        restaurant.InsertFactura(factura);                       
                    }
                    restaurant.InsertMesaCerrada(cerrada);
                    restaurant.DeleteMesaAbierta(mesaAbierta.ID);
                    restaurant.Save();
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
            var T = mesasAbiertas.GetProductos(Texto);
            switch (T.Count)
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
        private void Ocultarproductos()
        {
            foreach (Button b in productos)
            {
                b.Visible = false;
                b.Text = null;
            }
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
        private void grupo_Click(object sender, EventArgs e)
        {
            var item = (Button)sender;
            grupoActivo = item.Text;
            pagina = 0;
            Cargarproductos();
        }
        private void Producto_Click(object sender, EventArgs e)
        {
            var item = (Button)sender;
            AgregarItem((Producto)item.Tag);
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
            if (Producto.UsaContornos.GetValueOrDefault())
            {
                FrmRestaurant_PedirContornos f = new FrmRestaurant_PedirContornos()
                { LlevaTermino = Producto.LlevaTermino.GetValueOrDefault() };
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
            mesaAbierta.MesasAbiertasProductos.Add(item);
            mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x=>x.Anulado!=true).ToList();
            mesasAbiertasProductoBindingSource.ResetBindings(true);
            mesaAbierta.Totalizar();
            mesasAbiertaBindingSource.ResetCurrentItem();
        }
        private void Cargarproductos()
        {
            var i = 0;
            Ocultarproductos();
            var items = restaurant.GetAllProductosDepartamento(grupoActivo,36).Skip(i * 36);
            foreach (Producto s in items)
            {
                productos[i].Visible = true;
                productos[i].Text = s.Descripcion;
                productos[i].Tag = s;
                i++;
            }
            pagina++;
        }
        private void CargarGrupos()
        {
            var mgrupos = restaurant.GetAllDepartamentos(18); // mesasAbiertas.GetDepartamentos().Take(18);
            grupos.ForEach(x => x.Text = null);
            grupoActivo = mgrupos.FirstOrDefault();
            var i = 0;
            foreach (string s in mgrupos)
            {
                grupos[i].Visible = true;
                grupos[i].Text = s;
                i++;
            }
            Cargarproductos();
        }
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                EditarItem();

            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
                {
                    if (gridView1.IsFocusedView)
                    {
                        var i = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
                        i.Anulado = true;
                        mesaAbierta.Totalizar();
                        mesasAbiertasProductoBindingSource.DataSource = mesaAbierta.MesasAbiertasProductos.Where(x=>x.Anulado!=true).ToList();
                        mesasAbiertasProductoBindingSource.ResetBindings(true);
                    }
                    e.Handled = true;
                }
            }
            mesaAbierta.Totalizar();
            mesasAbiertaBindingSource.ResetCurrentItem();
        }
        private void EditarItem()
        {
            var item = (MesasAbiertasProducto)mesasAbiertasProductoBindingSource.Current;
            var f = new FrmRestaurant_ItemEdicion() { registroDetalle = item };
            f.Modificar(mesaAbierta.TipoPrecio);
            mesaAbierta.Totalizar();
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
                var f = new FrmVentasFacturasItemEdicion();
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
