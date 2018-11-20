using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;

namespace HK.Formas
{

    public partial class FrmVentasNotasEntregasItem : Form
    {
        public object frmPadre = null;
        public string IdNotaEntrega { set; get; }
        public Administrativo data;
        NotaEntrega notaEntrega;
        public FrmVentasNotasEntregasItem()
        {
            InitializeComponent();
            this.KeyPreview = true;
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmNotasEntregasItem_Load);
        }
        void FrmNotasEntregasItem_Load(object sender, EventArgs e)
        {
            #region ManejoGrid
            this.gridControl1.KeyDown += new KeyEventHandler(gridControl1_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            //gridControl1.ForceInitialize();
            //gridView1.OptionsLayout.Columns.Reset();
            //if (System.IO.File.Exists(string.Format(Application.StartupPath + "\\Layouts\\NotasEntregasItem{0}.XML", OK.SystemParameters.Empresa)))
            //{
            //    this.gridControl1.DefaultView.RestoreLayoutFromXml(string.Format(Application.StartupPath + "\\Layouts\\NotasEntregasItem{0}.XML", OK.SystemParameters.Empresa), DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            //else
            //{
            //    this.gridControl1.DefaultView.RestoreLayoutFromXml(Application.StartupPath + "\\Layouts\\NotasEntregasItem.XML", DevExpress.Utils.OptionsLayoutGrid.FullLayout);
            //}
            #endregion
            #region Eventos
            this.CedulaRifButtonEdit.Validating += new CancelEventHandler(CedulaRifButtonEdit_Validating);
            this.CedulaRifButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CedulaRifButtonEdit_ButtonClick);
            this.CedulaRifButtonEdit.Properties.ValidateOnEnterKey = true;
            this.globalBolivares.Validating += new CancelEventHandler(globalBolivares_Validating);
            this.btnSeniat.Click += new EventHandler(btnSeniat_Click);
            this.btnAgregar.Click += new EventHandler(btnAgregar_Click);
            this.KeyDown += new KeyEventHandler(FrmCotizacionItem_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.Email.Click += new EventHandler(Email_Click);
            this.Imprimir.Click += new EventHandler(Imprimir_Click);
            this.btnActualizarPrecios.Click += new EventHandler(ActualizarPrecios_Click);
            this.CargarDoc.Click += new EventHandler(CargarDoc_Click);
            this.txtVendedor.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(txtVendedor_ButtonClick);
            this.txtVendedor.Validating += new CancelEventHandler(txtVendedor_Validating);
            #endregion
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.CenterToScreen();
        }
        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(Basicas.CedulaRif(CedulaRifButtonEdit.Text));
            if (Empresa != null)
            {
                notaEntrega.CedulaRif = Basicas.CedulaRif(CedulaRifButtonEdit.Text);
                notaEntrega.RazonSocial = Empresa;
                this.notaEntregaBindingSource.ResetCurrentItem();
            }
        }
        void CargarDoc_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarNotasEntrega("");
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            notaEntrega = data.CloneDocumento((NotaEntrega)f.registro);
            notaEntrega.Fecha = DateTime.Today;
            notaEntrega.Hora = DateTime.Now;
            Enlazar();
        }
        void ActualizarPrecios_Click(object sender, EventArgs e)
        {
            data.ActualizarPrecios(notaEntrega);
            Enlazar();
        }
        void Imprimir_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_NotaEntrega(notaEntrega, false);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        void Email_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            FrmReportes f = new FrmReportes();
            f.Ventas_NotaEntrega(notaEntrega, true);
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
                    if (this.Aceptar.Enabled == true && notaEntrega.MontoTotal.GetValueOrDefault(0) > 0)
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
                FrmVentasItemEdicion f = new FrmVentasItemEdicion() { tipoPrecio = notaEntrega.TipoPrecio };
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                notaEntrega.DocumentosProductos.Add(f.registroDetalle);
                this.notaEntregaProductoBindingSource.DataSource = notaEntrega.DocumentosProductos.ToList();
                this.notaEntregaProductoBindingSource.ResetBindings(true);
                notaEntrega.Calcular();
                this.notaEntregaBindingSource.ResetCurrentItem();
            }
            while (true);
        }
        #region Vendedores

        void txtVendedor_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarVendedores("");
            LeerVendedor((Vendedor)F.registro);
        }
        void txtVendedor_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.notaEntregaBindingSource.EndEdit();
            Vendedor[] T = data.GetAllVendedores(txtVendedor.Text);
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
            notaEntrega.CodigoVendedor = vendedor.Codigo;
            notaEntrega.Vendedor = vendedor.Nombre;
            this.notaEntregaBindingSource.ResetCurrentItem();
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
                this.notaEntregaBindingSource.ResetCurrentItem();
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
            this.notaEntregaBindingSource.EndEdit();
            Tercero[] T = data.GetAllClientes(Texto);
            switch (T.Length)
            {
                case 0:
                    notaEntrega.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    notaEntrega.RazonSocial = "";
                    notaEntrega.Direccion = OK.SystemParameters.Ciudad;
                    notaEntrega.TipoPrecio = "PRECIO 1";
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
            this.notaEntregaBindingSource.ResetCurrentItem();
        }
        private void Leercliente(Tercero cliente)
        {
            if (cliente != null)
            {
                notaEntrega.CedulaRif = Basicas.CedulaRif(cliente.CedulaRif);
                notaEntrega.RazonSocial = cliente.RazonSocial;
                notaEntrega.Direccion = string.IsNullOrEmpty(cliente.Direccion) ? OK.SystemParameters.Ciudad : cliente.Direccion;
                notaEntrega.Email = cliente.Email;
                notaEntrega.Telefonos = cliente.Telefonos;
                notaEntrega.TipoPrecio = cliente.TipoPrecio == null ? "PRECIO 1" : cliente.TipoPrecio;
            }
        }
        #endregion
        private void Limpiar()
        {
            notaEntrega = new NotaEntrega();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Ver()
        {
            notaEntrega = data.FindNotaDeEntrega(IdNotaEntrega);
            Enlazar();
            this.Aceptar.Enabled = false;
            this.ShowDialog();
        }
        public void Modificar()
        {
            notaEntrega = data.FindNotaDeEntrega(IdNotaEntrega);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {

            this.notaEntregaBindingSource.DataSource = notaEntrega;
            this.notaEntregaBindingSource.ResetBindings(true);
            this.notaEntregaProductoBindingSource.DataSource = notaEntrega.DocumentosProductos.ToList();
            this.notaEntregaProductoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            if (!Guardar())
                return;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private bool Guardar()
        {
            try
            {
                notaEntregaBindingSource.EndEdit();
                notaEntrega = (NotaEntrega)notaEntregaBindingSource.Current;
                string result = data.GuardarNotaDeEntrega(notaEntrega);
                if (result != null)
                {
                    MessageBox.Show(result);
                    return false;
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
            this.notaEntregaBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        void globalBolivares_Validating(object sender, CancelEventArgs e)
        {
            this.notaEntregaBindingSource.EndEdit();
            notaEntrega.Calcular();
            this.notaEntregaBindingSource.ResetCurrentItem();
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
                    if (this.gridView1.IsFocusedView)
                    {
                        DocumentosProducto i = (DocumentosProducto)this.notaEntregaProductoBindingSource.Current;
                        notaEntrega.DocumentosProductos.Remove(i);
                        this.notaEntregaProductoBindingSource.DataSource = notaEntrega.DocumentosProductos.ToList();
                        this.notaEntregaProductoBindingSource.ResetBindings(true);
                        notaEntrega.Calcular();
                        this.notaEntregaBindingSource.ResetCurrentItem();
                    }
                    e.Handled = true;
                }
            }

        }
        private void EditarItem()
        {
            DocumentosProducto detalle = (DocumentosProducto)this.notaEntregaProductoBindingSource.Current;
            if (detalle == null)
                return;
            FrmVentasItemEdicion f = new FrmVentasItemEdicion() { registroDetalle = detalle, tipoPrecio= notaEntrega.TipoPrecio };
            f.Modificar();
            notaEntrega.Calcular();
            this.notaEntregaBindingSource.ResetCurrentItem();

        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DocumentosProducto item = (DocumentosProducto)this.notaEntregaProductoBindingSource.Current;
            if (item == null)
                btnAgregar.PerformClick();
            else
                EditarItem();
        }
        #endregion
        internal void CargarCotizacion(Cotizacion cotizacion)
        {
            notaEntrega = data.CrearNotaDeEntrega(cotizacion);
            Enlazar();
            this.ShowDialog();
        }
    }
}

