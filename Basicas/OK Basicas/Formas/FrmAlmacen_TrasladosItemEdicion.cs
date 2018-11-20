using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmAlmacen_TrasladosItemEdicion : Form
    {
        private Producto producto;
        public TrasladosProducto registroDetalle;
        public string idDeposito = null;
        public FrmAlmacen_TrasladosItemEdicion()
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
            this.CodigoProveedorTextEdit.Validating += new CancelEventHandler(CodigoProveedorTextEdit_Validating);
            this.CodigoProveedorTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CodigoProveedorTextEdit_ButtonClick);
            this.CantidadCalcEdit.Validating += new CancelEventHandler(CantidadCalcEdit_Validating);
            #endregion
            #region eventos
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmCotizacionesItemEdicion_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            #endregion
        }
        internal void Incluir()
        {
            Enlazar();
            this.ShowDialog();
        }
        internal void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        internal void Cancelar_Click(object sender, EventArgs e)
        {
            this.trasladosProductoBindingSource.ResetCurrentItem();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        internal void Aceptar_Click(object sender, EventArgs e)
        {
            var db = new DatosEntities(OK.CadenaConexion);
            trasladosProductoBindingSource.EndEdit();
            registroDetalle.IdTrasladoDetalle = registroDetalle.IdTrasladoDetalle == null ? TrasladosProducto.GetID() : registroDetalle.IdTrasladoDetalle;
            if (!db.Entry(registroDetalle).GetValidationResult().IsValid)
            {
                Basicas.ErroresDeValidacion(db.Entry(registroDetalle).GetValidationResult());
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        internal void Enlazar()
        {
            if (registroDetalle == null)
            {
                registroDetalle = new TrasladosProducto();
                registroDetalle.Cantidad = 1;
            }
            this.trasladosProductoBindingSource.DataSource = registroDetalle;
            this.trasladosProductoBindingSource.ResetBindings(true);
        }
        #region productos
        void CodigoProveedorTextEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit Editor = (DevExpress.XtraEditors.TextEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            registroDetalle = (TrasladosProducto)this.trasladosProductoBindingSource.Current;
            if (UbicarProducto(Texto))
            {
                if (producto == null)
                {
                    Editor.Undo();
                    e.Cancel = true;
                    return;
                }
                LeerProducto(false);
                Editor.Text = producto.Plu;
                if (string.IsNullOrEmpty(producto.Descripcion))
                {
                    Editor.Undo();
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                LeerProducto(false);
                Editor.Undo();
                e.Cancel = true;
                return;
            }
        }
        private void CodigoProveedorTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            registroDetalle = (TrasladosProducto)this.trasladosProductoBindingSource.Current;
            if (UbicarProducto(""))
            {
                LeerProducto(false);
            }
        }
        private void LeerProducto(bool Buscar)
        {
            if (producto == null)
            {
                return;
            }
            registroDetalle = (TrasladosProducto)this.trasladosProductoBindingSource.Current;
            this.CodigoProveedorTextEdit.Text = producto.Codigo;
            registroDetalle.Cantidad = 1;
          //  registroDetalle.ExistenciaAnterior = FactoryDepositos.Existencia(idDeposito, producto.IdProducto);
            registroDetalle.IdProducto = producto.IdProducto;
            registroDetalle.Descripcion = producto.Descripcion;
            registroDetalle.CodigoProveedor = producto.CodigoProveedor;
            registroDetalle.Departamento = producto.Departamento;
            registroDetalle.UnidadMedida = producto.UnidadMedida;
            registroDetalle.ExistenciaAnterior = producto.Existencia;
            this.trasladosProductoBindingSource.ResetCurrentItem();
        }
        private bool UbicarProducto(string Texto)
        {
            List<Producto> T = new List<Producto>();
            T = FactoryProductos.getItems(Texto);
            switch (T.Count)
            {
                case 0:
                    if (MessageBox.Show("Suministro no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        producto = new Producto();
                        return false;
                    }
                    FrmProductosItemSimple nuevo = new FrmProductosItemSimple();
                    nuevo.descripcion = Texto;
                    nuevo.Incluir();
                    if (nuevo.DialogResult == DialogResult.OK)
                    {
                        producto = nuevo.registro;
                    }
                    else
                    {
                        Application.DoEvents();
                        producto = new Producto();
                        return false;
                    }
                    break;
                case 1:
                    producto = T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProductos(Texto);
                    producto = (Producto)F.registro;
                    break;
            }
            LeerProducto(false);
            return true;
        }
        private void CantidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            if ((double)Editor.Value <= 0)
            {
                Editor.Value = 1;
                return;
            }
            if (this.trasladosProductoBindingSource.Current == null)
                return;
            registroDetalle = (TrasladosProducto)this.trasladosProductoBindingSource.Current;
            registroDetalle.Cantidad = (double)Editor.Value;
            Aceptar.PerformClick();
        }
        #endregion
    }
}
