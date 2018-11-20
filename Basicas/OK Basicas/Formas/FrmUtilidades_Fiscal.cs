using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace HK.Formas
{
    public partial class FrmUtilidades_Fiscal : Form
    {
        HK.BussinessLogic.FiscalConfig fiscalConfig;
        public FrmUtilidades_Fiscal()
        {

            InitializeComponent();
            fiscalConfig = new BussinessLogic.FiscalConfig();
            this.Load += new EventHandler(Frm_Load);
        }
        void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            this.bs.DataSource = fiscalConfig;
            this.bs.ResetBindings(true);
            this.PuertoComboBoxEdit.Properties.Items.AddRange(new object[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10" });
            this.TipoImpresoraComboBoxEdit.Properties.Items.AddRange(new object[] { "BIXOLON", "BIXOLON 2010", "EPSON", "WINDOWS", "TICKERA", "REMOTA", "NINGUNA" });
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmConfigurarEstacion_KeyDown);
        }

        void FrmConfigurarEstacion_KeyDown(object sender, KeyEventArgs e)
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

        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        void Aceptar_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            fiscalConfig.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
