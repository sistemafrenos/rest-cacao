using HK.BussinessLogic.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK
{
    public partial class FrmRestaurant_CambioDeMesa : Form
    {
        public string CodigoMesa;
        Restaurant data;
        private MesasAbierta mesaAbierta;
        public FrmRestaurant_CambioDeMesa()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCambioDeMesa_Load);
        }
        void FrmCambioDeMesa_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            if (data == null)
                data = new Restaurant();
            if (mesaAbierta == null)
                mesaAbierta = data.GetByCodigoMesaAbierta(CodigoMesa);
            if (mesaAbierta == null)
                return;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmCambioDeMesa_KeyDown);
            MesaTextEdit.Validating += new System.ComponentModel.CancelEventHandler(MesaTextEdit_Validating);
            MesaTextEdit.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(MesaTextEdit_ButtonClick);
            this.mesasAbiertaBindingSource.DataSource = mesaAbierta;
            this.mesasAbiertaBindingSource.ResetBindings(true);
        }
        private void DoBuscar()
        {
            FrmBuscarEntidadesRestaurant f = new FrmBuscarEntidadesRestaurant();
            f.BuscarMesas(MesaTextEdit.Text);
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                var objeto = (Mesa)f.registro;
                if (objeto != null)
                    MesaTextEdit.Text = objeto.Codigo;
            }
        }
        void MesaTextEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {  
            DoBuscar();
        }
        void MesaTextEdit_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var objeto = data.GetByCodigoMesa(MesaTextEdit.Text);
            if (objeto != null)
                DoBuscar();
            else
            {
                MesaTextEdit.Text = objeto.Codigo;
            }
        }
        private void UnirMesas(MesasAbierta nuevaMesaAbierta)
        {
            string result = data.UnirMesas(mesaAbierta, nuevaMesaAbierta);
            if (result != null)
            {
                MessageBox.Show(result, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        void FrmCambioDeMesa_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.Enter:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            var nuevaMesaAbierta = data.GetByCodigoMesaAbierta(MesaTextEdit.Text);
            if (nuevaMesaAbierta.MesasAbiertasProductos.Count>0)
            {
                if (MessageBox.Show("La mesa destino esta ocupada, desea unir estas mesas", "Atencion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    UnirMesas(nuevaMesaAbierta);
                    return;
                }
                else
                {
                    return;
                }
            }
            string result = data.CambioDeMesa( mesaAbierta, MesaTextEdit.Text);
            if (result != null)
            {
                MessageBox.Show(result, "ATENCION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CodigoMesa = MesaTextEdit.Text;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
