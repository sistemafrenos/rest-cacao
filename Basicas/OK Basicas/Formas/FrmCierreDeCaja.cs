using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.Fiscales;

namespace HK.Formas
{
    public partial class FrmCierreDeCaja : Form
    {
        List<string> Reporte = new List<string>();
        DateTime fecha = DateTime.Today;
        Administrativo data;
        public FrmCierreDeCaja()
        {
            InitializeComponent();
        }

        private void FrmCierreDeCaja_Load(object sender, EventArgs e)
        {
            data = new Administrativo();
            this.txtFecha.DateTime = DateTime.Today;
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(FrmLapso_KeyDown);
            this.btnImprimirFisca.Click += new EventHandler(btnImprimirFiscal_Click);
            this.btnImprimirTickera.Click += new EventHandler(btnImprimirTickera_Click);
            this.Cancelar.Click += new EventHandler(Cancelar_Click);
            this.btnCargar.Click += new EventHandler(btnCargar_Click);
            this.CenterToScreen();
        }

        void btnImprimirTickera_Click(object sender, EventArgs e)
        {
            IFiscal tickera = new Fiscales.FiscalTickera("");
            tickera.DocumentoNoFiscal(Reporte.ToArray());
            this.Close();
        }

        void btnImprimirFiscal_Click(object sender, EventArgs e)
        {
            IFiscal Fiscal = new Fiscales.FiscalBixolon("COM1");
            Fiscal.DocumentoNoFiscal(Reporte.ToArray());
            this.Close();
        }

        void btnCargar_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            fecha = txtFecha.DateTime;
            Reporte.Clear();
            //MesasCerradas cerradas = new MesasCerradas();
            Pago pagos = data.PagosxFecha(fecha,fecha);
            Vale[] valesDiarios =  data.GetByFechaVales(fecha,fecha);
            Documento[] facturasDia = data.GetDocumentos("", "FACTURA", "HOY");
            //var anulados = data.cerradasProductosAnulados(fecha, fecha);
            //var ventasxSalon = data.cerradasVentasxUbicacion(fecha, fecha);
            var ventasxDepartamento = data.facturasVentasxDepartamento(fecha, fecha);
            var ventasxProducto = data.facturasVentasxProducto(fecha, fecha);
            //    List<ReportViews.ProductosAnulados> anulados = Consultas.ProductosAnulados(fecha, fecha);
            Reporte.Add("CIERRE DE CAJA");
            Reporte.Add(" ");
            if (pagos.Efectivo > 0)
                Reporte.Add(string.Format("EFECTIVO    :{0}", pagos.Efectivo.Value.ToString("N2")));
            if(pagos.Cheque>0)
                Reporte.Add(string.Format("CHEQUES     :{0}",  pagos.Cheque.Value.ToString("N2")));
            if (pagos.TarjetaCredito > 0)
                Reporte.Add(string.Format("TARJETA CR  :{0}", pagos.TarjetaCredito.Value.ToString("N2")));
            if (pagos.TarjetaDebito > 0)
                Reporte.Add(string.Format("TARJETA DB  :{0}", pagos.TarjetaDebito.Value.ToString("N2")));
            if (pagos.CestaTicket > 0)
                Reporte.Add(string.Format("CESTA TICKET:{0}", pagos.CestaTicket.Value.ToString("N2")));
            if (pagos.Credito > 0)
                Reporte.Add(string.Format("CREDITOS    :{0}", pagos.Credito.Value.ToString("N2")));
            Reporte.Add(" ");
            Reporte.Add("VENTA X DEPARTAMENTO");
            foreach (var item in ventasxDepartamento)
            {
                Reporte.Add(
                    string.Format("{0}\t{1}\t{2}",
                    Basicas.PrintFix(item.Descripcion, 40, 1),
                    item.Cantidad.GetValueOrDefault(0).ToString("n2").PadLeft(4),
                    item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
                    )
                 );
            }
            Reporte.Add(" ");
            Reporte.Add("VENTA X PRODUCTOS");
            foreach (var item in ventasxProducto.ToList())
            {
                Reporte.Add(
                    string.Format("{0}\t{1}\t{2}",
                    Basicas.PrintFix(item.Descripcion, 40, 1),
                    item.Cantidad.GetValueOrDefault(0).ToString("n2").PadLeft(4),
                    item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
                    )
                 );
            }
            Reporte.Add(" ");
            Reporte.Add("VENTA X UBICACIONES");
            //foreach (var item in ventasxSalon)
            //{
            //    Reporte.Add(
            //        string.Format("{0}\t{1}\t{2}",
            //        Basicas.PrintFix(item.Descripcion, 40, 1),
            //        item.Cantidad.GetValueOrDefault(0).ToString("n2").PadLeft(4),
            //        item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
            //        )
            //     );
            //}
            Reporte.Add(" ");
            if (facturasDia.Length > 0)
            {
                Reporte.Add("FACTURAS DEL DIA");
                foreach (var item in facturasDia)
                {
                    Reporte.Add(string.Format("{0}\t{1}\t{2}\t{3}", item.Numero, item.CedulaRif.PadLeft(10), item.RazonSocial.PadRight(20), item.MontoTotal.Value.ToString("n2").PadLeft(8)));
                }
                Reporte.Add(string.Format("Total Facturas: {0}", facturasDia.Sum(d => d.MontoTotal).Value.ToString("N2")));
                Reporte.Add(" ");
            }
            if (valesDiarios.Length > 0)
            {
                Reporte.Add("VALES DEL DIA");
                foreach (var item in valesDiarios)
                {
                    Reporte.Add(string.Format("{0}\t{1}\t{2}", item.Numero, item.Nombre.PadLeft(20), item.Monto.Value.ToString("n2").PadLeft(8)));
                }
                Reporte.Add(string.Format("Total Vales: {0}", valesDiarios.Sum(d => d.Monto).Value.ToString("N2")));
                Reporte.Add(" ");
            }
         //   if (anulados > 0)
            //{
            //    Reporte.Add("ANULACIONES");
            //    foreach (var item in anulados)
            //    {
            //        Reporte.Add(
            //            string.Format("{0}\t{1}\t{2}",
            //            Basicas.PrintFix(item.Descripcion, 40, 1),
            //            item.Cantidad.GetValueOrDefault(0).ToString("n2").PadLeft(4),
            //            item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
            //            )
            //        );
            //    }
            //    Reporte.Add(" ");
            //}
            Reporte.Add("**** FIN ****");
            foreach (var linea in Reporte)
            {
                s.AppendLine(linea);
            }
            memoEdit1.Text = s.ToString();
            SistemaConfig econfig = new SistemaConfig();
            if (!string.IsNullOrEmpty(econfig.EmailDestinatario1))
                Basicas.EnviarEmail(Reporte.ToArray(), econfig.EmailDestinatario1);
            if (!string.IsNullOrEmpty(econfig.EmailDestinatario2))
                Basicas.EnviarEmail(Reporte.ToArray(), econfig.EmailDestinatario2);

        }
        void FrmLapso_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Cancelar.PerformClick();
                    e.Handled = true;
                    break;
            }
        }
        void Cancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}

