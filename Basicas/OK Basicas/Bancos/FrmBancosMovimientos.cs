using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class FrmBancosMovimientos : Form
    {
        Administrativo data;
        public Banco banco;
        List<BancosMovimiento> lista = new List<BancosMovimiento>();
        public FrmBancosMovimientos()
        {
            InitializeComponent();
            if (data == null)
                data = new Administrativo();
            this.Load += new EventHandler(FrmBancosMovimientos_Load);
        }
        void FrmBancosMovimientos_Load(object sender, EventArgs e)
        {
            this.txtAño.Text = DateTime.Today.Year.ToString();
            this.txtMes.Text = DateTime.Today.Month.ToString("00");
            this.Height = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Width = Screen.PrimaryScreen.Bounds.Width - 50;
            this.btnEmitirCheque.Click += new EventHandler(btnEmitirCheque_Click);
            this.btnDeposito.Click += new EventHandler(btnDeposito_Click);
            this.btnTransferencia.Click += new EventHandler(btnTransferencia_Click);
            this.btnCargar.Click += new EventHandler(btnCargar_Click);
            this.btnImprimir.Click += new EventHandler(btnImprimir_Click);
            this.btnVerTransaccion.Click += new EventHandler(btnVerTransaccion_Click);
            this.btnNotaCredito.Click += new EventHandler(btnNotaCredito_Click);
            this.btnNotaDebito.Click += new EventHandler(btnNotaDebito_Click);
            this.btnEliminar.Click += new EventHandler(btnEliminar_Click);
 //           this.btnGuardarCambios.Click += new EventHandler(btnGuardarCambios_Click);
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.Appearance.FocusedCell.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedCell.BackColor = Color.Orange;
            this.gridView1.Appearance.FocusedRow.ForeColor = Color.Black;
            this.gridView1.Appearance.FocusedRow.BackColor = Color.Orange;
            this.CenterToScreen();
            Busqueda();
        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Busqueda();
            FrmReportes f = new FrmReportes();
            f.Banco_EstadoDeCuenta(txtMes.Text, txtAño.Text, lista, txtSaldoInicial.Value);

        }

        void btnNotaDebito_Click(object sender, EventArgs e)
        {
            FrmBancosNotaDebito f = new FrmBancosNotaDebito() 
            { banco = banco };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }

        void btnNotaCredito_Click(object sender, EventArgs e)
        {
            FrmBancosNotaCredito f = new FrmBancosNotaCredito() { banco = banco };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }

        void btnTransferencia_Click(object sender, EventArgs e)
        {
            FrmBancosTransferencia f = new FrmBancosTransferencia() 
            { banco = banco };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }

        void btnDeposito_Click(object sender, EventArgs e)
        {
            FrmBancosDeposito f = new FrmBancosDeposito() 
            { banco = banco };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            BancosMovimiento registro = (BancosMovimiento)this.bs.Current;
            if (registro == null)
                return;
            if (registro.Tipo == "CHEQUE" || registro.Tipo == "TRANSFERENCIA")
            {
                RevertirPago();
            }
            //db.BancosMovimientos.Remove(registro);
            //db.SaveChanges();
            Busqueda();
        }

        private void RevertirPago()
        {
        }

        void btnVerTransaccion_Click(object sender, EventArgs e)
        {
            BancosMovimiento registro = (BancosMovimiento)this.bs.Current;
            if (registro == null)
                return;
            switch (registro.Tipo)
            {
                case "CHEQUE":
                    {
                        FrmBancosCheque f = new FrmBancosCheque() 
                        { registro = registro };
                        f.Ver();
                        break;
                    }
                case "TRANSFERENCIA":
                    {
                        FrmBancosTransferencia f = new FrmBancosTransferencia() { registro = registro };
                        f.Ver();
                        break;
                    }
                case "DEPOSITO":
                    {
                        FrmBancosDeposito f = new FrmBancosDeposito() { registro = registro };
                        f.Ver();
                        break;
                    }
                case "NOTA CR":
                    {
                        FrmBancosNotaCredito f = new FrmBancosNotaCredito() { registro = registro };
                        f.Ver();
                        break;
                    }
                case "NOTA DB":
                    {
                        FrmBancosNotaDebito f = new FrmBancosNotaDebito();
                        f.registro = registro;
                        f.Ver();
                        break;
                    }
            }
        }

        void btnCargar_Click(object sender, EventArgs e)
        {
            Busqueda();
        }

        void btnEmitirCheque_Click(object sender, EventArgs e)
        {
            FrmBancosCheque f = new FrmBancosCheque()
            { banco = banco };
            f.Incluir();
            if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                Busqueda();
        }

        private void Busqueda()
        {
            if (Cuenta.Text.Length == 0)
            {
                this.Cuenta.Items.Clear();
           //     this.Cuenta.Items.AddRange(FactoryBancos.getCuentasBancarias());
                return;
            }
            if (Cuenta.Text.Length > 20)
            {
            //    banco = FactoryBancos.ItemxNumeroCuenta(Cuenta.Text.Substring(0, 20));
                CargarMovimientos();
            }
            this.gridView1.BestFitColumns();
        }

        private void CargarMovimientos()
        {
            //db = new DatosEntities(OK.CadenaConexion);
            //lista = FactoryBancos.movimientos(db, banco, Convert.ToInt16(this.txtMes.Text), Convert.ToInt16(txtAño.Text));
            //DateTime primerdia = Basicas.MonthFirstDay(Convert.ToInt16(this.txtMes.Text), Convert.ToInt16(txtAño.Text));
            //double? debitos = db.BancosMovimientos.Where(x => x.Fecha < primerdia).Sum(x => x.Debito);
            //double? creditos = db.BancosMovimientos.Where(x => x.Fecha < primerdia).Sum(x => x.Credito);
            //double saldoInicial = creditos.GetValueOrDefault(0) - debitos.GetValueOrDefault(0);
            //double saldo = saldoInicial;
            //foreach (var item in lista)
            //{
            //    saldo = saldo + item.Credito.GetValueOrDefault(0) - item.Debito.GetValueOrDefault(0);
            //    item.Saldo = saldo;
            //}
            this.bs.DataSource = lista;
            this.bs.ResetBindings(true);
            //this.txtSaldoInicial.Value = (decimal)saldoInicial;
            //this.txtSaldoFinal.Value = (decimal)saldo;
        }
    }
}
