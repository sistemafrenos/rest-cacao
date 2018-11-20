using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Linq;
using HK;
using HK.BussinessLogic;

namespace HK.Fiscales
{
    public class FiscalBixolon : IFiscal, IDisposable
    {
        #region campos
        public static DateTime Fecha;
        public static double? MontoPorPagar = 0;
        public static double? SubTotalBases = 0;
        public static double? SubTotalIva = 0;
        #endregion
        public  int? ultimoZ = null;
        public  bool bRet;
        public  int? iError = 0;
        public  int? iStatus = 0;
        private  double? montoZ = 0;
        private   string NumeroFactura;
        private  string Puerto;
        private string ultimaDevolucion = "00";
        //    FrmInformacion AuditMensaje = new FrmInformacion();
        #region Delaraciones
        //declaracion de funciones de la DLL
        [DllImport("tfhkaif.dll")]
        public static extern bool OpenFpctrl(string lpPortName);

        [DllImport("tfhkaif.dll")]
        public static extern bool CloseFpctrl();

        [DllImport("tfhkaif.dll")]
        public static extern bool CheckFprinter();

        [DllImport("tfhkaif.dll")]
        public unsafe static extern bool ReadFpStatus(int* status, int* error);

        [DllImport("tfhkaif.dll")]
        public unsafe static extern bool SendCmd(int* status, int* error, string cmd);

        [DllImport("tfhkaif.dll")]
        public static extern int SendNcmd(int status, int error, string buffer);

        [DllImport("tfhkaif.dll")]
        public unsafe static extern int SendFileCmd(int* status, int* error, string file);

        [DllImport("tfhkaif.dll")]
        public unsafe static extern bool UploadStatusCmd(int* status, int* error, string cmd, string file);

        // Variables para monitorear retorno de funciones de la dll

