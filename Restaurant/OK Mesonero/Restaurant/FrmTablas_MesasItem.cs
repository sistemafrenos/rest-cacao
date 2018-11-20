using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmTablas_MesasItem : Form
    {
        public Restaurant data;
        public Mesa mesa;
        public FrmTablas_MesasItem()
        {
            InitializeComponent();
            if(data==null)
                 data = new Restaurant();
            if (mesa == null)
                mesa = new Mesa();
            this.Load += new EventHandler(FrmTablas_MesasItemLoad);
        }

        public string descripcion = null;
        void FrmTablas_MesasItemLoad(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            CrearCodigo.Click += btnCrearCodigo_Click;
            this.UbicacionComboBoxEdit.Properties.Items.AddRange(data.GetUbicaciones().Select(x=>x.Ubicacion).ToArray());
            Enlazar();
        }
        private void Limpiar()
        {
            mesa = new Mesa();
        }
        public void Incluir()
        {
            Limpiar();
            if (!string.IsNullOrEmpty(descripcion))
                mesa.Codigo = descripcion;
            Enlazar();
            this.ShowDialog();
        }
        public void Modificar(string id)
        {
            if (id == null)
                return;
            mesa = data.FindMesa(id);
            Enlazar();
            this.ShowDialog();
        }
        private void Enlazar()
        {
            this.mesaBindingSource.DataSource = mesa;
            this.mesaBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            mesaBindingSource.EndEdit();
            mesa = (Mesa)mesaBindingSource.Current;
            string resultado = data.GuardarMesa(mesa, true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Datos no guardados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.mesaBindingSource.ResetCurrentItem();
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
        void btnCrearCodigo_Click(object sender, EventArgs e)
        {
            CodigoTextEdit.Text = data.GetContadorCodigoMesa(UbicacionComboBoxEdit.Text);     
        }
    }
}
