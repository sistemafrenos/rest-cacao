using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using OKBL;

namespace HK.Formas
{
    public partial class FrmCotizacionesItemEdicion2 : Form
    {
        private string tipoPrecio = "PRECIO 1";
        public string TipoPrecio
        {
            get { return tipoPrecio; }
            set { tipoPrecio = value; }
        }
        ProductoBL producto;
        CotizacionProductoBL registroDetalle;
        public CotizacionProductoBL RegistroDetalle
        {
            get { return registroDetalle; }
            set { registroDetalle = value; }
        }


        public FrmCotizacionesItemEdicion2()
        {
            InitializeComponent();
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
            this.KeyDown += new KeyEventHandler(FrmCotizacionesItemEdicion_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            #endregion
            #region Seguridad            
            this.PrecioCalcEdit.Enabled= FactoryUsuarios.UsuarioActivo.PuedeCambiarPrecios.GetValueOrDefault(false);
            this.DescripcionTextEdit.Enabled = FactoryUsuarios.UsuarioActivo.PuedeModificarDescripcion.GetValueOrDefault(false);
            this.PrecioConIvaCalcEdit.Enabled = FactoryUsuarios.UsuarioActivo.PuedeCambiarPrecios.GetValueOrDefault(false);
            this.DescripcionTextEdit.Properties.AppearanceDisabled.BackColor = SystemColors.Info;
            this.DescripcionTextEdit.Properties.AppearanceDisabled.ForeColor = SystemColors.ControlText;
            this.PrecioCalcEdit.Properties.AppearanceDisabled.BackColor = SystemColors.Info;
            this.PrecioCalcEdit.Properties.AppearanceDisabled.ForeColor = SystemColors.ControlText;
            this.PrecioConIvaCalcEdit.Properties.AppearanceDisabled.BackColor = SystemColors.Info;
            this.PrecioConIvaCalcEdit.Properties.AppearanceDisabled.ForeColor = SystemColors.ControlText;
            #endregion
        }
        internal void Incluir(string tipoprecio)
        {
            this.TipoPrecio = tipoprecio;
            Enlazar();
            this.ShowDialog();
        }
        internal void Modificar(string tipoprecio)
        {
            this.TipoPrecio = tipoprecio;
            Enlazar();
            this.ShowDialog();
        }
        internal void Cancelar_Click(object sender, EventArgs e)
        {
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        internal void Aceptar_Click(object sender, EventArgs e)
        {
            cotizacionesProductoBindingSource.EndEdit();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        internal void Enlazar()
        {
            if (registroDetalle == null)
            {
                registroDetalle = new CotizacionesProducto();
                registroDetalle.TasaIva = Basicas.parametros.TasaIva;
                registroDetalle.Cantidad = 1;
                registroDetalle.Costo = 0;
                registroDetalle.Calcular();
            }
            this.cotizacionesProductoBindingSource.DataSource = registroDetalle;
            this.cotizacionesProductoBindingSource.ResetBindings(true);
        }
        #region productos
        private void CodigoButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.cotizacionesProductoBindingSource.EndEdit();
            List<Producto> T = ProductoBL.
            CargarCliente(Editor, Texto, T);
        }
        private void CodigoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarProductosVentas("");
            registro.LoadProducto(((Producto)F.registro).IdProducto);
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
        }

        private void LeerProducto(bool Buscar)
        {
            if (producto == null)
            {
                return;
            }
            registroDetalle.Item.Cantidad = 1;
            registroDetalle.Item.Costo = producto.Item.Costo;
            registroDetalle.Item.IdProducto = producto.Item.IdProducto;
            registroDetalle.Item.Descripcion = producto.Item.Descripcion;
            registroDetalle.Item.TasaIva = producto.Item.TasaIva;
            registroDetalle.Item.Departamento = producto.Item.Departamento;
            registroDetalle.Item.Codigo = producto.Item.Codigo;
            registroDetalle.Item.ExistenciaAnterior = producto.Item.Existencia;
            registroDetalle.Item.Costo = producto.Item.Costo;
            switch(this.TipoPrecio)
            {
                case "PRECIO 1":
                    registroDetalle.Precio = producto.Precio;
                    registroDetalle.PrecioConIva = producto.PrecioConIva;
                    break;
                case "PRECIO 2":
                    registroDetalle.Precio = producto.Precio2;
                    registroDetalle.PrecioConIva = producto.PrecioConIva2;
                    break;
            }
            registroDetalle.Calcular();
            this.cotizacionesProductoBindingSource.ResetCurrentItem();
        }
        private bool UbicarProducto(string Texto)
        {
            List<Producto> T = new List<Producto>();
            T = FactoryProductos.getItemsVentas(Texto);
            switch (T.Count)
            {
                case 0:
                    if (MessageBox.Show("Producto no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        producto = new Producto();
                        return false;
                    }
                    FrmProductosItemSimple nuevo = new FrmProductosItemSimple();
                    nuevo.descripcion = Texto;
                    nuevo.Incluir();
                    if (nuevo.DialogResult == DialogResult.OK)
                    {
                        Application.DoEvents();
                        producto = nuevo.registro;
                    }
                    else
                    {
                        producto = new Producto();
                        return false;
                    }
                    break;
                case 1:
                    producto = T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProductosVentas(Texto);
                    producto = (Producto)F.registro;
                    break;
            }
            LeerProducto(false);
            return true;
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
        }
        void PrecioCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registroDetalle.Precio = (double)Editor.Value;
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
        #endregion
    }
}
