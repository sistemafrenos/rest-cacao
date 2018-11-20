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
    public partial class FrmRestaurant_UsuariosItem : Form
    {
        public Usuario registro = null;
        public FrmRestaurant_UsuariosItem()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmUsuariosItem_Load);
        }

        void FrmUsuariosItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.ribbon.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(ribbon_ItemClick);
            this.ItemForPuedeCambiarMesa.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForPuedeDarConsumoInterno.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForPuedeDividirCuentas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForPuedePedirCorteDeCuenta.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            this.ItemForPuedeSepararCuentas.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
        }

        void ribbon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DevExpress.XtraBars.BarManager x = (DevExpress.XtraBars.BarManager)sender;
            e.Item.Appearance.Font = !e.Item.Appearance.Font.Strikeout ? new Font("Tahoma", 8.25f, FontStyle.Strikeout) : new Font("Tahoma", 8.25f, FontStyle.Bold);
        }
        
        private void Limpiar()
        {
            registro = new Usuario();
            registro.Activo = true;
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar()
        {
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            if (registro == null)
            {
                Limpiar();
            }
            this.usuarioBindingSource.DataSource = registro;
            this.usuarioBindingSource.ResetBindings(true);
            if (registro.disabled != null)
            {
                foreach (DevExpress.XtraBars.BarItem x in this.ribbon.Items)
                {
                    if (registro.disabled.Contains(x.Name))
                        x.Appearance.Font = new Font("Tahoma", 8.25f, FontStyle.Strikeout);
                }
            }
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            usuarioBindingSource.EndEdit();
            registro = (Usuario)usuarioBindingSource.Current;
          //  registro.UltimaEdicion = DateTime.Now;
          //  registro.IdUsuario = OK.usuario.IdUsuario;
            registro.TipoUsuario = "ADMINISTRATIVO";
            string disabled = "";
            foreach (DevExpress.XtraBars.BarItem x in this.ribbon.Items)
            {
                if (x.Name.Contains("barButton"))
                {
                    if (x.Appearance.Font.Strikeout)
                    {
                        disabled += x.Name + ",";
                    }
                }
            }
            registro.disabled = disabled;
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