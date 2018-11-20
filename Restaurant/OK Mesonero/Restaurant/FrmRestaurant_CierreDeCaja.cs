using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HK.BussinessLogic;
using HK.Fiscales;
using HK.BussinessLogic.Restaurant;

namespace HK.Formas
{
    public partial class FrmRestaurant_CierreDeCaja : Form
    {
        List<string> Reporte = new List<string>();
        DateTime fecha = DateTime.Today;
        Restaurant data;
        public FrmRestaurant_CierreDeCaja()
        {
            InitializeComponent();
        }

        private void FrmCierreDeCaja_Load(object sender, EventArgs e)
        {
            data = new Restaurant();
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
            IFiscal Fiscal = ((Fiscal)new Fiscal()).GetFiscal();
            Fiscal.DocumentoNoFiscal(Reporte.ToArray());
            this.Close();
        }
        void btnCargar_Click(object sender, EventArgs e)
        {
            StringBuilder s = new StringBuilder();
            fecha = txtFecha.DateTime;
            Reporte.Clear();
            Pago pagos = data.PagosxFecha(fecha,fecha);
            Vale[] valesDiarios =data.GetByFechaVales(fecha,fecha);
            var mesasAbiertas = data.GetMesasAbiertasSalon(null).Where(x=> x.Monto.GetValueOrDefault()>0);
            MesasCerrada[] mesasCerradas = data.GetByFechasTipoMesasCerradas(fecha, fecha,"TODO");
            var anulados = data.cerradasProductosAnulados(fecha, fecha);
            var ventasxSalon = data.cerradasVentasxUbicacion(fecha, fecha);
            var ventasxDepartamento = data.cerradasVentasxDepartamento(fecha, fecha);
            var ventasxProducto = data.cerradasVentasxProducto(fecha, fecha);
            var mesasAnuladas = data.cerradasMesasAnuladas(fecha, fecha);
            var rpDiarios = data.rpDiarios(fecha, fecha);
            foreach (var item in mesasCerradas)
            {
                item.Totalizar();
            }
            Reporte.Add("CIERRE DE CAJA");
            Reporte.Add(" "+fecha.ToLongDateString().ToUpperInvariant());
            Reporte.Add(" ");
            Reporte.Add("DESGLOSE PAGOS:");
            if (pagos.Efectivo > 0)
                Reporte.Add(string.Format(" EFECTIVO    :{0}", pagos.Efectivo.Value.ToString("N2").PadLeft(8)));
            if (pagos.Cheque > 0)
                Reporte.Add(string.Format(" CHEQUES     :{0}", pagos.Cheque.Value.ToString("N2").PadLeft(8)));
            if (pagos.TarjetaCredito > 0)
                Reporte.Add(string.Format(" TARJETA CR  :{0}", pagos.TarjetaCredito.Value.ToString("N2").PadLeft(8)));
            if (pagos.TarjetaDebito > 0)
                Reporte.Add(string.Format(" TARJETA DB  :{0}", pagos.TarjetaDebito.Value.ToString("N2").PadLeft(8)));
            if (pagos.CestaTicket > 0)
                Reporte.Add(string.Format(" CESTA TICKET:{0}", pagos.CestaTicket.Value.ToString("N2").PadLeft(8)));
            if (pagos.Credito > 0)
                Reporte.Add(string.Format(" CREDITOS    :{0}", pagos.Credito.Value.ToString("N2").PadLeft(8)));
            Reporte.Add(" ");
            Reporte.Add("TOTALES");
            var baseCerradas = mesasCerradas.Sum(d => d.MontoGravable).GetValueOrDefault(0);
            var mesonerosCerradas = mesasCerradas.Where(x => x.CobraServicio == true).Sum(d => d.MontoServicio);
         //   var mesonerosCerradas = baseCerradas * 0.1;
            var ivaCerradas = mesasCerradas.Sum(d => d.MontoIva).GetValueOrDefault(0);
            var totalCerradas = mesasCerradas.Sum(d => d.MontoTotal).GetValueOrDefault(0);
            Reporte.Add(
                string.Format(
                Basicas.PrintFix(" BASE IMPONIBLE:\t{0}",26,1), 
                baseCerradas.ToString("N2").PadLeft(8)
                )
            );
            if(mesonerosCerradas.GetValueOrDefault()>0)
            {
            Reporte.Add(
                string.Format(
                Basicas.PrintFix(" MESONEROS:\t{0}",26,1), 
                mesonerosCerradas.GetValueOrDefault(0).ToString("N2").PadLeft(8)
                )
            );
            }
            Reporte.Add(
                string.Format(
                Basicas.PrintFix(" MONTO IVA:\t{0}",26,1), 
                ivaCerradas.ToString("N2").PadLeft(8)
                )
            );
            Reporte.Add(
                string.Format(
                Basicas.PrintFix(" MONTO TOTAL:\t{0}",26,1), 
                totalCerradas.ToString("N2").PadLeft(8)
                )
            );
            Reporte.Add(" ");
            //Reporte.Add("VENTA X DEPARTAMENTO");
            //foreach (var item in ventasxDepartamento)
            //{
            //    Reporte.Add(
            //        string.Format("{0}  {1}\t{2}",
            //        item.Cantidad.GetValueOrDefault(0).ToString("n0").PadLeft(4),
            //        Basicas.PrintFix(item.Descripcion, 22, 1),
            //        item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
            //        )
            //     );
            //}
            //Reporte.Add(" ");
            Reporte.Add("VENTA X PRODUCTOS");
            foreach (var item in ventasxProducto)
            {
                Reporte.Add(
                    string.Format("{0}  {1}\t{2}",
                    item.Cantidad.GetValueOrDefault(0).ToString("n0").PadLeft(4),
                    Basicas.PrintFix(item.Descripcion, 22, 1),
                    item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
                    )
                 );
            }
            //Reporte.Add(" ");
            //Reporte.Add("VENTA X UBICACIONES");
            //foreach (var item in ventasxSalon)
            //{
            //    Reporte.Add(
            //        string.Format("{0}  {1}\t{2}",
            //        item.Cantidad.GetValueOrDefault(0).ToString("n0").PadLeft(4),
            //        Basicas.PrintFix(item.Descripcion, 22, 1),
            //        item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
            //        )
            //     );
            //}
            Reporte.Add(" ");
            if (mesasAbiertas.Count() > 0)
            {
                Reporte.Add("MESAS ABIERTAS");
                foreach (var item in mesasAbiertas)
                {
                    Reporte.Add(string.Format("{0}\t{1}\t{2}\t{3}", item.Ubicacion, item.Codigo.PadLeft(10), item.Apertura.GetValueOrDefault().ToShortTimeString(), item.Monto.Value.ToString("n2").PadLeft(8)));
                }
                Reporte.Add(string.Format("TOTAL ABIERTAS: {0}".PadRight(30), mesasAbiertas.Sum(d => d.Monto).Value.ToString("N2")));
                Reporte.Add(" ");
            }
            if (mesasCerradas.Length > 0)
            {
                Reporte.Add("MESAS CERRADAS");
                foreach (var item in mesasCerradas.OrderBy(x => x.Numero).ToList())
                {
                    Reporte.Add(string.Format("{0}\t{1}\t{2}", item.Numero, Basicas.PrintFix(item.RazonSocial, 20, 1), item.MontoTotal.Value.ToString("n2").PadLeft(8)));
                }
                Reporte.Add(string.Format("TOTAL CERRADAS: {0}".PadRight(30), mesasCerradas.Sum(d => d.MontoTotal).Value.ToString("N2")));
                Reporte.Add(" ");
            }
            //if (mesasAnuladas.Expression > 0)
            //{
                double total = 0;
                Reporte.Add("MESAS ANULADAS");
                foreach (var item in mesasAnuladas)
                {
                    total += (double)Basicas.GetValue(item, "MontoTotal");
                    Reporte.Add(string.Format("{0}\t{1}\t{2}\t{3}", Basicas.GetValue(item, "Numero"), ((string)Basicas.GetValue(item, "CedulaRif")).PadLeft(10), Basicas.PrintFix((string)Basicas.GetValue(item, "RazonSocial"), 20, 1), ((double)Basicas.GetValue(item,"MontoTotal")).ToString("n2").PadLeft(8)));

                }
                Reporte.Add(string.Format("TOTAL ANULADAS: {0}".PadRight(30), total.ToString("N2")));
                Reporte.Add(" ");
            //}

            //if (valesDiarios.Count()>0)
            //{
            //    Reporte.Add("VALES DEL DIA");
            //    foreach (var item in valesDiarios)
            //    {
            //        Reporte.Add(string.Format("{0}\t{1}\t{2}", item.Numero, item.Nombre.PadLeft(20), item.Monto.Value.ToString("n2").PadLeft(8)));
            //    }
            //    Reporte.Add(string.Format("TOTAL VALES: {0}".PadRight(30), valesDiarios.Sum(d => d.Monto).Value.ToString("N2")));
            //    Reporte.Add(" ");
            //}
            //Reporte.Add(" ");
            //Reporte.Add("RP DEL DIA");
            //foreach (var item in rpDiarios)
            //{
            //    Reporte.Add(
            //        string.Format("{0}  {1}",
            //        item.Cantidad.GetValueOrDefault(0).ToString("n0").PadLeft(4),
            //        Basicas.PrintFix(item.Descripcion, 30, 1)
            //        )
            //     );
            //}
            Reporte.Add(" ");
            if (anulados.Length > 0)
            {
                Reporte.Add("ANULACIONES");
                foreach (var item in anulados)
                {
                    Reporte.Add(
                        string.Format("{0}\t{1}\t{2}",
                        item.Cantidad.GetValueOrDefault(0).ToString("n0").PadLeft(4),
                        Basicas.PrintFix(item.Descripcion, 22, 1),
                        item.Bolivares.GetValueOrDefault(0).ToString("n2").PadLeft(8)
                        )
                    );
                }
                Reporte.Add(" ");
            }
            Reporte.Add("**** FIN ****");
            foreach (var linea in Reporte)
            {
                s.AppendLine(linea);
            }
            memoEdit1.Text = s.ToString();
            //SistemaConfig econfig = new SistemaConfig();
            //if (!string.IsNullOrEmpty(econfig.EmailDestinatario1))
            //    Basicas.EnviarEmail(Reporte.ToArray(), econfig.EmailDestinatario1);
            //if (!string.IsNullOrEmpty(econfig.EmailDestinatario2))
            //    Basicas.EnviarEmail(Reporte.ToArray(), econfig.EmailDestinatario2);

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