        #endregion
        public FiscalBixolon(string puerto)
        {
            Puerto = puerto;
            DetectarImpresora();
        }
        ~FiscalBixolon()
        {
            Dispose();
        }
        public void CerrarPuerto()
        {
            CloseFpctrl();
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
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    throw new Exception("Error al detectar la impresora", x);
                }
            }
        }
        private void ConectarImpresora()
        {
            int error = 0;
            int status = 0;
            if (!OpenFpctrl(Puerto))
            {
                throw (new Exception("Error de conexiÃ³n, verifique el puerto por favor..."));
            }
            unsafe
            {
                if (!ReadFpStatus(&status, &error))
                {
                    throw (new Exception("Error al leer el estado de la impresora favor revisar conexion..."));
                }
                if (error != 0)
                {
                    throw new Exception(MostrarError(error) + " " + MostrarStatus(status));
                }
            }
        }
        private void DesconectarImpresora()
        {
            if (!CloseFpctrl())
                throw new Exception("Error al Liberar la impresora");
        }
        private void CargarS1(bool conectar)
        {
            try
            {
                if (conectar)
                {
                    ConectarImpresora();
                }
                unsafe
                {
                    int error;
                    int status;
                    iError = error = 0;
                    iStatus = status = 0;
                    //if (!OpenFpctrl(OK.Parametros.PuertoImpresoraFiscal))
                    //    return;
                    if (!UploadStatusCmd(&status, &error, "S1", "StatusS1.TXT"))
                    {
                        return;
                        //  throw new Exception("Imposible leer datos desde Impresora Fiscal");
                    }
                    using (StreamReader sr = new StreamReader("StatusS1.TXT"))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            NumeroFactura = line.Substring(21, 8);
                            montoZ = (Convert.ToDouble(line.Substring(4, 17))) / 100;
                            ultimoZ = Convert.ToInt16(line.Substring(47, 4));
                            //NumeroRegistro = line.Substring(66, 10);
                            Fecha = Convert.ToDateTime(String.Format("{0}/{1}/{2}", line.Substring(82, 2), line.Substring(84, 2), line.Substring(86, 2)));
                            ultimoZ++;

                        }
                    }
                }
                if (conectar)
                {
                    DesconectarImpresora();
                }
            }
            catch (Exception e)
            {
                OK.ManejarException(e);
              //  throw new Exception("Imposible leer datos desde Impresora Fiscal\n" + e.Message);
            }
        }
        private void CargarS2()
        {
            int error = 0;
            int status = 0;
            try
            {
                unsafe
                {
                    iError = error;
                    iStatus = status;
                    if (!UploadStatusCmd(&status, &error, "S2", "StatusS2.TXT"))
                    {
                        throw new Exception("Imposible leer datos desde Impresora Fiscal");
                    }
                    using (StreamReader sr = new StreamReader("StatusS2.TXT"))
                    {
                        String line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            SubTotalBases = strToDouble(line.Substring(4, 13));
                            SubTotalIva = strToDouble(line.Substring(18, 13));
                            MontoPorPagar = strToDouble(line.Substring(52, 13));

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Imposible leer datos desde Impresora Fiscal\n" + e.Message);
            }
            return;
        }
        private void ImprimeComentarios(string s)
        {
            int error = 0;
            int status = 0;
            bool bRet;
            unsafe
            {
                if (s.Length <= 40 && s.Length > 0)
                    bRet = SendCmd(&status, &error, "@" + s);
                if (s.Length > 40)
                {
                    bRet = SendCmd(&status, &error, "@" + s.Substring(0, 40));
                    bRet = SendCmd(&status, &error, "@" + s.Substring(40, s.Length - 40));
                }
                if (s.Length > 80)
                {
                    bRet = SendCmd(&status, &error, "@" + s.Substring(80, s.Length - 80));
                }
                if (s.Length > 120)
                {
                    bRet = SendCmd(&status, &error, "@" + s.Substring(120, s.Length - 120));
                }
                if (s.Length > 160)
                {
                    bRet = SendCmd(&status, &error, "@" + s.Substring(160, s.Length - 160));
                }
                iError = error;
                iStatus = status;
            }
        }
        private string MostrarStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return "Status Desconocido ";
                case 1:
                    return "En Modo Prueba y en Espera ";
                case 2:
                    return "Modo Prueba y EmisiÃ³n de Documentos Fiscales ";
                case 3:
                    return "Modo Prueba y EmisiÃ³n de Documentos No Fiscales ";
                case 4:
                    return "Fiscal y en Espera ";
                case 5:
                    return "Modo Fiscal y EmisiÃ³n de Documentos Fiscales ";
                case 6:
                    return "Fiscal y EmisiÃ³n de Documentos No Fiscales ";
                case 7:
                    return "Modo Fiscal y Cercana Carga Completa De La Memoria Fiscal Y en Espera ";
                case 8:
                    return "En Modo Fiscal y Cercana Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos Fiscales ";
                case 9:
                    return "En Modo Fiscal y Cercana Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos No Fiscales ";
                case 10:
                    return "En Modo Fiscal y Carga Completa De La Memoria Fiscal Y en Espera ";
                case 11:
                    return "En Modo Fiscal y Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos Fiscales ";
                case 12:
                    return "En Modo Fiscal y Carga Completa De La Memoria Fiscal Y en EmisiÃ³n de Documentos No Fiscales ";
                default:
                    return null;
            }
        }
        private string MostrarError(int error)
        {
            switch (error)
            {
                case 0:
                    return "No hay Error  VALIDO ";
                case 1:
                    return "Fin en la Entrega de papel  VALIDO ";
                case 2:
                    return "Error de Ã­ndole MecÃ¡nico en la entrega de Papel   VALIDO ";
                case 3:
                    return "Fin en la Entrega de papel y Error MecÃ¡nico  VALIDO ";
                case 4:
                    return "Comando Invalido / Valor Invalido  INVALIDO ";
                case 5:
                    return "Tasa Invalida  INVALIDO ";
                case 6:
                    return "No hay Asignadas Directivas   INVALIDO ";
                case 7:
                    return "Comando Invalido  INVALIDO ";
                case 8:
                    return "Error Fiscal  INVALIDO ";
                case 9:
                    return "Error de la Memoria Fiscal  INVALIDO ";
                case 10:
                    return "Memoria Fiscal llena  INVALIDO ";
                case 11:
                    return "Buffer Completo   INVALIDO ";
                case 12:
                    return "Error en la ComunicaciÃ³n   INVALIDO ";
                case 13:
                    return "No Hay Respuesta   INVALIDO ";
                case 14:
                    return "Error LRC   INVALIDO ";
                case 145:
                    return "Error Interno  API  INVALIDO ";
                case 153:
                    return "Error  en la Apertura del Archivo  INVALIDO ";
                default:
                    return null;
            }
        }
        public void ImprimeFactura(Factura documento, Pago pago)
        {
            int error;
            int status;
            string sCmd;
            bool bRet;
            unsafe
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
                    ConectarImpresora();
                    double SubTotal = 0;
                    double MontoIva = 0;
                    System.Threading.Thread.Sleep(500);
                    bRet = SendCmd(&status, &error, "i01Cedula/Rif:" + documento.CedulaRif);
                    bRet = SendCmd(&status, &error, "i02Razon Social:");
                    if (documento.RazonSocial.Length <= 37)
                    {
                        bRet = SendCmd(&status, &error, "i03" + Basicas.PrintFix(documento.RazonSocial, 37, 1));
                    }
                    else
                    {
                        bRet = SendCmd(&status, &error, "i03" + documento.RazonSocial.Substring(0, 36));
                        bRet = SendCmd(&status, &error, "i04" + documento.RazonSocial.Substring(36, (documento.RazonSocial.Length - 36)));
                    }
                    if (documento.CedulaRif == "V000000000")
                    {
                        sCmd = "i04 SIN DERECHO A CREDITO FISCAL";
                        bRet = SendCmd(&status, &error, sCmd);
                    }
                    if (!string.IsNullOrEmpty(documento.NumeroOrden))
                    {
                        sCmd = string.Format("i05       MESA:{0}", documento.NumeroOrden);
                        bRet = SendCmd(&status, &error, sCmd);
                    }
                    if (!string.IsNullOrEmpty(documento.Vendedor))
                    {
                        sCmd = string.Format("i06VENDEDOR:{0}", documento.Vendedor);
                        bRet = SendCmd(&status, &error, sCmd);
                    }
                    if (!string.IsNullOrEmpty(documento.Comentarios))
                    {
                        sCmd = "i07COMENTARIOS:";
                        bRet = SendCmd(&status, &error, sCmd);
                        sCmd = string.Format("i08{0}", documento.Comentarios);
                        bRet = SendCmd(&status, &error, sCmd);
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
                        sCmd = "!";
                        if (d.TasaIva == 0)
                        {
                            sCmd = " ";
                        }
                        else if (d.TasaIva == 12)
                        {
                            sCmd = "!";
                        }
                        else if (d.TasaIva == 10)
                        {
                            sCmd = '"'.ToString();
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
                            bRet = SendCmd(&status, &error, sCmd + Precio + Cantidad + d.Descripcion);
                            if (!bRet)
                            {
                                throw new Exception(string.Format("No es posible imprimir en producto:{0}", d.Descripcion));
                            }
                        }
                        else
                        {
                            bRet = SendCmd(&status, &error, sCmd + Precio + Cantidad + Descripcion.Substring(0, 36));
                            if (!bRet)
                            {
                                throw new Exception(string.Format("No es posible imprimir en producto:{0}", d.Descripcion));
                            }
                            string Descripcion2 = d.Descripcion.Substring(36, (d.Descripcion.Length - 36));
                            bRet = SendCmd(&status, &error, "@" + Descripcion2);
                        }
                    }
                    //if (documento.DescuentoBs.GetValueOrDefault(0) != 0)
                    //{

                    //    documento.DescuentoBs = documento.MontoTotal.GetValueOrDefault(0) - SubTotal - MontoIva;
                    //    documento.DescuentoBs = documento.DescuentoBs.GetValueOrDefault(0) * -1;
                    //    documento.DescuentoPorcentaje = (documento.DescuentoBs.GetValueOrDefault(0) * 100) / (SubTotal + MontoIva);
                    //    bRet = SendCmd(&status, &error, "3");
                    //    string DescuentoPorcentaje = (documento.DescuentoPorcentaje.GetValueOrDefault(0) * 100).ToString("0000");
                    //    bRet = SendCmd(&status, &error, "p-" + DescuentoPorcentaje);
                    //}
                    //Pagos
                    // CargarS2();         

                    //if (documento.MontoServicio.GetValueOrDefault(0) > 0)
                    //{
                    //    sCmd =  " ";
                    //    string Precio = (documento.MontoServicio.GetValueOrDefault(0) * 100).ToString("0000000000");
                    //    bRet = SendCmd(&status, &error, sCmd + Precio + "00001000" + "SERVICIO 10%");
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
                        sCmd = "201" + (x * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.Efectivo.Value;
                    }
                    if (pago.CestaTicket.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "202" + ((double)pago.CestaTicket * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.CestaTicket.Value;
                    }
                    //
                    if (pago.Cheque.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "205" + ((double)pago.Cheque * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.Cheque.Value;
                    }
                    if (pago.TarjetaCredito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "209" + ((double)pago.TarjetaCredito * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.TarjetaCredito.Value;
                    }
                    if (pago.TarjetaDebito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "210" + ((double)pago.TarjetaDebito * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.TarjetaDebito.Value;
                    }
                    if (pago.Credito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "216" + ((double)pago.Credito * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.Credito.Value;
                    }
                    System.Threading.Thread.Sleep(500);
                    CargarS2();
                    if (MontoPorPagar > 0)
                    {
                        sCmd = "115" + (MontoPorPagar.Value * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                    }
                    CargarS1(false);
                    documento.Fecha = Fecha;
                    documento.Hora = DateTime.Now;
                    documento.Numero = NumeroFactura;
                    // Pendiente
                    //documento.MontoGravable = SubTotalBases;
                    //documento.MontoIva = MontoIva;
                    //documento.MontoTotal = SubTotalBases + MontoIva;
                    documento.NumeroZ = (ultimoZ.Value).ToString("0000");
                    //documento.MaquinaFiscal = NumeroRegistro;
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    System.Threading.Thread.Sleep(500);
                    OK.ManejarException(x);
                    DesconectarImpresora();
                    throw x;
                }
            }
        }
        public void ImprimeNotaCredito(NotaDeCredito documento, Pago pago)
        {
            if (documento == null)
            {
                throw new Exception("Documento en blanco no se puede imprimir");
            }
            ConectarImpresora();
            unsafe
            {
                try
                {
                    int error = 0;
                    int status = 0;
                    string sCmd;
                    bool bRet = false;
                    System.Threading.Thread.Sleep(500);
                    bRet = SendCmd(&status, &error, "i01Cedula/Rif:" + documento.CedulaRif);
                    bRet = SendCmd(&status, &error, "i02Razon Social:");
                    sCmd = "i03" + documento.RazonSocial;
                    bRet = SendCmd(&status, &error, sCmd);
                    bRet = SendCmd(&status, &error, "i04Direccion:");
                    if (documento.Direccion != null)
                    {
                        if (documento.Direccion.Length > 40)
                        {
                            sCmd = "i05" + documento.Direccion;
                            bRet = SendCmd(&status, &error, sCmd);
                            bRet = SendCmd(&status, &error, "i06" + documento.Direccion.Substring(40, documento.Direccion.Length - 40));
                        }
                        else
                        {
                            bRet = SendCmd(&status, &error, "i06" + documento.Direccion);
                        }

                    }
                    sCmd = "i07 # FACTURA AFECTADA:" + documento.DocumentoAfectado;
                    bRet = SendCmd(&status, &error, sCmd);

                    // Agrego el servicio en la ultima fila
                    // DS.ImpresionTicket.AddImpresionTicketRow(1, 1, 1, 1, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, 1, "", 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, "SERVICIO 10%", 1, documento[0].MontoServicio, 0, "", "", "");
                    double SubTotal = 0;
                    double MontoIva = 0;
                    System.Threading.Thread.Sleep(500);
                    foreach (DocumentosProducto d in documento.DocumentosProductos.ToList())
                    {
                        if (d.TasaIva == 0)
                        {
                            sCmd = "d0";
                        }
                        else if (d.TasaIva == 12)
                        {
                            sCmd = "d1";
                        }
                        else if (d.TasaIva == 10)
                        {
                            sCmd = "d2";
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
                            bRet = SendCmd(&status, &error, sCmd + Precio + Cantidad + d.Descripcion);
                            if (!bRet)
                            {
                                throw new Exception(string.Format("No es posible imprimir en producto:{0}", d.Descripcion));
                            }
                        }
                        else
                        {
                            bRet = SendCmd(&status, &error, sCmd + Precio + Cantidad + Descripcion.Substring(0, 36));
                            if (!bRet)
                            {
                                throw new Exception(string.Format("No es posible imprimir en producto:{0}", d.Descripcion));
                            }
                            //string Descripcion2 = d.Descripcion.Substring(36, (d.Descripcion.Length - 36));
                            //bRet = SendCmd(&status, &error, "@" + Descripcion2);
                        }
                    }
                    System.Threading.Thread.Sleep(500);
                    //if (documento.DescuentoBs != 0)
                    //{

                    //    documento.DescuentoBs = documento.MontoTotal - SubTotal - MontoIva;
                    //    documento.DescuentoBs = documento.DescuentoBs * -1;
                    //    documento.DescuentoPorcentaje = (documento.DescuentoBs * 100) / (SubTotal + MontoIva);
                    //    bRet = SendCmd(&status, &error, "3");
                    //    string DescuentoPorcentaje = ((double)documento.DescuentoPorcentaje * 100).ToString("0000");
                    //    bRet = SendCmd(&status, &error, "p-" + DescuentoPorcentaje);
                    //}
                    //Pagos
                    double TotalPagos = 0;
                    //if (documento.MontoServicio.GetValueOrDefault(0) > 0)
                    //{
                    //    sCmd = "d0";
                    //    string Precio = (documento.MontoServicio.GetValueOrDefault(0) * 100).ToString("0000000000");
                    //    bRet = SendCmd(&status, &error, sCmd + Precio + "00001000" + "SERVICIO 10%");
                    //}
                    // Pago pago = documento.Pago; // != null ? documento.Pagos : new Pago();
                    if (pago.Efectivo.GetValueOrDefault(0) != 0)
                    {
                        double x = pago.Efectivo.GetValueOrDefault(0) + pago.Cambio.GetValueOrDefault(0);
                        sCmd = "f01" + (x * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.Efectivo.Value;
                    }
                    if (pago.CestaTicket.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f02" + ((double)pago.CestaTicket * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.CestaTicket.Value;
                    }

                    if (pago.Cheque.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f05" + ((double)pago.Cheque * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.Cheque.Value;
                    }
                    if (pago.TarjetaCredito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f09" + ((double)pago.TarjetaCredito * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.TarjetaCredito.Value;
                    }
                    if (pago.TarjetaDebito.GetValueOrDefault(0) != 0)
                    {
                        sCmd = "f10" + ((double)pago.TarjetaDebito * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);
                        TotalPagos += pago.TarjetaDebito.Value;
                    }
                    if (documento.MontoTotal.GetValueOrDefault(0) > TotalPagos)
                    {
                        sCmd = "f16" + ((double)documento.MontoTotal - (double)TotalPagos * 100).ToString("000000000000");
                        bRet = SendCmd(&status, &error, sCmd);

                    }
                    CargarX();
                    CargarS1(false);
                    System.Threading.Thread.Sleep(500);
                    documento.NumeroZ = ultimoZ.Value.ToString("0000");
                    //documento.MaquinaFiscal = NumeroRegistro;
                    documento.Numero = ultimaDevolucion;
                    iError = error;
                    iStatus = status;
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    DesconectarImpresora();
                    throw x;
                }
            }
        }
        public void ImprimeFacturaCopia(Factura p)
        {
            int error = 0;
            int status = 0;
            bool bRet;

            unsafe
            {
                System.Threading.Thread.Sleep(1000);
                ConectarImpresora();
                string Numero = p.Numero;
                string n = Numero.Substring(1, 7);
                bRet = SendCmd(&status, &error, String.Format("RF{0}{0}", n));
                if (!bRet)
                {
                    throw new Exception("Esta impresora no puede imprimir ese resumen esa funcion es de la Bixolon 350 exclusivamente");
                }
                iError = error;
                iStatus = status;
                DesconectarImpresora();
                //return bRet;
            }
        }
        public void ReporteX()
        {
            int error = 0;
            int status = 0;
            string sCmd;
            bool bRet;
            ConectarImpresora();
            unsafe
            {
                //************ Imprimir Reporte X *******************
                sCmd = "I0X";
                bRet = SendCmd(&status, &error, sCmd);
            }
            iError = error;
            iStatus = status;
            DesconectarImpresora();
        }
        public void ReporteZ()
        {
            int error = 0;
            int status = 0;
            string sCmd;
            bool bRet;
            ConectarImpresora();
            unsafe
            {
                //************ Imprimir Reporte Z *******************
                sCmd = "I0Z";
                bRet = SendCmd(&status, &error, sCmd);
                //  CargarS1(false);
                ultimoZ++;
            }
            iError = error;
            iStatus = status;
            DesconectarImpresora();
        }
        public void CargarX()
        {
            try
            {
                unsafe
                {
                    int error;
                    int status;
                    iError = error = 0;
                    iStatus = status = 0;
                    if (!UploadStatusCmd(&status, &error, "U0X", "ReporteX.TXT"))
                    {
                        return;
                        // throw new Exception("Imposible leer datos desde Impresora Fiscal");
                    }
                    using (StreamReader sr = new StreamReader("ReporteX.TXT"))
                    {
                        String line;
                        // Read and display lines from the file until the end of 
                        // the file is reached.
                        while ((line = sr.ReadLine()) != null)
                        {
                            ultimaDevolucion = line.Substring(168, 8);
                        }

                    }
                }
            }
            catch (Exception x)
            {
                Basicas.ManejarError(x);
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
            int error;
            int status;
            string sCmd;
            bool bRet;
            unsafe
            {
                //************ Imprimir Reporte Z *******************
                try
                {
                    ConectarImpresora();
                    System.Threading.Thread.Sleep(500);
                    string Inicio = dateTime.Day.ToString("00") + dateTime.Month.ToString("00") + dateTime.Year.ToString("00").Substring(2, 2);
                    string Final = dateTime_2.Day.ToString("00") + dateTime_2.Month.ToString("00") + dateTime_2.Year.ToString("00").Substring(2, 2);
                    sCmd = string.Format("I2M", Inicio, Final);
                    bRet = SendCmd(&status, &error, sCmd);
                    if (bRet == false)
                    {
                        throw new Exception("Esta impresora no puede imprimir ese resumen esa funcion es de la Bixolon 350 exclusivamente");
                    }
                    iError = error;
                    iStatus = status;
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    throw new Exception("Error al imprimir el reporte Mensual IVA", x);
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
            int error;
            int status;
            unsafe
            {
                try
                {
                   ConectarImpresora();
                   System.Threading.Thread.Sleep(500);
                    foreach (string linea in Texto)
                    {
                        bRet = SendCmd(&status, &error, "800" + linea);
                    }
                    bRet = SendCmd(&status, &error, "810");
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    throw new Exception("Error al imprimir un documento no fiscal", x);
                }
            }

        }
        public void ImprimeVale(Vale documento)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                  //  ConectarImpresora();
                    bRet = SendCmd(&status, &error, string.Format("800 VALE DE CAJA:{0}", documento.Numero));
                    //bRet = SendCmd(&status, &error, "800" + "CAJERO:"+ documento.Cajero);
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + "CEDULA:" + documento.Cedula);
                    bRet = SendCmd(&status, &error, "800" + "NOMBRE:" + documento.Nombre);
                    bRet = SendCmd(&status, &error, "800" + documento.Concepto);
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + string.Format("MONTO BS.:{0} ", documento.Monto.Value.ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + " ");
                    HK.Utilitatios.Numalet let = new HK.Utilitatios.Numalet();
                    bRet = SendCmd(&status, &error, "800" + let.ToCustomCardinal((decimal)documento.Monto.Value));
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800 --------------------");
                    bRet = SendCmd(&status, &error, "810         FIRMA       ");
                    //DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ERROR");
                    throw x;
                }
            }
        }
        public void ImprimeCierre(CierreCaja cierre, CierreCaja calculo, List<MesasCerrada> cerradas)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    //ConectarImpresora();
                    bRet = SendCmd(&status, &error, "800 CIERRE DE CAJA");
                    bRet = SendCmd(&status, &error, "800" + string.Format("  EFECTIVO :{0}", cierre.Efectivo.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("    CHEQUE :{0}", cierre.Cheque.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("    BANESCO:{0}", cierre.Banesco.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  BANESCO 2:{0}", cierre.Banesco2.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  MERCANTIL:{0}", cierre.Mercantil.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  CORPBANCA:{0}", cierre.Corpbanca.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("   TARJETAS:{0}", cierre.Tarjetas.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("DEPOSI/TRAN:{0}", cierre.DepositosTransferencias.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("   CREDITOS:{0}", cierre.Creditos.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("      OTROS:{0}", cierre.Otros.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("     GASTOS:{0}", cierre.Gastos.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("      VALES:{0}", cierre.Vales.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("RETENCIONES:{0}", cierre.Retenciones.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  CRED.COBR:{0}", cierre.CreditosCobrados.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  T O T A L:{0}", cierre.TotalCaja.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format(" CRED.COBRA:{0}", cierre.CreditosCobrados.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format(" VENTA NETA:{0}", (cierre.TotalCaja.GetValueOrDefault(0) - cierre.CreditosCobrados.GetValueOrDefault(0)).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("   FACTURAS:{0}", calculo.CantidadFacturas.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800 ===============================================");
                    bRet = SendCmd(&status, &error, "800 SISTEMA");
                    bRet = SendCmd(&status, &error, "800" + string.Format(" EFECTIVO :{0}", calculo.Efectivo.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("   CHEQUE :{0}", calculo.Cheque.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  TARJETAS:{0}", calculo.Tarjetas.GetValueOrDefault(0).ToString("n2")));
                    // bRet = SendCmd(&status, &error, "800" + string.Format(" TARJETAS:{0}", calculo.Tarjetas));
                    bRet = SendCmd(&status, &error, "800" + string.Format(" DEPOS/TRA:{0}", calculo.DepositosTransferencias.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("  CREDITOS:{0}", calculo.Creditos.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("     VALES:{0}", calculo.Vales.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format(" T O T A L:{0}", calculo.TotalCaja.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("CRED.COBRA:{0}", calculo.CreditosCobrados.GetValueOrDefault(0).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("VENTA NETA:{0}", (calculo.TotalCaja.GetValueOrDefault(0) - calculo.CreditosCobrados.GetValueOrDefault(0)).ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + "NUMERO       MONTO    Q     MESA");
                    foreach (var item in cerradas.Where(x => x.Factura != "INTERNO"))
                    {
                        bRet = SendCmd(&status, &error, "800" + string.Format("{0} {1} {2} {3}", item.Factura, item.MontoTotal.Value.ToString("n2").PadLeft(10), item.NumeroImpresiones.Value.ToString("N0").PadLeft(03), item.CodigoMesa.PadLeft(10)));
                    }
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " MONTO    Q     MESA");
                    foreach (var item in cerradas.Where(x => x.Factura == "INTERNO"))
                    {
                        bRet = SendCmd(&status, &error, "800" + string.Format("{0} {1} {2}", item.MontoTotal.Value.ToString("n2").PadLeft(10), item.NumeroImpresiones.Value.ToString("N0").PadLeft(03), item.CodigoMesa.PadLeft(10)));
                    }

                    bRet = SendCmd(&status, &error, "810  FIN.");
                    //DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ERROR");
                    throw x;
                }
            }

        }
        public void ImprimeOrden(Factura documento)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    System.Threading.Thread.Sleep(500);
                    bRet = SendCmd(&status, &error, string.Format("800 CLIENTE:{0}\n", documento.RazonSocial));
                    bRet = SendCmd(&status, &error, "800" + "      COMANDA    ");
                    bRet = SendCmd(&status, &error, String.Format("800{0} {1}", documento.Tipo, documento.NumeroOrden));
                    foreach (var item in documento.DocumentosProductos)
                    {
                        if (item.Cantidad.GetValueOrDefault(0) > 1)
                        {
                            bRet = SendCmd(&status, &error, "800" + string.Format(" X {0}", item.Cantidad.Value.ToString("N0")));
                        }
                        bRet = SendCmd(&status, &error, "800" + item.Descripcion);
                        if (item.Comentario != null)
                        {
                            bRet = SendCmd(&status, &error, "800" + item.Comentario);

                        }
                    }
                    bRet = SendCmd(&status, &error, "810  ==========");
                    // bRet = SendCmd(&status, &error, "800 USTED SERA LLAMADO POR EL NUMERO=>" + documento.Numero.Substring(5,3));
                    System.Threading.Thread.Sleep(500);
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ==========");
                    System.Threading.Thread.Sleep(500);
                    throw x;
                }
            }
        }
        public void ImprimeCorte(MesasAbierta documento)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    System.Threading.Thread.Sleep(500);
                    bRet = SendCmd(&status, &error, "800" + "   NOTA DE CONSUMO    ");
                    bRet = SendCmd(&status, &error, String.Format("800ATENDIDO POR:{0}", documento.Mesonero));
                    bRet = SendCmd(&status, &error, "800" + "MESA:" + documento.CodigoMesa);
                    bRet = SendCmd(&status, &error, String.Format("800   Q:{0}", documento.NumeroImpresiones.GetValueOrDefault(0)));
                    if (!string.IsNullOrEmpty(documento.CedulaRif))
                    {
                        bRet = SendCmd(&status, &error, String.Format("800CEDULA/RIF:{0}", documento.CedulaRif));
                    }
                    if (!string.IsNullOrEmpty(documento.RazonSocial))
                    {
                        bRet = SendCmd(&status, &error, "800" + "RAZON SOCIAL:" + documento.RazonSocial);
                    }
                    bRet = SendCmd(&status, &error, "800" + "CANT  DESCRIPCION                    MONTO" + documento.Mesonero);
                    bRet = SendCmd(&status, &error, "800" + "==========================================");
                    foreach (var item in documento.MesasAbiertasProductos.Where(x => x.Anulado != true))
                    {
                        bRet = SendCmd(&status, &error, string.Format("800" + "{0} {1} {2}", item.Cantidad.Value.ToString("n2").PadLeft(5), item.Descripcion.PadRight(25).Substring(0, 25), (item.Precio.GetValueOrDefault(0) * item.Cantidad.GetValueOrDefault(0)).ToString("n2").PadLeft(8)));
                    }
                    double Total = documento.MontoTotal.GetValueOrDefault(0);
                    bRet = SendCmd(&status, &error, "800" + "==========================================");
                    bRet = SendCmd(&status, &error, "800" + string.Format("   SUB TOTAL:{0}".PadLeft(33), (documento.MontoGravable.GetValueOrDefault(0)).ToString("N2").PadLeft(8)));
                    bRet = SendCmd(&status, &error, "800" + string.Format("SERVICIO 10%:{0}".PadLeft(33), (documento.MontoServicio.GetValueOrDefault(0)).ToString("N2").PadLeft(8)));
                    bRet = SendCmd(&status, &error, "800" + string.Format("   MONTO IVA:{0}".PadLeft(33), (documento.MontoIva.GetValueOrDefault(0)).ToString("N2").PadLeft(8)));
                    bRet = SendCmd(&status, &error, "800" + string.Format(" MONTO TOTAL:{0}".PadLeft(33), (Total).ToString("N2").PadLeft(8)));
                    bRet = SendCmd(&status, &error, "810" + "==========================================");

                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ");
                    DesconectarImpresora();
                    throw x;
                }
            }

        }
        public void ImprimeCorteSinMontos(MesasAbierta documento)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    System.Threading.Thread.Sleep(500);
                    bRet = SendCmd(&status, &error, "800" + "   PLATOS CONSUMIDOS    ");
                    bRet = SendCmd(&status, &error, String.Format("800ATENDIDO POR:{0}", documento.Mesonero));
                    bRet = SendCmd(&status, &error, "800" + "MESA:" + documento.CodigoMesa);
                    bRet = SendCmd(&status, &error, String.Format("800Q:{0}", documento.NumeroImpresiones.GetValueOrDefault(0)));
                    if (!string.IsNullOrEmpty(documento.CedulaRif))
                    {
                        bRet = SendCmd(&status, &error, "800" + "CEDULA/RIF:" + documento.CedulaRif);
                    }
                    if (!string.IsNullOrEmpty(documento.RazonSocial))
                    {
                        bRet = SendCmd(&status, &error, "800" + "RAZON SOCIAL:" + documento.RazonSocial);
                    }
                    bRet = SendCmd(&status, &error, "800" + ":" + documento.NumeroImpresiones.GetValueOrDefault(0));
                    bRet = SendCmd(&status, &error, "800" + "CANT  DESCRIPCION               " + documento.Mesonero);
                    bRet = SendCmd(&status, &error, "800" + "======================================");
                    var resumido = from x in documento.MesasAbiertasProductos
                                   where x.Anulado != true && x.Departamento != "COMENTARIOS" && x.Precio.GetValueOrDefault() > 0 && x.Cantidad.GetValueOrDefault() > 0
                                   group x by x.Descripcion;
                    foreach (var item in resumido)
                    {
                        bRet = SendCmd(&status, &error, string.Format("800" + "{0} {1}",
                            item.Sum(c => c.Cantidad).Value.ToString("n2").PadLeft(5), item.Key.PadRight(22).Substring(0, 22)));
                    }
                    //double Total = documento.MontoTotal.GetValueOrDefault(0);
                    //bRet = SendCmd(&status, &error, "800" + "======================================");
                    //bRet = SendCmd(&status, &error, "800" + string.Format("   SUB TOTAL:{0}".PadLeft(33), (Total * 0.9).ToString("N2").PadLeft(8)));
                    //bRet = SendCmd(&status, &error, "800" + string.Format("SERVICIO 10%:{0}".PadLeft(33), (Total * 0.1).ToString("N2").PadLeft(8)));
                    //bRet = SendCmd(&status, &error, "800" + string.Format(" MONTO TOTAL:{0}".PadLeft(33), (Total).ToString("N2").PadLeft(8)));
                    bRet = SendCmd(&status, &error, "810" + "======================================");
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ");
                    DesconectarImpresora();
                    throw x;
                }
            }

        }
        public void ImprimeOrdenDespacho(Factura documento)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    bRet = SendCmd(&status, &error, "800" + "ORDEN DE DESPACHO");
                    bRet = SendCmd(&status, &error, "800" + "  ");
                    bRet = SendCmd(&status, &error, "800" + "   " + documento.Comentarios);
                    bRet = SendCmd(&status, &error, "800" + "  ");
                    bRet = SendCmd(&status, &error, "800" + string.Format(" TICKET:{0} ", documento.Numero));
                    bRet = SendCmd(&status, &error, "800" + string.Format("CLIENTE:{0} ", documento.RazonSocial));
                    bRet = SendCmd(&status, &error, "800" + string.Format("========================================"));
                    foreach (var item in documento.DocumentosProductos.ToList())
                    {
                        bRet = SendCmd(&status, &error, "800" + string.Format(" {0}) {1} ", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25).Substring(0, 25)));
                        if (item.Comentario != null)
                        {
                            //foreach (string p in item.Comentario)
                            //{
                            bRet = SendCmd(&status, &error, "800" + item.Comentario);
                            //}
                        }
                        // Pendiente
                        //if (item.Contornos != null)
                        //{
                        //    foreach (string p in item.Contornos)
                        //    {
                        //        bRet = SendCmd(&status, &error, "800" + p);
                        //    }
                        //}
                    }
                    bRet = SendCmd(&status, &error, "800" + "========================================");
                    bRet = SendCmd(&status, &error, "800" + documento.Comentarios);
                    bRet = SendCmd(&status, &error, "810" + "  ");
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ");
                    throw x;
                }
            }

        }
        public void ImprimeComanda(MesasAbierta documento, List<MesasAbiertasProducto> items)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    bRet = SendCmd(&status, &error, "800" + "      COMANDA    ");
                    bRet = SendCmd(&status, &error, "800" + "  ");
                    bRet = SendCmd(&status, &error, "800" + string.Format("TICKET:{0} COMANDA:{1}", documento.Numero, Administrativo.GetContador("Comanda")));
                    bRet = SendCmd(&status, &error, "800" + string.Format("FECHA :{0}    HORA:{1}", DateTime.Today.ToShortDateString(), DateTime.Now.ToShortTimeString()));
                    bRet = SendCmd(&status, &error, "800" + string.Format("MESA:{0}", documento.CodigoMesa));
                    bRet = SendCmd(&status, &error, "800" + string.Format("MESONERO:{0}", documento.Mesonero));
                    bRet = SendCmd(&status, &error, "800" + "========================================");
                    foreach (var item in items)
                    {
                        bRet = SendCmd(&status, &error, "800" + string.Format(" {0}) {1} ", item.Cantidad.Value.ToString("N0"), item.Descripcion.PadRight(25).Substring(0, 25)));
                        if (item.Comentario != null)
                        {
                            //foreach (string p in item.Comentarios)
                            //{
                            bRet = SendCmd(&status, &error, "800" + item.Comentario);
                            //}
                        }
                        //if (item.Contornos != null)
                        //{
                        //    foreach (string p in item.Contornos)
                        //    {
                        //        bRet = SendCmd(&status, &error, "800" + p);
                        //    }
                        //}
                    }
                    bRet = SendCmd(&status, &error, "800" + "========================================");
                    bRet = SendCmd(&status, &error, "810" + "  ");
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ");
                    throw x;
                }
            }

        }
        public void ImprimirReciboCobro(Pago caja)
        {
            int error;
            int status;
            unsafe
            {
                try
                {
                    ConectarImpresora();
                    Administrativo data = new Administrativo();
                    bRet = SendCmd(&status, &error, string.Format("800 COMPROBANTE DE PAGO:{0}", caja.Numero));
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + caja.Concepto);
                    bRet = SendCmd(&status, &error, "800 FECHA:" + caja.Documento.Fecha);
                    bRet = SendCmd(&status, &error, "800 FACTURA:" + caja.Documento.Numero);
                    bRet = SendCmd(&status, &error, "800 CED.RIF:" + caja.Documento.CedulaRif);
                    bRet = SendCmd(&status, &error, "800 CLIENTE:" + caja.Documento.RazonSocial);
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + string.Format("MONTO BS.:{0} ", caja.MontoPagado.Value.ToString("n2")));
                    bRet = SendCmd(&status, &error, "800" + " ");
                    HK.Utilitatios.Numalet let = new HK.Utilitatios.Numalet();
                    bRet = SendCmd(&status, &error, "800" + let.ToCustomCardinal((decimal)caja.MontoPagado.Value));
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800" + " ");
                    bRet = SendCmd(&status, &error, "800 --------------------");
                    bRet = SendCmd(&status, &error, "810         FIRMA       ");
                    DesconectarImpresora();
                }
                catch (Exception x)
                {
                    bRet = SendCmd(&status, &error, "810  ERROR");
                    throw x;
                }
            }
        }
        //public static void ImprimirReverso(MesasCerrada mesa )
        //{
        //    int error;
        //    int status;
        //    unsafe
        //    {
        //        try
        //        {
        //            ConectarImpresora();
        //            Factura f = FactoryFacturas.Item(caja.IdDocumento);
        //            bRet = SendCmd(&status, &error, string.Format("800 REVERSO DE MESA CERRADA:{0}", mesa.Numero));
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + mesa.CedulaRif);
        //            bRet = SendCmd(&status, &error, "800" + mesa.RazonSocial);
        //            bRet = SendCmd(&status, &error, "800" + "MESA:" + mesa.CodigoMesa);
        //            if (f != null)
        //            {
        //                bRet = SendCmd(&status, &error, "800 FECHA:" + f.Fecha);
        //                bRet = SendCmd(&status, &error, "800 FACTURA:" + f.Numero);
        //                bRet = SendCmd(&status, &error, "800 CED.RIF:" + f.CedulaRif);
        //                bRet = SendCmd(&status, &error, "800 CLIENTE:" + f.RazonSocial);
        //            }
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + string.Format("MONTO BS.:{0} ", caja.MontoPagado.Value.ToString("n2")));
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            Utilitatios.Numalet let = new Utilitatios.Numalet();
        //            bRet = SendCmd(&status, &error, "800" + string.Format(let.ToCustomCardinal((decimal)caja.MontoPagado.Value)));
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800" + " ");
        //            bRet = SendCmd(&status, &error, "800 --------------------");
        //            bRet = SendCmd(&status, &error, "810         FIRMA       ");
        //            DesconectarImpresora();
        //        }
        //        catch (Exception x)
        //        {
        //            bRet = SendCmd(&status, &error, "810  ERROR");
        //            throw x;
        //        }
        //    }
        //}
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
            DesconectarImpresora();
        }
    }
}
