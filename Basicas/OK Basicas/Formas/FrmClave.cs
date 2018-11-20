using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmClave : Form
    {
        public Usuario usuario = null;
        Administrativo data;
        public FrmClave()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmClave_Load);
            this.KeyPreview = true;
        }

        void FrmClave_Load(object sender, EventArgs e)
        {
            this.KeyDown += new KeyEventHandler(FrmClave_KeyDown);
            this.txtClave.Validating += new CancelEventHandler(txtClave_Validating);
        }

        void txtClave_Validating(object sender, CancelEventArgs e)
        {
            Validar();
        }

        private void Validar()
        {
            usuario = data.GetByClaveUsuario(txtClave.Text);
            if (usuario != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        void FrmClave_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Return:
                    Validar();
                    break;
                case Keys.Escape:
                    this.usuario = null;
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
            }
        }

    }
}
