using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_UsuariosItem : Form
    {
        Administrativo data;
        Usuario usuario;
        public DevExpress.XtraBars.Ribbon.RibbonControl MyRibbon { set; get; }
        public FrmTablas_UsuariosItem()
        {
            InitializeComponent();
            usuario = new Usuario();
            data = new Administrativo();
            this.Load += new EventHandler(FrmUsuariosItem_Load);
        }

        void FrmUsuariosItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }

        //void ribbon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    DevExpress.XtraBars.BarManager x = (DevExpress.XtraBars.BarManager)sender;
        //    e.Item.Appearance.Font = !e.Item.Appearance.Font.Strikeout ? new Font("Tahoma", 8.25f, FontStyle.Strikeout) : new Font("Tahoma", 8.25f, FontStyle.Bold);
        //}
        private void Limpiar()
        {
            usuario = new Usuario();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar(string id)
        {
            usuario = data.FindUsuario(id);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            this.usuarioBindingSource.DataSource = usuario;
            this.usuarioBindingSource.ResetBindings(true);
            //if (usuarios.current.disabled != null)
            //{
            //    foreach (DevExpress.XtraBars.BarItem x in this.MyRibbon.Items)
            //    {
            //        if (usuarios.current.disabled.Contains(x.Name))
            //            x.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Strikeout);
            //    }
            //}
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.EndEdit();
            usuario = (Usuario)usuarioBindingSource.Current;
            //string disabled = "";
            //foreach (DevExpress.XtraBars.BarItem x in this.MyRibbon.Items)
            //{
            //    if (x.Name.Contains("barButton"))
            //    {
            //        if (x.Appearance.Font.Strikeout)
            //        {
            //            disabled += x.Name + ",";
            //        }
            //    }
            //}
           // usuarios.current.disabled = disabled;
            string resultado = data.GuardarUsuario(usuario, true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.usuarioBindingSource.ResetCurrentItem();
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
