using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmTablas_MaestroDeCuentasItem : Form
    {
        public Administrativo data;
        public MaestroDeCuenta cuenta;
        public FrmTablas_MaestroDeCuentasItem()
        {
            InitializeComponent();
            if(data == null)
                data = new Administrativo();
            Load += Frm_Load;
        }
        void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += Frm_KeyDown;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
            DescripcionTextEdit.KeyDown += DescripcionTextEdit_KeyDown;
        }

        void DescripcionTextEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Aceptar.PerformClick();
        }
        private void Limpiar()
        {
            cuenta = new MaestroDeCuenta();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {
            maestroDeCuentaBindingSource.DataSource =cuenta;
            maestroDeCuentaBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            maestroDeCuentaBindingSource.EndEdit();
            string resultado = data.GuardarMaestroCuentas((MaestroDeCuenta)maestroDeCuentaBindingSource.Current, true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            maestroDeCuentaBindingSource.ResetCurrentItem();
            DialogResult = DialogResult.Cancel;
            Close();
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
                default: break;
            }
        }
    }
}
