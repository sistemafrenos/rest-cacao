using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.Clases;
using HK.Fiscales;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmRestaurant_Vale : Form
    {
        Administrativo data;
        Vale vale;
        public FrmRestaurant_Vale()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmVale_Load);
        }
        void FrmVale_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            data = new Administrativo();
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmValesItem_KeyDown);
            this.ConceptoTextEdit.Properties.Items.AddRange(data.getConceptosVales());
            this.CedulaButtonEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(CedulaButtonEdit_ButtonClick);
            vale = new Vale();
            this.valeBindingSource.DataSource = vale;
            this.valeBindingSource.ResetBindings(true);
        }

        void CedulaButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarMesoneros("");
            Mesonero mesonero = (Mesonero)F.registro;
            if (F.registro != null)
            {
                vale.Cedula = mesonero.Cedula;
                vale.Nombre = mesonero.Nombre;
            }
            else
            {
                CedulaButtonEdit.Text = null;
                NombreTextEdit.Text = null;
            }
            this.valeBindingSource.ResetCurrentItem();
        }
        private void Limpiar()
        {
            vale = new Vale();
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
            this.valeBindingSource.DataSource = vale;
            this.valeBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            valeBindingSource.EndEdit();
            vale = (Vale)valeBindingSource.Current;
            string result = data.GuardarVale(vale,true);
            if(result!=null)
            {
                IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
                Fiscal.ImprimeVale(vale);
            }
            this.DialogResult = DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.valeBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
        }
        private void FrmValesItem_KeyDown(object sender, KeyEventArgs e)
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

