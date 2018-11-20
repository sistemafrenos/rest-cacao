using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmRestaurant_Configurar : Form
    {
        BussinessLogic.RestaurantConfig sistemconfig;
        public FrmRestaurant_Configurar()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmConfigurarCorreo_Load);
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
            this.bindingSource2.EndEdit();
            sistemconfig.Save();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        void FrmConfigurarCorreo_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmConfigurarCorreo_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            sistemconfig = new BussinessLogic.RestaurantConfig();
            this.bindingSource2.DataSource = sistemconfig;
            this.bindingSource2.ResetBindings(true);
            ImpresoraComandasComboBoxEdit.Properties.Items.AddRange(new Object[] { "FISCAL", "WINDOWS","NINGUNA" });
            ImpresoraCorteCuentasComboBoxEdit.Properties.Items.AddRange(new Object[] { "FISCAL", "WINDOWS", "NINGUNA" });
        }
    }
}
