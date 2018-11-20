using HK.BussinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmTablas_ClientesItem : Form
    {
        Tercero cliente;
        public Administrativo data;
        public FrmTablas_ClientesItem()
        {
            InitializeComponent();

            Load += Frm_Load;
        }
        void Frm_Load(object sender, EventArgs e)
        {
            if (data == null)
                data = new Administrativo();
            KeyPreview = true;
            KeyDown += Frm_KeyDown;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
            TipoPrecioComboBoxEdit.Properties.Items.AddRange(new object[] { "PRECIO 1", "PRECIO 2", "PRECIO 3", "PRECIO 4" });
            CedulaRifTextEdit.Validating += CedulaRifTextEdit_Validating;
            btnSeniat.Click += btnSeniat_Click;
        }

        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(Basicas.CedulaRif(CedulaRifTextEdit.Text));
            if (Empresa != null)
            {
                cliente.CedulaRif = Basicas.CedulaRif(CedulaRifTextEdit.Text);
                cliente.RazonSocial = Empresa;
                bs.ResetCurrentItem();
            }
        }

        void CedulaRifTextEdit_Validating(object sender, CancelEventArgs e)
        {
            Tercero temporal = data.GetByCedulaCliente(CedulaRifTextEdit.Text);
            if (temporal != null)
            {
                if (temporal.Activo != true)
                {
                    temporal.Activo = true;
                    MessageBox.Show("Este Registro esta eliminado y sera recuperado");
                }
                cliente = temporal;
                bs.DataSource = cliente;
            }
            CedulaRifTextEdit.Text = OK.CedulaRif(CedulaRifTextEdit.Text);
            bs.ResetCurrentItem();
        }
        private void Limpiar()
        {
            cliente = new Tercero("CLIENTE");
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            ShowDialog();
        }
        public void Modificar(Tercero cliente)
        {
            this.cliente = cliente;
            CedulaRifTextEdit.TabStop = false;
            CedulaRifTextEdit.Properties.AppearanceReadOnly.BackColor = SystemColors.Info;
            CedulaRifTextEdit.Properties.AppearanceReadOnly.ForeColor = SystemColors.InfoText;
            CedulaRifTextEdit.Properties.ReadOnly = true;
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {
            CedulaRifTextEdit.Text = cliente.CedulaRif;
            bs.DataSource = cliente;
            bs.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            cliente = (Tercero)bs.Current;
            cliente.CedulaRif = CedulaRifTextEdit.Text;
            string resultado = data.GuardarCliente(cliente, true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            bs.ResetCurrentItem();
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void Frm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    Aceptar.PerformClick();
                    e.Handled = true;
                    break;
                default: break;
            }
        }
    }
}