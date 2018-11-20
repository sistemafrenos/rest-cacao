using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmTablas_ProveedoresItem : Form
    {
        Tercero proveedor;
        public Administrativo data;
        public FrmTablas_ProveedoresItem()
        {
            InitializeComponent();
            if(data==null)
                data = new Administrativo();
            Load += FrmProveedorsItem_Load;
        }
        void FrmProveedorsItem_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyDown += Frm_KeyDown;
            Aceptar.Click += Aceptar_Click;
            Cancelar.Click += Cancelar_Click;
        //    BancoComboBoxEdit.Properties.Items.AddRange( data.GetAllBancos());
            CedulaRifTextEdit.Validating += CedulaRifTextEdit_Validating;
            btnSeniat.Click += btnSeniat_Click;

        }

        void btnSeniat_Click(object sender, EventArgs e)
        {
            string Empresa = Basicas.VerificarRif(Basicas.CedulaRif(CedulaRifTextEdit.Text));
            if (Empresa != null)
            {
                proveedor.CedulaRif = Basicas.CedulaRif(CedulaRifTextEdit.Text);
                proveedor.RazonSocial = Empresa;
                bs.ResetCurrentItem();
            }
        }

        void CedulaRifTextEdit_Validating(object sender, CancelEventArgs e)
        {
            Tercero temporal = data.GetByCedulaRifProveedor( OK.CedulaRif(CedulaRifTextEdit.Text));
            if (temporal != null)
            {
                if (temporal.Activo != true)
                {
                    temporal.Activo = true;
                    MessageBox.Show("Este Regisgro esta eliminado y sera recuperado");
                }
                proveedor = temporal;
                bs.DataSource = proveedor;
            }
            CedulaRifTextEdit.Text = OK.CedulaRif(CedulaRifTextEdit.Text);
            bs.ResetCurrentItem();
        }
        private void Limpiar()
        {
            proveedor = new Tercero();
        }
        public void Incluir()
        {
            Limpiar();
            Enlazar();
            ShowDialog();
        }
        public void Modificar(Tercero registro)
        {
            proveedor = registro;
            CedulaRifTextEdit.TabStop = false;
            CedulaRifTextEdit.Properties.AppearanceReadOnly.BackColor = SystemColors.Info;
            CedulaRifTextEdit.Properties.AppearanceReadOnly.ForeColor = SystemColors.InfoText;
            CedulaRifTextEdit.Properties.ReadOnly = true;
            Enlazar();
            ShowDialog();
        }
        private void Enlazar()
        {
            CedulaRifTextEdit.Text = proveedor.CedulaRif;
            bs.DataSource = proveedor;
            bs.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            bs.EndEdit();
            proveedor = (Tercero)bs.Current;
            proveedor.CedulaRif = CedulaRifTextEdit.Text;
            string resultado = data.GuardarProveedor(proveedor,true);
            if (!string.IsNullOrEmpty(resultado))
            {
                MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
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
