using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmUtilidades_Parametros : Form
    {
        Administrativo data;
        public FrmUtilidades_Parametros()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmParametros_Load);
        }
        void FrmParametros_Load(object sender, EventArgs e)
        {
            txtUltimaFactura.Text = Administrativo.ReadContador("FACTURA");
            txtUltimaNotaCredito.Text = Administrativo.ReadContador("NOTACREDITO");
            txtUltimaCotizacion.Text = Administrativo.ReadContador("COTIZACION");
            txtUltimaNotaEntrega.Text = Administrativo.ReadContador("NOTAENTREGA");
            this.parametroBindingSource.DataSource = data.GetFirstParametro();
            this.parametroBindingSource.ResetBindings(true);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmParametros_KeyDown);
            this.TipoIvaComboBoxEdit.Properties.Items.AddRange(new string[] { "INCLUIDO", "EXCLUIDO" });
            this.CalculoPreciosComboBoxEdit.Properties.Items.AddRange(new string[] { "SOBRE COSTOS", "SOBRE PRECIOS" });
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int factura = 1;
                int NotaCredito = 1;
                int NotaEntrega = 1;
                int Cotizacion = 1;
                parametroBindingSource.EndEdit();
                OK.SystemParameters.Licencia = EmpresaTextEdit.Text.GetHashCode().ToString();
                var result = data.GuardarParametros();
                if (result != null)
                {
                    MessageBox.Show(result, "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (int.TryParse(txtUltimaFactura.Text, out factura))
                {
                    Administrativo.SetContador("FACTURA", (int)txtUltimaFactura.Value);
                }
                if (int.TryParse(txtUltimaNotaCredito.Text, out NotaCredito))
                {
                    Administrativo.SetContador("NOTACREDITO", (int)txtUltimaNotaCredito.Value);
                }
                if (int.TryParse(txtUltimaNotaEntrega.Text, out NotaEntrega))
                {
                    Administrativo.SetContador("NOTAENTREGA", (int)txtUltimaNotaEntrega.Value);
                }
                if (int.TryParse(txtUltimaCotizacion.Text, out Cotizacion))
                {
                    Administrativo.SetContador("COTIZACION", (int)txtUltimaCotizacion.Value);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al guardar los datos \n{0}\n{1}", ex.Source, ex.Message), "Atencion", MessageBoxButtons.OK);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.parametroBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmParametros_KeyDown(object sender, KeyEventArgs e)
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
