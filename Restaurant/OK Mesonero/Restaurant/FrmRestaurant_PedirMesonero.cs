using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmRestaurant_PedirMesonero : Form
    {
        public Mesonero mesonero;
        Restaurant restaurant;
        public FrmRestaurant_PedirMesonero()
        {
            InitializeComponent();
            mesonero = new Mesonero();
            restaurant = new Restaurant();
            Load += FrmRestaurant_PedirMesonero_Load;
        }

        void FrmRestaurant_PedirMesonero_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += FrmRestaurant_PedirMesonero_KeyDown;
            button0.Click += button_Click;
            button1.Click += button_Click;
            button2.Click += button_Click;
            button3.Click += button_Click;
            button4.Click += button_Click;
            button5.Click += button_Click;
            button6.Click += button_Click;
            button7.Click += button_Click;
            button8.Click += button_Click;
            button9.Click += button_Click;
            btnLimpiar.Click += Limpiar_Click;
            txtClave.Validating += txtClave_Validating;
            txtClave.KeyDown += txtClave_KeyDown;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
        }

        void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.Return)
                Aceptar.PerformClick();
        }

        void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        void Aceptar_Click(object sender, EventArgs e)
        {
            mesonero = restaurant.GetByCodigoMesonero(txtClave.Text);
            if (mesonero == null)
            {
                txtClave.Text = "";
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        void txtClave_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Aceptar.PerformClick();
        }

        void button_Click(object sender, EventArgs e)
        {
            txtClave.Text = txtClave.Text + ((Button)sender).Text;
        }
        void Limpiar_Click(object sender, EventArgs e)
        {
            txtClave.Text = "";
        }

        void FrmRestaurant_PedirMesonero_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F12)
                Aceptar.PerformClick();
            if (e.KeyCode == Keys.Escape)
                Cancelar.PerformClick();
        }
    }
}
