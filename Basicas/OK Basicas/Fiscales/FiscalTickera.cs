using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK.Fiscales
{
    public class FiscalTickera : IFiscal
    {
        public string UltimoZ = null;
        string Puerto;
        public FiscalTickera(string puerto)
        {
            Puerto = puerto;
            DetectarImpresora();
        }
        public void DetectarImpresora()
        {
            return;
        }
        public void CerrarPuerto()
        {
           
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
                         //  1234567890123456789012345678901234567890
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
            catch( Exception x)
            {
                throw new Exception("Error al imprimir Ticket", x);
            }
        }
        void IFiscal.ImprimeFacturaCopia(Factura documento)
        {
            
            if (documento == null)
                return;
            if (string.IsNullOrEmpty(documento.Numero))
            {
             //   documento.Numero = FactoryContadores.GetContador("NumeroFactura");
                documento.Fecha = DateTime.Today;
                documento.NumeroZ = null;
                documento.MaquinaFiscal = "TICKETS";
            }
            try
            {
                int Lineas = 1;
                LPrintWriter l = new LPrintWriter();
                l.WriteLine(OK.SystemParameters.Empresa);
                l.WriteLine("");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine(string.Format("FACTURA:{0}", documento.Numero).PadLeft(35, ' '));
                l.WriteLine("========================================");
                l.WriteLine(" ");
                l.WriteLine(String.Format("FECHA:{0}", documento.Fecha.ToShortDateString()).PadLeft(35, ' '));
                if (!string.IsNullOrEmpty(documento.Vendedor))
                    l.WriteLine(String.Format("ATENDIDO POR:{0}", documento.Vendedor).PadRight(38, ' '));
                if (!string.IsNullOrEmpty(documento.Comentarios))
                    l.WriteLine(String.Format("COMENTARIOS:\n{0}", documento.Comentarios).PadRight(38, ' '));
                if (!string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine("CLIENTE:");
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
                if (documento.MontoGravable.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("   MONTO GRAVABLE Bs.:".PadLeft(30) + documento.MontoGravable.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                if (documento.MontoExento.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("   MONTO EXENTO Bs.:".PadLeft(30) + documento.MontoExento.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                if (documento.MontoIva.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("   MONTO IVA Bs.:".PadLeft(30) + documento.MontoIva.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                if (documento.Descuentos.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("      DESCUENTO Bs.:".PadLeft(30) + documento.Descuentos.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                l.WriteLine("          TOTAL Bs.:".PadLeft(30) + documento.MontoTotal.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                l.WriteLine("========================================");
                
                //if (documento.Pago == null)
                //{
                //    documento.Pago= new Pago();
                //}
                //if (documento.Pago.Efectivo.GetValueOrDefault(0) > 0)
                //    l.WriteLine(String.Format("Efectivo .:{0}", documento.Pago.Efectivo.Value.ToString("N2")));
                //if (documento.Pago.TarjetaCredito.GetValueOrDefault(0) > 0)
                //    l.WriteLine(String.Format("Tarjeta CR:{0}", documento.Pago.TarjetaCredito.Value.ToString("N2")));
                //if (documento.Pago.TarjetaDebito.GetValueOrDefault(0) > 0)
                //    l.WriteLine(String.Format("Tarjeta DB:{0}", documento.Pago.TarjetaDebito.Value.ToString("N2")));
                //if (documento.Pago.Credito.GetValueOrDefault(0) > 0)
                //    l.WriteLine(String.Format("Credito...:{0}", documento.Pago.Credito.Value.ToString("N2")));
                //if (documento.Pago.Cheque.GetValueOrDefault(0) > 0)
                //    l.WriteLine(String.Format("Cheques...:{0}", documento.Pago.Cheque.Value.ToString("N2")));
                for (Lineas = 0; Lineas < 12; Lineas++)
                    l.WriteLine(".");
                l.WriteLine(".");
                l.Flush();
            }
            catch (Exception ex)
            {
                Basicas.ManejarError(ex);
            }

        }
        void ImprimeNotaDeCredito(NotaDeCredito documento, Pago pago)
       {
            if (documento == null)
                return;
            if (string.IsNullOrEmpty(documento.Numero))
            {
                documento.Numero = Administrativo.GetContador("NumeroFactura");
                documento.Fecha = DateTime.Now;
                documento.NumeroZ = null;
                documento.MaquinaFiscal = "TICKETS";
            }
            try
            {
                int Lineas = 1;
                LPrintWriter l = new LPrintWriter();
                l.WriteLine(OK.SystemParameters.Empresa);
                l.WriteLine("");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine(string.Format("DEVOLUCION:{0}", documento.Numero).PadLeft(35, ' '));
                l.WriteLine("========================================");
                l.WriteLine(" ");
                l.WriteLine(String.Format("FECHA:{0}", documento.Fecha.ToShortDateString()).PadLeft(35, ' '));
                l.WriteLine(String.Format("ATENDIDO POR:{0}", documento.Vendedor).PadLeft(35, ' '));
                l.WriteLine(String.Format("COMENTARIOS:\n{0}", documento.Comentarios).PadLeft(38, ' '));
                if (!string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine("CLIENTE:");
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
                if (documento.MontoGravable.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("   MONTO GRAVABLE Bs.:".PadLeft(30) + documento.MontoGravable.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                if (documento.MontoExento.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("   MONTO EXENTO Bs.:".PadLeft(30) + documento.MontoExento.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                if (documento.MontoIva.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("   MONTO IVA Bs.:".PadLeft(30) + documento.MontoIva.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                if (documento.Descuentos.GetValueOrDefault(0) > 0)
                {
                    l.WriteLine("      DESCUENTO Bs.:".PadLeft(30) + documento.Descuentos.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                l.WriteLine("          TOTAL Bs.:".PadLeft(30) + documento.MontoTotal.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                l.WriteLine("========================================");
                for (Lineas = 0; Lineas < 12; Lineas++)
                    l.WriteLine(".");
                l.WriteLine(".");
                l.Flush();
            }
            catch( Exception x )
            {
                throw new Exception(x.StackTrace, x);
            }
        }
        void ImprimeFacturaCopia(Factura doc)
        {
            ImprimeFactura(doc,new Pago());
        }
        void IFiscal.ReporteX()
        {
        }
        void IFiscal.ReporteZ()
        {     
        }
        void CargarX()
        {
        }
        void CargarS1()
        {
        }
        void CargarS2()
        {
        }
        double strToDouble(string p)
        {
            double Base = Convert.ToDouble(p.Substring(0, 10));
            double Decimales = Convert.ToDouble(p.Substring(10, 2));
            return Base + (Decimales / 100);
        }
        void IFiscal.ReporteMensualIVA(DateTime dateTime, DateTime dateTime_2)
        {

        }
        bool IsOK()
        {
            return true;
        }
        void IFiscal.DocumentoNoFiscal(string[] Texto)
        {
            StreamWriter l = new StreamWriter("NoFiscal.txt");
            foreach (var x in Texto)
            {
                l.WriteLine(x);
            }
            l.Flush();
            l.Dispose();
            RawPrinterHelper.SendFileToPrinter(Basicas.GetDefaultPrinterName(), "NoFiscal.txt");
        }
        void ImprimeVale()
        {

        }
        void ImprimeCierre(CierreCaja cierre, CierreCaja calculo, List<Factura> facturas, List<MesasCerrada> cerradas)
        {
        }
        void IFiscal.ImprimeOrdenDespacho(Factura documento)
        {
            try
            {
                StreamWriter l = new StreamWriter("OrdenDespacho.txt");
                l.WriteLine(" ");
                l.WriteLine(Basicas.TipoLetra(32) + string.Format("DESPACHO:{0}", documento.NumeroOrden) + Basicas.TipoLetra(7));
                l.WriteLine(Basicas.TipoLetra(7) + string.Format("CLIENTE:{0}", documento.RazonSocial) + Basicas.TipoLetra(7));
                l.WriteLine(string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                l.WriteLine("========================================");
                foreach (var item in documento.DocumentosProductos)
                {
                    l.WriteLine("{0}\n{1}", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25));
                    //if (item.Contornos != null)
                    //{
                    //    foreach (string p in item.Contornos)
                    //    {
                    //        l.WriteLine(p);
                    //    }
                    //}
                }
                l.WriteLine(Basicas.TipoLetra(07));
                l.WriteLine("\n\n\n\n\n\n.");
                l.Flush();
                l.Close();
                l.Dispose();
                RawPrinterHelper.SendFileToPrinter(Basicas.GetDefaultPrinterName(), "OrdenDespacho.txt");
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        void IFiscal.ImprimeCorte(MesasAbierta documento)
        {
            if (documento == null)
                return;
            try
            {
                int Lineas = 1;
                StreamWriter l = new StreamWriter("CorteDeCuenta.txt");
                l.WriteLine("NOTA DE CONSUMO MESA");
                l.WriteLine("MESA:{0}", documento.CodigoMesa);
                l.WriteLine("{0}{1}", "MESA:", Basicas.TipoLetra(40), documento.CodigoMesa);
                l.WriteLine(Basicas.TipoLetra(7));
                l.WriteLine("  #:{0}", documento.Numero);
                l.WriteLine("HORA:{0}", documento.Apertura.GetValueOrDefault().ToShortTimeString());
                l.WriteLine(" ");
                l.WriteLine("FECHA:{0} Q:{1}", documento.Apertura.Value.ToShortDateString(), documento.NumeroImpresiones.GetValueOrDefault(0) + 1);
                l.WriteLine(" ");
                l.WriteLine("           NO FISCAL  ");
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
                var Acumulado = from p in documento.MesasAbiertasProductos.Where(x => x.Anulado != true && x.Codigo != "COMENTARIO")
                                group p by new { p.Descripcion }
                                    into itemResumido
                                    select new
                                    {
                                        Descripcion = itemResumido.Key.Descripcion,
                                        Cantidad = itemResumido.Sum(x => x.Cantidad),
                                        Total = itemResumido.Sum(x => x.Precio * x.Cantidad)
                                    };
                foreach (var Item in Acumulado)
                {
                    l.WriteLine("{0} {1} {2}", Item.Cantidad.Value.ToString("N2").PadRight(5, ' '), Item.Descripcion.PadRight(24, ' ').Substring(0, 24), (Item.Total.Value).ToString("N2").PadLeft(8));
                }
                l.WriteLine("========================================");
                l.WriteLine("           NO FISCAL  ");
                documento.Totalizar();
                if (documento.MontoServicio.GetValueOrDefault(0) >= 0)
                {
                    l.WriteLine("   SUB TOTAL Bs.:".PadLeft(30) + documento.MontoGravable.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                    l.WriteLine("10% SERVICIO Bs.:".PadLeft(30) + documento.MontoServicio.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                    l.WriteLine("         IVA Bs.:".PadLeft(30) + documento.MontoIva.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                }
                else
                {
                    l.WriteLine("   SUB TOTAL Bs.:".PadLeft(30) + documento.MontoGravable.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                    l.WriteLine("         IVA Bs.:".PadLeft(30) + documento.MontoIva.GetValueOrDefault(0).ToString("N2").PadLeft(8));

                }
                l.WriteLine("      TOTAL Bs.:".PadLeft(30) + documento.MontoTotal.GetValueOrDefault(0).ToString("N2").PadLeft(8));
                l.WriteLine("           NO FISCAL  ");
                l.WriteLine("========================================");
                if (string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine("SI DESEA FACTURA PERSONALIZADA");
                    l.WriteLine("FAVOR INDIQUE LO SIGUIENTE:");
                    l.WriteLine(" ");
                    l.WriteLine("CEDULA/RIF:__________________________");
                    l.WriteLine(" ");
                    l.WriteLine("    NOMBRE:__________________________");
                    l.WriteLine(" ");
                    l.WriteLine(" DIRECCION:__________________________");
                    l.WriteLine(" ");
                }
                for (Lineas = 0; Lineas < 8; Lineas++)
                    l.WriteLine(" ");
                l.WriteLine(".");
                l.Flush();
                l.Close();
                l.Dispose();
                RawPrinterHelper.SendFileToPrinter(Basicas.GetDefaultPrinterName(), "CorteDeCuenta.txt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        void IFiscal.ImprimeCorteSinMontos(MesasAbierta documento)
        {
            if (documento == null)
                return;
            try
            {
                int Lineas = 1;
                StreamWriter l = new StreamWriter("CorteDeCuenta.txt");
                l.WriteLine("NOTA DE CONSUMO MESA");
                l.WriteLine("MESA:{0}", documento.CodigoMesa);
                l.WriteLine("{0}{1}", "MESA:", Basicas.TipoLetra(40), documento.CodigoMesa);
                l.WriteLine(Basicas.TipoLetra(7));
                l.WriteLine("  #:{0}", documento.Numero);
                l.WriteLine("HORA:{0}", documento.Apertura.GetValueOrDefault().ToShortTimeString());
                l.WriteLine(" ");
                l.WriteLine("FECHA:{0} Q:{1}", documento.Apertura.Value.ToShortDateString(), documento.NumeroImpresiones.GetValueOrDefault(0) + 1);
                l.WriteLine(" ");
                l.WriteLine("           NO FISCAL  ");
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
                var Acumulado = from p in documento.MesasAbiertasProductos.Where(x => x.Anulado != true && x.Codigo != "COMENTARIO")
                                group p by new { p.Descripcion }
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
                l.WriteLine("========================================");
                if (string.IsNullOrEmpty(documento.CedulaRif))
                {
                    l.WriteLine("SI DESEA FACTURA PERSONALIZADA");
                    l.WriteLine("FAVOR INDIQUE LO SIGUIENTE:");
                    l.WriteLine(" ");
                    l.WriteLine("CEDULA/RIF:__________________________");
                    l.WriteLine(" ");
                    l.WriteLine("    NOMBRE:__________________________");
                    l.WriteLine(" ");
                    l.WriteLine(" DIRECCION:__________________________");
                    l.WriteLine(" ");
                }
                for (Lineas = 0; Lineas < 8; Lineas++)
                    l.WriteLine(" ");
                l.WriteLine(".");
                l.Flush();
                l.Close();
                l.Dispose();
                RawPrinterHelper.SendFileToPrinter(Basicas.GetDefaultPrinterName(), "CorteDeCuenta.txt");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //void IFiscal.ImprimeCorteSinMontos(MesasAbierta documento)
        //{
        //    if (documento == null)
        //        return;
        //    if (documento.CodigoMesa == null)
        //        return;
        //    try
        //    {
        //        int Lineas = 1;
        //        StreamWriter l = new StreamWriter("CorteDeCuenta.txt");
        //        l.WriteLine(OK.SystemParameters.Empresa);
        //        l.WriteLine("");
        //        l.WriteLine(" NOTA DE CONSUMO ");
        //        l.WriteLine("{0}{1}","MESA:",Basicas.TipoLetra(40),documento.CodigoMesa);
        //        l.WriteLine("{0}{1}","   #:",Basicas.TipoLetra(40),documento.Numero);
        //        l.WriteLine("{0}{1}","HORA:",Basicas.TipoLetra(40),documento.Apertura.GetValueOrDefault().ToShortTimeString());
        //        l.WriteLine(" ");
        //        l.WriteLine("{0}{1}",Basicas.TipoLetra(7), string.Format("FECHA:{0} Q:{1}",documento.Apertura.Value.ToShortDateString(), documento.NumeroImpresiones.GetValueOrDefault(0) + 1));
        //        l.WriteLine(" ");
        //        l.WriteLine(Basicas.TipoLetra(7));
        //        //if (!string.IsNullOrEmpty(documento.CedulaRif))
        //        //{
        //        //    l.WriteLine(" ");
        //        //    l.WriteLine(String.Format("CEDULA/RIF:{0}", documento.CedulaRif));
        //        //    l.WriteLine(String.Format("    NOMBRE:{0}", documento.RazonSocial));
        //        //    l.WriteLine(String.Format(" DIRECCION:{0}", documento.Direccion));
        //        //    l.WriteLine(" ");
        //        //}
        //        //else
        //            l.WriteLine(" ");
        //        l.WriteLine("{0}{1}",Basicas.TipoLetra(7),"CANT  DESCRIPCION                 ");
        //        l.WriteLine("========================================");
        //        var Acumulado = from p in documento.MesasAbiertasProductos.Where(x => x.Anulado != true)
        //                        group p by new { p.Descripcion }
        //                            into itemResumido
        //                            select new
        //                            {
        //                                Descripcion = itemResumido.Key.Descripcion,
        //                                Cantidad = itemResumido.Sum(x => x.Cantidad),
        //                                Total = itemResumido.Sum(x => x.Precio * x.Cantidad)
        //                            };

        //        foreach (var Item in Acumulado)
        //        {
        //            l.WriteLine("{0} {1} ", Item.Cantidad.Value.ToString("N2").PadRight(5, ' '), Item.Descripcion.PadRight(30, ' ').Substring(0, 30));
        //        }
        //        l.WriteLine(" ");
        //        l.WriteLine("POR EXIGENCIAS DEL SENIAT SEGUN LA ");
        //        l.WriteLine("PROVIDENCIA 0071 NO PODEMOS");
        //        l.WriteLine("EMITIR CORTES PARCIALES O TOTALES");
        //        l.WriteLine("AGRADECEMOS VERIFIQUE SUS CONSUMOS");
        //        if (string.IsNullOrEmpty(documento.CedulaRif) || documento.CedulaRif == Basicas.CedulaRif("0"))
        //        {
        //            l.WriteLine(" ");
        //            l.WriteLine("EXIJA SU FACTURA EN CAJA");
        //            l.WriteLine("FAVOR INDIQUE LO SIGUIENTE:");
        //            l.WriteLine(" ");
        //            l.WriteLine("CEDULA/RIF:__________________________");
        //            l.WriteLine(" ");
        //            l.WriteLine("    NOMBRE:__________________________");
        //            l.WriteLine(" ");
        //            l.WriteLine(" DIRECCION:__________________________");
        //            l.WriteLine(" ");
        //        }
        //        for (Lineas = 0; Lineas < 6; Lineas++)
        //        {
        //            l.WriteLine(" ");
        //        }
        //        l.WriteLine("========================================");
        //        for (Lineas = 0; Lineas < 8; Lineas++)
        //        {
        //            l.WriteLine(" ");
        //        }
        //        l.WriteLine(".");
        //        l.Flush();
        //        l.Close();
        //        l.Dispose();
        //        RawPrinterHelper.SendFileToPrinter(Basicas.GetDefaultPrinterName(), "CorteDeCuenta.txt");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Error al imprimir corte cuenta", ex);
        //    }
        //}
        void ImprimeComanda(MesasAbierta documento)
        {
            
            const string Impresora = "COCINA";
            var porimprimir = from p in documento.MesasAbiertasProductos
                              where !String.IsNullOrEmpty(p.EnviarComanda) && string.IsNullOrEmpty(p.NumeroComanda) && p.EnviarComanda != "NINGUNA"
                              select p;
            if (porimprimir.Count() == 0)
                return;
            try
            {
                Administrativo data = new Administrativo();
                string NumeroComanda = Administrativo.GetContador("ComandaCocina");
                data.GuardarCambios();
                StreamWriter l = new StreamWriter(String.Format("Comanda_{0}.txt", Impresora));
                l.WriteLine(" ");
                l.WriteLine(Basicas.TipoLetra(32) + string.Format("MESA:{0}  COMANDA:{1}", documento.CodigoMesa, NumeroComanda.Substring(3, 3)) + Basicas.TipoLetra(7));
                l.WriteLine(Basicas.TipoLetra(07) + string.Format("TICKET:{0}", documento.Numero));
                l.WriteLine(string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                l.WriteLine(string.Format("ATENDIDO POR:{0}", Basicas.TipoLetra(23) + documento.Mesonero + Basicas.TipoLetra(7)));
                l.WriteLine("========================================");
                foreach (var item in porimprimir)
                {
                    item.NumeroComanda = NumeroComanda;
                    l.WriteLine("{0} {1}", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25));
                    if (item.Comentario != null)
                    {
                        l.WriteLine(Basicas.TipoLetra(32) + item.Comentario + Basicas.TipoLetra(40));
                    }
                }
                l.WriteLine(Basicas.TipoLetra(07));
                l.WriteLine(Basicas.TipoLetra(32) + (documento.CodigoMesa == null ? "PARA LLEVAR" : "") + Basicas.TipoLetra(07));
                l.WriteLine("\n\n\n\n\n\n.");
                l.Flush();
                l.Close();
                l.Dispose();
                //switch (Impresora)
                //{
                //    case "NINGUNA":
                //        break;
                //    default:
                        RawPrinterHelper.SendFileToPrinter(Impresora, String.Format("Comanda_{0}.txt", Impresora));
                        //break;
                //}
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
            }
        }
        void ConectarImpresora()
        {
        }
        void LiberarImpresora()
        {
        }
        void IFiscal.ImprimirReciboCobro(Pago caja)
        {
            if (caja == null)
                return;
            try
            {
                int Lineas = 1;
                LPrintWriter l = new LPrintWriter();
                l.WriteLine(OK.SystemParameters.Empresa);
                l.WriteLine("");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine(string.Format("RECIBO DE COBRO:{0}", caja.Numero).PadLeft(35, ' '));
                l.WriteLine("========================================");
                l.WriteLine(" ");
                l.WriteLine("HEMOS RECIBIDO DE :");
                l.WriteLine(String.Format("{0}", caja.Documento.CedulaRif));
                l.WriteLine(String.Format("{0}", caja.Documento.RazonSocial));
                l.WriteLine(String.Format("{0}", caja.Documento.Direccion));
                l.WriteLine(" ");
                l.WriteLine("LA CANTIDAD  DE :" + caja.MontoPagado.Value.ToString("n2"));
                l.WriteLine(string.Format("({0})", HK.Utilitatios.Numalet.ToCardinal(caja.MontoPagado.Value)));
                l.WriteLine(" ");
                l.WriteLine("POR CONCETO DE :\n" + caja.Concepto);
                l.WriteLine(" ");
                l.WriteLine(" ");
                l.WriteLine(" ");
                l.WriteLine(" ");
                l.WriteLine(" ");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine("               Recibo Conforme");
                for (Lineas = 0; Lineas < 12; Lineas++)
                    l.WriteLine(".");
                l.WriteLine(".");
                l.Flush();
            }
            catch (Exception ex)
            {
                Basicas.ManejarError(ex);
            }
        }
        void ReporteMensualIVA(int mes, int ano)
        {

        }
        void ImprimirListado(List<Factura> Lista)
        {
            if (Lista.Count < 1)
                return;
            try
            {
                int Lineas = 1;
                double Total = 0;
                LPrintWriter l = new LPrintWriter();
                l.WriteLine(OK.SystemParameters.Empresa);
                l.WriteLine("");
                l.WriteLine(" ");
                l.WriteLine("========================================");
                l.WriteLine(string.Format("LISTADO DE FACTURAS:{0}", Lista.ElementAt(0).Fecha.ToShortDateString()).PadLeft(35, ' '));
                l.WriteLine("========================================");
                l.WriteLine(" ");
                foreach (var item in Lista)
                {
                    l.WriteLine(string.Format("{0} :{1}", item.Numero, item.MontoTotal.Value.ToString("N2").PadLeft(10)));
                    Total += item.MontoTotal.GetValueOrDefault(0);
                }
                l.WriteLine("========================================");
                l.WriteLine(string.Format("T O T A L =>{0}", Total.ToString("N2").PadLeft(10)));
                l.WriteLine(" ");
                l.WriteLine(" ");
                l.WriteLine(" ");
                for (Lineas = 0; Lineas < 12; Lineas++)
                    l.WriteLine(".");
                l.WriteLine(".");
                l.Flush();
            }
            catch (Exception ex)
            {
                Basicas.ManejarError(ex);
            }
        }
        void ImprimeCierre(CierreCaja cierre, CierreCaja original, List<MesasCerrada> facturas, List<MesasCerrada> cerradas)
        {
          //   throw new NotImplementedException();
        }
        void IFiscal.ImprimeComanda(MesasAbierta documento, List<MesasAbiertasProducto> items)
        {
          //  throw new NotImplementedException();
        }
        void IFiscal.ImprimeNotaCredito(NotaDeCredito documento, Pago pago)
        {
            throw new NotImplementedException();
        }
        void IFiscal.ImprimeVale(Vale documento)
        {
            //throw new NotImplementedException();
        }
        string IFiscal.NumeroRegistro
        {
            get
            {
                return ""; //   throw new NotImplementedException();
            }
            set
            {
              //  throw new NotImplementedException();
            }
        }
        void Dispose()
        {
            //
        }
        public void ImprimeFactura(Factura documento,Pago Pago)
        {
           // throw new NotImplementedException();
        }
        void IDisposable.Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
