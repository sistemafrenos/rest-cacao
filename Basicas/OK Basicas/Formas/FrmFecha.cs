using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmFecha : Form
    {
        public DateTime fecha { set; get; }
        public FrmFecha()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmFecha_Load);
        }
        void FrmFecha_Load(object sender, EventArgs e)
        {

            this.txtFecha.DateTime = DateTime.Today;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }

        void txtCajero_Validating(object sender, CancelEventArgs e)
        {
        }
        void FrmLapso_KeyDown(object sender, KeyEventArgs e)
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
            this.fecha = txtFecha.DateTime;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
