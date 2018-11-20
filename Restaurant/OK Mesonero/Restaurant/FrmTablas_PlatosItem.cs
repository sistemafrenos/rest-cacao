using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_PlatosItem : Form
    {
        public Restaurant data;
        Producto producto;
        public FrmTablas_PlatosItem()
        {
            InitializeComponent();
            Load += new EventHandler(Frm_Load);
            if (data == null)
                data = new Restaurant();
        }

        public string descripcion = null;
        private void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true; 
            KeyDown += new KeyEventHandler(Frm_KeyDown);
            Aceptar.Click += new EventHandler(Aceptar_Click);
            Cancelar.Click += new EventHandler(Cancelar_Click);
            btnCargarProducto.Click += new EventHandler(btnCargarProducto_Click);
            GrupoMenuComboBoxEdit.Properties.Items.AddRange(data.GetGruposVentas());
            TasaIvaComboBoxEdit.Properties.Items.Add(OK.SystemParameters.TasaIva);
            TasaIvaComboBoxEdit.Properties.Items.Add(OK.SystemParameters.TasaIvaB);
            TasaIvaComboBoxEdit.Properties.Items.Add(0);
            TasaIvaComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            TasaIvaComboBoxEdit.TabStop = true;
            TasaIvaComboBoxEdit.Validating += new CancelEventHandler(TasaIvaComboBoxEdit_Validating);
            PrecioCalcEdit.Validating += new CancelEventHandler(PrecioCalcEdit_Validating);
            PrecioConIvaCalcEdit.Validating += new CancelEventHandler(PrecioConIvaCalcEdit_Validating);
            Precio2CalcEdit.Validating += new CancelEventHandler(Precio2CalcEdit_Validating);
            PrecioConIva2CalcEdit.Validating += new CancelEventHandler(PrecioConIva2CalcEdit_Validating);
            btnCrearCodigo.Click += new EventHandler(btnCrearCodigo_Click);
            ImpresionComandaComboBoxEdit.Properties.Items.AddRange(new object[] { "COCINA","BARRA","TICKETS" });
            btnProductoCompuesto.Click += btnProductoCompuesto_Click;
            Enlazar();
        }

        void btnProductoCompuesto_Click(object sender, EventArgs e)
        {
            using (var f = new FrmTablas_PlatosInsumos())
            {
                f.plato = producto;
                f.ShowDialog();
            }
        }

        private void Limpiar()
        {
            producto = new Producto();
            producto.LlevaInventario = false;
        }
        public void Incluir()
        {
            Limpiar();
            if (!string.IsNullOrEmpty(descripcion))
            {
                producto.Codigo = descripcion;
            }
            Enlazar();
            ShowDialog();
        }
        public void Modificar(string idProducto)
        {
            producto = data.FindProducto(idProducto);
            Enlazar();
            ShowDialog();
        }
        public void Copiar(Producto p)
        {
            producto = p;
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {
            if (producto == null)
            {
                Limpiar();
            }
            producto.Utilidad = producto.Utilidad == null ? OK.SystemParameters.Utilidad : producto.Utilidad;
            producto.Utilidad2 = producto.Utilidad2 == null ? OK.SystemParameters.Utilidad2 : producto.Utilidad2;
            productoBindingSource.DataSource = producto;
            productoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            productoBindingSource.EndEdit();
            producto = (Producto)productoBindingSource.Current;
            producto.HabilitadoParaCompras = false;
            producto.LlevaInventario = false;
            
            var resultado = data.GuardarPlato(producto, true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Datos no guardados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            productoBindingSource.ResetCurrentItem();
            DialogResult = DialogResult.Cancel;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    btnCargarProducto.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        private void btnCrearCodigo_Click(object sender, EventArgs e)
        {
            CodigoTextEdit.Text = data.GetContadorCodigoPlato(GrupoMenuComboBoxEdit.Text);
        }
        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            var f = new FrmBuscarEntidades();
            f.BuscarProductos(string.Empty);
            if (f.registro != null)
            {
                producto = data.ClonePlato(producto);
                Enlazar();
            }
        }
        private void TasaIvaComboBoxEdit_Validating(object sender, CancelEventArgs e)
        {
            var editor = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            var valor = Convert.ToDouble(editor.Text);
            producto.Precio = ProductoExtended.CalcularPrecio(producto.Costo, producto.Utilidad);
            producto.Precio2 = ProductoExtended.CalcularPrecio(producto.Costo, producto.Utilidad);
            producto.PrecioConIva = ProductoExtended.PrecioConIva(producto.Precio, valor);
            producto.PrecioConIva2 = ProductoExtended.PrecioConIva(producto.Precio2, valor);
            PrecioCalcEdit.Value = (decimal)producto.Precio;
            Precio2CalcEdit.Value = (decimal)producto.Precio2;
            PrecioConIvaCalcEdit.Value = (decimal)producto.PrecioConIva;
            PrecioConIva2CalcEdit.Value = (decimal)producto.PrecioConIva2;
        }
        private void PrecioCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.PrecioConIva = ProductoExtended.PrecioConIva((double)Editor.Value, producto.TasaIva);
            PrecioConIvaCalcEdit.Value = (decimal)producto.PrecioConIva;
        }
        private void PrecioConIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio = ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
            PrecioCalcEdit.Value = (decimal)producto.Precio;
        }
        private void Precio2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.PrecioConIva2 = ProductoExtended.PrecioConIva((double)Editor.Value, producto.TasaIva);
            PrecioConIva2CalcEdit.Value = (decimal)ProductoExtended.PrecioConIva(producto.Precio2, producto.TasaIva);
        }
        private void PrecioConIva2CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            var Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            producto.Precio2 = ProductoExtended.PrecioBase((double)Editor.Value, producto.TasaIva);
            Precio2CalcEdit.Value = (decimal)producto.Precio2;
        }
    }
}
