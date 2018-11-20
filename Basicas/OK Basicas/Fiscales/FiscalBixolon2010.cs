using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using HK;
using HK.BussinessLogic;
using TfhkaNet.IF.VE;
using TfhkaNet.IF;

namespace HK.Fiscales
{
    public class FiscalBixolon2010 : IFiscal, IDisposable
    {
        #region campos
        public static DateTime Fecha;
        public static double? MontoPorPagar = 0;
        public static double? SubTotalBases = 0;
        public static double? SubTotalIva = 0;
        public string RIF;
        public  int? ultimoZ = null;
        #endregion
        public  bool bRet;
        public  int? iError = 0;
        public  int? iStatus = 0;
        private double? montoZ = 0;
        private string NumeroFactura;
        private string Puerto;
        private string ultimaDevolucion;
        Tfhka fiscal;
        public FiscalBixolon2010(string puerto)
        {
            fiscal = new Tfhka();
            Puerto = puerto;
            DetectarImpresora();
        }
        ~FiscalBixolon2010()
        {
            fiscal.CloseFpCtrl();
            fiscal = null;
            Dispose();
        }
        public void CerrarPuerto()
        {
            fiscal.CloseFpCtrl();
        }
        public double? MontoZ 
            {
                get
                {
                    CargarS1(true);
                    return montoZ;
                }
            }
        public string NumeroRegistro
            { set; get;}       
        private void DetectarImpresora()
        {
            try
            {
                bool test1 = fiscal.CheckFPrinter();
                if (fiscal.OpenFpCtrl(Puerto))
                {
                    if (!fiscal.ReadFpStatus())
                    {
                        throw (new Exception(string.Format("Error de conexión, Estatus {0} verifique el puerto por favor...", fiscal.Status_Error)));
                    }
                }
                else
                {
                    var texto = fiscal.ComPort;
                    bool test = fiscal.CheckFPrinter();
                    var x = fiscal.Estado;
                    throw (new Exception(string.Format("Error al abrir el puerto {0}", Puerto)));
                }
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
        }
        private void CargarS1(bool conectar)
        {
            try
            {
                S1PrinterData data =  fiscal.GetS1PrinterData();
                NumeroFactura = data.LastInvoiceNumber.ToString("00000000");
                montoZ = data.TotalDailySales;
                ultimoZ = data.DailyClosureCounter+1;
                NumeroRegistro = data.RegisteredMachineNumber;
                RIF = data.RIF;
                Fecha = data.CurrentPrinterDateTime.Date;
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        private void CargarS2()
        {
            try
            {
                S2PrinterData data = fiscal.GetS2PrinterData();
                SubTotalBases = data.SubTotalBases;
                SubTotalIva = data.SubTotalTax;
                MontoPorPagar = data.AmountPayable;
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        private void ImprimeComentarios(string s)
        {
            try
            {
                if (s.Length <= 40 && s.Length > 0)
                   fiscal.SendCmd("@"+s);
                if (s.Length > 40)
                {
                    fiscal.SendCmd("@" + s.Substring(0, 40));
                    fiscal.SendCmd("@" + s.Substring(40, s.Length - 40));
                }
                if (s.Length > 80)
                {
                    fiscal.SendCmd("@" + s.Substring(80, s.Length - 80));
                }
                if (s.Length > 120)
                {
                    fiscal.SendCmd("@" + s.Substring(120, s.Length - 120));
                }
                if (s.Length > 160)
                {
                    fiscal.SendCmd("@" + s.Substring(160, s.Length - 160));
                }
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        private string MostrarStatus(int status)
        {
            switch (fiscal.Estado)
            {
                case "0":
                    return "Status Desconocido ";
                case "1":
                    return "En Modo Prueba y en Espera ";
                case "2":
                    return "Modo Prueba y EmisiÃ³n de Documentos Fiscales ";
                case "3":
                    return "Modo Prueba y EmisiÃ³n de Documentos No Fiscales ";
                case "4":
                    return "Fiscal y en Espera ";
                case "5":
                    return "Modo Fiscal y EmisiÃ³n de Documentos Fiscales ";
                case "6":
                    return "Fiscal y EmisiÃ³n de Documentos No Fiscales ";
                case "7":
                    return "Modo Fiscal y Cercana Carga Completa De La Memoria Fiscal Y en Espera ";
                case "8":
                    return "En Modo Fiscal y Cercana Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos Fiscales ";
                case "9":
                    return "En Modo Fiscal y Cercana Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos No Fiscales ";
                case "10":
                    return "En Modo Fiscal y Carga Completa De La Memoria Fiscal Y en Espera ";
                case "11":
                    return "En Modo Fiscal y Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos Fiscales ";
                case "12":
                    return "En Modo Fiscal y Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos No Fiscales ";
                default:
                    return null;
            }
        }
        private string MostrarError(int error)
        {
            switch (fiscal.Status_Error)
            {
                case "0":
                    return "No hay Error  VALIDO ";
                case "1":
                    return "Fin en la Entrega de papel  VALIDO ";
                case "2":
                    return "Error de Ã­ndole MecÃ¡nico en la entrega de Papel   VALIDO ";
                case "3":
                    return "Fin en la Entrega de papel y Error MecÃ¡nico  VALIDO ";
                case "4":
                    return "Comando Invalido / Valor Invalido  INVALIDO ";
                case "5":
                    return "Tasa Invalida  INVALIDO ";
                case "6":
                    return "No hay Asignadas Directivas   INVALIDO ";
                case "7":
                    return "Comando Invalido  INVALIDO ";
                case "8":
                    return "Error Fiscal  INVALIDO ";
                case "9":
                    return "Error de la Memoria Fiscal  INVALIDO ";
                case "10":
                    return "Memoria Fiscal llena  INVALIDO ";
                case "11":
                    return "Buffer Completo   INVALIDO ";
                case "12":
                    return "Error en la ComunicaciÃ³n   INVALIDO ";
                case "13":
                    return "No Hay Respuesta   INVALIDO ";
                case "14":
                    return "Error LRC   INVALIDO ";
                case "145":
                    return "Error Interno  API  INVALIDO ";
                case "153":
                    return "Error  en la Apertura del Archivo  INVALIDO ";
                default:
                    return null;
            }
        }
        public void ImprimeFactura(Factura documento, Pago pago)
        {
                try
                {
                    if (documento == null)
                    {
                        throw new Exception("Documento en blanco no se puede imprimir");
                    }
                    if (documento.MontoTotal <= 0)
                    {
                        throw new Exception("Esta factura no tiene productos");
                    }
                    if (fiscal.Estado != "OK")
                    {
                        throw new Exception(string.Format("Error en impresora Fiscal Error {0}, Estado {1} ", fiscal.Status_Error,fiscal.StatusPort));
                    }
                    double SubTotal = 0;
                    double MontoIva = 0;
                    System.Threading.Thread.Sleep(500);
                    fiscal.SendCmd("i01Cedula/Rif:" + documento.CedulaRif);
                    fiscal.SendCmd("i02Razon Social:");
                    if (documento.RazonSocial.Length <= 37)
                    {
                        fiscal.SendCmd("i03" + Basicas.PrintFix(documento.RazonSocial, 37, 1));
                    }
                    else
                    {
                        fiscal.SendCmd("i03" + documento.RazonSocial.Substring(0, 36));
                        fiscal.SendCmd("i04" + documento.RazonSocial.Substring(36, (documento.RazonSocial.Length - 36)));
                    }
                    if (documento.CedulaRif == "V000000000")
                    {
                        fiscal.SendCmd("i04 SIN DERECHO A CREDITO FISCAL");
                    }
                    if (documento.Direccion != null)
                    {
                        if (documento.Direccion.Length > 40)
                        {
                            fiscal.SendCmd("i05" + documento.Direccion);
                            fiscal.SendCmd("i06" + documento.Direccion.Substring(40, documento.Direccion.Length - 40));
                        }
                        else
                        {
                            fiscal.SendCmd("i06" + documento.Direccion);
                        }

                    }
                    if (!string.IsNullOrEmpty(documento.NumeroOrden))
                    {
                        fiscal.SendCmd(string.Format("i07       MESA:{0}", documento.NumeroOrden));
                    }
                    if (!string.IsNullOrEmpty(documento.Vendedor))
                    {
                        fiscal.SendCmd(string.Format( "i07VENDEDOR:{0}", documento.Vendedor));
                    }
                    if (!string.IsNullOrEmpty(documento.Comentarios))
                    {
                       fiscal.SendCmd(string.Format("i07COMENTARIOS:{0}", documento.Comentarios));
                    }
                    var Acumulado = from p in documento.DocumentosProductos.Where(x => x.Cantidad.GetValueOrDefault(0) >= 0.5)
                                    group p by new { p.Descripcion, p.TasaIva, p.Precio, p.PrecioConIva }
                                        into itemResumido
                                        select new
                                        {
                                            Descripcion = itemResumido.Key.Descripcion,
                                            TasaIva = itemResumido.Key.TasaIva,
                                            Cantidad = itemResumido.Sum(x => x.Cantidad),
                                            Precio = itemResumido.Key.Precio,
                                            PrecioConIva = itemResumido.Key.PrecioConIva
                                        };
                    System.Threading.Thread.Sleep(500);
                    foreach (var d in Acumulado.Where(x=>x.Cantidad.GetValueOrDefault()>0 && x.Precio.GetValueOrDefault()>0))
                    {
                        var sCmd = "!";
                        if (d.TasaIva == 0)
                        {
                            sCmd = " ";
                        }
                        else if (d.TasaIva == OK.SystemParameters.TasaIva)
                        {
                            sCmd = "!";
                        }
                        else if (d.TasaIva == OK.SystemParameters.TasaIvaB)
                        {
                            sCmd = '"'.ToString();
                        }
                        else if (d.TasaIva == OK.SystemParameters.TasaIvaC)
                        {
                            sCmd = '#'.ToString();
                        }
                    SubTotal = ((double)d.Cantidad.GetValueOrDefault(0) * (double)d.PrecioConIva.GetValueOrDefault(0));
                        MontoIva += ((double)d.Cantidad.GetValueOrDefault(0) * ((double)d.PrecioConIva.GetValueOrDefault(0)) - (double)d.Precio.GetValueOrDefault(0));
                        string Precio = "0000000000";
                        if (OK.SystemParameters.TipoIva == "INCLUIDO")
                        {
                            Precio = (d.PrecioConIva.GetValueOrDefault(0) * 100).ToString("0000000000");
                        }
                        else
                        {
                            Precio = (d.Precio.GetValueOrDefault(0) * 100).ToString("0000000000");
                        }
                        string Cantidad = (d.Cantidad.GetValueOrDefault(0) * 1000).ToString("00000000");
                        string Descripcion = d.Descripcion.PadRight(37);
                        if (d.Descripcion.Length <= 37)
                        {
                            bRet = fiscal.SendCmd( sCmd + Precio + Cantidad + d.Descripcion);
                            if (!bRet)
                            {
                                TfhkaNet.IF.PrinterStatus e = fiscal.GetPrinterStatus();
                                OK.ManejarException(new Exception( string.Format("Estatus:{0},Error:{1}",e.PrinterStatusDescription,e.PrinterErrorDescription)));
                            }
                        }
                        else
                        {
                            bRet = fiscal.SendCmd( sCmd + Precio + Cantidad + Descripcion.Substring(0, 36));
                            string Descripcion2 = d.Descripcion.Substring(36, (d.Descripcion.Length - 36));
                            bRet = fiscal.SendCmd( "@" + Descripcion2);
                            if (!bRet)
                            {
                                TfhkaNet.IF.PrinterStatus e = fiscal.GetPrinterStatus();
                                OK.ManejarException(new Exception( string.Format("Estatus:{0},Error:{1}",e.PrinterStatusDescription,e.PrinterErrorDescription)));
                            }
                        }
                    }
                    //if (documento.DescuentoBs.GetValueOrDefault(0) != 0)
                    //{

                    //    documento.DescuentoBs = documento.MontoTotal.GetValueOrDefault(0) - SubTotal - MontoIva;
                    //    documento.DescuentoBs = documento.DescuentoBs.GetValueOrDefault(0) * -1;
                    //    documento.DescuentoPorcentaje = (documento.DescuentoBs.GetValueOrDefault(0) * 100) / (SubTotal + MontoIva);
                    //    bRet = fiscal.SendCmd( "3");
                    //    string DescuentoPorcentaje = (documento.DescuentoPorcentaje.GetValueOrDefault(0) * 100).ToString("0000");
                    //    bRet = fiscal.SendCmd( "p-" + DescuentoPorcentaje);
                    //}
                    //Pagos
                    // CargarS2();         

                    //if (documento.MontoServicio.GetValueOrDefault(0) > 0)
                    //{
                    //    sCmd =  " ";
                    //    string Precio = (documento.MontoServicio.GetValueOrDefault(0) * 100).ToString("0000000000");
                    //    bRet = fiscal.SendCmd( sCmd + Precio + "00001000" + "SERVICIO 10%");
                    //}
                    System.Threading.Thread.Sleep(500);
                    double TotalPagos = 0;
                    if (pago == null)
                    {
                        pago = new Pago();
                        pago.Efectivo = documento.MontoTotal.GetValueOrDefault();
                    }
                    if (pago.Efectivo.GetValueOrDefault(0) != 0)
                    {
                        double x = pago.Efectivo.GetValueOrDefault(0) + pago.Cambio.GetValueOrDefault(0);
                        fiscal.SendCmd( "201" + (x * 100).ToString("000000000000"));
                        TotalPagos += pago.Efectivo.Value;
                    }
                    if (pago.CestaTicket.GetValueOrDefault(0) != 0)
                    {
                        fiscal.SendCmd( "202" + ((double)pago.CestaTicket * 100).ToString("000000000000"));
                        TotalPagos += pago.CestaTicket.Value;
                    }
                    //
                    if (pago.Cheque.GetValueOrDefault(0) != 0)
                    {
                        fiscal.SendCmd( "205" + ((double)pago.Cheque * 100).ToString("000000000000"));
                        TotalPagos += pago.Cheque.Value;
                    }
                    if (pago.TarjetaCredito.GetValueOrDefault(0) != 0)
                    {
                        fiscal.SendCmd( "209" + ((double)pago.TarjetaCredito * 100).ToString("000000000000"));
                        TotalPagos += pago.TarjetaCredito.Value;
                    }
                    if (pago.TarjetaDebito.GetValueOrDefault(0) != 0)
                    {
                        fiscal.SendCmd("210" + ((double)pago.TarjetaDebito * 100).ToString("000000000000"));
                        TotalPagos += pago.TarjetaDebito.Value;
                    }
                    if (pago.Credito.GetValueOrDefault(0) != 0)
                    {
                        fiscal.SendCmd( "216" + ((double)pago.Credito * 100).ToString("000000000000"));
                        TotalPagos += pago.Credito.Value;
                    }
                    System.Threading.Thread.Sleep(1000);
                    CargarS2();
                    if (MontoPorPagar > 0)
                    {
                        fiscal.SendCmd( "115" + (MontoPorPagar.Value * 100).ToString("000000000000"));
                    }
                    System.Threading.Thread.Sleep(1000);
                    CargarS1(false);
                    documento.Fecha = Fecha;
                    documento.Hora = DateTime.Now;
                    documento.Numero = NumeroFactura;
                 //   documento.MontoGravable = SubTotalBases;
                 //   documento.MontoIva = MontoIva;
                 //   documento.MontoTotal = SubTotalBases + MontoIva;
                    documento.NumeroZ  = (ultimoZ.Value).ToString("0000");
                    documento.MaquinaFiscal = NumeroRegistro;
                }
                catch (TfhkaNet.IF.PrinterException x)
                {
                    throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

                }
                catch (Exception x)
                {
                    throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
                }
        }
        public void ImprimeNotaCredito(NotaDeCredito documento, Pago pago)
        {
            if (documento == null)
            {
                throw new Exception("Documento en blanco no se puede imprimir");
            }
            unsafe
            {
                try
                {
                    string sCmd;
                    bool bRet = false;
                    System.Threading.Thread.Sleep(500);
                    fiscal.SendCmd("i01Cedula/Rif:" + documento.CedulaRif);
                    fiscal.SendCmd("i02Razon Social:");
                    fiscal.SendCmd("i03" + documento.RazonSocial);
                    fiscal.SendCmd("i04Direccion:");
                    if (documento.Direccion != null)
                    {
                        if (documento.Direccion.Length > 40)
                        {
                            fiscal.SendCmd("i05" + documento.Direccion);
                            fiscal.SendCmd("i06" + documento.Direccion.Substring(40, documento.Direccion.Length - 40));
                        }
                        else
                        {
                            fiscal.SendCmd("i06" + documento.Direccion);
                        }

                    }
                    fiscal.SendCmd("i07 # FACTURA AFECTADA:" + documento.DocumentoAfectado);
                    // Agrego el servicio en la ultima fila
                    // DS.ImpresionTicket.AddImpresionTicketRow(1, 1, 1, 1, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 1, "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "SERVICIO 10%", 1, documento[0].MontoServicio, 0, "", "", "");
                    double SubTotal = 0;
                    double MontoIva = 0;
                    System.Threading.Thread.Sleep(500);
                    foreach (DocumentosProducto d in documento.DocumentosProductos.ToList())
                    {
                        sCmd = "d1";
                        if (d.TasaIva == 0)
                        {
                            sCmd = "d0";
                        }
                        else if (d.TasaIva == OK.SystemParameters.TasaIva)
                        {
                            sCmd = "d1";
                        }
                        else if (d.TasaIva == OK.SystemParameters.TasaIvaB)
                        {
                            sCmd = "d2";
                        }
                        else if (d.TasaIva == OK.SystemParameters.TasaIvaC)
                        {
                            sCmd = "d3";
                        }
                        SubTotal += ((double)d.Cantidad.GetValueOrDefault(0) * (double)d.Precio.GetValueOrDefault(0));
                        MontoIva += ((double)d.Cantidad.GetValueOrDefault(0) * ((double)d.PrecioConIva.GetValueOrDefault(0)) - (double)d.Precio.GetValueOrDefault(0));
                        string Precio = "0000000000";
                        if (OK.SystemParameters.TipoIva == "INCLUIDO")
                        {
                            Precio = (d.PrecioConIva.GetValueOrDefault(0) * 100).ToString("0000000000");
                        }
                        else
                        {
                            Precio = (d.Precio.GetValueOrDefault(0) * 100).ToString("0000000000");
                        }
                        string Cantidad = (d.Cantidad.GetValueOrDefault(0) * 1000).ToString("00000000");
                        string Descripcion = d.Descripcion.PadRight(37);
                        if (d.Descripcion.Length <= 37)
                        {
                            bRet = fiscal.SendCmd(sCmd + Precio + Cantidad + d.Descripcion);
                            if (!bRet)
                            {
                                TfhkaNet.IF.PrinterStatus e = fiscal.GetPrinterStatus();
                                OK.ManejarException(new Exception(string.Format("Estatus:{0},Error:{1}", e.PrinterStatusDescription, e.PrinterErrorDescription)));
                            }
                        }
                        else
                        {
                            bRet = fiscal.SendCmd(sCmd + Precio + Cantidad + Descripcion.Substring(0, 36));
                            if (!bRet)
                            {
                                TfhkaNet.IF.PrinterStatus e = fiscal.GetPrinterStatus();
                                OK.ManejarException(new Exception(string.Format("Estatus:{0},Error:{1}", e.PrinterStatusDescription, e.PrinterErrorDescription)));
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(500);
                    //if (documento.DescuentoBs != 0)
                    //{

                    //    documento.DescuentoBs = documento.MontoTotal - SubTotal - MontoIva;
                    //    documento.DescuentoBs = documento.DescuentoBs * -1;
                    //    documento.DescuentoPorcentaje = (documento.DescuentoBs * 100) / (SubTotal + MontoIva);
                    //    bRet = fiscal.SendCmd( "3");
                    //    string DescuentoPorcentaje = ((double)documento.DescuentoPorcentaje * 100).ToString("0000");
                    //    bRet = fiscal.SendCmd( "p-" + DescuentoPorcentaje);
                    //}
                    //Pagos
                    double TotalPagos = 0;
                    //if (documento.MontoServicio.GetValueOrDefault(0) > 0)
                    //{
                    //    sCmd = "d0";
                    //    string Precio = (documento.MontoServicio.GetValueOrDefault(0) * 100).ToString("0000000000");
                    //    bRet = fiscal.SendCmd( sCmd + Precio + "00001000" + "SERVICIO 10%");
                    //}
                    // Pago pago = pago; // != null ? pagos : new Pago();
                    if (pago.Efectivo.GetValueOrDefault(0) != 0)
                    {
                        double x = pago.Efectivo.GetValueOrDefault(0) + pago.Cambio.GetValueOrDefault(0);
                        sCmd = "f01" + (x * 100).ToString("000000000000");
                        bRet = fiscal.SendCmd( sCmd);
                        TotalPagos += pago.Efectivo.Value;
                    }
                    if (pago.CestaTicket.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f02" + ((double)pago.CestaTicket * 100).ToString("000000000000");
                        bRet = fiscal.SendCmd( sCmd);
                        TotalPagos += pago.CestaTicket.Value;
                    }

                    if (pago.Cheque.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f05" + ((double)pago.Cheque * 100).ToString("000000000000");
                        bRet = fiscal.SendCmd( sCmd);
                        TotalPagos += pago.Cheque.Value;
                    }
                    if (pago.TarjetaCredito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f09" + ((double)pago.TarjetaCredito * 100).ToString("000000000000");
                        bRet = fiscal.SendCmd( sCmd);
                        TotalPagos += pago.TarjetaCredito.Value;
                    }
                    if (pago.TarjetaDebito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f10" + ((double)pago.TarjetaDebito * 100).ToString("000000000000");
                        bRet = fiscal.SendCmd( sCmd);
                        TotalPagos += pago.TarjetaDebito.Value;
                    }
                    if (documento.MontoTotal.GetValueOrDefault(0) > TotalPagos)
                    {
                        sCmd = "f16" + ((double)documento.MontoTotal - (double)TotalPagos * 100).ToString("000000000000");
                        bRet = fiscal.SendCmd( sCmd);

                    }
                    CargarX();
                    CargarS1(false); 
                    System.Threading.Thread.Sleep(500);
                    documento.NumeroZ = ultimoZ.Value.ToString("0000");
                    documento.MaquinaFiscal = NumeroRegistro;
                    documento.Numero = ultimaDevolucion;
                }
                catch (TfhkaNet.IF.PrinterException x)
                {
                    throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

                }
                catch (Exception x)
                {
                    throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
                }
            }
        }
        public void ImprimeFacturaCopia(Factura p)
        {
            bool bRet;

            unsafe
            {
                System.Threading.Thread.Sleep(1000);
                string Numero = p.Numero;
                string n = Numero.Substring(1, 7);
                bRet = fiscal.SendCmd( String.Format("RF{0}{0}", n));
                if (!bRet)
                {
                    throw new Exception("Esta impresora no puede imprimir ese resumen esa funcion es de la Bixolon 350 exclusivamente");
                }
                //return bRet;
            }
        }
        public void ReporteX()
        {
            string sCmd;
            bool bRet;
            try
            {
                //************ Imprimir Reporte X *******************
                sCmd = "I0X";
                bRet = fiscal.SendCmd( sCmd);
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void ReporteZ()
        {
            try
            {
                S1PrinterData d = fiscal.GetS1PrinterData();
                if (d.QuantityOfInvoicesToday < 1)
                {
                    throw new Exception("No hay facturas aún hoy");
                }
                ultimoZ = d.DailyClosureCounter + 2;
                //************ Imprimir Reporte Z *******************
                fiscal.SendCmd( "I0Z");
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void CargarX()
        {
            try
            {  
                ReportData x = fiscal.GetXReport();
                ultimaDevolucion = x.NumberOfLastCreditNote.ToString("00000000");
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        private double strToDouble(string p)
        {
            double Base = Convert.ToDouble(p.Substring(0, 10));
            double Decimales = Convert.ToDouble(p.Substring(10, 2));
            return Base + (Decimales / 100);
        }
        public void ReporteMensualIVA(DateTime dateTime, DateTime dateTime_2)
        {
            string sCmd;
            bool bRet;
            unsafe
            {
                //************ Imprimir Reporte Z *******************
                try
                {
                    System.Threading.Thread.Sleep(500);
                    string Inicio = dateTime.Day.ToString("00") + dateTime.Month.ToString("00") + dateTime.Year.ToString("00").Substring(2, 2);
                    string Final = dateTime_2.Day.ToString("00") + dateTime_2.Month.ToString("00") + dateTime_2.Year.ToString("00").Substring(2, 2);
                    sCmd = string.Format("I2M", Inicio, Final);
                    bRet = fiscal.SendCmd( sCmd);
                    if (bRet == false)
                    {
                        throw new Exception("Esta impresora no puede imprimir ese resumen esa funcion es de la Bixolon 350 exclusivamente");
                    }
                }
                catch (TfhkaNet.IF.PrinterException x)
                {
                    throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

                }
                catch (Exception x)
                {
                    throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
                }
            }
        }
        public bool IsOK()
        {
            if (iError == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void DocumentoNoFiscal(string[] Texto)
    {
            try
            {
                System.Threading.Thread.Sleep(500);
                foreach (string linea in Texto)
                {
                    bRet = fiscal.SendCmd( "800" + linea);
                }
                bRet = fiscal.SendCmd( "810");
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void ImprimeVale(Vale documento)
        {
            unsafe
            {
                try
                {
                    bRet = fiscal.SendCmd( string.Format("800 VALE DE CAJA:{0}", documento.Numero));
                    //bRet = fiscal.SendCmd( "800" + "CAJERO:"+ documento.Cajero);
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + "CEDULA:" + documento.Cedula);
                    bRet = fiscal.SendCmd( "800" + "NOMBRE:" + documento.Nombre);
                    bRet = fiscal.SendCmd( "800" + documento.Concepto);
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + string.Format("MONTO BS.:{0} ", documento.Monto.Value.ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + " ");
                    HK.Utilitatios.Numalet let = new HK.Utilitatios.Numalet();
                    bRet = fiscal.SendCmd( "800" + let.ToCustomCardinal((decimal)documento.Monto.Value));
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800 --------------------");
                    bRet = fiscal.SendCmd( "810         FIRMA       ");
                }
                catch (TfhkaNet.IF.PrinterException x)
                {
                    throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

                }
                catch (Exception x)
                {
                    throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
                }
            }
        }
        public void ImprimeCierre(CierreCaja cierre, CierreCaja calculo, List<MesasCerrada> cerradas)
        {
                try
                {
                    //ConectarImpresora();
                    bRet = fiscal.SendCmd( "800 CIERRE DE CAJA");
                    bRet = fiscal.SendCmd( "800" + string.Format("  EFECTIVO :{0}", cierre.Efectivo.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("    CHEQUE :{0}", cierre.Cheque.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("    BANESCO:{0}", cierre.Banesco.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  BANESCO 2:{0}", cierre.Banesco2.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  MERCANTIL:{0}", cierre.Mercantil.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  CORPBANCA:{0}", cierre.Corpbanca.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("   TARJETAS:{0}", cierre.Tarjetas.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("DEPOSI/TRAN:{0}", cierre.DepositosTransferencias.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("   CREDITOS:{0}", cierre.Creditos.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("      OTROS:{0}", cierre.Otros.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("     GASTOS:{0}", cierre.Gastos.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("      VALES:{0}", cierre.Vales.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("RETENCIONES:{0}", cierre.Retenciones.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  CRED.COBR:{0}", cierre.CreditosCobrados.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  T O T A L:{0}", cierre.TotalCaja.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format(" CRED.COBRA:{0}", cierre.CreditosCobrados.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format(" VENTA NETA:{0}", (cierre.TotalCaja.GetValueOrDefault(0) - cierre.CreditosCobrados.GetValueOrDefault(0)).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("   FACTURAS:{0}", calculo.CantidadFacturas.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800 ===============================================");
                    bRet = fiscal.SendCmd( "800 SISTEMA");
                    bRet = fiscal.SendCmd( "800" + string.Format(" EFECTIVO :{0}", calculo.Efectivo.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("   CHEQUE :{0}", calculo.Cheque.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  TARJETAS:{0}", calculo.Tarjetas.GetValueOrDefault(0).ToString("n2")));
                    // bRet = fiscal.SendCmd( "800" + string.Format(" TARJETAS:{0}", calculo.Tarjetas));
                    bRet = fiscal.SendCmd( "800" + string.Format(" DEPOS/TRA:{0}", calculo.DepositosTransferencias.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("  CREDITOS:{0}", calculo.Creditos.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("     VALES:{0}", calculo.Vales.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format(" T O T A L:{0}", calculo.TotalCaja.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("CRED.COBRA:{0}", calculo.CreditosCobrados.GetValueOrDefault(0).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + string.Format("VENTA NETA:{0}", (calculo.TotalCaja.GetValueOrDefault(0) - calculo.CreditosCobrados.GetValueOrDefault(0)).ToString("n2")));
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + "NUMERO       MONTO    Q     MESA");
                    foreach (var item in cerradas.Where(x => x.Factura != "INTERNO"))
                    {
                        bRet = fiscal.SendCmd( "800" + string.Format("{0} {1} {2} {3}", item.Factura, item.MontoTotal.Value.ToString("n2").PadLeft(10), item.NumeroImpresiones.Value.ToString("N0").PadLeft(03), item.CodigoMesa.PadLeft(10)));
                    }
                    bRet = fiscal.SendCmd( "800" + " ");
                    bRet = fiscal.SendCmd( "800" + " MONTO    Q     MESA");
                    foreach (var item in cerradas.Where(x => x.Factura == "INTERNO"))
                    {
                        bRet = fiscal.SendCmd( "800" + string.Format("{0} {1} {2}", item.MontoTotal.Value.ToString("n2").PadLeft(10), item.NumeroImpresiones.Value.ToString("N0").PadLeft(03), item.CodigoMesa.PadLeft(10)));
                    }

                    bRet = fiscal.SendCmd( "810  FIN.");
                    //DesconectarImpresora();
                }
                catch (TfhkaNet.IF.PrinterException x)
                {
                    throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

                }
                catch (Exception x)
                {
                     bRet = fiscal.SendCmd( "810  ERROR.");
                    throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
                }
        }
        public void ImprimeOrden(Factura documento)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                bRet = fiscal.SendCmd( string.Format("800 CLIENTE:{0}\n", documento.RazonSocial));
                bRet = fiscal.SendCmd( "800" + "      COMANDA    ");
                bRet = fiscal.SendCmd( String.Format("800{0} {1}", documento.Tipo, documento.NumeroOrden));
                foreach (var item in documento.DocumentosProductos)
                {
                    if (item.Cantidad.GetValueOrDefault(0) > 1)
                    {
                        bRet = fiscal.SendCmd( "800" + string.Format(" X {0}", item.Cantidad.Value.ToString("N0")));
                    }
                    bRet = fiscal.SendCmd( "800" + item.Descripcion);
                    if (item.Comentario != null)
                    {
                        bRet = fiscal.SendCmd( "800" + item.Comentario);

                    }
                }
                bRet = fiscal.SendCmd( "810  ==========");
                // bRet = fiscal.SendCmd( "800 USTED SERA LLAMADO POR EL NUMERO=>" + documento.Numero.Substring(5,3));
                System.Threading.Thread.Sleep(500);
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                bRet = fiscal.SendCmd("810  ERROR.");
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void ImprimeCorte(MesasAbierta documento)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                bRet = fiscal.SendCmd( "800" + "   NOTA DE CONSUMO    ");
                bRet = fiscal.SendCmd( String.Format("800ATENDIDO POR:{0}", documento.Mesonero));
                bRet = fiscal.SendCmd( "800" + "MESA:" + documento.CodigoMesa);
                bRet = fiscal.SendCmd( String.Format("800   Q:{0}", documento.NumeroImpresiones.GetValueOrDefault(0)));
                if (!string.IsNullOrEmpty(documento.CedulaRif))
                {
                    bRet = fiscal.SendCmd( String.Format("800CEDULA/RIF:{0}", documento.CedulaRif));
                }
                if (!string.IsNullOrEmpty(documento.RazonSocial))
                {
                    bRet = fiscal.SendCmd( "800" + "RAZON SOCIAL:" + documento.RazonSocial);
                }
                bRet = fiscal.SendCmd( "800" + "CANT  DESCRIPCION                    MONTO" + documento.Mesonero);
                bRet = fiscal.SendCmd( "800" + "==========================================");
                foreach (var item in documento.MesasAbiertasProductos.Where(x => x.Anulado != true))
                {
                    bRet = fiscal.SendCmd( string.Format("800" + "{0} {1} {2}", item.Cantidad.Value.ToString("n2").PadLeft(5), item.Descripcion.PadRight(25).Substring(0, 25), (item.Precio.GetValueOrDefault(0) * item.Cantidad.GetValueOrDefault(0)).ToString("n2").PadLeft(8)));
                }
                double Total = documento.MontoTotal.GetValueOrDefault(0);
                bRet = fiscal.SendCmd( "800" + "==========================================");
                bRet = fiscal.SendCmd( "800" + string.Format("   SUB TOTAL:{0}".PadLeft(33), (documento.MontoGravable.GetValueOrDefault(0)).ToString("N2").PadLeft(8)));
                bRet = fiscal.SendCmd( "800" + string.Format("SERVICIO 10%:{0}".PadLeft(33), (documento.MontoServicio.GetValueOrDefault(0)).ToString("N2").PadLeft(8)));
                bRet = fiscal.SendCmd( "800" + string.Format("   MONTO IVA:{0}".PadLeft(33), (documento.MontoIva.GetValueOrDefault(0)).ToString("N2").PadLeft(8)));
                bRet = fiscal.SendCmd( "800" + string.Format(" MONTO TOTAL:{0}".PadLeft(33), (Total).ToString("N2").PadLeft(8)));
                bRet = fiscal.SendCmd( "800" + "==========================================");
                bRet = fiscal.SendCmd( "800" + "Por favor escriba sus datos:");
                bRet = fiscal.SendCmd( "800" + "Cedula / Rif.:____________________________");
                bRet = fiscal.SendCmd( "800" + "Nombre / Razon Social:");
                bRet = fiscal.SendCmd( "800" + "__________________________________________");
                bRet = fiscal.SendCmd( "800" + "Direccion:");
                bRet = fiscal.SendCmd( "810" + "__________________________________________");

            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                bRet = fiscal.SendCmd("810  ERROR.");
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void ImprimeCorteSinMontos(MesasAbierta documento)
        {
            try
            {
                System.Threading.Thread.Sleep(500);
                bRet = fiscal.SendCmd("800" + "   PLATOS CONSUMIDOS    ");
                bRet = fiscal.SendCmd(String.Format("800ATENDIDO POR:{0}", documento.Mesonero));
                bRet = fiscal.SendCmd("800" + "MESA:" + documento.CodigoMesa);
                bRet = fiscal.SendCmd(String.Format("800 Q:{0}", documento.NumeroImpresiones.GetValueOrDefault(0)));
                if (!string.IsNullOrEmpty(documento.CedulaRif))
                {
                    bRet = fiscal.SendCmd("800" + "CEDULA/RIF:" + documento.CedulaRif);
                }
                if (!string.IsNullOrEmpty(documento.RazonSocial))
                {
                    bRet = fiscal.SendCmd("800" + "RAZON SOCIAL:" + documento.RazonSocial);
                }
                bRet = fiscal.SendCmd("800" + ":" + documento.NumeroImpresiones.GetValueOrDefault(0));
                bRet = fiscal.SendCmd("800" + "CANT  DESCRIPCION               " + documento.Mesonero);
                bRet = fiscal.SendCmd("800" + "======================================");
                var resumido = from x in documento.MesasAbiertasProductos
                               where x.Anulado != true && x.Departamento != "COMENTARIOS" && x.Precio.GetValueOrDefault() > 0 && x.Cantidad.GetValueOrDefault() > 0
                               group x by x.Descripcion;
                foreach (var item in resumido)
                {
                    bRet = fiscal.SendCmd(string.Format("800" + "{0} {1}",
                        item.Sum(c => c.Cantidad).Value.ToString("n2").PadLeft(5), item.Key.PadRight(22).Substring(0, 22)));
                }
                //double Total = documento.MontoTotal.GetValueOrDefault(0);
                //bRet = fiscal.SendCmd( "800" + "======================================");
                //bRet = fiscal.SendCmd( "800" + string.Format("   SUB TOTAL:{0}".PadLeft(33), (Total * 0.9).ToString("N2").PadLeft(8)));
                //bRet = fiscal.SendCmd( "800" + string.Format("SERVICIO 10%:{0}".PadLeft(33), (Total * 0.1).ToString("N2").PadLeft(8)));
                //bRet = fiscal.SendCmd( "800" + string.Format(" MONTO TOTAL:{0}".PadLeft(33), (Total).ToString("N2").PadLeft(8)));
                bRet = fiscal.SendCmd("810" + "======================================");
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                bRet = fiscal.SendCmd("810  ERROR.");
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void ImprimeOrdenDespacho(Factura documento)
        {
            try
            {
                bRet = fiscal.SendCmd( "800" + "ORDEN DE DESPACHO");
                bRet = fiscal.SendCmd( "800" + "  ");
                bRet = fiscal.SendCmd( "800" + "   " + documento.Comentarios);
                bRet = fiscal.SendCmd( "800" + "  ");
                bRet = fiscal.SendCmd( "800" + string.Format(" TICKET:{0} ", documento.Numero));
                bRet = fiscal.SendCmd( "800" + string.Format("CLIENTE:{0} ", documento.RazonSocial));
                bRet = fiscal.SendCmd( "800" + string.Format("========================================"));
                foreach (var item in documento.DocumentosProductos.ToList())
                {
                    bRet = fiscal.SendCmd( "800" + string.Format(" {0}) {1} ", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25).Substring(0, 25)));
                    if (item.Comentario != null)
                    {
                        //foreach (string p in item.Comentario)
                        //{
                        bRet = fiscal.SendCmd( "800" + item.Comentario);
                        //}
                    }
                    // Pendiente
                    //if (item.Contornos != null)
                    //{
                    //    foreach (string p in item.Contornos)
                    //    {
                    //        bRet = fiscal.SendCmd( "800" + p);
                    //    }
                    //}
                }
                bRet = fiscal.SendCmd( "800" + "========================================");
                bRet = fiscal.SendCmd( "800" + documento.Comentarios);
                bRet = fiscal.SendCmd( "810" + "  ");
            }
            catch (TfhkaNet.IF.PrinterException x)
            {
                throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

            }
            catch (Exception x)
            {
                bRet = fiscal.SendCmd("810  ERROR.");
                throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
            }
        }
        public void ImprimeComanda(MesasAbierta documento, List<MesasAbiertasProducto> items)
        {
                try
                {
                    bRet = fiscal.SendCmd( "800" + "      COMANDA    ");
                    bRet = fiscal.SendCmd( "800" + "  ");
                    bRet = fiscal.SendCmd( "800" + string.Format("TICKET:{0} COMANDA:{1}", documento.Numero, Administrativo.GetContador("Comanda")));
                    bRet = fiscal.SendCmd( "800" + string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                    bRet = fiscal.SendCmd( "800" + string.Format("MESA:{0}", documento.CodigoMesa));
                    bRet = fiscal.SendCmd( "800" + string.Format("MESONERO:{0}", documento.Mesonero));
                    bRet = fiscal.SendCmd( "800" + "========================================");
                    foreach (var item in items)
                    {
                        bRet = fiscal.SendCmd( "800" + string.Format(" {0}) {1} ", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25).Substring(0, 25)));
                        if (item.Comentario != null)
                        {
                            //foreach (string p in item.Comentarios)
                            //{
                            bRet = fiscal.SendCmd( "800" + item.Comentario);
                            //}
                        }
                        //if (item.Contornos != null)
                        //{
                        //    foreach (string p in item.Contornos)
                        //    {
                        //        bRet = fiscal.SendCmd( "800" + p);
                        //    }
                        //}
                    }
                    bRet = fiscal.SendCmd( "800" + "========================================");
                    bRet = fiscal.SendCmd( "810" + "  ");
                }
                catch (TfhkaNet.IF.PrinterException x)
                {
                    throw new Exception(string.Format("Error de impresora: {0}, estatus {1}", x.Message, fiscal.Estado));

                }
                catch (Exception x)
                {
                    bRet = fiscal.SendCmd("810  ERROR.");
                    throw new Exception(string.Format("Error de conexión\n{0}\nEstatus {1}", x.Message, fiscal.Status_Error));
                }
        }
        public void ImprimirReciboCobro(Pago caja)
        {
            try
            {
                Administrativo data = new Administrativo();
                bRet = fiscal.SendCmd( string.Format("800 COMPROBANTE DE PAGO:{0}", caja.Numero));
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + caja.Concepto);
                bRet = fiscal.SendCmd( "800 FECHA:" + caja.Documento.Fecha);
                bRet = fiscal.SendCmd( "800 FACTURA:" + caja.Documento.Numero);
                bRet = fiscal.SendCmd( "800 CED.RIF:" + caja.Documento.CedulaRif);
                bRet = fiscal.SendCmd( "800 CLIENTE:" + caja.Documento.RazonSocial);
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + string.Format("MONTO BS.:{0} ", caja.MontoPagado.Value.ToString("n2")));
                bRet = fiscal.SendCmd( "800" + " ");
                HK.Utilitatios.Numalet let = new HK.Utilitatios.Numalet();
                bRet = fiscal.SendCmd( "800" + let.ToCustomCardinal((decimal)caja.MontoPagado.Value));
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800" + " ");
                bRet = fiscal.SendCmd( "800 --------------------");
                bRet = fiscal.SendCmd( "810         FIRMA       ");
            }
            catch (Exception x)
            {
                bRet = fiscal.SendCmd( "810  ERROR");
                throw x;
            }
        }
        public int UltimoZ()
        {
            if (ultimoZ == null)
            {
                CargarS1(true);
            }
            return ultimoZ.GetValueOrDefault(0);
        }
        internal void ImprimirListado()
        {
            return;
        }
        internal void ImprimeCierre(CierreCaja cierre, List<MesasCerrada> facturas, List<MesasCerrada> cerradas)
        {
            return;
        }
        public void Dispose()
        {
          //  DesconectarImpresora();
        }
    }
}
