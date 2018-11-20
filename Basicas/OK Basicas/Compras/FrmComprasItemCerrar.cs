using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmAdministrativo_ComprasItemCerrar : Form
    {
        public Documento registro;
        public FrmAdministrativo_ComprasItemCerrar()
        {
            InitializeComponent();
            KeyDown += FrmAdministrativo_ComprasItemCerrar_KeyDown;
            this.Load += new EventHandler(FrmComprasItemCerrar_Load);
            this.DescuentoCalcEdit.Validated += new EventHandler(DescuentoCalcEdit_Validated);
            this.MontoExentoCalcEdit.Validated += new EventHandler(MontoExentoCalcEdit_Validated);
            this.MontoGravableBTextEdit.Validated += new EventHandler(MontoGravableBTextEdit_Validated);
            this.MontoGravableCalcEdit.Validated += new EventHandler(MontoGravableCalcEdit_Validated);
            this.MontoImpuestosLicoresCalcEdit.Validated += new EventHandler(MontoImpuestosLicoresCalcEdit_Validated);
            this.MontoTotalCalcEdit.KeyDown += new KeyEventHandler(MontoTotalCalcEdit_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }

        void FrmAdministrativo_ComprasItemCerrar_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    registro.Totalizar();
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
                case Keys.F12:
                    this.Aceptar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }

        void MontoImpuestosLicoresCalcEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registro.MontoImpuestosLicores = (double)Editor.Value;
            registro.Totalizar();
            compraBindingSource.ResetCurrentItem();
        }
        void MontoGravableCalcEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registro.MontoGravable = (double)Editor.Value;
            registro.Totalizar();
            compraBindingSource.ResetCurrentItem();
        }
        void MontoGravableBTextEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registro.MontoGravableB = (double)Editor.Value;
            registro.Totalizar();
            compraBindingSource.ResetCurrentItem();
        }
        void MontoExentoCalcEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registro.MontoExento = (double)Editor.Value;
            registro.Totalizar();
            compraBindingSource.ResetCurrentItem();
        }
        void DescuentoCalcEdit_Validated(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.CalcEdit Editor = (DevExpress.XtraEditors.CalcEdit)sender;
            registro.Descuentos = (double)Editor.Value;
            registro.Totalizar();
            compraBindingSource.ResetCurrentItem();
        }
        void MontoTotalCalcEdit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.Aceptar.PerformClick();
            }
        }

        void FrmComprasItemCerrar_Load(object sender, EventArgs e)
        {
            registro.Totalizar();
            this.compraBindingSource.DataSource = registro;
            this.compraBindingSource.ResetBindings(true);
        }
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                compraBindingSource.EndEdit();
                registro = (Documento)compraBindingSource.Current;
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.compraBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
