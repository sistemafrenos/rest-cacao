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
    public partial class FrmLapsoProveedor : Form
    {
        public bool pedirFechas = true;
        public DateTime desde { set; get; }
        public DateTime hasta { set; get; }
        Administrativo data;
        public Tercero proveedor;
        public FrmLapsoProveedor()
        {
            InitializeComponent();
            data = new Administrativo();
            this.Load += new EventHandler(FrmLapsoProveedor_Load);
        }
        void FrmLapsoProveedor_Load(object sender, EventArgs e)
        {
            this.txtDesde.DateTime = DateTime.Today;
            this.txtHasta.DateTime = DateTime.Today;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            if (pedirFechas == false)
            {
                itemDesde.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                itemHasta.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
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
            this.desde = txtDesde.DateTime;
            this.hasta = txtHasta.DateTime;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}

