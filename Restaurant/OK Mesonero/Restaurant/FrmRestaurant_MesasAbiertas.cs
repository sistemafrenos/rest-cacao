using HK.BussinessLogic;
using HK.BussinessLogic.Restaurant;
using HK.Fiscales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HK.Formas
{
    public partial class FrmRestaurant_MesasAbiertas : Form
    {
        Restaurant restaurant;
        Mesa[] mesasCache=null;
        Salon[] salonesCache=null;
        Producto[] productoCache = null;
        public FrmRestaurant_MesasAbiertas()
        {
            InitializeComponent();
            restaurant = new Restaurant();
            this.Load += new EventHandler(FrmMesasAbiertas_Load);
        }
        void FrmMesasAbiertas_Load(object sender, EventArgs e)
        {
            btnAplicacion.Visible = OK.usuario.AccesoMenu.GetValueOrDefault(false);
            btnFacturas.Visible = OK.usuario.CierreDeCaja.GetValueOrDefault(false);
            btnAplicacion.Visible = OK.usuario.AccesoMenu.GetValueOrDefault(false);
            btnReporteX.Visible = OK.usuario.ReporteX.GetValueOrDefault(false);
            btnReporteZ.Visible = OK.usuario.ReporteX.GetValueOrDefault(false);
            btnVale.Visible = OK.usuario.Vale.GetValueOrDefault(false);
            btnContarDinero.Visible = OK.usuario.ContarDinero.GetValueOrDefault(false);
            btnCierre.Visible = OK.usuario.CierreDeCaja.GetValueOrDefault(false);
            this.txtEmpresa.Text = OK.SystemParameters.Empresa;
            this.btnAplicacion.Click += new EventHandler(btnAplicacion_Click);
            this.btnFacturas.Click += new EventHandler(btnFacturas_Click);
            this.btnContarDinero.Click += new EventHandler(btnContarDinero_Click);
            this.btnMinimizar.Click += new EventHandler(btnMinimizar_Click);
            this.btnReporteX.Click += new EventHandler(btnReporteX_Click);
            this.btnReporteZ.Click += new EventHandler(btnReporteZ_Click);
            this.btnVale.Click += btnVale_Click;
            this.btnSalir.Click += new EventHandler(btnSalir_Click);
            this.btnCierre.Click += new EventHandler(btnCierre_Click);
            this.layoutSalones.Click += new EventHandler(layoutSalones_Click);
            this.layoutMesas.Click += new EventHandler(layoutMesas_Click);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 5000;
            timer1.Enabled = true;
            this.WindowState = FormWindowState.Maximized;
            Enlazar();
        }

        void btnVale_Click(object sender, EventArgs e)
        {
            using (var vale = new FrmRestaurant_Vale())
            {
                vale.ShowDialog();
            }
        }

        private void Enlazar()
        {
            if (salonesCache == null)
            {
                salonesCache = restaurant.GetUbicaciones();
            }
            if (mesasCache == null)
            {
                mesasCache = restaurant.GetAllMesas("");
            }
            if (productoCache == null)
            {
                productoCache = restaurant.GetAllPlatos("", null);
            }
            restaurant = new Restaurant();
            this.salonesBs.DataSource = salonesCache;
            this.salonesBs.ResetBindings(true);
            if (salonesBs.Current == null)
                return;
            CargarMesas((Salon)salonesBs.Current);
        }
     
        void btnCierre_Click(object sender, EventArgs e)
        {
            using (var f = new FrmRestaurant_CierreDeCaja())
            {
                f.ShowDialog();
            }
        }

        void btnFacturas_Click(object sender, EventArgs e)
        {
            using (var facturas = new FrmRestaurant_ConsultarFacturas())
            {
                facturas.ShowDialog();
            }
        }

        void btnReporteX_Click(object sender, EventArgs e)
        {
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ReporteX();
        }
        void btnReporteZ_Click(object sender, EventArgs e)
        {
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ReporteZ();
        }
        void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de salir", "Atencion", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
        void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        void btnContarDinero_Click(object sender, EventArgs e)
        {
            using (var f = new FrmContarDinero())
            {
                f.ShowDialog();
            }
        }
        void btnAplicacion_Click(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            using(var f = new Administrativo_Restaurant())
            {
                 f.ShowDialog();
            }
            this.timer1.Enabled = true;
            Enlazar();
            productoCache = null;
            mesasCache = null;
            salonesCache = null;
        }

        void layoutMesas_Click(object sender, EventArgs e)
        {
            Mesa mesa = (Mesa)this.mesasBs.Current;
            EditarMesa(mesa);
        }

        void layoutSalones_Click(object sender, EventArgs e)
        {
            CargarMesas((Salon)this.salonesBs.Current);
        }
        void timer1_Tick(object sender, EventArgs e)
        {

            DoUpdate();
        }

        private void DoUpdate()
        {
            restaurant = new Restaurant();
            mesasCache = mesasCache = restaurant.GetAllMesas("");
            CargarMesas((Salon)this.salonesBs.Current);
        }
        void CargarMesas(Salon salon)
        {
            if (salon != null)
            {
                try
                {
                    var x = restaurant.GetMesasAbiertasSalon(salon.Ubicacion,mesasCache);
                    this.mesasBs.DataSource = x;
                    this.mesasBs.ResetBindings(true);
                }
                catch { }
            }
        }
        void EditarMesa(Mesa mesa)
        {
            using(var  f = new FrmRestaurant_EditarMesaFast() )
            {
                this.timer1.Enabled = false;
                f.Editar(mesa.Codigo, productoCache);
                DoUpdate();
                Application.DoEvents();
                this.timer1.Enabled = true;
            }
        }
    }
}

