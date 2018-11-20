using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using HK;


namespace HK.Formas
{
    public partial class FrmSeniat_RetencionesISLRItem : Form
    {
        public BussinessLogic.RetencionesISLR retenciones;
        string Mes = "";
        string Ano = "";
        public FrmSeniat_RetencionesISLRItem()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmRetencionesISLRItem_Load);
        }

        void FrmRetencionesISLRItem_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            retenciones = new BussinessLogic.RetencionesISLR();
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.MontoDocumentoCalcEdit.Validated += new EventHandler(MontoDocumentoCalcEdit_Validated);
            this.BaseImponibleCalcEdit.Validating += new CancelEventHandler(BaseImponibleCalcEdit_Validating);
            this.MontoSujetoRetencionCalcEdit.Validating += new CancelEventHandler(MontoSujetoRetencionCalcEdit_Validating);
            this.PorcentajeRetencionCalcEdit.Validating += new CancelEventHandler(PorcentajeRetencionCalcEdit_Validating);
        }

        void MontoSujetoRetencionCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.retencionesISLRBindingSource.EndEdit();
            retenciones.current.Calcular();
        }
        void PorcentajeRetencionCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            this.retencionesISLRBindingSource.EndEdit();
            retenciones.current.Calcular();
        }
        void MontoDocumentoCalcEdit_Validated(object sender, EventArgs e)
        {
            this.retencionesISLRBindingSource.EndEdit();
            retenciones.current.BaseImponible = retenciones.current.MontoTotal.GetValueOrDefault(0) / (1 + (OK.SystemParameters.TasaIva.GetValueOrDefault(0) / 100));
            retenciones.current.MontoSujetoRetencion = retenciones.current.BaseImponible;
            retenciones.current.MontoIva = retenciones.current.BaseImponible * OK.SystemParameters.TasaIva.GetValueOrDefault(0) / 100;
            retenciones.current.Calcular();
        }
        void BaseImponibleCalcEdit_Validating(object sender, CancelEventArgs e)
        {
            retencionesISLRBindingSource.EndEdit();
            retenciones.current.MontoSujetoRetencion = retenciones.current.BaseImponible;
            retenciones.current.Calcular();
        }
        private void Limpiar()
        {
            retenciones.Clear();
        }
        public void Incluir(string mes, string año)
        {
            Mes = mes;
            Ano = año;
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
            this.retencionesISLRBindingSource.DataSource = retenciones.current;
            this.retencionesISLRBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                retencionesISLRBindingSource.EndEdit();
                retenciones.current = (RetencionISLR)retencionesISLRBindingSource.Current;
                retenciones.current.Calcular();
                retenciones.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error al guardar los datos \n{0}\n{1}", ex.Source, ex.Message), "Atencion", MessageBoxButtons.OK);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.retencionesISLRBindingSource.ResetCurrentItem();
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



        public void CrearRetencion(Documento compra)
        {
            Mes = compra.Mes.Value.ToString("00");
            Ano = compra.Ano.Value.ToString("00");
            compra.Calcular();
            Limpiar();
            Enlazar();
            this.ShowDialog();
        }
    }
}
