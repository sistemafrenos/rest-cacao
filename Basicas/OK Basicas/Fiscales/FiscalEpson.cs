using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;
using System.Data;
using System.Data.Linq;
using System.Linq;
using HK;
using HK.Clases;
using System.Threading;

namespace HK.Fiscales

{
    /// <summary>
    /// Classe con la declaraciÃ³n de las funciones PNPDLL.dll
    /// </summary>
    public class FiscalEpson : IFiscal
    {
        private  string ultimoZ = null;
        private  string maquinaFiscal = null;
        private string puerto = "COM1";
        private string[] respuestas;
        

        /// <summary>
        /// Classe con la declaraciÃ³n de las funciones PNPDLL.dll
        /// </summary>
        #region DECLARACIÃ“N DE LAS FUNCIONES de PNPDLL.DLL
        [DllImport("PNPDLL.dll")]     public static extern string PFAbreNF();
        [DllImport("PNPDLL.dll")]
        public static extern string PFabrefiscal(String Razon, String RIF);
        [DllImport("PNPDLL.dll")]
        public static extern string PFtotal();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrepz();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrepx();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrenglon(String Descripcion, String cantidad, String monto, String iva);
        [DllImport("PNPDLL.dll")]
        public static extern string PFabrepuerto(String numero);
        [DllImport("PNPDLL.dll")]
        public static extern string PFcierrapuerto();
        [DllImport("PNPDLL.dll")]
        public static extern string PFDisplay950(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFLineaNF(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCierraNF();
        [DllImport("PNPDLL.dll")]
        public static extern string PFDescuento(String edbarra, String monto);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCortar();
        [DllImport("PNPDLL.dll")]
        public static extern string PFTfiscal(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFparcial();
        [DllImport("PNPDLL.dll")]
        public static extern string PFSerial();
        [DllImport("PNPDLL.dll")]
        public static extern string PFtoteconomico();
        [DllImport("PNPDLL.dll")]
        public static extern string PFCancelaDoc(String edlinea, String monto);
        [DllImport("PNPDLL.dll")]
        public static extern string PFGaveta();
        [DllImport("PNPDLL.dll")]
        public static extern string PFDevolucion(String razon, String rif,
        String comp, String maqui, String fecha, String hora);
        [DllImport("PNPDLL.dll")]
        public static extern string PFSlipON();
        [DllImport("PNPDLL.dll")]
        public static extern string PFSLIPOFF();
        [DllImport("PNPDLL.dll")]
        public static extern string PFestatus(String edlinea);
        [DllImport("PNPDLL.dll")]
        public static extern string PFreset();
        [DllImport("PNPDLL.dll")]
        public static extern string PFendoso(String campo1, String campo2,
        String campo3, String tipoendoso);
        [DllImport("PNPDLL.dll")]
        public static extern string PFvalida675(String campo1, String campo2, String campo3, String campo4);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCheque2(String mon, String ben, String fec, String c1, String c2, String c3, String c4, String campo1, String campo2);
        [DllImport("PNPDLL.dll")]
        public static extern string PFcambiofecha(String edfecha, String edhora);
        [DllImport("PNPDLL.dll")]
        public static extern string PFcambiatasa(String t1, String t2, String t3);
        [DllImport("PNPDLL.dll")]
        public static extern string PFBarra(String edbarra);
        [DllImport("PNPDLL.dll")]
        public static extern string PFVoltea();
        [DllImport("PNPDLL.dll")]
        public static extern string PFLeereloj();
        [DllImport("PNPDLL.dll")]
        public static extern string PFrepMemNF(String desf, String hasf,
        String modmem);
        [DllImport("PNPDLL.dll")]
        public static extern string PFRepMemoriaNumero(String desn, String hasn, String modmem);
        [DllImport("PNPDLL.dll")]
        public static extern string PFCambtipoContrib(String tip);
        [DllImport("PNPDLL.dll")]
        public static extern string PFultimo();
        [DllImport("PNPDLL.dll")]
        public static extern string PFTipoImp(String edtexto);
        #endregion
        //    FrmInformacion AuditMensaje = new FrmInformacion();
        string Puerto;
        public FiscalEpson(string puerto)
        {
            this.puerto= puerto;
            DetectarImpresora();
        }
        ~FiscalEpson()
        {
            var respuesta = PFcierrapuerto();
            if (respuesta != "OK")
                 throw new Exception("Error al cerrar el puerto");
        }
        public void CerrarPuerto()
        {
            PFcierrapuerto();
        }
        public double? MontoZ
        {
            get
            {
                return 0;
            }
        }
        public  void DetectarImpresora()
        {
                try
                {
                Puerto = puerto.Length == 4 ? puerto[3].ToString() : puerto;
                var respuesta = PFabrepuerto(Puerto);
                if (respuesta != "OK")
                    throw new Exception(string.Format("Error al abrir el puerto"));
                respuesta = PFTipoImp("300");
                CargarS1(false);
                maquinaFiscal = respuestas[2];
                    //var CodigoFiscal = respuestas[3];
                    //if (CodigoFiscal == "00")
                    //    return;
                    //if (CodigoFiscal == "01")
                    //    PFCancelaDoc("C","0");
                    //if (CodigoFiscal == "02")
                    //    PFCierraNF();
                    //if (CodigoFiscal == "04")
                    //    PFrepz();
                    //if (CodigoFiscal == "08")
                    //    PFreset();
                }
                catch (Exception x)
                { 
                    OK.ManejarException(x);
                } 
        }
        public  int UltimoZ()
        {
            if (ultimoZ == null)
            {
                CargarS1(true);
            }
            return Convert.ToInt16(ultimoZ);
        }
        public  string MaquinaFiscal()
        {
            if (maquinaFiscal == null)
            {
                CargarS1(true);
            }
            return "EPSON";
        }
        public  void ImprimeFactura(HK.Factura documento, Pago pago)
        {
            unsafe
            {
                string respuesta = "";
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
                    respuesta = PFabrefiscal(documento.RazonSocial, documento.CedulaRif);
                    if (respuesta != "OK")
                        throw new Exception("No es posible iniciar la factura revise si realizo el reporte Z");
                    respuesta = PFTfiscal("DIRECCION CLIENTE:");
                    if (documento.Direccion.Length > 0)
                    {
                        if (documento.Direccion.Length > 38)
                        {
                            respuesta = PFTfiscal(documento.Direccion.Substring(0, 38));
                            respuesta = PFTfiscal(documento.Direccion.Substring(38, documento.Direccion.Length - 38));
                        }
                        else
                        {
                            respuesta = PFTfiscal(documento.Direccion);
                        }
                    }

                    foreach (var d in documento.DocumentosProductos)
                    {
                        if(string.IsNullOrEmpty( d.Comentario))
                            respuesta = PFrenglon(d.Descripcion, d.Cantidad.Value.ToString("N0").Replace(",", "").Replace(".", ""), d.Precio.Value.ToString("N2").Replace(".", "").Replace(",", "."), d.TasaIva.Value.ToString("n2").Replace(",", ""));
                        else
                            respuesta = PFrenglon(d.Descripcion + " " +  d.Comentario, d.Cantidad.Value.ToString("N0").Replace(",", "").Replace(".", ""), d.Precio.Value.ToString("N2").Replace(".", "").Replace(",", "."), d.TasaIva.Value.ToString("n2").Replace(",", ""));
                        if (respuesta != "OK")
                            throw new Exception(string.Format("Error al enviar el producto {0} hacia la impresora", d.Descripcion));
                    }
                    respuesta = PFparcial();
                    if (respuesta != "OK")
                    {
                        PFCancelaDoc("C", "0");
                        throw new Exception("Error al totalizar");
                    }
                    Thread.Sleep(1000);
                    if ( !string.IsNullOrEmpty(documento.Comentarios))
                        respuesta = PFTfiscal("NOTA:" + documento.Comentarios );
                    if (!string.IsNullOrEmpty(documento.Vendedor))
                    {
                        respuesta = PFTfiscal("VEND.:" + Basicas.PrintFix( documento.Vendedor, 25, 1));
                    }
                    if ( !string.IsNullOrEmpty(OK.SystemParameters.NotaPieFactura))
                        respuesta = PFTfiscal(OK.SystemParameters.NotaPieFactura);
                    if ( !string.IsNullOrEmpty(OK.SystemParameters.NotaPieFactura2))
                        respuesta = PFTfiscal(OK.SystemParameters.NotaPieFactura2);
                    if (!string.IsNullOrEmpty(OK.SystemParameters.NotaPieFactura3))
                        respuesta = PFTfiscal(OK.SystemParameters.NotaPieFactura3);
                    respuesta = PFtotal();
                    if (respuesta != "OK")
                    {
                        PFCancelaDoc("C", "0");
                        throw new Exception("Error al cerrar la factura");
                    }
                    Thread.Sleep(1000);
                    CargarS1(false);
                    documento.Numero = respuestas[9];
                    documento.NumeroZ = respuestas[11];
                    documento.MaquinaFiscal = maquinaFiscal;
                }
                catch (Exception x)
                {
                    System.Threading.Thread.Sleep(1000);
                    PFCancelaDoc("C", "0");
                    PFreset();
                    throw x;
                }
            }
        }
        public  void ImprimeNotaCredito(NotaDeCredito documento, Pago pagoS)
        {
            string respuesta = "";
            try
            {
                if (documento == null)
                {
                    throw new Exception("Documento en blanco no se puede imprimir");
                }
                documento.Totalizar();
                if (documento.MontoTotal.GetValueOrDefault(0) == 0)
                {
                    throw new Exception("Este Documento esta imcompletos");
                }
                respuesta = PFDevolucion(documento.RazonSocial, documento.CedulaRif, documento.DocumentoAfectado, documento.MaquinaFiscal, DateTime.Today.ToShortDateString(), DateTime.Today.ToShortTimeString());
                if (respuesta != "OK")
                    throw new Exception("No es posible iniciar la nota de credito revise si realizo el reporte Z");
                foreach (var d in documento.DocumentosProductos)
                {
                    respuesta = PFrenglon(d.Descripcion, d.Cantidad.Value.ToString("N0").Replace(",", "").Replace(".", ""), d.Precio.Value.ToString("N2").Replace(".", "").Replace(",", "."), d.TasaIva.Value.ToString("n2").Replace(",", ""));
                }
                if (!string.IsNullOrEmpty(documento.Comentarios))
                    respuesta = PFTfiscal("NOTA:" + documento.Comentarios);
                respuesta = PFtotal();
                System.Threading.Thread.Sleep(2000);
                CargarS1(false);
                documento.Numero = respuestas[10];
                documento.NumeroZ = respuestas[11];
                PFestatus("T");
               // documento.Numero = PFultimo().Substring(0, 8);
                documento.MaquinaFiscal = maquinaFiscal;
            }
            catch (Exception x)
            {
                System.Threading.Thread.Sleep(1000);
                PFCancelaDoc("C", "0");
                PFreset();
                throw x;
            }
        }
        public  void ImprimeFacturaCopia(HK.Factura factura)
        {
        }
        public  void ReporteX()
        {
            try
            {
                var respuesta = PFrepx();
            }
            catch
            {
                PFreset();
            }
        }
        public  void ReporteZ()
        {
            try
            {
                PFrepz();
                CargarS1(false);
            }
            catch
            {
                PFreset();
            }
        }
        public  void CargarX(bool conectar)
        {

        }
        public  void CargarS1(bool conectar)
        {
            var respuesta = PFestatus("N");
            if (respuesta == "OK")
            {
                try
                {
                    string msg2 = PFultimo();
                    respuestas = msg2.Split(',');
                    ultimoZ = respuestas[11];
                    maquinaFiscal = respuestas[2];

                  //  Basicas.ManejarError(new Exception(string.Format("Estado de Impresora {1}[{0}]",respuestas,maquinaFiscal)));

                }
                catch { }
            }
        }
        private  void CargarS2()
        {

        }
        private  double strToDouble(string p)
        {
            double Base = Convert.ToDouble(p.Substring(0, 10));
            double Decimales = Convert.ToDouble(p.Substring(10, 2));
            return Base + (Decimales / 100);
        }
        public  void ReporteMensualIVA(DateTime dateTime, DateTime dateTime_2)
        {

        }
        public  bool IsOK()
        {
            return true;
        }
        public  void DocumentoNoFiscal(string[] Texto)
        {
            try
            {
                var bRet = PFAbreNF();
                if (bRet == "OK")
                {
                    System.Threading.Thread.Sleep(500);
                    foreach (string linea in Texto)
                    {
                        bRet = PFLineaNF(linea);
                    }
                    bRet = PFCierraNF();
                }
            }
            catch { }
        }
        public  void ImprimeVale(Vale documento)
        {
        }
        public void ImprimeCierre(CierreCaja cierre, CierreCaja calculo, List<MesasCerrada> cerradas)
        {
        }


        public void ImprimeCierre(CierreCaja cierre, CierreCaja original, List<MesasCerrada> facturas, List<MesasCerrada> cerradas)
        {
            throw new NotImplementedException();
        }

        public void ImprimeComanda(MesasAbierta documento, List<MesasAbiertasProducto> items)
        {
            throw new NotImplementedException();
        }

        public void ImprimeCorte(MesasAbierta documento)
        {
            throw new NotImplementedException();
        }

        public void ImprimeCorteSinMontos(MesasAbierta mesaAbierta)
        {
            throw new NotImplementedException();
        }

        public void ImprimeOrdenDespacho(Factura documento)
        {
            throw new NotImplementedException();
        }

        public void ImprimirReciboCobro(Pago caja)
        {
            throw new NotImplementedException();
        }

        public string NumeroRegistro
        {
            set { }
            get
            {
                var respuesta = PFSerial();
                if (respuesta != "OK")
                    return "";
                return PFultimo();
            }
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
