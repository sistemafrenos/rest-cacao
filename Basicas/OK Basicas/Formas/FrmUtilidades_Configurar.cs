using System;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmUtilidades_Configurar : Form
    {
        HK.BussinessLogic.SistemaConfig fiscalConfig;
        public FrmUtilidades_Configurar()
        {

            InitializeComponent();
            fiscalConfig = new BussinessLogic.SistemaConfig();
            this.Load += new EventHandler(Frm_Load);
        }
        void Frm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            this.bs.DataSource = fiscalConfig;
            this.bs.ResetBindings(true);
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
