using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmAdministrativoComprasItemGasto : Form
    {
        MaestroDeCuenta cuenta = null;
        public Compra registro = new Compra();
        private Proveedore proveedor = new Proveedore();
        DatosEntities db = new DatosEntities(Basicas.CadenaConexion);
        public FrmAdministrativoComprasItemGasto()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmComprasItem_Load);
        }
        void FrmComprasItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            #region Eventos
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmComprasItem_KeyDown);            
            this.FechaDateEdit.Validating += new CancelEventHandler(FechaDateEdit_Validating);
            this.CodigoCuenta.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(btnCodigoCuenta_ButtonClick);
            this.CodigoCuenta.Validating += new CancelEventHandler(CodigoCuenta_Validating);
            this.DescuentoCalcEdit.Validating += new CancelEventHandler(Calcular_Validating);
            this.MontoExentoCalcEdit.Validating += new CancelEventHandler(Calcular_Validating);
            this.MontoGravableBTextEdit.Validating += new CancelEventHandler(Calcular_Validating);
            this.MontoGravableCalcEdit.Validating += new CancelEventHandler(Calcular_Validating);
            this.MontoIvaBCalcEdit.Validating += new CancelEventHandler(Calcular_Validating);
            this.MontoIvaCalcEdit.Validating += new CancelEventHandler(Calcular_Validating);
            this.MontoSinDerechoCreditoCalcEdit.Validating += new CancelEventHandler(Calcular_Validating);
            #endregion
            #region Proveedor
            this.CedulaRifTextEdit.Validating+=new CancelEventHandler(CedulaRifButtonEdit_Validating);
            this.CedulaRifTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CedulaRifButtonEdit_ButtonClick);
            #endregion
            FactoryMaestroDeCuentas.AutoCreate();
        }
        void FechaDateEdit_Validating(object sender, CancelEventArgs e)
        {   
            DevExpress.XtraEditors.DateEdit editor = (DevExpress.XtraEditors.DateEdit)sender;
            registro.Vence = this.FechaDateEdit.DateTime.AddDays((double)proveedor.DiasCredito.GetValueOrDefault(0));
        }
        void Calcular_Validating(object sender, CancelEventArgs e)
        {
            this.compraBindingSource.EndEdit();
            registro.Calcular();
        }
        #region Proveedor
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarProveedores("");
            if (F.registro != null)
            {
                proveedor = (Proveedore)F.registro;
                proveedor = FactoryProveedores.Item(proveedor.CedulaRif);
                LeerProveedor();
            }
            else
            {
                proveedor = new Proveedore();
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.compraBindingSource.EndEdit();
            List<Proveedore> T = FactoryProveedores.getItems(Texto);
            switch (T.Count)
            {
                case 0:
                    proveedor = null;
                    CrearProveedor();
                    break;
                case 1:
                    proveedor = T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProveedores(Texto);
                    if (F.registro != null)
                    {
                        proveedor = (Proveedore)F.registro;
                        proveedor = FactoryProveedores.Item(proveedor.CedulaRif);
                    }
                    else
                    {
                        proveedor = null;
                    }
                    break;
            }
            LeerProveedor();
        }
        private void LeerProveedor()
        {
            CrearProveedor();
            this.proveedoreBindingSource.DataSource = proveedor;
            this.proveedoreBindingSource.ResetCurrentItem();
        }
        private void CrearProveedor()
        {
            if (proveedor == null)
            {
                proveedor = new Proveedore();
                proveedor.LimiteCredito = 0;
                proveedor.DiasCredito = 0;
                proveedor.PorcentajeRetencionIva = 0;
                proveedor.PrestaServicios = false;
                proveedor.UltimaEdicion = DateTime.Today;
                proveedor.CedulaRif = Basicas.CedulaRif(this.CedulaRifTextEdit.Text);
            }
        }
        #endregion
        #region Cuenta
        void CodigoCuenta_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            List<MaestroDeCuenta> T = FactoryMaestroDeCuentas.getItems(Texto);
            switch (T.Count)
            {
                case 0:
                    cuenta = new MaestroDeCuenta();
                    break;
                case 1:
                    cuenta = T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarCuentas(Texto);
                    if (F.registro != null)
                    {
                        cuenta = (MaestroDeCuenta)F.registro;
                    }
                    else
                    {
                        cuenta = new MaestroDeCuenta();
                    }
                    break;
            }
            LeerCuenta();
        }
        private void LeerCuenta()
        {
            registro.CodigoCuenta = cuenta.Codigo;
            registro.DescripcionCuenta = cuenta.Descripcion;
        }
        void btnCodigoCuenta_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarCuentas("");
            if (F.registro != null)
            {
                cuenta = (MaestroDeCuenta)F.registro;                
            }
            else
            {
                cuenta = new MaestroDeCuenta();
            }
            LeerCuenta();
        }
        #endregion
        private void Limpiar()
        {
            DatosEntities db = new DatosEntities(Basicas.CadenaConexion);
            registro = new Compra();
            registro.Fecha = DateTime.Today;
            registro.Vence = DateTime.Today;
            registro.Año = registro.Fecha.Value.Year;
            registro.Mes = registro.Fecha.Value.Month;
            registro.TasaIva = Basicas.parametros().TasaIva;
            registro.TasaIvaB = Basicas.parametros().TasaIvaB;
            registro.IdUsuario = FactoryUsuarios.UsuarioActivo.IdUsuario;
            registro.IncluirLibroCompras = true;
            registro.MontoImpuestosLicores = 0;
            registro.Descuento = 0;
            registro.DescuentoProntoPago = 0;
            registro.DescripcionCuenta = null;
            registro.Deposito = Basicas.parametros().DepositoCompras;
            registro.MontoExento = 0;
            registro.MontoGravable = 0;
            registro.MontoGravableB = 0;
            registro.MontoImpuestosLicores=0;
            registro.MontoIva =0;
            registro.MontoIvaB =0;
            registro.MontoSinDerechoCredito =0;
            registro.MontoTotal =0;
            proveedor = new Proveedore();
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
            Proveedore proveedor = FactoryProveedores.Item(db, registro.CedulaRif);
            if (proveedor == null)
            {
                proveedor = new Proveedore();
            }
            this.proveedoreBindingSource.DataSource = proveedor;
            this.proveedoreBindingSource.ResetBindings(true);
            this.compraBindingSource.DataSource = registro;
            this.compraBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                compraBindingSource.EndEdit();
                registro = (Compra)compraBindingSource.Current;
                proveedoreBindingSource.EndEdit();
                proveedor = (Proveedore)proveedoreBindingSource.Current;
                if (proveedor.Errores().Count > 0)
                {
                    MessageBox.Show(proveedor.ErroresStr(), "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                registro.CedulaRif = proveedor.CedulaRif;
                registro.Direccion = proveedor.Direccion;
                registro.RazonSocial = proveedor.RazonSocial;
                if (registro.Errores().Count > 0)
                {
                    MessageBox.Show(registro.ErroresStr(), "Errores", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                registro.Estatus = "CERRADA";
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
                this.compraBindingSource.EndEdit();
                if (registro.IdCompra != null)
                    registro = ReversarCompra(registro);
                registro.IdUsuario = FactoryUsuarios.UsuarioActivo.IdUsuario;
                registro.CajaChica = txtCajaChica.Checked;
                registro.Calcular();
                if (registro.Errores().Count>0)
                {
                    MessageBox.Show(registro.ErroresStr(), "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                 if (proveedor.EntityState == EntityState.Detached)
                {
                    proveedor.IdProveedor = FactoryContadores.GetMax("IdProveedor");
                    proveedor.Activo = true;
                    db.Proveedores.AddObject(proveedor);
                }                
                if (registro.EntityState == EntityState.Detached)
                {
                    registro.IdCompra = FactoryContadores.GetMax("IdCompra");
                    db.Compras.AddObject(registro);
                }
                db.SaveChanges();
                if (registro.Estatus == "CERRADA")
                {
                    FactoryLibroCompras.EscribirItem(registro);
                    FactoryCompras.Inventario(registro);
                    if (registro.CajaChica != true)
                    {
                        FactoryCuentasxPagar.RegistrarMovimiento(registro);
                    }
                    else
                    {
                        FactoryCajasChica.RegistrarItem(registro);
                    }

                }
                return true;
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
                return false;
            }
        }

        private Compra ReversarCompra(Compra registro)
        {
            using (var tempDb = new DatosEntities(Basicas.CadenaConexion))
            {
                Compra x = FactoryCompras.Item(tempDb, registro.IdCompra);
                if (x != null)
                {
                    FactoryCompras.InventarioDevolver(x);
                    FactoryLibroCompras.EliminarItem(x);
                    FactoryCuentasxPagar.ReversarMovimiento(x);
                    FactoryCajasChica.ReversarItem(x);
                    Compra nuevo = new Compra();
                    nuevo.Año = registro.Año;
                    nuevo.CedulaRif = registro.CedulaRif;
                    nuevo.CodigoCuenta = registro.CodigoCuenta;
                    nuevo.Comentarios = registro.Comentarios;
                    nuevo.Deposito = registro.Deposito;
                    nuevo.DescripcionCuenta = registro.DescripcionCuenta;
                    nuevo.Descuento = registro.Descuento;
                    nuevo.Direccion = registro.Direccion;
                    nuevo.Estatus = registro.Estatus;
                    nuevo.Fecha = registro.Fecha;
                    nuevo.IdUsuario = registro.IdUsuario;
                    nuevo.IncluirLibroCompras = registro.IncluirLibroCompras;
                    nuevo.LibroCompras = false;
                    nuevo.LibroInventarios = false;
                    nuevo.Mes = registro.Mes;
                    nuevo.MontoExento = registro.MontoExento;
                    nuevo.MontoGravable = registro.MontoGravable;
                    nuevo.MontoGravableB = registro.MontoGravableB;
                    nuevo.MontoImpuestosLicores = registro.MontoImpuestosLicores;
                    nuevo.MontoIva = registro.MontoIva;
                    nuevo.MontoIvaB = registro.MontoIvaB;
                    nuevo.MontoSinDerechoCredito = registro.MontoSinDerechoCredito;
                    nuevo.MontoTotal = registro.MontoTotal;
                    nuevo.Numero = x.Numero;
                    nuevo.NumeroControl = x.NumeroControl;
                    nuevo.RazonSocial = x.RazonSocial;
                    nuevo.TasaIva = registro.TasaIva;
                    nuevo.TasaIvaB = registro.TasaIvaB;
                    nuevo.UltimaEdicion = registro.UltimaEdicion;
                    nuevo.Vence = registro.Vence;
                    nuevo.IdCompra = FactoryContadores.GetMax("IdCompra");
                    tempDb.Compras.DeleteObject(x);
                    tempDb.SaveChanges();
                    return nuevo;
                }
                else
                    return registro;
            }
            
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.compraBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmComprasItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (this.Aceptar.Enabled == true && registro.MontoTotal.GetValueOrDefault(0) > 0)
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
    }
}
