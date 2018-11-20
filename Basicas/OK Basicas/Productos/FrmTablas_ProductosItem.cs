using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmTablas_ProductosItem : Form
    {
        public Producto producto;
        public Administrativo data;
        public FrmTablas_ProductosItem()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
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
            this.TasaIvaComboBoxEdit.Validating += new CancelEventHandler(TasaIvaComboBoxEdit_Validating);
            this.CostoCalcEdit.Validating += new CancelEventHandler(CostoCalcEdit_Validating);
            this.PrecioCalcEdit.Validating += new CancelEventHandler(PrecioCalcEdit_Validating);
            this.PrecioConIvaCalcEdit.Validating += new CancelEventHandler(PrecioConIvaCalcEdit_Validating);
            this.Precio2CalcEdit.Validating += new CancelEventHandler(Precio2CalcEdit_Validating);
            this.PrecioConIva2CalcEdit.Validating += new CancelEventHandler(PrecioConIva2CalcEdit_Validating);

            this.Precio3CalcEdit.Validating += new CancelEventHandler(Precio3CalcEdit_Validating);
            this.PrecioConIva3CalcEdit.Validating += new CancelEventHandler(PrecioConIva3CalcEdit_Validating);

            this.Precio4CalcEdit.Validating += new CancelEventHandler(Precio4CalcEdit_Validating);
            this.PrecioConIva4CalcEdit.Validating += new CancelEventHandler(PrecioConIva4CalcEdit_Validating);

            this.btnCrearCodigo.Click += new EventHandler(btnCrearCodigo_Click);
            this.CostoCalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioCalcEdit.Properties.ValidateOnEnterKey = true;
            this.Precio2CalcEdit.Properties.ValidateOnEnterKey = true;
            this.Precio3CalcEdit.Properties.ValidateOnEnterKey = true;
            this.Precio4CalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIvaCalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIva2CalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIva3CalcEdit.Properties.ValidateOnEnterKey = true;
            this.PrecioConIva4CalcEdit.Properties.ValidateOnEnterKey = true;
            Enlazar();
        }
        public void Incluir(string descripcion)
        {
            producto = new Producto();
            producto.HabilitadoParaVentas = true;
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
            FrmBuscarEntidades f = new FrmBuscarEntidades();
            f.BuscarProductos("");
            if (f.registro != null)
            {
                producto = data.CloneProducto((Producto)f.registro);
                Enlazar();
            }
        }
        #region Calculo de precios
        void TasaIvaComboBoxEdit_Validating(object sender, CancelEventArgs e)
        {
           
            DevExpress.XtraEditors.ComboBoxEdit editor = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            double? valor = Convert.ToDouble(editor.Text);
            producto.Precio = ProductoExtended.CalcularPrecio(producto.Costo,  producto.Utilidad);
            producto.Precio2 = ProductoExtended.CalcularPrecio(producto.Costo,  producto.Utilidad2);
            producto.Precio3 = ProductoExtended.CalcularPrecio(producto.Costo, producto.Utilidad3);
            producto.Precio4 = ProductoExtended.CalcularPrecio(producto.Costo, producto.Utilidad4);
            producto.PrecioConIva = ProductoExtended.PrecioConIva(producto.Precio, valor);
            producto.PrecioConIva2 = ProductoExtended.PrecioConIva(producto.Precio2, valor);
            producto.PrecioConIva3 = ProductoExtended.PrecioConIva(producto.Precio3, valor);
            producto.PrecioConIva4 = ProductoExtended.PrecioConIva(producto.Precio4, valor);
            PrecioCalcEdit.Value = (decimal)producto.Precio;
            Precio2CalcEdit.Value = (decimal)producto.Precio2;
            Precio3CalcEdit.Value = (decimal)producto.Precio3;
            Precio4CalcEdit.Value = (decimal)producto.Precio4;
            PrecioConIvaCalcEdit.Value = (decimal)producto.PrecioConIva;
            PrecioConIva2CalcEdit.Value = (decimal)producto.PrecioConIva2;
            PrecioConIva3CalcEdit.Value = (decimal)producto.PrecioConIva3;
            PrecioConIva4CalcEdit.Value = (decimal)producto.PrecioConIva4;
        }
        void CostoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio = ProductoExtended.CalcularPrecio((double)editor.Value, producto.Utilidad);
            producto.Precio2 = ProductoExtended.CalcularPrecio((double)editor.Value, producto.Utilidad2);
            producto.Precio3 = ProductoExtended.CalcularPrecio((double)editor.Value, producto.Utilidad3);
            producto.Precio4 = ProductoExtended.CalcularPrecio((double)editor.Value, producto.Utilidad4);

            producto.PrecioConIva = ProductoExtended.PrecioConIva(producto.Precio, producto.TasaIva);
            producto.PrecioConIva2 = ProductoExtended.PrecioConIva(producto.Precio2, producto.TasaIva);
            producto.PrecioConIva3 = ProductoExtended.PrecioConIva(producto.Precio3, producto.TasaIva);
            producto.PrecioConIva4 = ProductoExtended.PrecioConIva(producto.Precio4, producto.TasaIva);

            PrecioCalcEdit.Value = (decimal)producto.Precio;
            Precio2CalcEdit.Value = (decimal)producto.Precio2;
            Precio3CalcEdit.Value = (decimal)producto.Precio3;
            Precio4CalcEdit.Value = (decimal)producto.Precio4;

            PrecioConIvaCalcEdit.Value = (decimal)producto.PrecioConIva;
            PrecioConIva2CalcEdit.Value = (decimal)producto.PrecioConIva2;
            PrecioConIva3CalcEdit.Value = (decimal)producto.PrecioConIva3;
            PrecioConIva4CalcEdit.Value = (decimal)producto.PrecioConIva4;

        }
        // Precio 1
        void PrecioCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.PrecioConIva = ProductoExtended.PrecioConIva((double)Editor.Value, producto.TasaIva);
            PrecioConIvaCalcEdit.Value = (decimal)producto.PrecioConIva;
        }
        void PrecioConIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio = ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
            PrecioCalcEdit.Value = (decimal)producto.Precio;
        }
        void UtilidadCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio = ProductoExtended.CalcularPrecio(producto.Costo, (double)Editor.Value);
            PrecioCalcEdit.Value = (decimal)producto.Precio;
            PrecioConIvaCalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio, producto.TasaIva);
        }
        // Precio 2
        void Precio2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.PrecioConIva2 = ProductoExtended.PrecioConIva((double)Editor.Value, producto.TasaIva);
            PrecioConIva2CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio2, producto.TasaIva);
        }
        void PrecioConIva2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio2 = ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
            Precio2CalcEdit.Value = (decimal)producto.Precio2;
        }
        void Utilidad2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio2 = ProductoExtended.CalcularPrecio(producto.Costo, (double)Editor.Value);
            Precio2CalcEdit.Value = (decimal)producto.Precio2;
            PrecioConIva2CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio2, producto.TasaIva);
        }
        // Precio 3
        void Precio3CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.PrecioConIva3 = ProductoExtended.PrecioConIva((double)Editor.Value, producto.TasaIva);
            PrecioConIva3CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio3, producto.TasaIva);
        }
        void PrecioConIva3CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio3 = ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
            Precio3CalcEdit.Value = (decimal)producto.Precio3;
        }
        void Utilidad3CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio3 = ProductoExtended.CalcularPrecio(producto.Costo, (double)Editor.Value);
            Precio3CalcEdit.Value = (decimal)producto.Precio3;
            PrecioConIva3CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio3, producto.TasaIva);
        }
        // Precio 4
        void Precio4CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.PrecioConIva4 = ProductoExtended.PrecioConIva((double)Editor.Value, producto.TasaIva);
            PrecioConIva4CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio4, producto.TasaIva);
        }
        void PrecioConIva4CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            // producto.Precio4 = ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
            Precio4CalcEdit.Value = (decimal)ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
        }
        void Utilidad4CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio4 = ProductoExtended.CalcularPrecio(producto.Costo, (double)Editor.Value);
            Precio4CalcEdit.Value = (decimal)producto.Precio4;
            PrecioConIva4CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio4, producto.TasaIva);
        }
        #endregion
    }
}
