using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_ProductosDescargar : Form
    {
        public Administrativo data;
        private Producto producto;
        private DocumentosProducto registroDetalle;
        public FrmTablas_ProductosDescargar()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            registroDetalle = new DocumentosProducto();
            this.Load += new EventHandler(Frm_Load);
        }
        void Frm_KeyDown(object sender, KeyEventArgs e)
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
                default:
                    break;
            }
        }
        void Frm_Load(object sender, EventArgs e)
        {
            #region Productos
            this.CodigoTextEdit.Validating += new CancelEventHandler(CodigoTextEdit_Validating);
            this.CodigoTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CodigoTextEdit_ButtonClick);
            this.CantidadCalcEdit.Validating += new CancelEventHandler(CantidadCalcEdit_Validating);
            this.Ventax.Validating += new CancelEventHandler(Ventax_Validating);
            this.CantidadCalcEdit.Enter += new EventHandler(CantidadCalcEdit_Enter);
            #endregion
            #region eventos
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            #endregion
            Ventax.Properties.Items.AddRange(new Object[] { "UNIDAD", "EMPAQUE" });
            Enlazar();
        }

        void Ventax_Validating(object sender, CancelEventArgs e)
        {
            fijarCantidad();
        }

        void CantidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            fijarCantidad();
        }
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
            this.documentoProductoBindingSource.ResetCurrentItem();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        internal void Aceptar_Click(object sender, EventArgs e)
        {
            documentoProductoBindingSource.EndEdit();
            string retorno = data.GuardarDescarga((DocumentosProducto)documentoProductoBindingSource.Current);
            if (!string.IsNullOrEmpty(retorno))
            {
                MessageBox.Show(retorno, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        internal void Enlazar()
        {
            registroDetalle.Cantidad = 1;
            this.documentoProductoBindingSource.DataSource = registroDetalle;
            this.documentoProductoBindingSource.ResetBindings(true);
        }
        #region productos
        private void fijarCantidad()
        {
            if (registroDetalle.Presentacion != "UNIDAD")
                registroDetalle.Salida = registroDetalle.UnidadesxEmpaque * registroDetalle.Cantidad;
            else
                registroDetalle.Salida = registroDetalle.Cantidad;
            this.CantidadNetaCalcEdit.Value = (decimal)registroDetalle.Salida;
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
            registroDetalle.Salida = 1;
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
            this.documentoProductoBindingSource.DataSource = registroDetalle;
            this.documentoProductoBindingSource.ResetBindings(true);
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
    }
}
