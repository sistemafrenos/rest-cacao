using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmCierrePuntoDeVentas : Form
    {
        List<Pago> tarjetasDiarias;
        Administrativo data;
        public Banco banco;
        public FrmCierrePuntoDeVentas()
        {
            InitializeComponent();
            tarjetasDiarias = new List<Pago>();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmCierrePuntoDeVentas_Load);
        }


        void FrmCierrePuntoDeVentas_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.CuentaBancariaButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CuentaBancariaButtonEdit_ButtonClick);
            this.CuentaBancariaButtonEdit.Validating += new CancelEventHandler(CuentaBancariaButtonEdit_Validating);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.txtFecha.DateTime = DateTime.Today;
            Cargar();
            this.CenterToParent();
        }

        private void Cargar()
        {
            foreach (var item in tarjetasDiarias)
            {
                item.ComisionPunto = 0;
                item.NetoDepositar = 0;
                if (item.TarjetaCredito.HasValue)
                {
                    item.ComisionPunto += item.TarjetaCredito.Value * 0.05;
                    item.NetoDepositar += item.TarjetaCredito - item.ComisionPunto;
                }
                if (item.TarjetaDebito.HasValue)
                {
                    item.ComisionPunto += item.TarjetaDebito * 0.01;
                    item.NetoDepositar += item.TarjetaDebito - item.ComisionPunto;
                }
            }
            this.gridControl1.DataSource = tarjetasDiarias.ToList();
        }

        void Aceptar_Click(object sender, EventArgs e)
        {
            if (banco == null)
            {
                MessageBox.Show("Debe Elegir un numero de cuenta");
                return;
            }
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                MessageBox.Show("Debe asignar el numero de lote");
                return;
            }
            Guardar();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private bool Guardar()
        {
            BancosMovimiento registro = new BancosMovimiento()
            { Concepto = "CIERRE PUNTO DE VENTA", Credito = tarjetasDiarias.Sum(x => x.NetoDepositar), 
                Fecha = txtFecha.DateTime,
                Numero = txtNumero.Text, Tipo = "DEPOSITO" };
            try
            {
                //if (!db.Entry(registro).GetValidationResult().IsValid)
                //{
                //    Basicas.ErroresDeValidacion(db.Entry(registro).GetValidationResult());
                //    return false;
                //}
                //banco = db.Bancos.Single(x => x.IdBanco == banco.IdBanco);
                //banco.BancosMovimientos.Add(registro);
                //db.SaveChanges();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
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
        #region Terceros
        void CuentaBancariaButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarBancos("");
            if (F.registro != null)
            {
                CuentaBancariaButtonEdit.Text = ((Banco)F.registro).Cuenta;
            }
        }
        void CuentaBancariaButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            cajaBindingSource.EndEdit();
            Banco[] T = data.GetAllBancos("");
            switch (T.Length)
            {
                case 0:
                    CuentaBancariaButtonEdit.Text = null;
                    break;
                case 1:
                    CuentaBancariaButtonEdit.Text= T[0].Cuenta;
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarBancos(Texto);
                    if (F.registro != null)
                    {
                        CuentaBancariaButtonEdit.Text=((Banco)F.registro).Cuenta;
                    }
                    F = null;
                    break;
            }
        }
        #endregion
    }
}
