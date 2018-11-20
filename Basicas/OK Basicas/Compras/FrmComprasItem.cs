using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmComprasItem : Form
    {
        public string ID { set; get; }
        public Administrativo data;
        public Compra compra;
        public FrmComprasItem()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            compra = new Compra();
            Load += FrmComprasItem_Load;
        }
        void FrmComprasItem_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            #region Eventos
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
            KeyDown += FrmComprasItem_KeyDown;
            DescuentoCalcEdit.Validating += DescuentoCalcEdit_Validating;
            MontoImpuestosLicoresCalcEdit.Validated += MontoImpuestosLicoresCalcEdit_Validated;
            FechaDateEdit.Validating += FechaDateEdit_Validating;
            btnAgregarItems.Click += btnAgregarItems_Click;
            CodigoCuenta.Validating += CodigoCuenta_Validating;
            CodigoCuenta.ButtonClick += CodigoCuenta_ButtonClick;
            toolEspera.Click += new EventHandler(toolEspera_Click);
            toolRecuperar.Click += new EventHandler(toolRecuperar_Click);
            #endregion
            #region Tercero
            CedulaRifTextEdit.Validating += CedulaRifButtonEdit_Validating;
            CedulaRifTextEdit.ButtonClick += CedulaRifButtonEdit_ButtonClick;
            #endregion
            #region Productos
            gridControl1.KeyDown += gridControl1_KeyDown;
            #endregion
            Height = Screen.PrimaryScreen.Bounds.Height - 100;
            Width = Screen.PrimaryScreen.Bounds.Width - 50;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridView1.OptionsView.EnableAppearanceOddRow = true;
            gridView1.OptionsView.EnableAppearanceEvenRow = true;
            gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            CenterToScreen();
        }

        void toolRecuperar_Click(object sender, EventArgs e)
        {
                FrmBuscarEntidades f = new FrmBuscarEntidades();
                f.BuscarComprasAbiertas("");
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
                compra = data.FindCompra(((Compra)f.registro).ID);
                compra.Fecha = DateTime.Today;
                compra.Hora = DateTime.Now;
                compra.Calcular();
                Enlazar();
        }

        void toolEspera_Click(object sender, EventArgs e)
        {
            try
            {
                compraBindingSource.EndEdit();
                comprasProductoBindingSource.EndEdit();
                compra = (Compra)compraBindingSource.Current;
                var result = data.GuardarCompra(compra, "COMPRA ABIERTA", true);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                    return;
                }
                this.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(OK.ManejarException(x));
            }
        }
        #region Proveedores
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarProveedores("");
            if (F.registro != null)
            {
                LeerProveedor((Tercero)F.registro);
                this.compraBindingSource.ResetCurrentItem();
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
            this.compraBindingSource.EndEdit();
            Tercero[] T = data.GetAllProveedores(Texto);
            switch (T.Length)
            {
                case 0:
                    compra.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    compra.RazonSocial = "";
                    compra.Direccion = OK.SystemParameters.Ciudad;
                    compra.TipoPrecio = "PRECIO 1";
                    break;
                case 1:
                    LeerProveedor(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProveedores(Texto);
                    if (F.registro != null)
                    {
                        LeerProveedor((Tercero)F.registro);
                    }
                    break;
            }
            this.compraBindingSource.ResetCurrentItem();
        }
        private void LeerProveedor(Tercero proveedor)
        {
            if (proveedor != null)
            {
                var p = data.FindProveedor(proveedor.ID); 
                //compra.Tercero = data.FindProveedor(proveedor.ID);
                compra.Tercero = p;
                compra.CedulaRif = Basicas.CedulaRif(proveedor.CedulaRif);
                compra.RazonSocial = proveedor.RazonSocial;
                compra.Direccion = string.IsNullOrEmpty(proveedor.Direccion) ? OK.SystemParameters.Ciudad : proveedor.Direccion;
                compra.Email = proveedor.Email;
                compra.Telefonos = proveedor.Telefonos;
                compra.TipoPrecio = proveedor.TipoPrecio == null ? "PRECIO 1" : proveedor.TipoPrecio;
            }
        }
        #endregion
        #region Cuentas
        private void CodigoCuenta_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
            {
                return;
            }
            var T = data.GetAllMaestroCuenta(Editor.Text);
            switch (T.Length)
            {
                case 0:
                    LeerCuenta(new MaestroDeCuenta());
                    break;
                case 1:
                    LeerCuenta(T[0]);
                    break;
                default:
                    using (var F = new FrmBuscarEntidades())
                    {
                        F.BuscarCuentas(Editor.Text);
                        LeerCuenta(new MaestroDeCuenta());
                        if (F.registro != null)
                        {
                            LeerCuenta((MaestroDeCuenta)F.registro);
                        }
                    }
                    break;
            }
        }
        private void CodigoCuenta_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            using (var F = new FrmBuscarEntidades())
            {
                F.BuscarCuentas(string.Empty);
                if (F.registro != null)
                {
                    LeerCuenta((MaestroDeCuenta)F.registro);
                }
            }
        }
        private void LeerCuenta(MaestroDeCuenta cuenta)
        {
            compra.CodigoCuenta = cuenta.Codigo;
            compra.DescripcionCuenta = cuenta.Descripcion;
            compraBindingSource.ResetCurrentItem();
        }
        #endregion
        void btnAgregarItems_Click(object sender, EventArgs e)
        {
            if(Aceptar.Enabled)
               AgregarRegistro();
        }
        private void AgregarRegistro()
        {
            do
            {
                using (FrmComprasItemEdcion f = new FrmComprasItemEdcion())
                {
                    f.data = data;
                    f.Incluir();
                    if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                        return;
                    compra.DocumentosProductos.Add(f.registroDetalle);
                    compra.Calcular();
                    compraBindingSource.ResetCurrentItem();
                    comprasProductoBindingSource.DataSource = compra.DocumentosProductos.ToList();
                    comprasProductoBindingSource.ResetBindings(true);
                }
            }
            while (true);
        }
        void FechaDateEdit_Validating(object sender, CancelEventArgs e)
        {
            if (compra.Tercero != null)
                compra.Vence = FechaDateEdit.DateTime.AddDays((double)compra.Tercero.DiasCredito.GetValueOrDefault(0));
            else
                compra.Vence = FechaDateEdit.DateTime;
        }
        void MontoImpuestosLicoresCalcEdit_Validated(object sender, EventArgs e)
        {
            compraBindingSource.EndEdit();
            compra.Totalizar();
        }
        void DescuentoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            compraBindingSource.EndEdit();
            compra.Totalizar();
        }
        private void Limpiar()
        {
            compra = new Compra();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            ShowDialog();
        }
        public void Ver()
        {
            btnAgregarItems.Enabled = false;
            compra = data.FindCompra(ID);
            Enlazar();
            Aceptar.Enabled = false;
            ShowDialog();
        }
        public void Modificar()
        {
            compra = data.FindCompra(ID);
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {
            compraBindingSource.DataSource = compra;
            compraBindingSource.ResetBindings(true);
            comprasProductoBindingSource.DataSource = compra.DocumentosProductos.ToList();
            comprasProductoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                compraBindingSource.EndEdit();
                comprasProductoBindingSource.EndEdit();
                compra = (Compra)compraBindingSource.Current;
                var f = new FrmAdministrativo_ComprasItemCerrar() 
                { registro = compra };
                f.ShowDialog();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                    return;
                compraBindingSource.EndEdit();
                compra = (Compra)compraBindingSource.Current;
                string result = data.ProcesarCompra(compra);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageBox.Show(result);
                    return;
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            compraBindingSource.ResetCurrentItem();
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void FrmComprasItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    btnAgregarItems.PerformClick();
                    break;
                case Keys.F3:
                    toolEspera.PerformClick();
                    break;
                case Keys.F4:
                    toolRecuperar.PerformClick();
                    break;
                case Keys.Escape:
                    if (Aceptar.Enabled == true && compra.MontoTotal.GetValueOrDefault(0) > 0)
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
            }
        }
        #region ManejoDocumentoProductos
        private void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                gridView1.MoveBy(0);
            }
            if (gridView1.ActiveEditor == null && Aceptar.Enabled)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.Back)
                {
                    if (gridView1.IsFocusedView)
                    {
                        DocumentosProducto i = (DocumentosProducto)comprasProductoBindingSource.Current;
                        compra.DocumentosProductos.Remove(i);
                        compra.Calcular();
                        comprasProductoBindingSource.DataSource = compra.DocumentosProductos.ToList();
                        comprasProductoBindingSource.ResetBindings(true);
                        compraBindingSource.ResetBindings(true);
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
            DocumentosProducto i = (DocumentosProducto)comprasProductoBindingSource.Current;
            using (FrmComprasItemEdcion f = new FrmComprasItemEdcion())
            {
                f.data = data;
                f.registroDetalle = i;
                f.Modificar();
            }
            compra.Calcular();
            compraBindingSource.ResetCurrentItem();
        }
        #endregion
    }
}
