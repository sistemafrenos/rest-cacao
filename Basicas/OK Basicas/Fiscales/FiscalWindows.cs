using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using HK;
using HK.Clases;
using HK.Formas;
using HK.BussinessLogic;

namespace HK.Fiscales
{
    /// <summary>
    /// Classe con la declaraciÃ³n de las funciones PNPDLL.dll
    /// </summary>
    public class FiscalWindows : IFiscal
    {
        public string UltimoZ = null;
        string Puerto;
        public FiscalWindows(string puerto)
        {
            Puerto = puerto;
            DetectarImpresora();
        }
        public void CerrarPuerto()
        {}
        //    FrmInformacion AuditMensaje = new FrmInformacion();
        public void DetectarImpresora()
        {
            return;
        }
        public double? MontoZ
        {
            get
            {
                return 0;
            }
        }
        public void ImprimeTicket(Factura documento)
        {
            if (documento == null)
                return;
            try
            {
                int Lineas = 1;
                LPrintWriter l = new LPrintWriter();
                // l.WriteLine(OK.Parametros.Empresa );
                // l.WriteLine("");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine(string.Format("NOTA DE DESPACHO:{0}", documento.Numero).PadLeft(35, ' '));
                l.WriteLine("========================================");
                l.WriteLine(" ");
                l.WriteLine(String.Format("FECHA:{0}", documento.Fecha.ToShortDateString()).PadLeft(35, ' '));
                // l.WriteLine(String.Format("NUMERO:{0}".PadLeft(35, ' '), documento.Numero));
                l.WriteLine(String.Format("ATENDIDO POR:{0}", documento.Vendedor).PadLeft(35, ' '));
                if (!string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine(" ");
                    l.WriteLine(String.Format("{0}", documento.CedulaRif));
                    l.WriteLine(String.Format("{0}", documento.RazonSocial));
                    l.WriteLine(String.Format("{0}", documento.Direccion));
                    l.WriteLine(" ");
                }
                l.WriteLine("CANT  DESCRIPCION               MONTO   ");
                l.WriteLine("========================================");
                var Acumulado = from p in documento.DocumentosProductos
                                group p by new
                                { p.Descripcion }
                                into itemResumido
                                select new
                                {
                                Descripcion = itemResumido.Key.Descripcion,
                                Cantidad = itemResumido.Sum(x => x.Cantidad),
                                Total = itemResumido.Sum(x => x.PrecioConIva * x.Cantidad)
                                };

                foreach (var Item in Acumulado)
                {
                    l.WriteLine("{0} {1} {2}", Item.Cantidad.Value.ToString("N2").PadRight(5, ' '), Item.Descripcion.PadRight(24, ' ').Substring(0, 24), (Item.Total.Value).ToString("N2").PadLeft(8));
                    if (Item.Descripcion.Length > 24)
                    {
                        l.WriteLine("     {0}", Item.Descripcion.Substring(24, (Item.Descripcion.Length - 24)));
                    }
                }
                l.WriteLine("========================================");
                if (documento.Descuentos.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("      DESCUENTO Bs.:".PadLeft(30) + documento.Descuentos.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                l.WriteLine("          TOTAL Bs.:".PadLeft(30) + documento.MontoTotal.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                l.WriteLine("========================================");
                l.WriteLine("NO SE ACEPTAN DEVOLUCIONES DE DINERO");
                l.WriteLine("LA EMPRESA NO SE HACE RESPONSABLE POR");
                l.WriteLine("MERCANCIA DEJADA EN DEPOSITO");
                for (Lineas = 0; Lineas < 12; Lineas++)
                    l.WriteLine(".");
                l.WriteLine(".");
                l.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace, ex);
            }
        }
        public void ImprimeFactura(Factura documento, Pago pago)
        { 
            
            FrmReportes r = new FrmReportes();
            if (documento.Numero == null)
            {
                documento.Numero = Administrativo.GetContador("FACTURA");
            }
            r.Ventas_Factura(documento, false);
        }
        public void ImprimeNotaCredito(NotaDeCredito documento, Pago pago)
        {
            try
            {
                if (documento == null)
                {
                    throw new Exception("Documento en blanco no se puede imprimir");
                }
                if (documento.Numero == null)
                {
                    documento.Numero = Administrativo.GetContador("NOTA CREDITO");
                }
                documento.Totalizar();
                if (documento.MontoTotal.GetValueOrDefault(0) == 0)
                {
                    throw new Exception("Este Documento esta imcompletos");
                }
                FrmReportes f = new FrmReportes();
                if (int.Parse(documento.Numero) == 0)
                {
                    documento.Numero = Administrativo.GetContador("NOTA CREDITO");
                }
                f.NotaCredito(documento,  pago);
            }
            catch (Exception x)
            {
                System.Threading.Thread.Sleep(1000);
                throw x;
            }
        }
        public void ImprimeFacturaCopia(Factura documento)
        {
            FrmReportes r = new FrmReportes();
            r.Ventas_Factura(documento, false);
        }
        public void ReporteX()
        {
            return;
        }
        public void ReporteZ()
        {
        }
        public void CargarX(bool conectar)
        {
            return;
        }
        public  void CargarS1(bool conectar)
        {
            return;
        }
        private double strToDouble(string p)
        {
            double Base = Convert.ToDouble(p.Substring(0, 10));
            double Decimales = Convert.ToDouble(p.Substring(10, 2));
            return Base + (Decimales / 100);
        }
        public void ReporteMensualIVA(DateTime dateTime, DateTime dateTime_2)
        {

        }
        public bool IsOK()
        {
            return true;
        }
        public void DocumentoNoFiscal(string[] Texto)
        {
        }
        public void ImprimeVale(Vale documento)
        {
            return;
        }
        public void ImprimeCierre(CierreCaja cierre, CierreCaja calculo, List<Factura> facturas, List<MesasCerrada> cerradas)
        {
            return;
        }
        public void ImprimeOrden(Factura documento)
        {
            return;
        }
        public void ImprimeCorte(MesasAbierta documento)
        {
            return;
        }
        public  void ImprimeCorteSinMontos(MesasAbierta documento)
        {
            if (documento == null)
                return;
            if (documento.CodigoMesa == null)
                return;
            try
            {
                int Lineas = 1;
                LPrintWriter l = new LPrintWriter();
                l.Impresora = "CORTES";
                l.WriteLine(OK.SystemParameters.Empresa);
                l.WriteLine("");
                l.WriteLine("PLATOS CONSUMIDOS");
                l.WriteLine(Basicas.TipoLetra(40) +String.Format("MESA:{0}", documento.CodigoMesa) + Basicas.TipoLetra(7));
                l.WriteLine(" ");
                l.WriteLine(String.Format("FECHA:{0}/{1}-{2} Q:{3}", documento.Apertura.Value.ToShortDateString(), documento.Apertura.Value.ToShortTimeString(), DateTime.Now.ToShortTimeString(), documento.NumeroImpresiones.GetValueOrDefault(0) + 1));
                //if (!string.IsNullOrEmpty(documento.CedulaRif))
                //{
                //    l.WriteLine(" ");
                //    l.WriteLine(String.Format("CEDULA/RIF:{0}", documento.CedulaRif));
                //    l.WriteLine(String.Format("    NOMBRE:{0}", documento.RazonSocial));
                //    l.WriteLine(String.Format(" DIRECCION:{0}", documento.Direccion));
                //    l.WriteLine(" ");
                //}
                //else
                    l.WriteLine(" ");
                l.WriteLine("CANT  DESCRIPCION                 ");
                l.WriteLine("========================================");
                var Acumulado = from p in documento.MesasAbiertasProductos.Where(x=>x.Anulado!=true && x.Departamento!="COMENTARIOS" && x.Precio.GetValueOrDefault()>0 )
                                group p by new
                                { p.Descripcion }
                                into itemResumido
                                select new
                                {
                                Descripcion = itemResumido.Key.Descripcion,
                                Cantidad = itemResumido.Sum(x => x.Cantidad),
                                Total = itemResumido.Sum(x => x.Precio * x.Cantidad)
                                };

                foreach (var Item in Acumulado)
                {
                    l.WriteLine("{0} {1} ", Item.Cantidad.Value.ToString("N2").PadRight(5, ' '), Item.Descripcion.PadRight(30, ' ').Substring(0, 30));
                }
               // l.WriteLine("SERVICIO DE MUELLE {0}",documento.MontoServicio.Value.ToString("n2"));
                if (string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine(String.Format("SI DESEA FACTURA PERSONALIZADA"));
                    l.WriteLine(String.Format("FAVOR INDIQUE LO SIGUIENTE:"));
                    l.WriteLine(" ");
                    l.WriteLine("CEDULA/RIF:__________________________");
                    l.WriteLine(" ");
                    l.WriteLine(String.Format("    NOMBRE:__________________________"));
                    l.WriteLine(" ");
                    l.WriteLine(String.Format(" DIRECCION:__________________________"));
                    l.WriteLine(" ");
                }
                for (Lineas = 0; Lineas < 6; Lineas++)
                {
                    l.WriteLine(" ");
                }
                l.WriteLine("========================================");
                for (Lineas = 0; Lineas < 8; Lineas++)
                {
                    l.WriteLine(" ");
                }
                l.WriteLine(".");
                l.Flush();
                l.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al imprimir", ex);
            }
        }
        public void ImprimeComanda(MesasAbierta documento, List<MesasAbiertasProducto> items)
        {
            return;
        }
        private void ImprimeComentarios(string s)
        {
            return;
        }
        private void ConectarImpresora()
        {
            return;
        }
        private void LiberarImpresora()
        {
            return;
        }
        internal  void ImprimirReciboCobro(Pago caja)
        {
            FrmReportes f = new FrmReportes();
            f.Recibo(caja);
        }

        public void ReporteMensualIVA(int mes, int ano)
        {
            return;
        }

        internal void ImprimirListado(List<Factura> Lista)
        {
            return;
        }


        public void ImprimeCierre(CierreCaja cierre, CierreCaja original, List<MesasCerrada> facturas, List<MesasCerrada> cerradas)
        {
            throw new NotImplementedException();
        }

        public void ImprimeOrdenDespacho(Factura documento)
        {
            if (documento == null)
                return;
            try
            {
                int Lineas = 1;
                LPrintWriter l = new LPrintWriter();
                // l.WriteLine(OK.Parametros.Empresa );
                // l.WriteLine("");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine(string.Format("NOTA DE DESPACHO:{0}", documento.Numero).PadLeft(35, ' '));
                l.WriteLine("========================================");
                l.WriteLine(" ");
                l.WriteLine(String.Format("FECHA:{0}", documento.Fecha.ToShortDateString()).PadLeft(35, ' '));
                // l.WriteLine(String.Format("NUMERO:{0}".PadLeft(35, ' '), documento.Numero));
                l.WriteLine(String.Format("ATENDIDO POR:{0}", documento.Vendedor).PadLeft(35, ' '));
                if (!string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine(" ");
                    l.WriteLine(String.Format("{0}", documento.CedulaRif));
                    l.WriteLine(String.Format("{0}", documento.RazonSocial));
                    l.WriteLine(String.Format("{0}", documento.Direccion));
                    l.WriteLine(" ");
                }
                l.WriteLine("CANT  DESCRIPCION               MONTO   ");
                l.WriteLine("========================================");
                var Acumulado = from p in documento.DocumentosProductos
                                group p by new { p.Descripcion }
                                    into itemResumido
                                    select new
                                    {
                                        Descripcion = itemResumido.Key.Descripcion,
                                        Cantidad = itemResumido.Sum(x => x.Cantidad),
                                        Total = itemResumido.Sum(x => x.PrecioConIva * x.Cantidad)
                                    };

                foreach (var Item in Acumulado)
                {
                    l.WriteLine("{0} {1} {2}", Item.Cantidad.Value.ToString("N2").PadRight(5, ' '), Item.Descripcion.PadRight(24, ' ').Substring(0, 24), (Item.Total.Value).ToString("N2").PadLeft(8));
                    if (Item.Descripcion.Length > 24)
                    {
                        l.WriteLine("     {0}", Item.Descripcion.Substring(24, (Item.Descripcion.Length - 24)));
                    }
                }
                l.WriteLine("========================================");
                if (documento.Descuentos.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("      DESCUENTO Bs.:".PadLeft(30) + documento.Descuentos.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                l.WriteLine("          TOTAL Bs.:".PadLeft(30) + documento.MontoTotal.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                l.WriteLine("========================================");
                l.WriteLine("NO SE ACEPTAN DEVOLUCIONES DE DINERO");
                l.WriteLine("LA EMPRESA NO SE HACE RESPONSABLE POR");
                l.WriteLine("MERCANCIA DEJADA EN DEPOSITO");
                for (Lineas = 0; Lineas < 12; Lineas++)
                    l.WriteLine(".");
                l.WriteLine(".");
                l.Flush();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace, ex);
            }
        }

        void IFiscal.ImprimirReciboCobro(Pago caja)
        {
            throw new NotImplementedException();
        }

        public string NumeroRegistro
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
