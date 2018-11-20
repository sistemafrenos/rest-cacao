using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmDatosEmail : Form
    {
        public string asunto { set; get; }
        public string Texto { set; get; }
        public string destinatario { set; get; }
        public FrmDatosEmail()
        {
            InitializeComponent();
        }
        private void FrmDatosEmail_Load(object sender, EventArgs e)
        {

            txtAsunto.Text = this.asunto;
            txtDestinatario.Text = this.destinatario;
            txtTexto.Text = this.Texto;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmDatosEmail_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }

        void FrmDatosEmail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    break;
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bindingSource1.EndEdit();
            this.asunto = txtAsunto.Text;
            this.destinatario = txtDestinatario.Text;
            this.Texto = txtTexto.Text;
            this.Close();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bindingSource1.CancelEdit();
            this.Close();
        }
    }
}
