using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HK.BussinessLogic;
using Microsoft.Reporting.WinForms;


namespace HK.Formas
{
    public partial class FrmReportes : Form
    {

        private const string email = "";
        private string titulo;
        private bool IsRender = false;
        SistemaConfig config;
        public FrmReportes()
        {
            KeyPreview = true;
            InitializeComponent();
            config = new SistemaConfig();
            KeyDown += FrmKeyDown;
            Activated += FrmReportes_Activated;
            FormClosing += FrmReportes_FormClosing;
            btnEmail.Click += btnEmail_Click;
            Cancelar.Click += Cancelar_Click;
            btnImprimir.Click += btnImprimir_Click;
            Width = Screen.PrimaryScreen.Bounds.Width - 50;
            Height = Screen.PrimaryScreen.Bounds.Height - 100;
        }
        void btnImprimir_Click(object sender, EventArgs e)
        {
            using (ReportPrintDocument p = new ReportPrintDocument(reportViewer1.LocalReport))
            {
                p.Print();
            }
        }
        void btnEmail_Click(object sender, EventArgs e)
        {
            string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
            Basicas.EnviarEmail(archivo, titulo, email);
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            Close();
        }
        void FrmKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Cancelar.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F12:
                    btnImprimir.PerformClick();
                    e.Handled = true;
                    break;
                case Keys.F11:
                    btnEmail.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }
        void FrmReportes_Activated(object sender, EventArgs e)
        {
            if (IsRender == false)
                reportViewer1.RefreshReport();
            IsRender = true;
        }
        void FrmReportes_FormClosing(object sender, FormClosingEventArgs e)
        {
            reportViewer1.LocalReport.ReleaseSandboxAppDomain();
        }
        #region Tablas
        public void Tablas_Clientes(Tercero[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Tablas_Clientes.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Tablas_Proveedores(Tercero[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Tablas_Proveedores.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Proveedores", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Tablas_Usuarios(object lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Tablas_Usuarios.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Tablas_MaestroDeCuentas(MaestroDeCuenta[] Lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Tablas_MaestroDeCuentas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("MaestroDeCuentas", Lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }

        public void Tablas_Productos(Producto[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Tablas_Productos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Tablas_Mesas(Mesa[] lista)
        {
            if (lista.Count() < 1)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Tablas_Mesas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Mesas", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //  reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Tablas_Mesoneros(Mesonero[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Tablas_Mesoneros.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Mesoneros", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //   reportViewer1.RefreshReport();
            ShowDialog();
        }
        #endregion
        #region Almacen
        public void Almancen_ListadoInventarios()
        {
            FrmPedirDepartamentoProveedor f = new FrmPedirDepartamentoProveedor() { Text = "Listado Inventarios", PedirDepartamento = true };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            Producto[] lista = data.GetAllProductos(f.Departamento,f.proveedor.RazonSocial);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Almacen_ListadoInventarios.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("TotalInventarios", lista.Sum(x => x.CostoTotal).Value.ToString("n2")));
            ShowDialog();
        }
        public void Almacen_InventariosxProveedor()
        {
            FrmPedirDepartamentoProveedor f = new FrmPedirDepartamentoProveedor() { PedirProveedor = true, Text = "Inventario x Proveedor" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK || f.proveedor.RazonSocial == null)
                return;
            var lista = Consultas.ExistenciasxProveedor(f.proveedor);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Almacen_InventariosProveedor.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Proveedor", f.proveedor.RazonSocial));
            ShowDialog();
        }
        public void Almacen_ListadoProductos(Producto[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Almacen_ListadoProductos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Almacen_ListadoMinimos()
        {
            FrmPedirDepartamentoProveedor f = new FrmPedirDepartamentoProveedor() { Text = "Listado Minimos", PedirDepartamento = true, PedirProveedor = true };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data;
            data = new Administrativo();
            Producto[] lista = data.GetAllProductos(f.proveedor.RazonSocial, f.Departamento).Where(x=>x.Cantidad<x.Minimo).ToArray();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Almacen_Minimos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Almacen_ListaPrecios()
        {
            FrmPedirDepartamentoProveedor f = new FrmPedirDepartamentoProveedor() { Text = "Listado De Precios", PedirDepartamento = true };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            Producto[] lista = data.GetAllProductosVentas("", f.Departamento);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Almacen_ListaPrecios.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Almacen_ProductosMovimientos(ProductosMovimientos[] list, Producto producto)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Almacen_ProductosMovimientos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", new Producto[] { producto }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ProductosMovimientos", list));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        #endregion
        #region Almacen
        public void Almacen_ComprasxGrupos()
        {
            FrmLapso f = new FrmLapso() { Text = "Compras x Grupos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            Administrativo data = new Administrativo();
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Almacen_ComprasxGrupo.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ComprasxGrupos", data.ProductosComprasxGrupo(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void Almacen_ComprasxProductos()
        {
            FrmLapso f = new FrmLapso() { Text = "Compras x Platos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Almacen_ComprasxProducto.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ComprasxProductos", data.ProductosComprasxProducto(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //  reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Almacen_VentasxDepartamento()
        {
            FrmLapso f = new FrmLapso() { Text = "Ventas x Grupos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Almacen_VentasxGrupo.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VentaxGrupos", data.facturasVentasxDepartamento(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //  reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Almacen_VentasxProductos()
        {
            FrmLapso f = new FrmLapso() { Text = "Ventas x Platos" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Almacen_VentasxProducto.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Ventas", data.facturasVentasxProducto(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            // reportViewer1.RefreshReport();
            ShowDialog();
        }
        #endregion
        #region Administrativo

        public void Administrativo_Facturas(Factura[] lista, string lapso, bool email)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Administrativo_Facturas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Facturas", lista));
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
        public void Administrativo_VentasxLapso()
        {
            FrmLapso f = new FrmLapso() { Text = "Ventas x Lapso" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Administrativo_VentasxLapso.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VentasxDia", Consultas.VentasDiariasxLapso(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        #endregion
        #region Vendedores
        public void ListadoVendedores(Vendedor[] lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\ListadoVendedores.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Vendedores", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void ListadoFacturasMensualesVendedores()
        {
            FrmLapso f = new FrmLapso() { Text = "Facturas x Lapso" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            Documento[] lista = data.GetDocumentos("", "FACTURA", f.desde, f.hasta);
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\ListadoVentasxVendedores.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Facturas", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void VentasxLapsoVendedor()
        {
            FrmLapsoVendedor f = new FrmLapsoVendedor() { Text = "Ventas Vendedor x Lapso" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\ListadoVentasxVendedor.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Facturas", Consultas.VentasLapsoxVendedor(f.desde, f.hasta, f.vendedor)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        public void ResumenxLapsoVendedor()
        {
            FrmLapsoVendedor f = new FrmLapsoVendedor() { Text = "Resumen Vendedor x Lapso" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            var lista = Consultas.ResumenLapsoxVendedor(f.desde, f.hasta, f.vendedor);
            foreach(var x in lista)
            {
                x.Bolivares = x.Bolivares.GetValueOrDefault();
                x.Cantidad = x.Cantidad.GetValueOrDefault();
            }
            string s =  f.vendedor.Nombre==null?"TODOS":f.vendedor.Nombre;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Administrativo_ResumenVentaxVendedor.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Resumen", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Vendedor",s));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            ShowDialog();
        }
        #endregion
        public void Compras(Documento registro)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Compras.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Compras", new Documento[] { registro }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ComprasProductos", registro.DocumentosProductos.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            
            ShowDialog();
        }
        public void ComprasxLapso()
        {
            FrmLapso f = new FrmLapso() { Text = "Compras x Lapso" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            // Pendiente
            Administrativo data = new Administrativo();
            Resumen[] lista = data.ProductosComprasxGrupo(f.desde, f.hasta);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\ComprasxLapso.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Productos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde:{0} Hasta:{1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //      reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void ReporteFacturasNaturalesyJuridicas()
        {
            FrmLapso f = new FrmLapso() { Text = "Listado de Facturas Naturales y Juridicas" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            Documento[] Lista = data.GetDocumentos("","FACTURA",f.desde, f.hasta);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\ListadoFacturasNaturalesJuridicas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Facturas", Lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //     reportViewer1.RefreshReport();
            ShowDialog();
        }
        #region LibrosFiscales
        public void Seniat_ImprimirRetencionISLR(RetencionISLR item)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Seniat_RetencionISLR.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RetencionISLR", new RetencionISLR[] { item }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Seniat_LibroDeVentas()
        {
            FrmMesyAno f = new FrmMesyAno() { Text = "Libro de Ventas" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            int Mes = f.Mes;
            int Ano = f.Ano;
            Administrativo data = new Administrativo();
            var consulta = data.GetByMesLibroInventario(Mes, Ano);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Seniat_LibroDeVentas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LibroVentas", consulta.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Periodo", string.Format("Mes {0} Ano {1}", Mes, Ano)));
            ShowDialog();
        }
        public void Seniat_LibroDeVentas(LibroVenta[] Lista, string periodo)
        {
            var paso2 = from x in Lista
                        orderby x.Fecha, x.MaquinaFiscal, x.Factura
                        select x;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Seniat_LibroDeVentas.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LibroVentas", paso2.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Periodo", periodo));
            ShowDialog();
        }
        public void Seniat_LibroDeVentasResumido()
        {
            FrmMesyAno f = new FrmMesyAno() { Text = "Libro de Ventas Resumido" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            var lista = data.GetByMesLibroVentas(f.Mes, f.Ano);
            var items = data.ResumirLibroVenta(lista).OrderBy(x=>x.Inicio).ToList();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Seniat_LibroDeVentasResumido.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LibroVentas", items));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Periodo", string.Format("Mes {0} Ano {1}", f.Mes, f.Ano)));
            ShowDialog();
        }
        public void Seniat_LibroDeVentasDiario(LibroVenta[] lista, string periodo)
        {
            Administrativo data = new Administrativo();
            var items = data.ResumirLibroVentaNumeroZ(lista).OrderBy(x => x.NumeroZ).ToList();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            this.reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Seniat_LibroDeVentasDiario.rdlc";
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LibroVentas", items.ToArray()));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Periodo", periodo));
            this.reportViewer1.RefreshReport();
            this.ShowDialog();
        }
        public void Seniat_LibroDeCompras()
        {
            FrmMesyAno f = new FrmMesyAno() { Text = "Libro de Compras" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            var consulta =data.GetByMesLibroInventario (f.Mes, f.Ano);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Seniat_LibroDeCompras.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Compras", consulta.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void Seniat_LibroDeCompras(LibroCompra[] Lista, string periodo)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Seniat_LibroDeCompras.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Compras", Lista.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Periodo", periodo));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Seniat_LibroDeInventarios(LibroInventario[] Lista, string periodo)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Seniat_LibroDeInventarios.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LibroInventarios", Lista.Where(x => !( x.Inicio == 0 && x.Final == 0 )).ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Periodo", periodo));
            ShowDialog();
        }
        public void Seniat_ImprimirRetencion(List<Retencion> lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Seniat_Retencion.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Retencion", lista.OrderBy(x => x.Numero).ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Seniat_ImprimirRetencionDoble(List<Retencion> lista)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Seniat_RetencionDoble.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Retencion", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Seniat_RelacionRetencionesISLR()
        {
            FrmLapsoProveedor f = new FrmLapsoProveedor();
            f.Text = "Listado de Retenciones ISLR";
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            HK.BussinessLogic.RetencionesISLR retenciones = new RetencionesISLR();
            var consulta = retenciones.GetLapso(f.desde, f.hasta, "");
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Seniat_RelacionRetencionesISLR.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("RetencionISLR", consulta.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        #endregion
        public void EstadoDeCuentaProveedor(Tercero proveedor, bool email)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\EstadoDeCuentaProveedor.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Proveedores", new Tercero[] { proveedor }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ProveedoresMovimientos", proveedor.TercerosMovimientos.Where(x => x.Saldo > 0).ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "ESTADO DE CUENTA", proveedor.Email);
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                //            reportViewer1.RefreshReport();
                ShowDialog();
            }
        }
        public void NotaCredito(NotaDeCredito registro, Pago pago)
        {
            Utilitatios.Numalet let = new Utilitatios.Numalet();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            registro.Numero = Convert.ToInt16(registro.Numero).ToString("000000");
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\NotaCredito.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Factura", new NotaDeCredito[] { registro }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("FacturaProductos", registro.DocumentosProductos.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MontoEnLetras", let.ToCustomCardinal((decimal)registro.MontoTotal)));
            
            ShowDialog();
        }
        #region Ventas
        public void Ventas_Factura(Factura registro, Boolean email)
        {
            //Tercero cliente = FactoryTerceros.Item(registro.CedulaRif);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Ventas_Factura.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Factura", new Documento[] { registro }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("FacturaProductos", registro.DocumentosProductos.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Condicion", registro.Saldo > 0 ? "CREDITO" : "CONTADO"));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "FACTURA", registro.Email);
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                ShowDialog();
            }
        }
        public void Ventas_Cotizacion(Cotizacion registro, Boolean email)
        {
            try
            {
                titulo = "COTIZACION";
                Text = titulo;
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Ventas_Cotizacion.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Cotizacion", new Cotizacion[] { registro }));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CotizacionProductos", registro.DocumentosProductos.ToList()));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("FechaCotizacion", registro.Fecha.ToShortDateString()));
                reportViewer1.LocalReport.SetParameters(new ReportParameter("NumeroCotizacion", registro.Numero));
                if (email)
                {
                    string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                    reportViewer1.LocalReport.ReleaseSandboxAppDomain();
                    Basicas.EnviarEmail(archivo, titulo, registro.Email);
                }
                else
                {
                    ShowDialog();
                }
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        public void Ventas_NotaEntrega(NotaEntrega registro, Boolean email)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Ventas_NotaEntrega.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("NotaEntrega", new Documento[] { registro }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("NotaEntregaProductos", registro.DocumentosProductos.ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("FechaNotaEntrega", registro.Fecha.ToShortDateString()));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("NumeroNotaEntrega", registro.Numero));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "NOTA ENTREGA", registro.Email);
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                ShowDialog();
            }
        }

        #endregion
        public void Recibo(Pago caja)
        {
            Utilitatios.Numalet let = new Utilitatios.Numalet();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\ReciboCobro.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Caja", new Pago[] { caja }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Tercero", new Tercero[] { caja.Documento.Tercero }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("MontoEnLetras", let.ToCustomCardinal((decimal)caja.MontoPagado.Value)));
            //     reportViewer1.RefreshReport();sb
            ShowDialog();
        }
        public void VentasxDepartamento()
        {
            FrmLapso f = new FrmLapso();
            f.Text = "Ventas x Departamento";
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\VentasxDepartamento.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VentasxDepartamento", data.facturasVentasxDepartamento(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde {0} Hasta {1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void VentasxProducto()
        {
            FrmLapso f = new FrmLapso() { Text = "Ventas x Departamento" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\VentasxProducto.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("VentasxProducto", Consultas.VentasxProducto(f.desde, f.hasta)));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde {0} Hasta {1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void ReporteCajaChica(List<CajaChica> Lista)
        {
            if (Lista.Count < 1)
                return;
            Administrativo data = new Administrativo();
            CajaChica item = Lista[0];
            Banco banco = new Banco();
            BancosMovimiento DatosCheque = (from x in banco.BancosMovimientos
                                            where x.ID == item.MovimientoBancoID
                                            select x).FirstOrDefault();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\CajaChica.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("CajaChica", Lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            if (DatosCheque != null)
                reportViewer1.LocalReport.SetParameters(new ReportParameter("DatosDelPago", string.Format("CHEQUE #:{0} BANCO:{2} \\n FECHA:{3} BENEFICIARIO:{4} \\n  MONTO:{1}", DatosCheque.Numero, DatosCheque.Debito, DatosCheque.Banco.Cuenta, DatosCheque.Fecha.Value.ToShortDateString(), DatosCheque.Beneficiario)));
            else
                reportViewer1.LocalReport.SetParameters(new ReportParameter("DatosDelPago", "CHEQUE PENDIENTE POR EMITIR"));
            ShowDialog();
        }
        #region Bancos
        public void Banco_RegistroDeEgresos(List<BancosMovimiento> list, DateTime desde, DateTime hasta)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Atencion");
                return;
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Bancos_EgresosLapso.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Egresos", list));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde {0} Hasta {1}", desde.ToShortDateString(), hasta.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Banco_RegistroDeMovimientos(List<BancosMovimiento> list, DateTime desde, DateTime hasta)
        {
            if (list.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Atencion");
                return;
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Bancos_MovimientosLapso.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", list));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Desde {0} Hasta {1}", desde.ToShortDateString(), hasta.ToShortDateString())));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("CuentaBancaria", string.Format("CUENTA:{0} ", list[0].Banco.Cuenta)));
            //   reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Banco_EstadoDeCuenta(string mes, string ano, List<BancosMovimiento> lista, decimal saldoInicial)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("No se encontraron datos", "Atencion");
                return;
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Bancos_EstadoDeCuenta.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("SaldoInicial", saldoInicial.ToString("N2")));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Mes {0} Ano {1}", mes, ano)));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("CuentaBancaria", string.Format("CUENTA:{0} ", lista[0].Banco.Cuenta)));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void Banco_ImprimirCH(BancosMovimiento registro)
        {
            List<Banco> bancos = new List<Banco>();
            List<BancosMovimiento> cheques = new List<BancosMovimiento>();
            cheques.Add(registro);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\Bancos_Cheque.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Bancos", bancos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BancosMovimientos", cheques));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Usuarios", new Usuario[] { OK.usuario }));
            ShowDialog();
        }
        public void Banco_SaldoConsolidado()
        {
            FrmFecha f = new FrmFecha();
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            Administrativo data = new Administrativo();
            DateTime primerdia = f.fecha;
            Banco[] lista = data.GetAllBancos("");
            foreach (Banco item in lista)
            {
                double? debitos = item.BancosMovimientos.Where(x => x.Fecha <= primerdia).ToList().Sum(x => x.Debito);
                double? creditos = item.BancosMovimientos.Where(x => x.Fecha <= primerdia).ToList().Sum(x => x.Credito);
                item.Saldo = creditos.GetValueOrDefault(0) - debitos.GetValueOrDefault(0);
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\Bancos_SaldosConsolidados.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Bancos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", primerdia.ToShortDateString()));
            ShowDialog();
        }
        #endregion
        #region CxP
        public void CxP_ListadoVencimientos()
        {
            FrmFecha f = new FrmFecha();
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            List<ReportViews.CxP_ProveedoresMovimiento> lista = ReportViews.CxP_ListadoVencimientosFecha(f.fecha);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxP_ListadoVencimientos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Vencimientos hasta el dia :{0}", f.fecha.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxC_ListadoVencimientos()
        {
            FrmFecha f = new FrmFecha();
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            List<ReportViews.CxC_TercerosMovimiento> lista = ReportViews.CxC_ListadoVencimientosFecha(f.fecha);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_ListadoVencimientos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Vencimientos hasta el dia :{0}", f.fecha.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxP_Resumen()
        {
            Administrativo data = new Administrativo();
            Tercero[] proveedor = data.GetAllProveedores("");
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\CxP_Resumen.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Proveedores", proveedor ));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //   reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxP_ListadoGeneral()
        {
            List<ReportViews.CxP_ProveedoresMovimiento> lista = ReportViews.CxP_ListadoGeneral();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxP_ListadoGeneral.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxP_ListadoPagosxLapso()
        {
            FrmLapso f = new FrmLapso();
            f.Text = "Listado Pagos x Lapso";
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            List<ReportViews.CxP_ProveedoresMovimiento> lista = ReportViews.CxP_ListadoPagosxLapso(f.desde, f.hasta);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxP_PagosRealizados.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Lapso desde: {0} hasta: {1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxP_HistorialMovimientosLapso()
        {
            FrmLapsoProveedor f = new FrmLapsoProveedor() { Text = "Historial de Movimientos x Lapso" };
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            List<ReportViews.CxP_ProveedoresMovimiento> lista = ReportViews.CxP_ProveedoresMovimientoLapso(f.desde, f.hasta, f.proveedor);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxP_HistorialMovimientosLapso.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Lapso desde: {0} hasta: {1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //   reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxP_TransferenciaLote(List<TercerosMovimiento> lista, bool email)
        {
            if (lista.Count < 1)
                return;
            int? NumeroLote = lista[0].NumeroLote == null ? 0 : lista[0].NumeroLote;
            var listaNueva = (from item in lista
                              select new HK.ReportViews.CxP_ProveedoresMovimiento
                              {
                              Fecha = item.Fecha,
                              Vence = item.Vence,
                              Tipo = item.Tipo,
                              Concepto = item.Concepto,
                              Credito = item.Credito,
                              Debito = item.Debito,
                              PagarHoy = item.PagarHoy,
                              RazonSocial = item.Tercero.RazonSocial,
                              Cuenta = item.Tercero.NumeroCuenta,
                              Banco = item.Tercero.Banco,
                              Rif = item.Tercero.CedulaRif,
                              Email = item.Tercero.Email,
                              Numero = item.Numero,
                              DocumentoID = item.DocumentoID
                          
                              }).ToList();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxP_LoteParaTransferencia.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", listaNueva.ToArray()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("NumeroLote", string.Format("Numero de lote :{0}", NumeroLote)));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "LOTE PARA TRANSFERENCIA", "");
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                
                ShowDialog();
            }
        }
        public void CxP_TransferenciaLoteTotales(List<TercerosMovimiento> lista, bool email)
        {
            if (lista.Count < 1)
                return;
            int? NumeroLote = lista[0].NumeroLote == null ? 0 : lista[0].NumeroLote;
            var listaNueva = (from item in lista
                              select new HK.ReportViews.CxP_ProveedoresMovimiento
                              {
                              Fecha = item.Fecha,
                              Vence = item.Vence,
                              Tipo = item.Tipo,
                              Concepto = item.Concepto,
                              Credito = item.Credito,
                              Debito = item.Debito,
                              PagarHoy = item.PagarHoy,
                              RazonSocial = item.Tercero.RazonSocial,
                              NumeroCuenta = item.Tercero.NumeroCuenta,
                              Banco = item.Tercero.Banco,
                              Rif = item.Tercero.CedulaRif,
                              Email = item.Tercero.Email,
                              Numero = item.Numero
                              }).ToList();
            var Totalizada = (from x in listaNueva
                              group x by x.RazonSocial
                              into movimiento
                              select new HK.ReportViews.CxP_ProveedoresMovimiento
                              {
                              RazonSocial = movimiento.Key,
                              PagarHoy = movimiento.Sum( x => x.PagarHoy )
                              }).ToList();
            foreach (var item in Totalizada)
            {
                var x = (from i in listaNueva
                         where i.RazonSocial == item.RazonSocial
                         select i).FirstOrDefault();
                item.Rif = x.Rif;
                item.Banco =  x.Banco;
                item.NumeroCuenta = x.NumeroCuenta;
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxP_LoteParaTransferenciaTotales.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", Totalizada.ToArray()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("NumeroLote", string.Format("Numero de lote :{0} Fecha Ejecucion:{1}", NumeroLote, DateTime.Today.ToShortDateString())));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "LOTE PARA TRANSFERENCIA", "");
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                
                ShowDialog();
            }
        }
        #endregion
        #region CxC
        public void CxC_ListadoGeneral()
        {
            List<ReportViews.CxC_TercerosMovimiento> lista = ReportViews.CxC_ListadoGeneral();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_ListadoGeneral.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //     reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxC_Resumen()
        {
            Administrativo data = new Administrativo();
            Tercero[] proveedor = data.GetAllClientes("");
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\CxC_Resumen.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", proveedor));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //   reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxC_EstadoDeCuentaTercero(Tercero cliente, bool email)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_EstadoDeCuentaCliente.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", new Tercero[] { cliente }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ClientesMovimientos", cliente.TercerosMovimientos.Where(x => x.Saldo > 0).ToList()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            if (email)
            {
                string archivo = Basicas.ExportReportToPDF(reportViewer1.LocalReport);
                Basicas.EnviarEmail(archivo, "ESTADO DE CUENTA", cliente.Email);
                reportViewer1.LocalReport.ReleaseSandboxAppDomain();
            }
            else
            {
                //         reportViewer1.RefreshReport();
                ShowDialog();
            }
        }
        public void CxC_EstadoDeCuentaVendedor()
        {
            Administrativo data = new Administrativo();
            FrmLapsoVendedor f = new FrmLapsoVendedor();
            f.pedirFechas = false;
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            if (f.vendedor == null)
            {
                return;
            }
            Administrativo adm = new Administrativo();
            var lista =   adm.GetDocumentosPendientesVendedor(f.vendedor);
            foreach (var item in lista)
            {
                item.Comentarios = item.Tercero.RazonSocial + " " + item.Concepto;
            }
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\CxC_EstadoDeCuentaxVendedor.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ClientesMovimientos", lista.OrderBy(x=>x.Comentarios).ToArray()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Vendedor", f.vendedor.Nombre == null ? "TODOS" : f.vendedor.Nombre));
            ShowDialog();
        }
        public void CxC_ReporteCuentasxCobrarVendedor()
        {
            FrmLapsoVendedor f = new FrmLapsoVendedor();
            f.pedirFechas = false;
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            if (f.vendedor == null)
            {
                return;
            }
            Administrativo adm = new Administrativo();
            var lista = adm.GetResumenDocumentosPendientesVendedor(f.vendedor);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes + @"\CxC_CuentasxCobrarxVendedor.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Data", lista.ToArray()));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Vendedor", f.vendedor.Nombre==null?"TODOS":f.vendedor.Nombre));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxC_ResumenCuentasxCobrar()
        {
            Administrativo data = new Administrativo();
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_ResumenCuentasxCobrar.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", data.GetTercerosConSaldoPendiente("","CLIENTE") ));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            ShowDialog();
        }
        public void CxC_ListadoCobrosxLapso()
        {
            FrmLapso f = new FrmLapso();
            f.Text = "Listado Cobros x Lapso";
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            List<ReportViews.CxC_TercerosMovimiento> lista = ReportViews.CxC_ListadoCobrosxLapso(f.desde, f.hasta);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_CobrosRealizados.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Lapso desde: {0} hasta: {1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxC_HistorialMovimientosLapso()
        {
            FrmLapsoCliente f = new FrmLapsoCliente();
            f.Text = "Historial de Movimientos x Lapso";
            f.ShowDialog();
            if (f.DialogResult != System.Windows.Forms.DialogResult.OK)
                return;
            List<ReportViews.CxC_TercerosMovimiento> lista = ReportViews.CxC_TercerosMovimientoLapso(f.desde, f.hasta, f.cliente);
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_HistorialMovimientosLapso.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Movimientos", lista));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Lapso", string.Format("Lapso desde: {0} hasta: {1}", f.desde.ToShortDateString(), f.hasta.ToShortDateString())));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        public void CxC_ReporteCuentasxCobrarMovimientos(Tercero cliente, TercerosMovimiento[] movimientos)
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = config.DirectorioReportes +@"\CxC_CuentasxCobrarxMovimientos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Clientes", new Tercero[] { cliente }));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("ClientesMovimientos", movimientos));
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Parametros", new Parametro[] { OK.SystemParameters }));
            //    reportViewer1.RefreshReport();
            ShowDialog();
        }
        #endregion
    }
}
