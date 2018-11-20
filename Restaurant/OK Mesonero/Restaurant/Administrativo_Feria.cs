using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using HK.Clases;
using HK.Fiscales;

namespace HK.Formas
{
    public partial class Administrativo_Feria : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Administrativo_Feria()
        {
            InitializeComponent();
            this.Load += new EventHandler(FrmFeriaAdministrativo_Load);
        }

        void FrmFeriaAdministrativo_Load(object sender, EventArgs e)
        {
            this.barButtonClientes.ItemClick += new ItemClickEventHandler(barButtonClientes_ItemClick);
            this.barButtonProveedores.ItemClick += new ItemClickEventHandler(barButtonProveedores_ItemClick);
            this.barButtonInsumos.ItemClick += new ItemClickEventHandler(barButtonInsumos_ItemClick);
            this.barButtonProductos.ItemClick += new ItemClickEventHandler(barButtonProductos_ItemClick);
            this.barButtonAjustePreciosProductos.ItemClick += new ItemClickEventHandler(barButtonAjustePreciosProductos_ItemClick);
            this.barButtonCargarProductos.ItemClick += new ItemClickEventHandler(barButtonCargarProductos_ItemClick);
            this.barButtonVentasxGrupos.ItemClick += new ItemClickEventHandler(barButtonVentasxGrupos_ItemClick);
            this.barButtonVentasxProducto.ItemClick += new ItemClickEventHandler(barButtonVentasxProducto_ItemClick);
            this.barComprasxProducto.ItemClick += new ItemClickEventHandler(barComprasxProducto_ItemClick);
            this.barComprasxGrupos.ItemClick += new ItemClickEventHandler(barComprasxGrupos_ItemClick);
            this.barButtonListadoInventarios.ItemClick += new ItemClickEventHandler(barButtonListadoInventarios_ItemClick);
            this.barButtonConsumos.ItemClick += new ItemClickEventHandler(barButtonConsumos_ItemClick);
            this.barButtonUsuarios.ItemClick += new ItemClickEventHandler(barButtonUsuarios_ItemClick);
            this.barButtonRespaldo.ItemClick += new ItemClickEventHandler(barButtonRespaldo_ItemClick);
            this.barButtonRecuperacion.ItemClick += new ItemClickEventHandler(barButtonRecuperacion_ItemClick);
            this.barButtonConfigurarEstacion.ItemClick += new ItemClickEventHandler(barButtonConfigurarEstacion_ItemClick);
            this.barButtonConfigurarCorreo.ItemClick += new ItemClickEventHandler(barButtonConfigurarCorreo_ItemClick);
            this.barButtonContadorDinero.ItemClick += new ItemClickEventHandler(barButtonContadorDinero_ItemClick);
            this.barButtonLibroCompras.ItemClick += new ItemClickEventHandler(barButtonLibroCompras_ItemClick);
            this.barButtonLibroVentas.ItemClick += new ItemClickEventHandler(barButtonLibroVentas_ItemClick);
            this.barButtonLibroInventarios.ItemClick += new ItemClickEventHandler(barButtonLibroInventarios_ItemClick);
            this.barButtonReporteX.ItemClick += new ItemClickEventHandler(barButtonReporteX_ItemClick);
            this.barButtonReporteZ.ItemClick += new ItemClickEventHandler(barButtonReporteZ_ItemClick);
            this.barButtonMesas.ItemClick += new ItemClickEventHandler(barButtonMesas_ItemClick);
            this.barButtonMesoneros.ItemClick += new ItemClickEventHandler(barButtonMesoneros_ItemClick);
            this.barButtonCierreDeCaja.ItemClick += new ItemClickEventHandler(barButtonCierreDeCaja_ItemClick);
            this.barButtonListadoFacturasMensuales.ItemClick += new ItemClickEventHandler(barButtonListadoFacturasMensuales_ItemClick);
            this.barButtonCuentasxCobrar.ItemClick += new ItemClickEventHandler(barButtonCuentasxCobrar_ItemClick);
            this.barButtonCompras.ItemClick += new ItemClickEventHandler(barButtonCompras_ItemClick);
            this.barButtonCuentasxPagar.ItemClick += new ItemClickEventHandler(barButtonCuentasxPagar_ItemClick);
            this.barButtonDescargar.ItemClick += new ItemClickEventHandler(barButtonDescargar_ItemClick);
            this.barButtonConfigurarFiscal.ItemClick += barButtonConfigurarFiscal_ItemClick;
        }

