using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmComprasItemEdcion : Form
    {
        public DocumentosProducto registroDetalle;
    //    readonly ProductosMovimientos[] ultimasCompras;
        public Administrativo data;
        private Producto producto;
        public FrmComprasItemEdcion()
        {
            InitializeComponent();
            registroDetalle = new DocumentosProducto();
            if (data == null)
                data = new Administrativo();
            Load += FrmCotizacionesItemEdicion_Load;
        }
        void FrmCotizacionesItemEdicion_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void FrmCotizacionesItemEdicion_Load(object sender, EventArgs e)
        {
            #region Productos
            CodigoTextEdit.Validating += CodigoTextEdit_Validating;
            CodigoTextEdit.ButtonClick += CodigoTextEdit_ButtonClick;
            #endregion
            #region precios
            CantidadCalcEdit.Validating += CantidadCalcEdit_Validating;
            Ventax.Validating += new CancelEventHandler(Ventax_Validating);
            CantidadCalcEdit.Enter += CantidadCalcEdit_Enter;
            CostoCalcEdit.Validating += CostoCalcEdit_Validating;
            CostoIvaCalcEdit.Validating += CostoIvaCalcEdit_Validating;
            TasaIvaCalcEdit.Validating += TasaIvaCalcEdit_Validating;
            CantidadNetaCalcEdit.Validating += CantidadNetaCalcEdit_Validating;
            ImpuestoLicoresCalcEdit.Validating += ImpuestoLicoresCalcEdit_Validating;
            PrecioCalcEdit.Validating += PrecioCalcEdit_Validating;
            PrecioConIvaCalcEdit.Validating += PrecioConIvaCalcEdit_Validating;
            UtilidadCalcEdit.Validating += UtilidadCalcEdit_Validating;
            Precio2CalcEdit.Validating += Precio2CalcEdit_Validating;
            Utilidad2CalcEdit.Validating += Utilidad2CalcEdit_Validating;
            PrecioConIva2CalcEdit.Validating += PrecioConIva2CalcEdit_Validating;

            Precio3CalcEdit.Validating += Precio3CalcEdit_Validating;
            Utilidad3CalcEdit.Validating += Utilidad3CalcEdit_Validating;
            PrecioConIva3CalcEdit.Validating += PrecioConIva3CalcEdit_Validating;

            Precio4CalcEdit.Validating += Precio4CalcEdit_Validating;
            Utilidad4CalcEdit.Validating += Utilidad4CalcEdit_Validating;
            PrecioConIva4CalcEdit.Validating += PrecioConIva4CalcEdit_Validating;

            CostoNetoCalcEdit.Validating += CostoNetoCalcEdit_Validating;
            #endregion
            #region eventos
            KeyPreview = true;
            KeyDown += FrmCotizacionesItemEdicion_KeyDown;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
            #endregion
            Ventax.Properties.Items.AddRange(new Object[] { "UNIDAD", "EMPAQUE" });
        }

        void Ventax_Validating(object sender, CancelEventArgs e)
        {
            fijarCantidad();
            this.comprasProductoBindingSource.ResetCurrentItem();
        }
        void CantidadCalcEdit_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CodigoTextEdit.Text))
            {
                CodigoTextEdit.Focus();
            }
        }
        internal void Incluir()
        {
            Enlazar();
            ShowDialog();
        }
        internal void Modificar()
        {
            Enlazar();
            ShowDialog();
        }
        internal void Cancelar_Click(object sender, EventArgs e)
        {
            comprasProductoBindingSource.ResetCurrentItem();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        internal void Aceptar_Click(object sender, EventArgs e)
        {
            comprasProductoBindingSource.EndEdit();
            registroDetalle = (DocumentosProducto)comprasProductoBindingSource.Current;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        internal void Enlazar()
        {
            if (registroDetalle == null)
            {
                registroDetalle = new DocumentosProducto() 
                { 
                    TasaIva = OK.SystemParameters.TasaIva, Cantidad = 1, 
                    Costo = 0, ImpuestoLicores = 0 
                };
            //    productosMovimientoBindingSource.DataSource = ultimasCompras;
            //    productosMovimientoBindingSource.ResetBindings(true);
                registroDetalle.Calcular();
            }
            comprasProductoBindingSource.DataSource = registroDetalle;
            comprasProductoBindingSource.ResetBindings(true);
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
            T = data.GetAllProductosCompras(Texto);
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
