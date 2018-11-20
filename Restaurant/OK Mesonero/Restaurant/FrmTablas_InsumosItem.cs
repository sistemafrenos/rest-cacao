using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_InsumosItem : Form
    {
        public Producto producto;
        public Restaurant data;
        public FrmTablas_InsumosItem()
        {
            InitializeComponent();
            if (data == null)
                data = new Restaurant();
            this.Load += new EventHandler(FrmProductosItemSimple_Load);
        }
        public string descripcion = null;
        void FrmProductosItemSimple_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.btnCargarProducto.Click += new EventHandler(btnCargarProducto_Click);
            this.DepartamentoButtonEdit.Properties.Items.AddRange( data.GetGruposVentas());
            this.TasaIvaComboBoxEdit.Properties.Items.Add(OK.SystemParameters.TasaIva);
            this.TasaIvaComboBoxEdit.Properties.Items.Add(OK.SystemParameters.TasaIvaB);
            this.TasaIvaComboBoxEdit.Properties.Items.Add(0);
            this.TasaIvaComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.TasaIvaComboBoxEdit.TabStop = true;
            this.btnCrearCodigo.Click += new EventHandler(btnCrearCodigo_Click);
            this.CostoCalcEdit.Properties.ValidateOnEnterKey = true;
            Enlazar();
        }
        public void Incluir(string descripcion)
        {
            producto = new Producto();
            producto.HabilitadoParaVentas = false;
            producto.HabilitadoParaCompras = true;
            producto.LlevaInventario = true;
            if (!string.IsNullOrEmpty(descripcion))
            {
                producto.Codigo = descripcion;
                producto.Descripcion = descripcion;
            }
            this.ShowDialog();
        }
        public void Modificar(string idProducto)
        {
            if (idProducto == null)
                return;
            producto = data.FindProducto(idProducto);
            Enlazar();
            this.ShowDialog();
        }
        public void Copiar(Producto p)
        {
            producto = data.CloneProducto(p);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            this.productoBindingSource.DataSource = producto;
            this.productoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {  
            productoBindingSource.EndEdit();
            producto = (Producto)productoBindingSource.Current;
            string resultado = data.GuardarProducto(producto,true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Datos no guardados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.productoBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    this.btnCargarProducto.PerformClick();
                    e.Handled = true;
                    break;
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
        void btnCrearCodigo_Click(object sender, EventArgs e)
        { 
            CodigoTextEdit.Text = data.CrearCodigoProducto(DepartamentoButtonEdit.Text);
        }
        void btnCargarProducto_Click(object sender, EventArgs e)
        {
            FrmBuscarEntidadesRestaurant f = new FrmBuscarEntidadesRestaurant();
            f.BuscarInsumos("");
            if (f.registro != null)
            {
                producto = data.CloneProducto((Producto)f.registro);
                Enlazar();
            }
        }
    }
}
