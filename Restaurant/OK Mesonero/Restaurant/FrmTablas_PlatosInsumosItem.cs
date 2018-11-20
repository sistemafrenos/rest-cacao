
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_PlatosInsumosItem : Form
    {
        public ProductosCompuesto item;
        Restaurant data;
        Producto producto;
        public FrmTablas_PlatosInsumosItem()
        {
            InitializeComponent();
            if (data == null)
                data = new Restaurant();
            Load += new EventHandler(Frm_Load);
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += new KeyEventHandler(Frm_KeyDown);
            Aceptar.Click += new EventHandler(Aceptar_Click);
            Cancelar.Click += new EventHandler(Cancelar_Click);
            CantidadCalcEdit.Validating += CostoCalcEdit_Validating;
            CostoCalcEdit.Validating += CostoCalcEdit_Validating;
            CodigoButtonEdit.ButtonClick+=CodigoButtonEdit_ButtonClick;
            CodigoButtonEdit.Validating += CodigoButtonEdit_Validating;
            CantidadCalcEdit.KeyDown += CantidadCalcEdit_KeyDown;
            Enlazar();
        }

        void CantidadCalcEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Aceptar.PerformClick();
        }

        void CostoCalcEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            itemBindingSource.EndEdit();
            item.Calcular();
            itemBindingSource.ResetCurrentItem();
        }
        private void Enlazar()
        {
            this.itemBindingSource.DataSource = item;
            this.itemBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            itemBindingSource.EndEdit();
            item.Calcular();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            itemBindingSource.ResetCurrentItem();
            DialogResult = DialogResult.Cancel;
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
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
        #region productos
        private void CodigoButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (!Editor.IsModified)
                return;
            UbicarProducto(Editor.Text);
            LeerProducto();
        }
        private void CodigoButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (UbicarProducto(""))
            {
                LeerProducto();
            }
        }
        private void LeerProducto()
        {
            if (producto == null)
            {
                producto = new Producto();
            }
            Application.DoEvents();
            item.Cantidad = 1;
            item.Costo = producto.Costo;
            item.InsumoID = producto.ID;
            item.Descripcion = producto.Descripcion;
            item.Codigo = producto.Codigo;
            CodigoButtonEdit.Text = producto.Codigo;
            item.Calcular();
            this.itemBindingSource.DataSource = item;
            this.itemBindingSource.ResetBindings(true);
            Application.DoEvents();
        }
        private bool UbicarProducto(string Texto)
        {
            Producto[] T = data.GetAllInsumos(Texto);
            switch (T.Length)
            {
                case 0:
                    if (MessageBox.Show("Insumo no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        producto = new Producto();
                        return false;
                    }
                    FrmTablas_InsumosItem nuevo = new FrmTablas_InsumosItem();
                    nuevo.Incluir(Texto);
                    if (nuevo.DialogResult == DialogResult.OK)
                    {
                        Application.DoEvents();
                        producto = nuevo.producto;
                    }
                    else
                    {
                        producto = new Producto();
                        return false;
                    }
                    break;
                case 1:
                    producto = (Producto)T[0];
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarProductosCompras(Texto);
                    producto = (Producto)F.registro;
                    break;
            }
            LeerProducto();
            return true;
        }
        #endregion
    }
}
