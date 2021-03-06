using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmNotaDebitoCliente : Form
    {
        public Documento registro;
        public FrmNotaDebitoCliente()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmNotaDebito_Load);
        }
        public string IdDocumento;
        void FrmNotaDebito_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmMesasItem_KeyDown);
            this.DebitoCalcEdit.Validating += new CancelEventHandler(DebitoCalcEdit_Validating);
        }

        void DebitoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit c = (DevExpress.XtraEditors.CalcEdit)sender;
            if (c.Value > 0)
            {
                Aceptar.PerformClick();
            }
        }
        private void Limpiar()
        {
            registro = new Documento();
            registro.Fecha = DateTime.Today;
            registro.Tipo = "NOTA DEBITO";
            registro.Vence = registro.Fecha;
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.FechaDateEdit.Enabled = false;
            this.NumeroTextEdit.Enabled = false;
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        public void Ver()
        {
            Enlazar();
            this.dataLayoutControl1.Enabled = false;
            this.Aceptar.Visible = false;
            this.ShowDialog();
        }
        private void Enlazar()
        {
            if (registro == null)
            {
                Limpiar();
            }
            this.documentosBindingSource.DataSource = registro;
            this.documentosBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                documentosBindingSource.EndEdit();
                registro = (Documento)documentosBindingSource.Current;
                registro.Vence = registro.Fecha;
                registro.Saldo = registro.MontoTotal;
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
            this.documentosBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmMesasItem_KeyDown(object sender, KeyEventArgs e)
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
