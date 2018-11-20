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
    public partial class FrmCotizacionesItem2 : Form
    {
        public FrmCotizacionesItem2()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCotizacionesItem_Load);
        }

        public CotizacionBL registro = new CotizacionBL();
        void FrmCotizacionesItem_Load(object sender, EventArgs e)
        {
            #region ManejoGrid
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            gridControl1.ForceInitialize();
            gridView1.OptionsLayout.Columns.Reset();
            if (System.IO.File.Exists(string.Format(Application.StartupPath + "\\Layouts\\CotizacionesItem{0}.XML", Basicas.parametros.Empresa)))
            {
                this.gridControl1.DefaultView.RestoreLayoutFromXml(string.Format(Application.StartupPath + "\\Layouts\\CotizacionesItem{0}.XML", Basicas.parametros.Empresa), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            }
            else
            {
                this.gridControl1.DefaultView.RestoreLayoutFromXml(Application.StartupPath + "\\Layouts\\CotizacionesItem.XML", DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            }
            #endregion
            #region Seguridad
            //if (FactoryUsuarios.UsuarioActivo.TipoUsuario != "SUPER USUARIO")
            //{
            //    if (FactoryUsuarios.UsuarioActivo.PuedeCambiarVendedor.GetValueOrDefault(false))
            //    {
            //        this.txtVendedor.Enabled = false;
            //    }
            //}
            #endregion Seguridad
            #region Eventos
            this.CedulaRifButtonEdit.Validating+=new CancelEventHandler(CedulaRifButtonEdit_Validating);
            this.CedulaRifButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CedulaRifButtonEdit_ButtonClick);
            this.globalBolivares.Validating += new CancelEventHandler(globalBolivares_Validating);
            this.btnAgregar.Click+=new EventHandler(btnAgregar_Click);
            this.KeyDown += new KeyEventHandler(FrmCotizacionItem_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.Email.Click += new EventHandler(Email_Click);
            this.Imprimir.Click += new EventHandler(Imprimir_Click);
            this.btnActualizarPrecios.Click += new EventHandler(ActualizarPrecios_Click);
            this.CargarDoc.Click += new EventHandler(CargarDoc_Click);
            //this.txtVendedor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtVendedor_ButtonClick);
            //this.txtVendedor.Validating += new CancelEventHandler(txtVendedor_Validating);
            #endregion
            this.KeyPreview = true;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.CenterToScreen();
        }

        void CargarDoc_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarCotizaciones("");
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            registro.Item = (Cotizacion)registro.Clone();
            Enlazar();
        }
        void ActualizarPrecios_Click(object sender, EventArgs e)
        {
            registro.ActualizarPrecios();
            this.cotizacioneBindingSource.ResetCurrentItem();
        }
        void Imprimir_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            registro.Save();
            f.Cotizacion(registro.Item,false);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        void Email_Click(object sender, EventArgs e)
        {
            FrmReportes f = new FrmReportes();
            registro.Save();
            f.Cotizacion(registro.Item, true);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        void FrmCotizacionItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAgregar.PerformClick();
                    break;
                case Keys.Escape:
                    if (this.Aceptar.Enabled == true && registro.Item.MontoTotal.GetValueOrDefault(0) > 0)
                    {
                        if (MessageBox.Show("Esta seguro de salir", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            Cancelar.PerformClick();
                            e.Handled = true;
                        }
                    }
                    else
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
        void btnAgregar_Click(object sender, EventArgs e)
        {
            do
            {
                FrmCotizacionesItemEdicion f = new FrmCotizacionesItemEdicion();
                //// todo
 
                f.Incluir("PRECIO 1");
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                registro.Item.CotizacionesProductos.Add(f.registroDetalle);
                this.cotizacionesProductoBindingSource.DataSource = registro.Item.CotizacionesProductos.ToList();
                this.cotizacionesProductoBindingSource.ResetBindings(true);
                registro.Totalizar();
            } while (true);
        }

        #region Clientes
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            registro.LoadCliente(((Cliente)F.registro).CedulaRif);
            this.cotizacioneBindingSource.ResetCurrentItem();
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.cotizacioneBindingSource.EndEdit();
            List<Cliente> T =  registro.TipoPrecio1 FactoryClientes.getItems(Texto);
            CargarCliente(Editor, Texto, T);
        }
        private void CargarCliente(DevExpress.XtraEditors.ButtonEdit Editor, string Texto, List<Cliente> T)
        {
            switch (T.Count)
            {
                case 0:
                    registro.LoadCliente(Editor.Text);
                    registro.Item.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    break;
                case 1:
                    registro.LoadCliente(T[0].CedulaRif);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarClientes(Texto);
                    registro.LoadCliente(((Cliente)F.registro).CedulaRif);
                    break;
            }
            this.cotizacioneBindingSource.ResetCurrentItem();
        }
        void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.cotizacioneBindingSource.EndEdit();
            List<Cliente> T = FactoryClientes.getItems(Texto);
            CargarCliente(Editor, Texto, T);
        }
        #endregion
        private void Limpiar()
        {
            registro = new CotizacionBL();
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
            this.cotizacioneBindingSource.DataSource = registro.Item;
            this.cotizacioneBindingSource.ResetBindings(true);
            this.cotizacionesProductoBindingSource.DataSource = registro.Item.CotizacionesProductos.ToList();
            this.cotizacionesProductoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                cotizacioneBindingSource.EndEdit();
                if (!registro.Validate())
                {
                    Basicas.ErroresDeValidacion(registro.GetErrores());
                }
                if(registro.Save())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.cotizacioneBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        void globalBolivares_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registro.Item.Descuentos = (double)Editor.Value;
            registro.Totalizar();
        }
        #region ManejoDocumentoProductos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                EditarItem();                
            }

            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
                {
                    if (this.gridView1.IsFocusedView)
                    {
                        CotizacionesProducto i = (CotizacionesProducto)this.cotizacionesProductoBindingSource.Current;
                        registro.Item.CotizacionesProductos.Remove(i);
                        registro.Totalizar();
                    }
                    e.Handled = true;
                }
            }

        }
        private void EditarItem()
        {
            CotizacionesProducto item = (CotizacionesProducto)this.cotizacionesProductoBindingSource.Current;
            if (item == null)
                return;
            FrmCotizacionesItemEdicion f = new FrmCotizacionesItemEdicion();
            f.registroDetalle = item;
            f.Modificar(registro.TipoPrecio);
            registro.Totalizar();
            this.cotizacioneBindingSource.ResetCurrentItem();
        }
        void cotizacioneBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            registro.Totalizar();
            this.cotizacioneBindingSource.ResetCurrentItem();
        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            CotizacionesProducto item = (CotizacionesProducto)this.cotizacionesProductoBindingSource.Current;
            if (item == null)
                btnAgregar.PerformClick();
            else
                EditarItem();
        }
        #endregion
    }
}

