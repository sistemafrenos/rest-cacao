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
    public partial class FrmBancosReporteMovimientos : Form
    {
        public Banco banco = null;
        public MaestroDeCuenta cuenta = null;
        public Tercero proveedor = null;
        public DateTime desde = DateTime.Today;
        public DateTime hasta = DateTime.Today;
        public FrmBancosReporteMovimientos()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmBancosReporteMovimientos_Load);
        }

        void  FrmBancosReporteMovimientos_Load(object sender, EventArgs e)
        {
            this.txtDesde.DateTime = desde;
            this.txtHasta.DateTime = hasta;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.Aceptar.Click += new EventHandler(Aceptar_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
        }
        void FrmLapso_KeyDown(object sender, KeyEventArgs e)
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
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void Aceptar_Click(object sender, EventArgs e)
        {
            this.desde = txtDesde.DateTime;
            this.hasta = txtHasta.DateTime;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //using (var db = new DatosEntities(OK.CadenaConexion))
            //{
            //    string cadena = "";
            //    var consulta = from x in db.BancosMovimientos
            //                   where x.Fecha >= desde && x.Fecha <= hasta
            //                   select x;
            //    if (banco != null)
            //    {
            //        consulta = from x in consulta
            //                   where x.IdBanco == banco.IdBanco
            //                   select x;
            //    }
            //    if (Cheques.Checked)
            //        cadena += "CHEQUE/";
            //    if (depositos.Checked)
            //        cadena += "DEPOSITO/";
            //    if (NotaCR.Checked)
            //        cadena += "NOTA CR/";
            //    if (NotaDB.Checked)
            //        cadena += "NOTA DB/";
            //    if (transferencias.Checked)
            //        cadena += "TRANSFERENCIA/";
            //    if (cadena != "")
            //        consulta = from x in consulta
            //                   where  cadena.Contains(x.Tipo)
            //                   select x;
            //    FrmReportes f = new FrmReportes();
            //    f.Banco_RegistroDeMovimientos(consulta.ToList(), desde, hasta);
            //}
            this.Close();
        }
    }
}
