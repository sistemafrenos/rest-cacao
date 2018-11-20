using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmVentasItemEdicion : Form
    {
        public Administrativo data;
        public DocumentosProducto registroDetalle;
        public string tipoPrecio = "PRECIO 1";
        Producto producto = new Producto();
        public FrmVentasItemEdicion()
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
            this.CodigoButtonEdit.Validating += new CancelEventHandler(CodigoButtonEdit_Validating);
            this.CodigoButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CodigoButtonEdit_ButtonClick);
            this.CodigoButtonEdit.Properties.ValidateOnEnterKey = true;
            this.CantidadCalcEdit.Validating += new CancelEventHandler(CantidadCalcEdit_Validating);
            this.PrecioCalcEdit.Validating += new CancelEventHandler(PrecioCalcEdit_Validating);
            this.PrecioConIvaCalcEdit.Validating += new CancelEventHandler(PrecioConIvaCalcEdit_Validating);
            this.PrecioConIvaCalcEdit.KeyDown += new KeyEventHandler(PrecioConIvaCalcEdit_KeyDown);
            this.Ventax.Validating += new CancelEventHandler(Ventax_Validating);
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
            this.KeyDown += new KeyEventHandler(FrmCotizacionesItemEdicion_KeyDown);
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
            Ventax.Properties.Items.AddRange( new Object[] { "UNIDAD","EMPAQUE" });
            Ventax.Text = "UNIDAD";
        }
        public void Incluir()
        {
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            producto = data.FindProducto(registroDetalle.ProductoID);
            if(producto!=null)
                this.PrecioCalcEdit.Properties.Items.AddRange(new Object[] { producto.Precio.GetValueOrDefault(0).ToString("n2"), producto.Precio2.GetValueOrDefault(0).ToString("n2"), producto.Precio3.GetValueOrDefault(0).ToString("n2"), producto.Precio4.GetValueOrDefault(0).ToString("n2") });
            this.ShowDialog();
        }
        public void Cancelar_Click(object sender, EventArgs e)
        {
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        public void Aceptar_Click(object sender, EventArgs e)
        {
            cotizacionesProductoBindingSource.EndEdit();
            registroDetalle.Precio = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva, registroDetalle.TasaIva);
            registroDetalle.CalcularItemFactura();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        private void Enlazar()
        {
            if (registroDetalle == null)
            {
                registroDetalle = new DocumentosProducto();
                registroDetalle.UnidadMedida = "UNIDAD";
                registroDetalle.CalcularItemFactura();
            }
            this.cotizacionesProductoBindingSource.DataSource = registroDetalle;
            this.cotizacionesProductoBindingSource.ResetBindings(false);
        }
        #region productos
        void CodigoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarProductosVentas("");
            if(F.registro!=null)
                LeerProducto((Producto)F.registro);
        }
        void CodigoButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit Editor = (DevExpress.XtraEditors.TextEdit)sender;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            if (!Editor.IsModified)
                return;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            Producto Producto = new Producto();
            string Texto = Editor.Text;
            Producto[] T = data.GetAllProductosVentas(Texto, null);
            switch (T.Length)
            {
                case 0:
                    if (MessageBox.Show("Producto no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        LeerProducto(new Producto());
                        return;
                    }
                    FrmTablas_ProductosItem nuevo = new FrmTablas_ProductosItem()
                    { data = data };
                    nuevo.Incluir(Texto);
                    if (nuevo.DialogResult == DialogResult.OK)
                    {
                        Application.DoEvents();
                        LeerProducto(nuevo.producto);
                        return;
                        
                    }
                    else
                    {
                        LeerProducto(new Producto());
                        return;
                    }
                case 1:
                    LeerProducto(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProductosVentas(Texto);
                    if (F.registro != null)
                    {
                        LeerProducto((Producto)F.registro);
                    }
                    else
                    {
                        return;
                    }
                    break;
            }
        }
        private void LeerProducto(Producto producto)
        {
            registroDetalle.Codigo = producto.Codigo;
            registroDetalle.Costo = producto.Costo;
            registroDetalle.Departamento = producto.Departamento;
            registroDetalle.Descripcion = producto.Descripcion;
            registroDetalle.Inicio = producto.Existencia;
            registroDetalle.ProductoID = producto.ID;
            registroDetalle.LlevaInventario = producto.LlevaInventario.GetValueOrDefault();
            FijarPrecio(producto);
            registroDetalle.CalcularItemFactura();
            this.producto = producto;
            Enlazar();
        }

        private void FijarPrecio(Producto producto)
        {
            if (Ventax.Text != "UNIDAD")
            {
                registroDetalle.Salida = producto.UnidadesxEmpaque * registroDetalle.Cantidad;
            }
            else
            {
                registroDetalle.Salida = registroDetalle.Cantidad;
            }
            switch (this.tipoPrecio)
            {
                case "PRECIO 1":
                        registroDetalle.Precio = producto.Precio;
                        registroDetalle.PrecioConIva = producto.PrecioConIva;
                        break;
                case "PRECIO 3":
                        registroDetalle.Precio = producto.Precio3 * producto.UnidadesxEmpaque;
                        registroDetalle.PrecioConIva = producto.PrecioConIva3 * producto.UnidadesxEmpaque;
                        break;
                case "PRECIO 2":
                        registroDetalle.Precio = producto.Precio2;
                        registroDetalle.PrecioConIva = producto.PrecioConIva2;
                        break;
                case "PRECIO 4":
                        registroDetalle.Precio = producto.Precio4 * producto.UnidadesxEmpaque;
                        registroDetalle.PrecioConIva = producto.PrecioConIva4 * producto.UnidadesxEmpaque;
                        break;
             }
            this.PrecioCalcEdit.Properties.Items.Clear();
            this.PrecioCalcEdit.Properties.Items.AddRange(new Object[] { producto.Precio.GetValueOrDefault(0).ToString("n2"), producto.Precio2.GetValueOrDefault(0).ToString("n2"), producto.Precio3.GetValueOrDefault(0).ToString("n2"), producto.Precio4.GetValueOrDefault(0).ToString("n2") });
        }
        #endregion
        void CantidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            if ((double)Editor.Value <= 0)
            {
                Editor.Value = 1;
            }
            registroDetalle.Cantidad = (double)Editor.Value;
            FijarPrecio(producto);
            registroDetalle.Calcular();
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
        }
        void Ventax_Validating(object sender, CancelEventArgs e)
        {
            FijarPrecio(producto);
            registroDetalle.Calcular();
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
        }
        void PrecioCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit Editor = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            try
            {
                registroDetalle.Precio = double.Parse(Editor.Text);
            } catch 
            {
                registroDetalle.Precio = 0;
            }
            registroDetalle.PrecioConIva = ProductoExtended.PrecioConIva(registroDetalle.Precio, registroDetalle.TasaIva);
            registroDetalle.Calcular();
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.PrecioConIva = (double)Editor.Value;
            registroDetalle.Precio = ProductoExtended.PrecioBase(registroDetalle.PrecioConIva, registroDetalle.TasaIva);
            registroDetalle.Calcular();
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
        }
        void PrecioConIvaCalcEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Aceptar.PerformClick();
            }
        }
    }
}
