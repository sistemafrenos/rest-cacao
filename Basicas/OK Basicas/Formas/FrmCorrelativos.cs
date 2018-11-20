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
    public partial class FrmCorrelativos : Form
    {
        public FrmCorrelativos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmCorrelativos_Load);
        }


       // DatosEntities db = new DatosEntities(OK.CadenaConexion);
        Contador NumeroFactura = new Contador();
        Contador NumeroControl = new Contador();
        Contador NotaCredito = new Contador();
        Contador NumeroRecibo = new Contador();
        Contador NumeroCotizacion = new Contador();
        void FrmCorrelativos_Load(object sender, EventArgs e)
        {
            //db = new DatosEntities(OK.CadenaConexion);
            //NumeroFactura = (from x in db.Contadores
            //                 where x.Variable == "NumeroFactura"
            //                 select x).FirstOrDefault();
            //NumeroControl = (from x in db.Contadores
            //                 where x.Variable == "NumeroControl"
            //                 select x).FirstOrDefault();
            //NotaCredito = (from x in db.Contadores
            //               where x.Variable == "NotaCredito"
            //               select x).FirstOrDefault();
            //NumeroRecibo = (from x in db.Contadores
            //                where x.Variable == "NumeroRecibo"
            //                select x).FirstOrDefault();
            //NumeroCotizacion = (from x in db.Contadores
            //                    where x.Variable == "NumeroCotizacion"
            //                    select x).FirstOrDefault();
            //txtNumeroFactura.Text = NumeroFactura.Valor.GetValueOrDefault(0).ToString("00000000");
            //txtNumeroControl.Text = NumeroControl.Valor.GetValueOrDefault(0).ToString();
            //txtNotaCredito.Text = NotaCredito.Valor.GetValueOrDefault(0).ToString();
            //txtNumeroRecibo.Text = NumeroRecibo.Valor.GetValueOrDefault(0).ToString();
            //txtNumeroCotizacion.Text = NumeroCotizacion.Valor.GetValueOrDefault(0).ToString();
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmParametros_KeyDown);
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                //NumeroFactura.Valor =  (int)txtNumeroFactura.Value;
                //NumeroControl.Valor = (int)txtNumeroControl.Value;
                //NotaCredito.Valor = (int)txtNotaCredito.Value;
                //NumeroRecibo.Valor = (int)txtNumeroRecibo.Value;
                //NumeroCotizacion.Valor = (int)txtNumeroCotizacion.Value;
                //db.SaveChanges();
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        private void FrmParametros_KeyDown(object sender, KeyEventArgs e)
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
