using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using HK.BussinessLogic;
using HK.Formas;
using HK.BussinessLogic.Restaurant;

namespace HK
{
    public partial class FrmRestaurant_Reportes : Form
    {
        private const string email = "";
      //  private string titulo;
      //  private bool  IsRender=true;
        SistemaConfig config;
        public FrmRestaurant_Reportes()
        {
            InitializeComponent();
          //  IsRender = true;
          //  titulo = "Reportes restaurant";
            config = new SistemaConfig();
        }
        #region Restaurant
        public void Restaurant_Cotizacion(Cotizacion registro, Boolean email)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_Cotizacion.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Cotizacion", new Cotizacion[] { registro }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CotizacionProductos", registro.DocumentosProductos.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("FechaCotizacion", registro.Fecha.ToShortDateString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("NumeroCotizacion", registro.Numero));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "COTIZACION", registro.Email);
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                //    reportViewer1.RefreshReport();
                ShowDialog();
            }
        }
        public void Restaurant_Platos(Producto[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_Platos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Platos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Restaurant_PlatosIngredientes()
        {
            Restaurant data = new Restaurant();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_PlatosIngredientes.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Recetas", data.GetRecetas()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Restaurant_VentasxPlatos()
        {
            Restaurant data = new Restaurant();
            FrmLapso f = new FrmLapso() { Text = "Ventas x Platos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_VentasxPlatos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Ventas",  data.cerradasVentasxProducto(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void Restaurant_VentasxDepartamentos()
        {
            Restaurant data = new Restaurant();
            FrmLapso f = new FrmLapso() { Text = "Ventas x Departamentos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_VentasxDepartamentos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Ventas", data.cerradasVentasxDepartamento(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void Restaurant_VentasxUbicacion()
        {
            Restaurant data = new Restaurant();
            FrmLapso f = new FrmLapso() { Text = "Ventas x Ubicacion" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_VentasxUbicacion.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Resumen", data.cerradasVentasxUbicacion(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void Restaurant_VentasxPorMesonero()
        {
            FrmLapso f = new FrmLapso() { Text = "Ventas x Mesonero" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Restaurant data = new Restaurant();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_VentasxMesoneros.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VentaxGrupos", data.VentasxMesonero(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void Restaurant_ConsumoInsumos()
        {
            Restaurant data = new Restaurant();
            FrmLapso f = new FrmLapso() { Text = "Consumo de Insumos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            // Pendiente
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_ConsumoxInsumo.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Resumen", data.cerradasVentasxDepartamento(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void Restaurant_MesasCerradas(MesasCerrada[] lista, string lapso, bool email)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Restaurant_MesasCerradas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("MesasCerradas", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", lapso));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, string.Format("LISTADO DE FACTURAS {0}", lapso), "tu@mail.com");
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                //      reportViewer1.RefreshReport();
                ShowDialog();
            }
        }
        public void Restaurant_Insumos(Producto[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Tablas_Insumos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        private void FrmRestaurant_Reportes_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        //public void Restaurant_Sugerencias(List<Sugerencia> productos)
        //{
        //    reportViewer1.ProcessingMode = ProcessingMode.Local;
        //    reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Sugerencias.rdlc";
        //    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Sugerencias", productos));
        //    ShowDialog();
        //}
        #endregion
    }
}
