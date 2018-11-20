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
    public partial class FrmAlmacen_TrasladosItem : Form
    {
        public Traslado registro = new Traslado();
        private Producto Producto = null;
        //private TrasladosProducto registroDetalle = null;
        DatosEntities db = new DatosEntities(OK.CadenaConexion);
        public FrmAlmacen_TrasladosItem()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmTrasladosItem_Load);
        }
        void FrmTrasladosItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            #region Eventos
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmTrasladosItem_KeyDown);
            this.btnAgregarItems.Click += new EventHandler(btnAgregarItems_Click);
            this.OrigenComboBoxEdit.Properties.Items.AddRange(FactoryDepositos.getDepositos());
            this.DestinoComboBoxEdit.Properties.Items.AddRange(FactoryDepositos.getDepositos());
            #endregion
            #region Productos
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridView1_ValidateRow);
            this.gridControl1.KeyDown+=new KeyEventHandler(gridControl1_KeyDown);
            #endregion
        }
        void btnAgregarItems_Click(object sender, EventArgs e)
        {
            AgregarRegistro();
        }
        private void AgregarRegistro()
        {
            do
            {
                FrmAlmacen_TrasladosItemEdicion f = new FrmAlmacen_TrasladosItemEdicion();
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                registro.TrasladosProductos.Add(f.registroDetalle);
                this.trasladosProductoBindingSource.DataSource = registro.TrasladosProductos;
                this.trasladosProductoBindingSource.ResetBindings(true);
                this.gridControl1.DataSource = registro.TrasladosProductos.ToList();
                this.gridControl1.RefreshDataSource();
                this.gridView1.BestFitColumns();
                //registro.Totalizar();
            } while (true);
        }
        private void Limpiar()
        {
            DatosEntities db = new DatosEntities(OK.CadenaConexion);
            registro = new Traslado();
            registro.Fecha = DateTime.Today;
            registro.IdUsuario = FactoryUsuarios.UsuarioActivo.IdUsuario;
            registro.Origen = Basicas.parametros.DepositoCompras;
            registro.Destino = Basicas.parametros.DepositoVentas;
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Ver()
        {
            Enlazar();
            this.Aceptar.Enabled = false;
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            if (registro == null)
            {
                Limpiar();
            }
            this.trasladosBindingSource.DataSource = registro;
            this.trasladosBindingSource.ResetBindings(true);
            this.trasladosProductoBindingSource.DataSource = registro.TrasladosProductos;
            this.trasladosProductoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                trasladosBindingSource.EndEdit();
                trasladosProductoBindingSource.EndEdit();
                registro = (Traslado)trasladosBindingSource.Current;
                //registro.Totalizar();
                registro.IdTraslado = registro.IdTraslado == null ? TrasladosProducto.GetID() : registro.IdTraslado;
                if (!db.Entry(registro).GetValidationResult().IsValid)
                {
                    Basicas.ErroresDeValidacion(db.Entry(registro).GetValidationResult());
                    return;
                }
                if (!Guardar())
                    return;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        private bool Guardar()
        {
            try
            {
                registro.IdTraslado = registro.IdTraslado==null?Traslado.GetID():registro.IdTraslado;
                registro.IdUsuario = FactoryUsuarios.UsuarioActivo.IdUsuario;
                if (!db.Entry(registro).GetValidationResult().IsValid)
                {
                    Basicas.ErroresDeValidacion(db.Entry(registro).GetValidationResult());
                    return false;
                }
                if (db.Entry(registro).State == EntityState.Detached)
                {
                    db.Traslados.Add(registro);
                }
                foreach (HK.TrasladosProducto p in registro.TrasladosProductos)
                {
                    if (p.IdTrasladoDetalle == null)
                    {
                        p.IdTrasladoDetalle = TrasladosProducto.GetID();
                    }
                }
                db.SaveChanges();
                FactoryTraslados.Inventarios(registro);
                return true;
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
                return false;
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.trasladosBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmTrasladosItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    this.btnAgregarItems.PerformClick();
                    break;
                case Keys.Escape:
                    if (MessageBox.Show("Esta seguro de salir", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Cancelar.PerformClick();
                        e.Handled = true;
                    }
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        #region ManejoDocumentoProductos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                gridView1.MoveBy(0);
            }
            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
                {
                    if (this.gridView1.IsFocusedView)
                    {
                        TrasladosProducto i = (TrasladosProducto)this.trasladosProductoBindingSource.Current;
                        registro.TrasladosProductos.Remove(i);
                    }
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Return)
                {
                    EditarRegistro();
                    e.Handled = true;
                }
                if (e.KeyCode == Keys.Insert)
                {
                    AgregarRegistro();
                }
            }
        }
        private void EditarRegistro()
        {
            TrasladosProducto i = (TrasladosProducto)this.trasladosProductoBindingSource.Current;
            FrmAlmacen_TrasladosItemEdicion f = new FrmAlmacen_TrasladosItemEdicion();
            f.registroDetalle = i;
            f.Modificar();
        }
        void TrasladosProductoBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
         //   registro.Totalizar();
            this.trasladosBindingSource.ResetCurrentItem();
        }
        void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView item = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if(Producto!=null)
                if (Producto.IdProducto == null)
                {
                    gridView1.ActiveEditor.Reset();
                    item.CancelUpdateCurrentRow();
                }
        }
        #endregion
    }
}
