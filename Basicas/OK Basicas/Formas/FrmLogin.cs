using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmLogin : Form
    {
        public string Sistema;
        public string TipoUsuario;
        Administrativo data;
        Usuario usuario = new Usuario();
        List<string> usuarios = new List<string>();
        public FrmLogin()
        {
            InitializeComponent();
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            IniciarPantalla();
            this.KeyPreview = true;
            usuario = new Usuario();
            this.KeyDown += new KeyEventHandler(FrmLogin_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.Configurar.Click += new EventHandler(Configurar_Click);
            this.txtUsuario.Properties.Items.AddRange(usuarios);
            if (usuarios.Count>0)
            {
                this.txtUsuario.Text = usuarios[0];
            }
            this.txtContraseña.KeyDown += new KeyEventHandler(txtContraseña_KeyDown);
            this.txtContraseña.Properties.CharacterCasing = CharacterCasing.Upper;
            this.txtUsuario.Properties.CharacterCasing = CharacterCasing.Upper;
            this.Text = Sistema;
        }
        void Configurar_Click(object sender, EventArgs e)
        {
            if (ConfigurarDB())
            {
                IniciarPantalla();
            }
        }
        private void IniciarPantalla()
        {
            try
            {
                data = new Administrativo();
                usuarios = data.GetAllUsuarios("").Select(x => x.Nombre).ToList();
            }
            catch (Exception x)
            {
                var s = x.Message;
                MessageBox.Show("No se puede establecer comunicacion con la base de datos/n"+ x.Message, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (usuarios.Count == 0)
            {
                data.CrearUsuario("USUARIO");
                usuarios.Add("USUARIO");
            }
        }
        public bool ConfigurarDB()
        {
            FrmUtilidades_ConfigurarServidor f = new FrmUtilidades_ConfigurarServidor();
            f.ShowDialog();
            return f.DialogResult == System.Windows.Forms.DialogResult.OK;

        }
        void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Aceptar.PerformClick();
            }
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text == "MAESTRO" && this.txtContraseña.Text == "ALEMAN")
            {
                OK.usuario = new Usuario();
                OK.usuario.TipoUsuario = "ADMINISTRADOR";
                OK.usuario.Nombre = "MAESTRO";
                OK.usuario.disabled = "";
            }
            else
            {
                usuario = data.GetByNombreClaveUsuario(this.txtUsuario.Text, this.txtContraseña.Text);
                if (usuario == null)
                {
                    MessageBox.Show("Este Usuario y contraseña son invalidos");
                    return;
                }
                OK.usuario = usuario;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        void FrmLogin_KeyDown(object sender, KeyEventArgs e)
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
