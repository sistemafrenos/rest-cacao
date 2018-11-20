using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_MesonerosItem : Form
    {
        public Mesonero mesonero;
        public Restaurant restaurant;
        public FrmTablas_MesonerosItem()
        {
            InitializeComponent();
            mesonero = new Mesonero();
            if (restaurant == null)
            {
                restaurant = new Restaurant();
            }
            this.Load += new EventHandler(FrmTablas_MesasItemLoad);
        }
        void FrmTablas_MesasItemLoad(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            CedulaTextEdit.Validating += CedulaTextEdit_Validating;
            Enlazar();
        }

        void CedulaTextEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CedulaTextEdit.Text = OK.CedulaRif(CedulaTextEdit.Text);
        }
        private void Limpiar()
        {
            mesonero = new Mesonero();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar(string id)
        {
            if (id == null)
                return;
            mesonero = restaurant.FindMesonero(id);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            this.mesoneroBindingSource.DataSource = mesonero;
            this.mesoneroBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            mesoneroBindingSource.EndEdit();
            mesonero = (Mesonero)mesoneroBindingSource.Current;
            string resultado = restaurant.GuardarMesonero(mesonero,true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Datos no guardados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.mesoneroBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
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