        void barButtonConfigurarFiscal_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUtilidades_Fiscal f = new FrmUtilidades_Fiscal();
            f.ShowDialog();
        }

        void barButtonDescargar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_ProductosDescargar f = new FrmTablas_ProductosDescargar();
            f.ShowDialog();
        }


        void barComprasxProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_ComprasxProductos();
        }

        void barComprasxGrupos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_ComprasxGrupos();
        }

        void barButtonCuentasxPagar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCuentasxPagar f = new FrmCuentasxPagar();
            f.MdiParent = this;
            f.Show();
        }

        void barButtonCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCompras f = new FrmCompras();
            f.MdiParent = this;
            f.Show();
        }

        void barButtonCuentasxCobrar_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmCuentasxCobrar f = new FrmCuentasxCobrar();
            f.MdiParent = this;
            f.Show();
        }

        void barButtonListadoFacturasMensuales_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.ReporteFacturasNaturalesyJuridicas();
        }
        void barButtonCierreDeCaja_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        void barButtonMesoneros_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_Mesoneros f = new FrmTablas_Mesoneros();
            f.MdiParent = this;
            f.Show();
        }

        void barButtonMesas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_Mesas f = new FrmTablas_Mesas();
            f.MdiParent = this;
            f.Show();
        }

        void barButtonListadoInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almancen_ListadoInventarios();
        }

        void barButtonProveedores_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_Proveedores proveedores = new FrmTablas_Proveedores();
            proveedores.MdiParent = this;
            proveedores.Show();
        }

        void barButtonInsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_Productos Insumos = new FrmTablas_Productos();
            Insumos.MdiParent = this;
            Insumos.Show();
        }

        void barButtonResumenZ_ItemClick(object sender, ItemClickEventArgs e)
        {
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
            FrmSeniat_LibroInventarios LibroInventarios = new FrmSeniat_LibroInventarios();
            LibroInventarios.MdiParent = this;
            LibroInventarios.Show();
        }

        void barButtonLibroVentas_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSeniat_LibroVentas LibroVentas = new FrmSeniat_LibroVentas();
            LibroVentas.MdiParent = this;
            LibroVentas.Show();
        }

        void barButtonLibroCompras_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmSeniat_LibroCompras LibroCompras = new FrmSeniat_LibroCompras();
            LibroCompras.MdiParent = this;
            LibroCompras.Show();
        }

        void barButtonContadorDinero_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmContarDinero f = new FrmContarDinero();
            f.ShowDialog();
        }

        void barButtonConfigurarCorreo_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUtilidades_ConfigurarCorreo f = new FrmUtilidades_ConfigurarCorreo();
            f.ShowDialog();

        }

        void barButtonConfigurarEstacion_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmUtilidades_ConfigurarServidor f = new FrmUtilidades_ConfigurarServidor();
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
            //FrmRestaurant_Usuarios Usuarios = new FrmRestaurant_Usuarios();
            //Usuarios.MdiParent = this;
            //Usuarios.Show();
        }

        void barButtonConsumos_ItemClick(object sender, ItemClickEventArgs e)
        {
            var f = new FrmRestaurant_Reportes();
            f.Restaurant_ConsumoInsumos();
        }

        void barButtonInventarios_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almancen_ListadoInventarios();
        }

        void barButtonVentasxProducto_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_VentasxProductos();
        }

        void barButtonVentasxGrupos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmReportes f = new FrmReportes();
            f.Almacen_VentasxDepartamento();
        }

        void barButtonCargarProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            do
            {
                FrmTablas_ProductosCargar f = new FrmTablas_ProductosCargar();
                f.Incluir();
                if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
            }
            while (true);
        }

        void barButtonClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_Clientes Clientes = new FrmTablas_Clientes();
            Clientes.MdiParent = this;
            Clientes.Show();
        }

        void barButtonAjustePreciosProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_ProductosAjustePrecios f = new FrmTablas_ProductosAjustePrecios();
            f.ShowDialog();
        }

        void barButtonProductos_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmTablas_Platos f = new FrmTablas_Platos();
            f.MdiParent = this;
            f.Show();
        }
    }
}
