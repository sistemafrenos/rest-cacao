using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_ProductosCargar : Form
    {
        Producto producto;
        Tercero proveedor;
        public Administrativo data;
        public DocumentosProducto registroDetalle;
        public FrmTablas_ProductosCargar()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmCotizacionesItemEdicion_Load);
        }
        void FrmCotizacionesItemEdicion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void FrmCotizacionesItemEdicion_Load(object sender, EventArgs e)
        {
            #region Productos
            this.CodigoTextEdit.Validating += new CancelEventHandler(CodigoTextEdit_Validating);
            this.CodigoTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CodigoTextEdit_ButtonClick);
            #endregion
            #region precios
            this.CantidadCalcEdit.Validating += new CancelEventHandler(CantidadCalcEdit_Validating);
            this.CantidadCalcEdit.Enter += new EventHandler(CantidadCalcEdit_Enter);
            this.CostoCalcEdit.Validating += new CancelEventHandler(CostoCalcEdit_Validating);
            this.CostoIvaCalcEdit.Validating += new CancelEventHandler(CostoIvaCalcEdit_Validating);
            this.TasaIvaCalcEdit.Validating += new CancelEventHandler(TasaIvaCalcEdit_Validating);

            this.CantidadNetaCalcEdit.Validating += new CancelEventHandler(CantidadNetaCalcEdit_Validating);
            this.PrecioCalcEdit.Validating += new CancelEventHandler(PrecioCalcEdit_Validating);
            this.PrecioConIvaCalcEdit.Validating += new CancelEventHandler(PrecioConIvaCalcEdit_Validating);
            this.UtilidadCalcEdit.Validating += new CancelEventHandler(UtilidadCalcEdit_Validating);

            this.Precio2CalcEdit.Validating += new CancelEventHandler(Precio2CalcEdit_Validating);
            this.PrecioConIva2CalcEdit.Validating += new CancelEventHandler(PrecioConIva2CalcEdit_Validating);
            this.Utilidad2CalcEdit.Validating += new CancelEventHandler(Utilidad2CalcEdit_Validating);

            this.Precio3CalcEdit.Validating += new CancelEventHandler(Precio3CalcEdit_Validating);
            this.PrecioConIva3CalcEdit.Validating += new CancelEventHandler(PrecioConIva3CalcEdit_Validating);
            this.Utilidad3CalcEdit.Validating += new CancelEventHandler(Utilidad3CalcEdit_Validating);

            this.Precio4CalcEdit.Validating += new CancelEventHandler(Precio4CalcEdit_Validating);
            this.PrecioConIva4CalcEdit.Validating += new CancelEventHandler(PrecioConIva4CalcEdit_Validating);
            this.Utilidad4CalcEdit.Validating += new CancelEventHandler(Utilidad4CalcEdit_Validating);


            this.CostoNetoCalcEdit.Validating += new CancelEventHandler(CostoNetoCalcEdit_Validating);
            Ventax.Validating += new CancelEventHandler(Ventax_Validating);
            this.CostoNetoCalcEdit.Properties.ValidateOnEnterKey = true;
            this.CostoCalcEdit.Properties.ValidateOnEnterKey = true;

            this.UtilidadCalcEdit.Properties.ValidateOnEnterKey = true;
            this.Utilidad2CalcEdit.Properties.ValidateOnEnterKey = true;
            this.Utilidad3CalcEdit.Properties.ValidateOnEnterKey = true;
            this.Utilidad4CalcEdit.Properties.ValidateOnEnterKey = true;

            this.PrecioCalcEdit.Properties.ValidateOnEnterKey = true;
            this.Precio2CalcEdit.Properties.ValidateOnEnterKey = true;
            this.Precio3CalcEdit.Properties.ValidateOnEnterKey = true;
            this.Precio4CalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIvaCalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIva2CalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIva3CalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIva4CalcEdit.Properties.ValidateOnEnterKey = true;
            Ventax.Properties.Items.AddRange(new Object[] { "UNIDAD", "EMPAQUE" });
            #endregion
            #region eventos
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmCotizacionesItemEdicion_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            #endregion
            #region Proveedor
            proveedor = data.GetAllProveedores("").FirstOrDefault();
            this.txtProveedor.Validating += new CancelEventHandler(CedulaRifButtonEdit_Validating);
            this.txtProveedor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CedulaRifButtonEdit_ButtonClick);
            #endregion
        }
        void Ventax_Validating(object sender, CancelEventArgs e)
        {
            fijarCantidad();
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        #region Terceros
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarProveedores("");
            if (F.registro != null)
            {
                txtProveedor.Text = ((Tercero)F.registro).RazonSocial;
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            Tercero[] T = data.GetAllProveedores(Texto);
            switch (T.Length)
            {
                case 0:
                    txtProveedor.Text = null;
                    break;
                case 1:
                    txtProveedor.Text = T[0].RazonSocial;
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProveedores(Texto);
                    if (F.registro != null)
                    {
                        txtProveedor.Text = ((Tercero)F.registro).RazonSocial;
                    }
                    break;
            }
        }
        #endregion
        void CantidadCalcEdit_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoTextEdit.Text))
            {
                CodigoTextEdit.Focus();
            }
        }
        public void Incluir()
        {
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        internal void Cancelar_Click(object sender, EventArgs e)
        {
            this.comprasProductoBindingSource.ResetCurrentItem();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        internal void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                comprasProductoBindingSource.EndEdit();
                registroDetalle = (DocumentosProducto)comprasProductoBindingSource.Current;
                data.GuardarCarga(registroDetalle, proveedor);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                OK.ManejarException(x);
            }
        }
        internal void Enlazar()
        {
            if (registroDetalle == null)
            {
                registroDetalle = new DocumentosProducto();
                registroDetalle.Fecha = DateTime.Today;
                registroDetalle.TasaIva = OK.SystemParameters.TasaIva;
                registroDetalle.Cantidad = 1;
                registroDetalle.Entrada = 1;
                registroDetalle.Costo = 0;
                registroDetalle.CostoNeto = 0;
                registroDetalle.ImpuestoLicores = 0;
                registroDetalle.Presentacion = "UNIDAD";
                registroDetalle.CalcularItemCompra();
            }
            this.comprasProductoBindingSource.DataSource = registroDetalle;
            this.comprasProductoBindingSource.ResetBindings(true);
        }
        #region productos
        private void fijarCantidad()
        {
            if (registroDetalle.Presentacion != "UNIDAD")
                registroDetalle.Entrada = registroDetalle.UnidadesxEmpaque * registroDetalle.Cantidad;
            else
                registroDetalle.Entrada = registroDetalle.Cantidad;
        }
        private void CodigoTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            UbicarProducto(Editor.Text);
            LeerProducto();
        }
        private void CodigoTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (UbicarProducto(""))
            {
                LeerProducto();
            }
        }
        private void LeerProducto()
        {
            if (producto == null)
            {
                producto = new Producto();
            }
            Application.DoEvents();
            registroDetalle.Cantidad = 1;
            registroDetalle.Entrada = 1;
            registroDetalle.Presentacion = "UNIDAD";
            registroDetalle.UnidadesxEmpaque = producto.UnidadesxEmpaque;
            registroDetalle.Costo = producto.Costo;
            registroDetalle.CostoNeto = producto.Costo;
            registroDetalle.Iva = producto.Costo * producto.TasaIva / 100;
            registroDetalle.CostoIva = producto.Costo + registroDetalle.Iva;
            registroDetalle.Inicio = producto.Existencia;
            registroDetalle.ProductoID = producto.ID;
            registroDetalle.Descripcion = producto.Descripcion;
            registroDetalle.TasaIva = producto.TasaIva;
            registroDetalle.UnidadMedida = producto.UnidadMedida;
            registroDetalle.Departamento = producto.Departamento;
            registroDetalle.ImpuestoLicores = 0;
            registroDetalle.Codigo = producto.Codigo;
            registroDetalle.CodigoProveedor = producto.CodigoProveedor;
            registroDetalle.Precio = producto.Precio;
            registroDetalle.Precio2 = producto.Precio2;
            registroDetalle.Precio3 = producto.Precio3;
            registroDetalle.Precio4 = producto.Precio4;
            registroDetalle.PrecioConIva = producto.PrecioConIva;
            registroDetalle.PrecioConIva2 = producto.PrecioConIva2;
            registroDetalle.PrecioConIva3 = producto.PrecioConIva3;
            registroDetalle.PrecioConIva4 = producto.PrecioConIva4;
            registroDetalle.Utilidad = producto.Utilidad == null ? OK.SystemParameters.Utilidad : producto.Utilidad;
            registroDetalle.Utilidad2 = producto.Utilidad2 == null ? OK.SystemParameters.Utilidad2 : producto.Utilidad2;
            registroDetalle.Utilidad3 = producto.Utilidad3 == null ? OK.SystemParameters.Utilidad3 : producto.Utilidad3;
            registroDetalle.Utilidad4 = producto.Utilidad4 == null ? OK.SystemParameters.Utilidad4 : producto.Utilidad4;
            registroDetalle.LlevaInventario = producto.LlevaInventario.GetValueOrDefault();
            fijarCantidad();
            CodigoTextEdit.Text = producto.Codigo;
            this.comprasProductoBindingSource.DataSource = registroDetalle;
            this.comprasProductoBindingSource.ResetBindings(true);
            Application.DoEvents();
        }
        private bool UbicarProducto(string Texto)
        {
            Producto[] T = data.GetAllProductosCompras(Texto);
            T =  data.GetAllProductosCompras(Texto);
            switch (T.Length)
            {
                case 0:
                    if (MessageBox.Show("Producto no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        producto = new Producto();
                        return false;
                    }
                    FrmTablas_ProductosItem nuevo = new FrmTablas_ProductosItem();
                    nuevo.Incluir(Texto);
                    if (nuevo.DialogResult == DialogResult.OK)
                    {
                        Application.DoEvents();
                        producto = nuevo.producto;
                    }
                    else
                    {
                        producto = new Producto();
                        return false;
                    }
                    break;
                case 1:
                    producto = (Producto)T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProductosCompras(Texto);
                    producto = (Producto)F.registro;
                    break;
            }
            LeerProducto();
            return true;
        }
        #endregion
        #region Precios
        void ImpuestoLicoresCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.ImpuestoLicores = (double)Editor.Value;
            registroDetalle.CostoNeto = ((registroDetalle.Costo.GetValueOrDefault(0) * registroDetalle.Cantidad.GetValueOrDefault(0)) + registroDetalle.ImpuestoLicores.GetValueOrDefault(0)) / registroDetalle.Entrada.GetValueOrDefault(1);
            registroDetalle.CalcularItemCompra();
        }
        private void CantidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            //if (!Editor.IsModified)
            //    return;
            if ((double)Editor.Value <= 0)
            {
                Editor.Value = 1;
            }
            registroDetalle.Cantidad = (double)Editor.Value;
            fijarCantidad();
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        private void CantidadNetaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            //if (!Editor.IsModified)
            //    return;
            if ((double)Editor.Value <= 0)
            {
                Editor.Value = (decimal)registroDetalle.Cantidad;
            }
            registroDetalle.Entrada = (double)Editor.Value;
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        private void TasaIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            if (!Editor.IsModified)
                return;
            registroDetalle.TasaIva = (double)Editor.Value;
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Precio = Basicas.Round((double)Editor.Value);
            registroDetalle.PrecioConIva = ProductoExtended.PrecioConIva(registroDetalle.Precio, registroDetalle.TasaIva);
            registroDetalle.Utilidad = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void Precio2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Precio2 = Basicas.Round((double)Editor.Value);
            registroDetalle.PrecioConIva2 = ProductoExtended.PrecioConIva(registroDetalle.Precio2, registroDetalle.TasaIva);
            registroDetalle.Utilidad2 = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio2);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void Precio3CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Precio3 = Basicas.Round((double)Editor.Value);
            registroDetalle.PrecioConIva3 = ProductoExtended.PrecioConIva(registroDetalle.Precio3, registroDetalle.TasaIva);
            registroDetalle.Utilidad3 = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio3);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void Precio4CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Precio4 = Basicas.Round((double)Editor.Value);
            registroDetalle.PrecioConIva4 = ProductoExtended.PrecioConIva(registroDetalle.Precio4, registroDetalle.TasaIva);
            registroDetalle.Utilidad4 = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio4);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.PrecioConIva = (double)Editor.Value;
            registroDetalle.Precio = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva, registroDetalle.TasaIva);
            registroDetalle.PrecioConIva = ProductoExtended.PrecioConIva(registroDetalle.Precio, registroDetalle.TasaIva);
            registroDetalle.Utilidad = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIva2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.PrecioConIva2 = (double)Editor.Value;
            registroDetalle.Precio2 = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva2, registroDetalle.TasaIva);
            registroDetalle.PrecioConIva2 = ProductoExtended.PrecioConIva(registroDetalle.Precio2, registroDetalle.TasaIva);
            registroDetalle.Utilidad2 = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio2);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIva3CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.PrecioConIva3 = (double)Editor.Value;
            registroDetalle.Precio3 = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva3, registroDetalle.TasaIva);
            registroDetalle.PrecioConIva3 = ProductoExtended.PrecioConIva(registroDetalle.Precio3, registroDetalle.TasaIva);
            registroDetalle.Utilidad3 = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio3);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIva4CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.PrecioConIva4 = (double)Editor.Value;
            registroDetalle.Precio4 = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva4, registroDetalle.TasaIva);
            registroDetalle.PrecioConIva4 = ProductoExtended.PrecioConIva(registroDetalle.Precio4, registroDetalle.TasaIva);
            registroDetalle.Utilidad4 = ProductoExtended.CalcularUtilidad(registroDetalle.CostoNeto, registroDetalle.Precio4);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void UtilidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Utilidad = (double)Editor.Value;
            registroDetalle.Precio = ProductoExtended.CalcularPrecio(registroDetalle.CostoNeto, registroDetalle.Utilidad);
            registroDetalle.PrecioConIva = ProductoExtended.PrecioConIva(registroDetalle.Precio, registroDetalle.TasaIva);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void Utilidad2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Utilidad2 = (double)Editor.Value;
            registroDetalle.Precio2 = ProductoExtended.CalcularPrecio(registroDetalle.CostoNeto, registroDetalle.Utilidad2);
            registroDetalle.PrecioConIva2 = ProductoExtended.PrecioConIva(registroDetalle.Precio2, registroDetalle.TasaIva);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void Utilidad3CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Utilidad3 = (double)Editor.Value;
            registroDetalle.Precio3 = ProductoExtended.CalcularPrecio(registroDetalle.CostoNeto, registroDetalle.Utilidad3);
            registroDetalle.PrecioConIva3 = ProductoExtended.PrecioConIva(registroDetalle.Precio3, registroDetalle.TasaIva);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void Utilidad4CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Utilidad4 = (double)Editor.Value;
            registroDetalle.Precio4 = ProductoExtended.CalcularPrecio(registroDetalle.CostoNeto, registroDetalle.Utilidad4);
            registroDetalle.PrecioConIva4 = ProductoExtended.PrecioConIva(registroDetalle.Precio4, registroDetalle.TasaIva);
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void CostoNetoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.CostoNeto = (double)Editor.Value;
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        private void CostoIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.CostoIva = (double)Editor.Value;
            registroDetalle.Costo = Basicas.Round(registroDetalle.CostoIva / (1 + (registroDetalle.TasaIva / 100)));
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        private void CostoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Costo = (double)Editor.Value;
            registroDetalle.CalcularItemCompra();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        #endregion
    }
}
