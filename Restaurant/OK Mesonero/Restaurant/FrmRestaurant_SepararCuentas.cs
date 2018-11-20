using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;

namespace HK
{
    public partial class FrmRestaurant_SepararCuentas : Form
    {
        public string codigoMesa;
        Restaurant data;
        private MesasAbierta mesaAbierta;
        private List<MesasAbiertasProducto> productosNuevos = new List<MesasAbiertasProducto>();
        private List<MesasAbiertasProducto> productosOriginales = new List<MesasAbiertasProducto>();
        public FrmRestaurant_SepararCuentas()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmSepararCuentas_Load);
        }
        void FrmSepararCuentas_Load(object sender, EventArgs e)
        {
            data = new Restaurant();
            if (data == null)
                data = new Restaurant();
            if (mesaAbierta == null)
                mesaAbierta = data.GetByCodigoMesaAbierta(codigoMesa);
            if (mesaAbierta == null)
                return;
            this.KeyPreview = true;
            this.txtMesaOriginal.Text = mesaAbierta.CodigoMesa;
            productosOriginales = data.GetMesaProductos(mesaAbierta);
            Enlazar();
            this.KeyDown += new KeyEventHandler(FrmSepararCuentas_KeyDown);
            this.gridControl1.DoubleClick += new EventHandler(gridControl1_DoubleClick);
            this.gridControl2.DoubleClick += new EventHandler(gridControl2_DoubleClick);
            this.MesaTextEdit.Validating+=new CancelEventHandler(MesaTextEdit_Validating);
            this.MesaTextEdit.ButtonClick +=new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(MesaTextEdit_ButtonClick);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }
        private void DoBuscar()
        {
            FrmBuscarEntidadesRestaurant f = new FrmBuscarEntidadesRestaurant();
            f.BuscarMesas(MesaTextEdit.Text);
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var objeto = (Mesa)f.registro;
                if (objeto != null)
                    MesaTextEdit.Text = objeto.Codigo;
            }
        }
        void MesaTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DoBuscar();
        }
        void MesaTextEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMesaOriginal.Text))
                return;
            var objeto = data.GetByCodigoMesa(MesaTextEdit.Text);
            if (objeto != null)
            {
                DoBuscar();
            }
            else
            {
                MesaTextEdit.Text = objeto.Codigo;
            }
        }
        void FrmSepararCuentas_KeyDown(object sender, KeyEventArgs e)
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
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MesaTextEdit.Text))
                return;
            if (txtMesaOriginal.Text == MesaTextEdit.Text)
                return;
            if (productosOriginales.Count == 0 || productosNuevos.Count == 0)
                return;
            
            data.SepararMesa(mesaAbierta,MesaTextEdit.Text,productosOriginales, productosNuevos);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #region CuentasS
        private void LeerMesa(Mesa cuenta)
        {
            MesaTextEdit.Text = cuenta.Codigo;
        }
        #endregion
        void gridControl2_DoubleClick(object sender, EventArgs e)
        {
            MesasAbiertasProducto p = (MesasAbiertasProducto)productosNuevosBindingSource.Current;
            if (p == null)
                return;
            productosOriginales.Add(OK.DeepCopy(p));
            productosNuevos.Remove(p);
            Enlazar();
        }
        double? Totalizar(List<MesasAbiertasProducto> productos)
        {
            return productos.Sum(x => x.Total);
        }
        void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            MesasAbiertasProducto p = (MesasAbiertasProducto)productosOriginalesBindingSource.Current;
            if (p == null)
                return;
            productosNuevos.Add(OK.DeepCopy(p));
            productosOriginales.Remove(p);
            Enlazar();
        }
        private void Enlazar()
        {
            this.productosOriginalesBindingSource.DataSource = productosOriginales;
            this.productosOriginalesBindingSource.ResetBindings(true);
            this.productosNuevosBindingSource.DataSource = productosNuevos;
            this.productosNuevosBindingSource.ResetBindings(true);
            totalOriginales.Value = (decimal)Totalizar(productosOriginales);
            totalNuevo.Value = (decimal)Totalizar(productosNuevos);
        }
    }
}
