using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmRetencionIvaCliente : Form
    {
        public string IdDocumento;
        public Documento registro;
        public FrmRetencionIvaCliente()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmRetencionIvaCliente_Load);
        }

        void FrmRetencionIvaCliente_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmMesasItem_KeyDown);
            this.CreditoCalcEdit.Validating += new CancelEventHandler(CreditoCalcEdit_Validating);
        }

        void CreditoCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit c = (DevExpress.XtraEditors.CalcEdit)sender;
            if (c.Value > 0)
            {
                Aceptar.PerformClick();
            }
        }
        private void Limpiar()
        {
            registro = new Documento() { Fecha = DateTime.Today, Tipo = "RETENCION IVA", Vence = DateTime.Today };
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
            this.documentoBindingSource.DataSource = registro;
            this.documentoBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                documentoBindingSource.EndEdit();
                registro = (Documento)documentoBindingSource.Current;
                registro.Vence = registro.Fecha;
                registro.Saldo = registro.MontoTotal;
                registro.Comentarios = "RETENCION IVA";
                registro.Tipo = "RETENCION IVA";
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
            this.documentoBindingSource.ResetCurrentItem();
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
