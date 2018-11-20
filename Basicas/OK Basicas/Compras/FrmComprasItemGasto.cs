using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;
using DevExpress.XtraEditors.Controls;

namespace HK.Formas
{
    public partial class FrmComprasItemGasto : Form
    {
        public string IdDocumento { set; get; }
        public Compra compra;
        public Administrativo data;
        public FrmComprasItemGasto()
        {
            InitializeComponent();
            if(data==null)
                data = new Administrativo();
            Load += FrmComprasItem_Load;
        }
        private void FrmComprasItem_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
            KeyDown += FrmComprasItem_KeyDown;
            FechaDateEdit.Validating += FechaDateEdit_Validating;
            DescuentoCalcEdit.Validating += Calcular_Validating;
            MontoExentoCalcEdit.Validating += Calcular_Validating;
            MontoGravableCalcEdit.Validating += Calcular_Validating;
            MontoGravableBTextEdit.Validating += Calcular_Validating;
            TasaIvaCalcEdit.Validating += Calcular_Validating;
            TasaIvaBTextEdit.Validating += Calcular_Validating;
            MontoIvaBCalcEdit.Validating += Calcular_Validating;
            MontoIvaCalcEdit.Validating += Calcular_Validating;
            MontoSinDerechoCreditoCalcEdit.Validating += Calcular_Validating;
            CedulaRifTextEdit.Validating += CedulaRifButtonEdit_Validating;
            CedulaRifTextEdit.ButtonClick += CedulaRifButtonEdit_ButtonClick;
            CodigoCuenta.ButtonClick += CodigoCuenta_ButtonClick;
            CodigoCuenta.Validating += CodigoCuenta_Validating;
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
                compra.Tercero = proveedor;
                compra.CedulaRif = Basicas.CedulaRif(proveedor.CedulaRif);
                compra.RazonSocial = proveedor.RazonSocial;
                compra.Direccion = string.IsNullOrEmpty(proveedor.Direccion) ? OK.SystemParameters.Ciudad : proveedor.Direccion;
                compra.Email = proveedor.Email;
                compra.Telefonos = proveedor.Telefonos;
                compra.TipoPrecio = proveedor.TipoPrecio == null ? "PRECIO 1" : proveedor.TipoPrecio;
            }
        }
        #endregion
        private void FechaDateEdit_Validating(object sender, CancelEventArgs e)
        {
            if (compra.Tercero != null)
                compra.Vence = FechaDateEdit.DateTime.AddDays((double)compra.Tercero.DiasCredito.GetValueOrDefault(0));
            else
                compra.Vence = FechaDateEdit.DateTime;
        }
        private void Calcular_Validating(object sender, CancelEventArgs e)
        {
            compraBindingSource.EndEdit();
            compra.Totalizar();
            compraBindingSource.ResetCurrentItem();
        }
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
            compra = data.FindCompra(IdDocumento);
            Enlazar();
            Aceptar.Enabled = false;
            ShowDialog();
        }
        public void Modificar()
        {
            compra = data.FindCompra(IdDocumento);
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {
            compraBindingSource.DataSource = compra;
            compraBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
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
                default:
                    break;
            }
        }
    }
}
