using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraBars;
using HK.Fiscales;
using HK.BussinessLogic;

namespace HK.Formas
{
    public partial class Administrativo_Restaurant : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Administrativo_Restaurant()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmFeriaAdministrativo_Load);
        }

        void FrmFeriaAdministrativo_Load(object sender, EventArgs e)
        {
            this.barButtonClientes.ItemClick += new ItemClickEventHandler(barButtonClientes_ItemClick);
            this.barButtonProveedores.ItemClick += new ItemClickEventHandler(barButtonProveedores_ItemClick);
            this.barButtonInsumos.ItemClick += new ItemClickEventHandler(barButtonInsumos_ItemClick);
            this.barButtonProductos.ItemClick += new ItemClickEventHandler(barButtonPlatos_ItemClick);
            this.barButtonAjustePreciosProductos.ItemClick += new ItemClickEventHandler(barButtonAjustePreciosProductos_ItemClick);
            this.barButtonVentasxDepartamento.ItemClick += new ItemClickEventHandler(barButtonVentasxGrupos_ItemClick);
            this.barButtonVentasxProducto.ItemClick += new ItemClickEventHandler(barButtonVentasxProducto_ItemClick);
            this.barButtonVentasUbicacion.ItemClick += barButtonVentasUbicacion_ItemClick;
            this.barButtonListadoInventarios.ItemClick += new ItemClickEventHandler(barButtonListadoInventarios_ItemClick);
            this.barButtonConsumos.ItemClick += new ItemClickEventHandler(barButtonConsumos_ItemClick);
            this.barButtonUsuarios.ItemClick += new ItemClickEventHandler(barButtonUsuarios_ItemClick);
            this.barButtonRespaldo.ItemClick += new ItemClickEventHandler(barButtonRespaldo_ItemClick);
            this.barButtonRecuperacion.ItemClick += new ItemClickEventHandler(barButtonRecuperacion_ItemClick);
            this.barButtonConfigurarImpresora.ItemClick += barButtonConfigurarImpresora_ItemClick;
            this.barButtonContadorDinero.ItemClick += new ItemClickEventHandler(barButtonContadorDinero_ItemClick);
            this.barButtonLibroCompras.ItemClick += new ItemClickEventHandler(barButtonLibroCompras_ItemClick);
            this.barButtonLibroVentas.ItemClick += new ItemClickEventHandler(barButtonLibroVentas_ItemClick);
            this.barButtonLibroInventarios.ItemClick += new ItemClickEventHandler(barButtonLibroInventarios_ItemClick);
            this.barButtonReporteX.ItemClick += new ItemClickEventHandler(barButtonReporteX_ItemClick);
            this.barButtonReporteZ.ItemClick += new ItemClickEventHandler(barButtonReporteZ_ItemClick);
            this.barButtonMesas.ItemClick += new ItemClickEventHandler(barButtonMesas_ItemClick);
            this.barButtonMesoneros.ItemClick += new ItemClickEventHandler(barButtonMesoneros_ItemClick);
            this.barButtonListadoFacturasMensuales.ItemClick += new ItemClickEventHandler(barButtonListadoFacturasMensuales_ItemClick);
            this.barButtonCuentasxCobrar.ItemClick += new ItemClickEventHandler(barButtonCuentasxCobrar_ItemClick);
            this.barButtonCotizacionesRestaurant.ItemClick += barButtonCotizacionesRestaurant_ItemClick;
            this.barButtonVentasxMesonero.ItemClick += barButtonVentasxMesonero_ItemClick;
            this.barButtonCompras.ItemClick += barButtonCompras_ItemClick;
            this.barButtonParametros.ItemClick += new ItemClickEventHandler(barButtonParametros_ItemClick);
            barButtonBaseDeDatos.ItemClick += barButtonBaseDeDatos_ItemClick;
            barButtonCorreos.ItemClick += barButtonCorreos_ItemClick;
            barButtonConfigurarFiscal.ItemClick += barButtonConfigurarFiscal_ItemClick;
            barButtonConfigurarSistemas.ItemClick += barButtonConfigurarSistemas_ItemClick;
        }

        void barButtonParametros_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUtilidades_Parametros p = new FrmUtilidades_Parametros();
            p.ShowDialog();
        }
        private bool ExisteTab(string tag)
        {
            foreach (DevExpress.XtraTabbedMdi.XtraMdiTabPage x in Tabs.Pages)
            {
                if ((string)x.MdiChild.Tag == tag)
                {
                    Tabs.SelectedPage = x;
                    return true;
                }
            }
            return false;
        }
        void barButtonCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmCompras"))
            {
                var Clientes = new FrmCompras();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmCompras";
                Clientes.Show();
            }
        }

        void barButtonCotizacionesRestaurant_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmRestaurant_Cotizaciones"))
            {
                var Clientes = new FrmRestaurant_Cotizaciones();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmRestaurant_Cotizaciones";
                Clientes.Show();
            }
        }

        void barButtonConfigurarSistemas_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_Configurar())
            {
                f.ShowDialog();
            }
        }
        void barButtonConfigurarImpresora_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmRestaurant_Configurar())
            {
                f.ShowDialog();
            }
        }

        void barButtonConfigurarFiscal_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_Fiscal())
            {
                f.ShowDialog();
            }
        }

        void barButtonCorreos_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_ConfigurarCorreo())
            {
                f.ShowDialog();
            }
        }

        void barButtonBaseDeDatos_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmUtilidades_ConfigurarServidor())
            {
                f.ShowDialog();
            }
        }

        void barButtonCuentasxCobrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmCuentasxCobrar"))
            {
                var Clientes = new FrmCuentasxCobrar();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmCuentasxCobrar";
                Clientes.Show();
            }
        }

        void barButtonListadoFacturasMensuales_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.ReporteFacturasNaturalesyJuridicas();
        }

        void barButtonMesoneros_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Mesoneros"))
            {
                var Clientes = new FrmTablas_Mesoneros();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Mesoneros";
                Clientes.Show();
            }
        }

        void barButtonMesas_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Mesas"))
            {
                var Clientes = new FrmTablas_Mesas();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Mesas";
                Clientes.Show();
            }
        }

        void barButtonListadoInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            Administrativo data = new Administrativo();
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_Insumos(data.GetAllProductosCompras(""));
        }

        void barButtonProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Proveedores"))
            {
                var form = new FrmTablas_Proveedores();
                form.MdiParent = this;
                form.Tag = "FrmTablas_Proveedores";
                form.Show();
            }
        }

        void barButtonInsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Insumos"))
            {
                var Clientes = new FrmTablas_Insumos();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Insumos";
                Clientes.Show();
            }
        }

        void barButtonReporteZ_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ReporteZ();
        }

        void barButtonReporteX_ItemClick(object sender, ItemClickEventArgs e)
        {
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.ReporteX();
        }

        void barButtonLibroInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSeniat_LibroInventarios LibroInventarios = new FrmSeniat_LibroInventarios() { MdiParent = this };
            LibroInventarios.Show();
        }

        void barButtonLibroVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSeniat_LibroVentas LibroVentas = new FrmSeniat_LibroVentas() { MdiParent = this };
            LibroVentas.Show();
        }

        void barButtonLibroCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSeniat_LibroCompras LibroCompras = new FrmSeniat_LibroCompras() { MdiParent = this };
            LibroCompras.Show();
        }

        void barButtonContadorDinero_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmContarDinero f = new FrmContarDinero();
            f.ShowDialog();
        }
        void barButtonRecuperacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUtilitarios_Restore f = new FrmUtilitarios_Restore();
            f.ShowDialog();
        }
        void barButtonRespaldo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUtilitarios_Backup f = new FrmUtilitarios_Backup();
            f.ShowDialog();
        }
        void barButtonUsuarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Usuarios"))
            {
                var Clientes = new FrmTablas_Usuarios();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Usuarios";
                Clientes.Show();
            }
        }
        void barButtonConsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_ConsumoInsumos();
        }

        void barButtonVentasxProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmRestaurant_Reportes())
            {
                f.Restaurant_VentasxPlatos();
            }
        }

        void barButtonVentasxMesonero_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmRestaurant_Reportes())
            {
                f.Restaurant_VentasxPorMesonero();
            }
        }

        void barButtonVentasUbicacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            using (var f = new FrmRestaurant_Reportes())
            {
                f.Restaurant_VentasxUbicacion();
            }
        }

        void barButtonVentasxGrupos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_VentasxDepartamentos();
        }

        void barButtonClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Clientes"))
            {
                var Clientes = new FrmTablas_Clientes();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Clientes";
                Clientes.Show();
            }
        }

        void barButtonAjustePreciosProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_ProductosAjustePrecios f = new FrmTablas_ProductosAjustePrecios();
            f.ShowDialog();
        }

        void barButtonPlatos_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!ExisteTab("FrmTablas_Platos"))
            {
                var Clientes = new FrmTablas_Platos();
                Clientes.MdiParent = this;
                Clientes.Tag = "FrmTablas_Platos";
                Clientes.Show();
            }
        }
    }
}
