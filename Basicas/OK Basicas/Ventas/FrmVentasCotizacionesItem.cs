using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;

namespace HK.Formas
{

    public partial class FrmVentasCotizacionesItem : Form
    {
        public string IdCotizacion { set; get; }
        Cotizacion cotizacion;
        public Administrativo data;
        public FrmVentasCotizacionesItem()
        {
            InitializeComponent();
            KeyPreview = true;
            if (data == null)
                data = new Administrativo();
            Load += FrmCotizacionesItem_Load;
        }
        void FrmCotizacionesItem_Load(object sender, EventArgs e)
        {
            #region ManejoGrid
            gridControl1.KeyDown += gridControl1_KeyDown;
            gridControl1.DoubleClick += gridControl1_DoubleClick;
            //gridControl1.ForceInitialize();
            //gridView1.OptionsLayout.Columns.Reset();
            //if (System.IO.File.Exists(string.Format(Application.StartupPath + "\\Layouts\\CotizacionesItem{0}.XML", OK.SystemParameters.Empresa)))
            //{
            //    gridControl1.DefaultView.RestoreLayoutFromXml(string.Format(Application.StartupPath + "\\Layouts\\CotizacionesItem{0}.XML", OK.SystemParameters.Empresa), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            //else
            //{
            //    gridControl1.DefaultView.RestoreLayoutFromXml(Application.StartupPath + "\\Layouts\\CotizacionesItem.XML", DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            #endregion
            #region Eventos
            CedulaRifButtonEdit.Validating += new CancelEventHandler(CedulaRifButtonEdit_Validating);
            CedulaRifButtonEdit.ButtonClick += CedulaRifButtonEdit_ButtonClick;
            CedulaRifButtonEdit.Properties.ValidateOnEnterKey = true;
            globalBolivares.Validating += new CancelEventHandler(globalBolivares_Validating);
            btnSeniat.Click += new EventHandler(btnSeniat_Click);
            btnAgregar.Click += new EventHandler(btnAgregar_Click);
            KeyDown += new KeyEventHandler(FrmCotizacionItem_KeyDown);
            Aceptar.Click += new EventHandler(Aceptar_Click);
            Cancelar.Click += new EventHandler(Cancelar_Click);
            Email.Click += new EventHandler(Email_Click);
            Imprimir.Click += new EventHandler(Imprimir_Click);
            btnActualizarPrecios.Click += new EventHandler(ActualizarPrecios_Click);
            CargarDoc.Click += new EventHandler(CargarDoc_Click);
            txtVendedor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtVendedor_ButtonClick);
            txtVendedor.Validating += new CancelEventHandler(txtVendedor_Validating);
            #endregion
            Width = Screen.PrimaryScreen.Bounds.Width - 50;
            Height = Screen.PrimaryScreen.Bounds.Height - 100;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            CenterToScreen();
        }

        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(Basicas.CedulaRif(CedulaRifButtonEdit.Text));
            if (Empresa != null)
            {
                cotizacion.CedulaRif = Basicas.CedulaRif(CedulaRifButtonEdit.Text);
                cotizacion.RazonSocial = Empresa;
                cotizacioneBindingSource.ResetCurrentItem();
            }
        }
        void CargarDoc_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarCotizaciones("");
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            cotizacion = data.CloneDocumento((Cotizacion)f.registro);
            cotizacion.Fecha = DateTime.Today;
            cotizacion.Hora = DateTime.Now;
            Enlazar();
        }
        void Imprimir_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            using (FrmReportes f = new FrmReportes())
            {
                f.Ventas_Cotizacion(cotizacion, false);
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        void Email_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_Cotizacion(cotizacion, true);
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        void FrmCotizacionItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAgregar.PerformClick();
                    break;
                case Keys.Escape:
                    if (Aceptar.Enabled == true && cotizacion.MontoTotal.GetValueOrDefault(0) > 0)
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
                    Aceptar.PerformClick();
                    e.Handled = true;
                    break;
                default: break;
            }
        }
        void btnAgregar_Click(object sender, EventArgs e)
        {
            do
            {
                FrmVentasItemEdicion f = new FrmVentasItemEdicion()
                {
                    data = data,
                    tipoPrecio = cotizacion.TipoPrecio 
                };
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                cotizacion.DocumentosProductos.Add(f.registroDetalle);
                cotizacionesProductoBindingSource.DataSource = cotizacion.DocumentosProductos.ToList();
                cotizacionesProductoBindingSource.ResetBindings(true);
                cotizacion.Calcular();
                cotizacioneBindingSource.ResetCurrentItem();
            }
            while (true);
        }
        #region Vendedores

        void txtVendedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (FrmBuscarEntidades F = new FrmBuscarEntidades())
            {
                F.BuscarVendedores("");
                LeerVendedor((Vendedor)F.registro);
            }
        }
        void txtVendedor_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            cotizacioneBindingSource.EndEdit();
            Vendedor[] T = data.GetAllVendedores(Editor.Text);
            switch (T.Length)
            {
                case 0:
                    LeerVendedor(null);
                    break;
                case 1:
                    LeerVendedor(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarVendedores(Texto);
                    LeerVendedor((Vendedor)F.registro);
                    break;
            }
        }
        private void LeerVendedor(Vendedor vendedor)
        {
            if (vendedor == null)
                vendedor = new Vendedor();
            cotizacion.CodigoVendedor = vendedor.Codigo;
            cotizacion.Vendedor = vendedor.Nombre;
            cotizacioneBindingSource.ResetCurrentItem();
        }

        #endregion
        #region Clientes
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            if (F.registro != null)
            {
                Leercliente((Tercero)F.registro);
                this.cotizacioneBindingSource.ResetCurrentItem();
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.cotizacioneBindingSource.EndEdit();
            Tercero[] T = data.GetAllClientes(Texto);
            switch (T.Length)
            {
                case 0:
                    cotizacion.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    cotizacion.RazonSocial = "";
                    cotizacion.Direccion = OK.SystemParameters.Ciudad;
                    cotizacion.TipoPrecio = "PRECIO 1";
                    break;
                case 1:
                    Leercliente(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarClientes(Texto);
                    if (F.registro != null)
                    {
                        Leercliente((Tercero)F.registro);
                    }
                    break;
            }
            this.cotizacioneBindingSource.ResetCurrentItem();
        }
        private void Leercliente(Tercero cliente)
        {
            if (cliente != null)
            {
                cotizacion.CedulaRif = Basicas.CedulaRif(cliente.CedulaRif);
                cotizacion.RazonSocial = cliente.RazonSocial;
                cotizacion.Direccion = string.IsNullOrEmpty(cliente.Direccion) ? OK.SystemParameters.Ciudad : cliente.Direccion;
                cotizacion.Email = cliente.Email;
                cotizacion.Telefonos = cliente.Telefonos;
                cotizacion.TipoPrecio = cliente.TipoPrecio == null ? "PRECIO 1" : cliente.TipoPrecio;
            }
        }
        #endregion
        private void Limpiar()
        {
            cotizacion = new Cotizacion();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            ShowDialog();
        }
        public void Ver()
        {
            cotizacion = data.FindCotizacion(IdCotizacion);
            Enlazar();
            Aceptar.Enabled = false;
            ShowDialog();
        }
        public void Modificar()
        {
            cotizacion = data.FindCotizacion(IdCotizacion);
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {

            cotizacioneBindingSource.DataSource = cotizacion;
            cotizacioneBindingSource.ResetBindings(true);
            cotizacionesProductoBindingSource.DataSource = cotizacion.DocumentosProductos.ToList();
            cotizacionesProductoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            DialogResult = DialogResult.OK;
            Close();
        }
        private bool Guardar()
        {
            try
            {
                cotizacioneBindingSource.EndEdit();
                cotizacion = (Cotizacion)cotizacioneBindingSource.Current;
                string result = data.GuardarCotizacion(cotizacion);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                    return false;
                    ;
                }
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
                return false;
            }
            return true;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            cotizacioneBindingSource.ResetCurrentItem();
            DialogResult = DialogResult.Cancel;
            Close();
        }
        void ActualizarPrecios_Click(object sender, EventArgs e)
        {
            data.ActualizarPrecios(cotizacion);
            Enlazar();
        }
        void globalBolivares_Validating(object sender, CancelEventArgs e)
        {
            cotizacioneBindingSource.EndEdit();
            cotizacion.Calcular();
            cotizacioneBindingSource.ResetCurrentItem();
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
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Back)
                {
                    if (gridView1.IsFocusedView)
                    {
                        DocumentosProducto i = (DocumentosProducto)cotizacionesProductoBindingSource.Current;
                        cotizacion.DocumentosProductos.Remove(i);
                        cotizacionesProductoBindingSource.DataSource = cotizacion.DocumentosProductos.ToList();
                        cotizacionesProductoBindingSource.ResetBindings(true);
                        cotizacion.Calcular();
                        cotizacioneBindingSource.ResetCurrentItem();
                    }
                    e.Handled = true;
                }
            }

        }
        private void EditarItem()
        {
            DocumentosProducto detalle = (DocumentosProducto)cotizacionesProductoBindingSource.Current;
            if (detalle == null)
                return;
            FrmVentasItemEdicion f = new FrmVentasItemEdicion()
            {  
                data = data,
                tipoPrecio = cotizacion.TipoPrecio,
                registroDetalle = detalle 
            };
            f.Modificar();
            cotizacion.Calcular();
            cotizacioneBindingSource.ResetCurrentItem();

        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DocumentosProducto item = (DocumentosProducto)cotizacionesProductoBindingSource.Current;
            if (item == null)
                btnAgregar.PerformClick();
            else
                EditarItem();
        }
        #endregion
    }
}

