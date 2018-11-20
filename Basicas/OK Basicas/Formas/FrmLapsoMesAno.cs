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
    public partial class FrmLapsoMesAno : Form
    {
        int Mes = DateTime.Today.Month;
        int Ano = DateTime.Today.Year;
        public FrmLapsoMesAno()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmLapsoMesAno_Load);
        }

        void FrmLapsoMesAno_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            for (int i = Ano - 5; i <= Ano; i++)
                txtAño.Properties.Items.Add(i.ToString());
            for (int i = 1; i <= 12; i++)
                txtMes.Properties.Items.Add(i.ToString());
            this.txtAño.Text = Ano.ToString();
            this.txtMes.Text = Mes.ToString();
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
            try
            {
                this.Mes = Convert.ToInt16(txtMes.Text);
                this.Ano = Convert.ToInt16(txtAño.Text);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch
            {
            }
        }
    }
}
