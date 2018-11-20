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
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_ProductosAjustePrecios : Form
    {
        Administrativo data;
        public FrmTablas_ProductosAjustePrecios()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmProductosAjustePrecios_Load);
        }

        void FrmProductosAjustePrecios_Load(object sender, EventArgs e)
        {
            this.btnBuscar.Click += new EventHandler(btnBuscar_Click);
            this.txtBuscar.KeyDown += txtBuscar_KeyDown;
            this.btnAumento.Click += new EventHandler(btnAumento_Click);
            this.btnAumentoBs.Click += new EventHandler(btnAumentoBs_Click);
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.txtPrecio.Validating += new CancelEventHandler(txtPrecio_Validating);
            this.txtPrecioConIva.Validating += new CancelEventHandler(txtPrecioConIva_Validating);
            this.txtPrecio2.Validating += new CancelEventHandler(txtPrecio2_Validating);
            this.txtPrecioConIva2.Validating += new CancelEventHandler(txtPrecioConIva2_Validating);
            this.txtPrecio3.Validating += new CancelEventHandler(txtPrecio3_Validating);
            this.txtPrecioConIva3.Validating += new CancelEventHandler(txtPrecioConIva3_Validating);
            this.txtPrecio4.Validating += new CancelEventHandler(txtPrecio4_Validating);
            this.txtPrecioConIva4.Validating += new CancelEventHandler(txtPrecioConIva4_Validating);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmProductosAjustePrecios_KeyDown);
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
            this.txtPrecio.ValidateOnEnterKey = true;
            this.txtPrecioConIva.ValidateOnEnterKey = true;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            this.CenterToScreen();
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            data.GuardarCambios();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Busqueda();
            }
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void FrmProductosAjustePrecios_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F3:
                    this.btnBuscar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Escape:
                    this.btnCancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F10:
                    this.btnGuardar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void txtPrecioConIva_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.PrecioConIva = Basicas.Round((double)Editor.Value);
            producto.Precio = ProductoExtended.PrecioBase(producto.PrecioConIva, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
            
        }
        void txtPrecioConIva2_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.PrecioConIva2 = Basicas.Round((double)Editor.Value);
            producto.Precio2 = ProductoExtended.PrecioBase(producto.PrecioConIva2, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void txtPrecioConIva3_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.PrecioConIva3 = Basicas.Round((double)Editor.Value);
            producto.Precio3 = ProductoExtended.PrecioBase(producto.PrecioConIva3, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void txtPrecioConIva4_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.PrecioConIva4 = Basicas.Round((double)Editor.Value);
            producto.Precio4 = ProductoExtended.PrecioBase(producto.PrecioConIva4, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.Precio = Basicas.Round((double)Editor.Value);
            producto.PrecioConIva = ProductoExtended.PrecioConIva(producto.Precio, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void txtPrecio2_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.Precio2 = Basicas.Round((double)Editor.Value);
            producto.PrecioConIva2 = ProductoExtended.PrecioConIva(producto.Precio2, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void txtPrecio3_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.Precio3 = Basicas.Round((double)Editor.Value);
            producto.PrecioConIva3 = ProductoExtended.PrecioConIva(producto.Precio3, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void txtPrecio4_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)this.gridControl1.MainView.ActiveEditor;
            if (!Editor.IsModified)
                return;
            Producto producto = (Producto)this.bs.Current;
            producto.Precio4 = Basicas.Round((double)Editor.Value);
            producto.PrecioConIva4 = ProductoExtended.PrecioConIva(producto.Precio4, producto.TasaIva);
            producto.FechaPrecio = DateTime.Now;
            data.SetPrecioProducto(producto);
        }
        void btnAumento_Click(object sender, EventArgs e)
        {
            this.gridView1.CancelUpdateCurrentRow();
            if (!Basicas.IsNumeric(toolPorcentaje.Text))
            {
                toolPorcentaje.Text = "0";
                return;
            }
            double Aumento = Convert.ToDouble(toolPorcentaje.Text);
            var lista = bs.List;
            foreach (Producto p in lista)
            {
                DoCambiar(Aumento, p);
                data.SetPrecioProducto(p);
            }
            this.gridControl1.RefreshDataSource();
        }
        void btnAumentoBs_Click(object sender, EventArgs e)
        {
            this.gridView1.CancelUpdateCurrentRow();
            if (!Basicas.IsNumeric(toolBs.Text))
            {
                toolBs.Text = "0";
                return;
            }
            double Aumento = Convert.ToDouble(toolBs.Text);
            var lista = bs.List;
            foreach (Producto p in lista)
            {
                p.PrecioConIva = p.PrecioConIva.GetValueOrDefault(0) + Aumento;
                p.PrecioConIva2 = p.PrecioConIva2.GetValueOrDefault(0) + Aumento;
                p.PrecioConIva3 = p.PrecioConIva3.GetValueOrDefault(0) + Aumento;
                p.Precio = ProductoExtended.PrecioBase(p.PrecioConIva, p.TasaIva);
                p.Precio2 = ProductoExtended.PrecioBase(p.PrecioConIva2, p.TasaIva);
                p.Precio3 = ProductoExtended.PrecioBase(p.PrecioConIva3, p.TasaIva);
                p.FechaPrecio = DateTime.Now;
                data.SetPrecioProducto(p);
            }
        }

        private void DoCambiar(double Aumento, Producto p)
        {
            p.PrecioConIva = p.PrecioConIva + (p.PrecioConIva * Aumento / 100);
            p.PrecioConIva2 = p.PrecioConIva2 + (p.PrecioConIva2 * Aumento / 100);
            p.PrecioConIva3 = p.PrecioConIva3 + (p.PrecioConIva3 * Aumento / 100);
            p.Precio = ProductoExtended.PrecioBase(p.PrecioConIva, p.TasaIva);
            p.Precio2 = ProductoExtended.PrecioBase(p.PrecioConIva2, p.TasaIva);
            p.Precio3 = ProductoExtended.PrecioBase(p.PrecioConIva3, p.TasaIva);
            p.FechaPrecio = DateTime.Now;
        }
        void btnBuscar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        private void Busqueda()
        {
            this.bs.DataSource = data.GetAllProductosSoloVentas(txtBuscar.Text, null);
            this.bs.ResetBindings(true);
        }
    }
}
