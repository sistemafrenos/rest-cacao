using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;

namespace HK.Formas
{
    public partial class FrmCuentasxPagarAplicarProntoPago : Form
    {
        public Documento compra = new Documento();
        public Tercero proveedor = new Tercero();
        public TercerosMovimiento registro = new TercerosMovimiento();
        public FrmCuentasxPagarAplicarProntoPago()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCuentasxPagarAplicarProntoPago_Load);
        }

        void FrmCuentasxPagarAplicarProntoPago_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Frm_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.proveedoresMovimientoBindingSource.DataSource = registro;
            this.proveedoresMovimientoBindingSource.ResetBindings(true);
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
        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TercerosMovimiento p = new TercerosMovimiento();
                p.Fecha = DateTime.Today;
                p.Comentarios = "PRONTO PAGO";
                p.Concepto = string.Format("PRONTO PAGO FACTURA #{0} ", compra.Numero);
                p.Tipo = "NOTA CR";
                p.Credito = compra.DescuentoProntoPago;
                p.Fecha = DateTime.Today;
                p.Numero = p.Numero;
                p.Saldo = 0;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar los datos \n" + ex.Source + "\n" + ex.Message, "Atencion", MessageBoxButtons.OK);
            }
        }
        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.proveedoresMovimientoBindingSource.ResetCurrentItem();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
