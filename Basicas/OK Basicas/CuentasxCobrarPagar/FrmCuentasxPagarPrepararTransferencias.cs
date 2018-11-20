using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmCuentasxPagarPrepararTransferencias : Form
    {
      //  DatosEntities db = new DatosEntities(OK.CadenaConexion);
        List<TercerosMovimiento> lista = new List<TercerosMovimiento>();
        Banco banco = null;
        DateTime fechaEjecucion = DateTime.Today;
        public Administrativo data;
        public Tercero proveedor;
        public FrmCuentasxPagarPrepararTransferencias()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(Frm_CxP_PrepararTransferencias_Load);
        }
        void Frm_CxP_PrepararTransferencias_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;

            txtFecha.Text = DateTime.Today.ToShortDateString();
            this.KeyDown += new KeyEventHandler(Frm_CxP_PrepararTransferencias_KeyDown);
            this.gridView1.DoubleClick += new EventHandler(gridView1_DoubleClick);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(gridView1_ValidateRow);
            this.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            this.btnGuardar.Click += new EventHandler(btnGuardar_Click);
            this.btnImprimirLote.Click += new EventHandler(btnImprimirLote_Click);
            this.btnImprimirLoteTotales.Click += new EventHandler(btnImprimirLoteTotales_Click);
            this.btnEnviarCorreo.Click += new EventHandler(btnEnviarCorreo_Click);
            this.btnProcesarLote.Click += new EventHandler(btnProcesarLote_Click);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - 50;
            Busqueda();
            this.CenterToScreen();
        }
        void btnProcesarLote_Click(object sender, EventArgs e)
        {
            //var lista = db.TercerosMovimientos.Where(x => x.PagarHoy > 0).ToList();
            //foreach (var item in lista)
            //{
            //    AplicarPagoLote(item);
            //}
            //this.Close();
        }
        private void AplicarPagoLote(TercerosMovimiento item)
        {
            if (item.Saldo.GetValueOrDefault(0) > 0)
            {
                TercerosMovimiento movimiento = new TercerosMovimiento();
                movimiento.PagarHoy = 0;
                movimiento.Concepto = "Pago/Abono Fact #" + item.Numero;
                movimiento.PagarHoy = item.PagarHoy;
                movimiento.Fecha = DateTime.Today;
                movimiento.Cuenta = item.Cuenta;
                movimiento.DescripcionCuenta = item.DescripcionCuenta;
                movimiento.Credito = movimiento.PagarHoy;
                movimiento.Tipo = "PAGO";
             //   movimiento.Numero = FactoryContadores.GetContador("PagoProveedor");
                movimiento.FormaDePago = "LOTE TRANSFERENCIA #" + txtNumeroLote.Text;
             //   db.TercerosMovimientos.Add(movimiento);
                item.Saldo = item.Saldo.GetValueOrDefault(0) - item.PagarHoy.GetValueOrDefault(0);
                item.PagarHoy = item.PagarHoy > item.Saldo ? item.Saldo : item.PagarHoy;
                item.Saldo = item.Saldo < 0 ? 0 : item.Saldo;
             //   db.SaveChanges();
            }
        }
        void btnImprimirLote_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                FrmReportes f = new FrmReportes();
                f.CxP_TransferenciaLote(lista.Where(item => item.PagarHoy.GetValueOrDefault(0) > 0).ToList(), false);
            }
        }
        void btnImprimirLoteTotales_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                FrmReportes f = new FrmReportes();
                f.CxP_TransferenciaLoteTotales(lista.Where(item => item.PagarHoy.GetValueOrDefault(0) > 0).ToList(), false);
            }
        }
        void btnEnviarCorreo_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                FrmReportes f = new FrmReportes();
                f.CxP_TransferenciaLote(lista.Where(item => item.PagarHoy.GetValueOrDefault(0) > 0).ToList(), true);
            }
        }
        bool Guardar()
        {
            return true;
        }
        void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Guardar())
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            TercerosMovimiento item = (TercerosMovimiento)e.Row;
            if (item != null)
            {
                if (item.PagarHoy.GetValueOrDefault(0) > item.Saldo)
                {
                    item.PagarHoy = item.Saldo;
                }
            }
        }
        void gridView1_DoubleClick(object sender, EventArgs e)
        {
            PagarHoy();
        }
        private void Busqueda()
        {
            lista = data.GetDocumentosPendientesProveedor(proveedor);
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
        }
        private void PagarHoy()
        {
            TercerosMovimiento movimiento = (TercerosMovimiento)this.bs.Current;
            if (movimiento == null)
                return;
            movimiento.PagarHoy = movimiento.Saldo;
        }

        void Frm_CxP_PrepararTransferencias_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnCancelar.PerformClick();
                    break;
                case Keys.F12:
                    btnGuardar.PerformClick();
                    break;
                case Keys.Space:
                    PagarHoy();
                    break;
            }
        }

        private void FrmCxP_PrepararTransferencias_Load(object sender, EventArgs e)
        {

        }

        private void btnEnviarTXT_Click(object sender, EventArgs e)
        {
            if (!ValidarPago())
                return;
            SaveFileDialog stxt = new SaveFileDialog();
            stxt.CheckPathExists = true;
            stxt.FileName = "PayMulBanesco.txt";
            stxt.FileOk += new CancelEventHandler(stxt_FileOk);
            stxt.ShowDialog();
        }
        private bool ValidarPago()
        {
            bool retorno = false;
            if (banco == null)
            {
                MessageBox.Show("Debe seleccionar el banco");
                return retorno;
            }
            foreach (TercerosMovimiento item in lista.Where(x => x.PagarHoy > 0))
            {
                if (item.PagarHoy.GetValueOrDefault(0) > item.Saldo.GetValueOrDefault(0))
                {
                    item.PagarHoy = item.Saldo;
                }
                // pendiente
                
                if (string.IsNullOrEmpty(proveedor.NumeroCuenta))
                {
                    MessageBox.Show("Este proveedor {0} no tiene cuenta bancaria asignada",proveedor.RazonSocial);
                    item.PagarHoy = null;
                }
                else
                    if (item.NumeroCuenta == null)
                    {
                        item.NumeroCuenta =proveedor.NumeroCuenta;
                    }
            }
            return true;
        }

        void stxt_FileOk(object sender, CancelEventArgs e)
        {
            Administrativo data = new Administrativo();
            Tercero proveedor;
            if (!ValidarPago())
                return;
            string filename = ((SaveFileDialog)sender).FileName;
            System.IO.StreamWriter f = new System.IO.StreamWriter(filename);
            // Registro De Control 
            f.Write(OK.SystemParameters.EmpresaRif + "\t");
            f.Write("HDR");
            f.Write("BANESCO");
            f.Write("E");
            f.Write("D  95B");
            f.Write("PAYMUL");
            f.WriteLine("P");
            // Registro De Encabezado
            f.Write("01");
            f.Write("SCV"); // Pago a proveedores 
            // f.Write("SAL"); // Nomina
            f.Write("                                ");
            f.Write("9");
            f.Write(txtNumeroLote.Text.PadRight(35));
            f.WriteLine("{0}{1}{2}{3}{4}{5}",
            DateTime.Today.Year.ToString("0000"),
            DateTime.Today.Month.ToString("00"),
            DateTime.Today.Day.ToString("00"),
            DateTime.Now.Hour.ToString("00"),
            DateTime.Now.Minute.ToString("00"),
            DateTime.Now.Second.ToString("00")
            );
            // Registro De Debito / Credito
            int IdDebito = 0;
            int IdCredito = 0;
            double TotalCreditos = 0;
            double TotalDebitos = 0;
            foreach (var item in lista.Where(x => x.PagarHoy > 0))
            {
                proveedor = data.FindProveedor(item.ID);
                // Debito
                IdDebito++;
                TotalDebitos += item.PagarHoy.GetValueOrDefault(0);
                f.Write("02");
                f.Write(IdDebito.ToString("00000000").PadRight(30));
                f.Write(OK.SystemParameters.EmpresaRif.PadRight(17));
                f.Write(OK.SystemParameters.Empresa.PadRight(35));
                f.Write(item.PagarHoy.Value.ToString("000000000000.00").Replace(".", ""));
                f.Write("VEF");
                f.Write(" ");
                f.Write(banco.Cuenta.PadRight(34));
                f.Write("BANESCO".PadRight(11));
                f.WriteLine("{0}{1}{2}",
                fechaEjecucion.Year.ToString("0000"),
                fechaEjecucion.Month.ToString("00"),
                fechaEjecucion.Day.ToString("00")
                );
                // Credito
                IdCredito++;
                TotalCreditos += item.PagarHoy.GetValueOrDefault(0);
                f.Write("03");
                f.Write(IdCredito.ToString("00000000").PadRight(30));
                f.Write(item.PagarHoy.Value.ToString("000000000000.00").Replace(".", ""));
                f.Write("VEF");
                f.Write(proveedor.NumeroCuenta.PadRight(34));
                f.Write(proveedor.NumeroCuenta.Substring(0, 4).PadRight(11));
                f.Write(" ".PadRight(3));
                f.Write(proveedor.CedulaRif.PadRight(17));
                f.Write(proveedor.RazonSocial.PadRight(70));
                f.Write(proveedor.Email != null ? proveedor.Email.PadRight(70) : "");
                f.Write(proveedor.Telefonos != null ? proveedor.Telefonos.PadRight(25) : "");
                f.Write(proveedor.ContactoCedulaRif != null ? proveedor.ContactoCedulaRif.PadRight(17) : "");
                f.Write(proveedor.Contacto != null ? proveedor.Contacto.PadRight(35) : "");
                f.Write(" "); // Calificador Fideicomiso
                f.Write(" ".PadRight(30)); // Ficha Empleado
                f.Write(" ".PadRight(2)); // Tipo Nomnina
                f.Write(" ".PadRight(21)); // Ubicacion Geografica
                f.WriteLine(item.NumeroCuenta.Substring(0, 4) == "0134" ? "42 " : "425"); // Forma de pago o 42 
            }
            // Registro De Documento
            // Registro De Ajuste de Credito 

            // Registro De Totales
            f.Write("06");
            f.Write(IdCredito.ToString("00000000").PadRight(15));
            f.Write(IdDebito.ToString("00000000").PadRight(15));
            f.WriteLine(TotalDebitos.ToString("000000000000.00").Replace(".", ""));
            f.Close();
        }
    }
}
