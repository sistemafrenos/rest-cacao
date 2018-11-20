using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_PlatosInsumos : Form
    {
        Restaurant data;
        public Producto plato { get; set; }
        Producto myPlato { set; get; }
        public FrmTablas_PlatosInsumos()
        {
            InitializeComponent();
            Load += FrmTablas_PlatosInsumos_Load;
        }

        void FrmTablas_PlatosInsumos_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            data = new Restaurant();
            myPlato = data.FindPlato(plato.ID);
            KeyDown += FrmTablas_PlatosInsumos_KeyDown;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
            btnCargarItem.Click += btnCargarItem_Click;
            gridControl1.KeyDown += gridControl1_KeyDown;
            Enlazar();
        }

        void gridControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (gridView1.ActiveEditor == null)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Subtract)
                {
                    if (gridView1.IsFocusedView)
                    {
                        ProductosCompuesto i = (ProductosCompuesto)productosCompuestosBindingSource.Current;
                        myPlato.ProductosCompuestos.Remove(i);
                        productosCompuestosBindingSource.DataSource = myPlato.ProductosCompuestos.ToList();
                        productosCompuestosBindingSource.ResetBindings(true);
                        myPlato.Costo = myPlato.ProductosCompuestos.Sum(x => x.TotalCosto);
                        productosCompuestosBindingSource.ResetCurrentItem();
                    }
                    e.Handled = true;
                }
                if(e.KeyCode ==Keys.Return)
                {
                    EditarItem();
                }
            }
        }
        void EditarItem()
        {
            using (var f = new FrmTablas_PlatosInsumosItem())
            {
                f.item = (ProductosCompuesto)productosCompuestosBindingSource.Current;
                f.ShowDialog();
            }
        }
        void btnCargarItem_Click(object sender, EventArgs e)
        {
            do
            {
                using (var f = new FrmTablas_PlatosInsumosItem())
                {
                    f.item = new ProductosCompuesto();
                    f.ShowDialog();
                    if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        f.item.Producto = myPlato;
                        var result = data.GuardarPlatoInsumo(f.item, true);
                        if (result != null)
                        {
                            MessageBox.Show(result);
                            return;
                        }
                        Enlazar();
                    }
                    else
                    {
                        return;
                    }
                }
            } while (true);
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            productosCompuestosBindingSource.CancelEdit();
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void Aceptar_Click(object sender, EventArgs e)
        {
            productosCompuestosBindingSource.EndEdit();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void Enlazar()
        {
            productoBindingSource.DataSource = myPlato;
            productosCompuestosBindingSource.DataSource = myPlato.ProductosCompuestos.ToList();
            productoBindingSource.ResetBindings(true);
        }

        void FrmTablas_PlatosInsumos_KeyDown(object sender, KeyEventArgs e)
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
    }
}
