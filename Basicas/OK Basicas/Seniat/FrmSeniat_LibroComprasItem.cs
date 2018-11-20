using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;

namespace HK.Formas
{
    public partial class FrmSeniat_LibroComprasItem : Form
    {
        public FrmSeniat_LibroComprasItem()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmLibroComprasItem_Load);
        }

        public LibroCompra registro = new LibroCompra();
        private Tercero proveedor = new Tercero();
        void FrmLibroComprasItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmLibroComprasItem_KeyDown);
            this.MontoGravableCalcEdit.Validating += new CancelEventHandler(MontoGravableCalcEdit_Validating);
            this.MontoExentoCalcEdit.Validating += new CancelEventHandler(MontoExentoCalcEdit_Validating);
            this.MontoIvaCalcEdit.Validating += new CancelEventHandler(MontoIvaCalcEdit_Validating);

            this.MontoGravableBCalcEdit.Validating += new CancelEventHandler(MontoGravableBCalcEdit_Validating);
            this.MontoIvaBCalcEdit.Validating += new CancelEventHandler(MontoIvaBCalcEdit_Validating);

        }
        void MontoIvaCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.libroCompraBindingSource.EndEdit();
            registro.Calcular();
        }
        void MontoIvaBCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.libroCompraBindingSource.EndEdit();
            registro.Calcular();
        }
        void MontoExentoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit editor = (DevExpress.XtraEditors.CalcEdit)sender;
            if (!editor.IsModified)
                return;
            this.libroCompraBindingSource.EndEdit();
            registro.Calcular();
        }
        void MontoGravableCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.libroCompraBindingSource.EndEdit();
            registro.MontoIva = registro.MontoGravable * registro.TasaIva / 100;
            registro.Calcular();
        }
        void MontoGravableBCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.libroCompraBindingSource.EndEdit();
            registro.MontoIvaB = registro.MontoGravableB * registro.TasaIvaB / 100;
            registro.Calcular();
        }
        private void Limpiar()
        {
            registro = new LibroCompra();
            proveedor = new Tercero();
        }
        public void Incluir(string mes, string año)
        {
            Limpiar();
            registro.Mes = Convert.ToInt16(mes);
            registro.Ano = Convert.ToInt16(año);
            registro.TasaIva = OK.SystemParameters.TasaIva;
            registro.TasaIvaB = OK.SystemParameters.TasaIvaB;
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
            this.libroCompraBindingSource.DataSource = registro;
            this.libroCompraBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                libroCompraBindingSource.EndEdit();
                registro = (LibroCompra)libroCompraBindingSource.Current;
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
            this.libroCompraBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmLibroComprasItem_KeyDown(object sender, KeyEventArgs e)
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

        private void MontoGravableCalcEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
