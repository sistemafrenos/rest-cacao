using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;


namespace HK.Formas
{
    public partial class FrmSeniat_LibroInventariosItem : Form
    {
        Producto producto;
        public Administrativo data;
        public LibroInventario registro = new LibroInventario();
        public FrmSeniat_LibroInventariosItem()
        {
            InitializeComponent();
            producto = new Producto();
                if(data==null)
            data = new Administrativo();
            this.Load += new EventHandler(FrmLibroInventariosItem_Load);
        }
        void FrmLibroInventariosItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmLibroInventariosItem_KeyDown);
            this.EntradasCalcEdit.Validating += CalcEdit_Validating;
            this.SalidasCalcEdit.Validating += CalcEdit_Validating;
            this.InicioCalcEdit.Validating += CalcEdit_Validating;
            this.AutoconsumoCalcEdit.Validating += CalcEdit_Validating;
            this.AutoconsumoCalcEdit.KeyDown += AutoconsumoCalcEdit_KeyDown;
            this.CodigoButtonEdit.ButtonClick+=CodigoButtonEdit_ButtonClick;
            this.CodigoButtonEdit.Validating += CodigoButtonEdit_Validating;
        }

        void AutoconsumoCalcEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Aceptar.PerformClick();
        }
        #region Productos
        void CodigoButtonEdit_Validating(object sender, CancelEventArgs e)
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
            LibroInventario registroDetalle = (LibroInventario)libroInventarioBindingSource.Current;
            Application.DoEvents();
            registroDetalle.Costo = producto.Costo;
            registroDetalle.Descripcion = producto.Descripcion;
            registroDetalle.Codigo = producto.Codigo;
            CodigoButtonEdit.Text= producto.Codigo;
            this.libroInventarioBindingSource.DataSource = registroDetalle;
            this.libroInventarioBindingSource.ResetBindings(true);
            Application.DoEvents();
        }
        private bool UbicarProducto(string Texto)
        {
            Producto[] T = data.GetAllProductosCompras(Texto);
            switch (T.Length)
            {
                case 0:
                    if (MessageBox.Show("Producto no Encontrado, Desea crear uno nuevo", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        producto = new Producto();
                        return false;
                    }
                    FrmTablas_ProductosItem nuevo = new FrmTablas_ProductosItem();
                    nuevo.Incluir(Texto);
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
        void CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.libroInventarioBindingSource.EndEdit();
            registro.Calcular();
            this.libroInventarioBindingSource.ResetCurrentItem();
        }
        private void Limpiar()
        {
            registro = new LibroInventario();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
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
            this.libroInventarioBindingSource.DataSource = registro;
            this.libroInventarioBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                libroInventarioBindingSource.EndEdit();
                registro = (LibroInventario)libroInventarioBindingSource.Current;
                registro.Calcular();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar los datos \n" + ex.Message, "Atencion", MessageBoxButtons.OK);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.libroInventarioBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmLibroInventariosItem_KeyDown(object sender, KeyEventArgs e)
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
