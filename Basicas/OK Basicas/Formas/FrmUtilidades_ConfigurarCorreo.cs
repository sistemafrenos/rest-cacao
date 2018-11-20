using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmUtilidades_ConfigurarCorreo : Form
    {
        List<string> servidores = new List<string> { "smtp.gmail.com", "smtp.live.com", "pop.server.com" };
        BussinessLogic.EmailConfig mailconfig;
        BussinessLogic.SistemaConfig sistemconfig;
        public FrmUtilidades_ConfigurarCorreo()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmConfigurarCorreo_KeyDown);
            this.HostTextEdit.Validated += new EventHandler(HostTextEdit_Validated);
            this.Load += new EventHandler(FrmConfigurarCorreo_Load);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }

        void HostTextEdit_Validated(object sender, EventArgs e)
        {
            switch (HostTextEdit.Text)
            {
                case "smtp.gmail.com":
                    this.txtPuerto.Text = "587";
                    break;
                case "smtp.live.com":
                    this.txtPuerto.Text = "587";
                    break;
                default :
                    this.txtPuerto.Text = "26";
                    break;
            }
        }

        void FrmConfigurarCorreo_KeyDown(object sender, KeyEventArgs e)
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
            this.bindingSource1.EndEdit();
            this.bindingSource2.EndEdit();
            mailconfig.Save();
            sistemconfig.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        void FrmConfigurarCorreo_Load(object sender, EventArgs e)
        {
            mailconfig = new BussinessLogic.EmailConfig();
            sistemconfig = new BussinessLogic.SistemaConfig();
            this.HostTextEdit.Properties.Items.AddRange(servidores);
            this.bindingSource1.DataSource = mailconfig;
            this.bindingSource1.ResetBindings(true);
            this.bindingSource2.DataSource = sistemconfig;
            this.bindingSource2.ResetBindings(true);
        }
    }
}
