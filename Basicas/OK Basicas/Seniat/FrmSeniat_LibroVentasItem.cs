using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmSeniat_LibroVentasItem : Form
    {
        public LibroVenta registro;
        public Administrativo data;
        private Tercero proveedor = new Tercero();
        public FrmSeniat_LibroVentasItem()
        {
            InitializeComponent();

            this.Load += new EventHandler(FrmLibroVentasItem_Load);
        }

        void FrmLibroVentasItem_Load(object sender, EventArgs e)
        {
            if (data == null)
                data = new Administrativo();
            this.KeyPreview = true;
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyDown += new KeyEventHandler(FrmLibroVentasItem_KeyDown);
            this.MontoExentoCalcEdit.Validating += CalcEdit_Validating;
            this.MontoGravableContribuyentesCalcEdit.Validating += CalcEdit_Validating;
            this.MontoGravableNoContribuyentesCalcEdit.Validating += CalcEdit_Validating;
            this.TasaIvaContribuyentesCalcEdit.Validating += CalcEdit_Validating;
            this.TasaIvaNoContribuyentesCalcEdit.Validating += CalcEdit_Validating;
            MontoExentoCalcEdit.KeyDown += MontoExentoCalcEdit_KeyDown;
            this.MontoExentoCalcEdit.KeyDown += MontoExentoCalcEdit_KeyDown;
            this.MontoGravableContribuyentesCalcEdit.KeyDown += MontoExentoCalcEdit_KeyDown;
            this.MontoGravableNoContribuyentesCalcEdit.KeyDown += MontoExentoCalcEdit_KeyDown;
            this.TasaIvaContribuyentesCalcEdit.KeyDown += MontoExentoCalcEdit_KeyDown;
            this.TasaIvaNoContribuyentesCalcEdit.KeyDown += MontoExentoCalcEdit_KeyDown;
            this.CedulaRifButtonEdit.Validating+=CedulaRifButtonEdit_Validating;
            this.CedulaRifButtonEdit.ButtonClick+=CedulaRifButtonEdit_ButtonClick;
        }

        #region Clientes
        void CedulaRifButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmBuscarEntidades F = new FrmBuscarEntidades();
            F.BuscarClientes("");
            if (F.registro != null)
            {
                Leercliente((Tercero)F.registro);
                this.libroVentaBindingSource.ResetCurrentItem();
            }
        }
        void CedulaRifButtonEdit_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.ButtonEdit Editor = (DevExpress.XtraEditors.ButtonEdit)sender;
            if (string.IsNullOrEmpty(Editor.Text))
                return;
            if (!Editor.IsModified)
                return;
            string Texto = Editor.Text;
            this.libroVentaBindingSource.EndEdit();
            Tercero[] T = data.GetAllClientes(Texto);
            switch (T.Length)
            {
                case 0:
                    registro.CedulaRif = Basicas.CedulaRif(Editor.Text);
                    registro.RazonSocial = "";
                    break;
                case 1:
                    Leercliente(T[0]);
                    break;
                default:
                    FrmBuscarEntidades F = new FrmBuscarEntidades();
                    F.BuscarClientes(Texto);
                    if (F.registro != null)
                    {
                        Leercliente((Tercero)F.registro);
                    }
                    break;
            }
            this.libroVentaBindingSource.ResetCurrentItem();
        }
        private void Leercliente(Tercero cliente)
        {
            if (cliente != null)
            {
                registro.CedulaRif = Basicas.CedulaRif(cliente.CedulaRif);
                registro.RazonSocial = cliente.RazonSocial;
            }
        }
        #endregion
        void MontoExentoCalcEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                Calcular();
        }
        void CalcEdit_Validating(object sender, CancelEventArgs e)
        {
            Calcular();
        }

        private void Calcular()
        {
            libroVentaBindingSource.EndEdit();
            registro.Calcular();
            this.libroVentaBindingSource.ResetCurrentItem();
        }
        private void Limpiar()
        {
            registro = new LibroVenta();
            proveedor = new Tercero();
        }
        public void Incluir(string mes, string año)
        {
            Limpiar();
            registro.Mes = Convert.ToInt16(mes);
            registro.Ano = Convert.ToInt16(año);
            registro.TasaIvaContribuyentes = OK.SystemParameters.TasaIva;
            registro.TasaIvaNoContribuyentes = OK.SystemParameters.TasaIva;
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
            this.libroVentaBindingSource.DataSource = registro;
            this.libroVentaBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                libroVentaBindingSource.EndEdit();
                registro = (LibroVenta)libroVentaBindingSource.Current;
                registro.CedulaRif = CedulaRifButtonEdit.Text;
                registro.Calcular();
                string resultado = data.GuardarLibroVenta(registro, true);
                if (!string.IsNullOrEmpty(resultado))
                {
                    MessageBox.Show(resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al validar los datos \n" + ex.Message, "Atencion", MessageBoxButtons.OK);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.libroVentaBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmLibroVentasItem_KeyDown(object sender, KeyEventArgs e)
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

        private void NotaCreditoTextEdit_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
