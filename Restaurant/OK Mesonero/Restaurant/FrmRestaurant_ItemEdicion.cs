using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmRestaurant_ItemEdicion : Form
    {
        public MesasAbiertasProducto registroDetalle;
        public string tipoPrecio = "PRECIO 1";
        public Administrativo data;
        Producto producto;
        public FrmRestaurant_ItemEdicion()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmFacturasItemEdicion_Load);
        }
        void FrmFacturasItemEdicion_KeyDown(object sender, KeyEventArgs e)
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
        void FrmFacturasItemEdicion_Load(object sender, EventArgs e)
        {
            #region Productos
            this.CodigoButtonEdit.Validating += new CancelEventHandler(CodigoButtonEdit_Validating);
            this.CodigoButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CodigoButtonEdit_ButtonClick);
            this.CantidadCalcEdit.Validating += new CancelEventHandler(CantidadCalcEdit_Validating);
            this.PrecioCalcEdit.Validating += new CancelEventHandler(PrecioCalcEdit_Validating);
            this.PrecioConIvaCalcEdit.Validating += new CancelEventHandler(PrecioConIvaCalcEdit_Validating);
            this.PrecioConIvaCalcEdit.KeyDown += new KeyEventHandler(PrecioConIvaCalcEdit_KeyDown);
            this.PrecioCalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIvaCalcEdit.Properties.ValidateOnEnterKey = true;
            this.CodigoButtonEdit.Properties.ValidateOnEnterKey = true;
            this.CantidadCalcEdit.Properties.ValidateOnEnterKey = true;
            this.CodigoButtonEdit.EnterMoveNextControl = true;
            this.CantidadCalcEdit.EnterMoveNextControl = true;
            this.PrecioCalcEdit.EnterMoveNextControl = true;
            this.PrecioConIvaCalcEdit.EnterMoveNextControl = true;
            #endregion
            #region eventos
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmFacturasItemEdicion_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            #endregion
            #region Seguridad
            this.PrecioCalcEdit.Enabled = OK.usuario.PuedeCambiarPrecios.GetValueOrDefault(false);
            this.DescripcionTextEdit.Enabled = OK.usuario.PuedeModificarDescripcion.GetValueOrDefault(false);
            this.PrecioConIvaCalcEdit.Enabled = OK.usuario.PuedeCambiarPrecios.GetValueOrDefault(false);
            this.DescripcionTextEdit.Properties.AppearanceDisabled.BackColor = SystemColors.Info;
            this.DescripcionTextEdit.Properties.AppearanceDisabled.ForeColor = SystemColors.ControlText;
            this.PrecioCalcEdit.Properties.AppearanceDisabled.BackColor = SystemColors.Info;
            this.PrecioCalcEdit.Properties.AppearanceDisabled.ForeColor = SystemColors.ControlText;
            this.PrecioConIvaCalcEdit.Properties.AppearanceDisabled.BackColor = SystemColors.Info;
            this.PrecioConIvaCalcEdit.Properties.AppearanceDisabled.ForeColor = SystemColors.ControlText;
            #endregion
        }
        public void Incluir(string tipoPrecio)
        {
            this.tipoPrecio = tipoPrecio;
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar(string tipoPrecio)
        {
            this.tipoPrecio = tipoPrecio;
            Enlazar();
            this.ShowDialog();
        }
        internal void Cancelar_Click(object sender, EventArgs e)
        {
            this.facturasProductoBindingSource.ResetCurrentItem();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        internal void Aceptar_Click(object sender, EventArgs e)
        {
            facturasProductoBindingSource.EndEdit();
            registroDetalle.Precio = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva, registroDetalle.TasaIva);
            registroDetalle.Calcular();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        internal void Enlazar()
        {
            if (registroDetalle == null)
            {
                registroDetalle = new MesasAbiertasProducto() { TasaIva = OK.SystemParameters.TasaIva, Cantidad = 1, Costo = 0 };
                registroDetalle.Calcular();
            }
            this.facturasProductoBindingSource.DataSource = registroDetalle;
            this.facturasProductoBindingSource.ResetBindings(true);
        }

        void CantidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            if ((double)Editor.Value <= 0)
            {
                Editor.Value = 1;
            }
            registroDetalle.Cantidad = (double)Editor.Value;
            registroDetalle.Calcular();
            this.facturasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Precio = (double)Editor.Value;
            registroDetalle.PrecioConIva = ProductoExtended.PrecioConIva(registroDetalle.Precio, registroDetalle.TasaIva);
            registroDetalle.Calcular();
            this.facturasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.PrecioConIva = (double)Editor.Value;
            registroDetalle.Precio = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva, registroDetalle.TasaIva);
            registroDetalle.Calcular();
            this.facturasProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIvaCalcEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Aceptar.PerformClick();
            }
        }
        #region productos
        private void CodigoButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            UbicarProducto(Editor.Text);
            LeerProducto();
        }
        private void CodigoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            DocumentosProducto registroDetalle = (DocumentosProducto)facturasProductoBindingSource.Current;
            Application.DoEvents();
            // registroDetalle.Cantidad = 1;
            registroDetalle.Salida = 1;
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
            switch (tipoPrecio)
            {
                case "PRECIO 1":
                     registroDetalle.Precio = producto.Precio;
                     registroDetalle.PrecioConIva = producto.PrecioConIva;
                    break;
                case "PRECIO 2":
                    registroDetalle.Precio = producto.Precio2;
                    registroDetalle.PrecioConIva = producto.PrecioConIva2;
                    break;
                case "PRECIO 3":
                    registroDetalle.Precio = producto.Precio3;
                    registroDetalle.Precio = producto.PrecioConIva3;
                    break;
                default:
                     registroDetalle.Precio = producto.Precio;
                     registroDetalle.PrecioConIva = producto.PrecioConIva;
                    break;
            }
            CodigoButtonEdit.Text = producto.Codigo;
            registroDetalle.Calcular();
            this.facturasProductoBindingSource.DataSource = registroDetalle;
            this.facturasProductoBindingSource.ResetBindings(true);
            Application.DoEvents();
        }
        private bool UbicarProducto(string Texto)
        {
            Producto[] T = data.GetAllProductosCompras(Texto);
            switch (T.Length)
            {
                case 0:
                    if (MessageBox.Show("Producto no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        producto = new Producto();
                        ;
                        return false;
                    }
                    FrmTablas_ProductosItem nuevo = new FrmTablas_ProductosItem();
                    nuevo.Incluir(null);
                    if (nuevo.DialogResult == DialogResult.OK)
                    {
                        Application.DoEvents();
                        producto = nuevo.producto;
                    }
                    else
                    {
                        producto = new Producto();
                        ;
                        return false;
                    }
                    break;
                case 1:
                    producto = (Producto)T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProductosVentas(Texto);
                    producto = (Producto)F.registro;
                    break;
            }
            LeerProducto();
            return true;
        }
        #endregion
    }
}
