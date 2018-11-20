using System;
namespace HK.Fiscales
{
    public interface IFiscal:IDisposable
    {
        void DocumentoNoFiscal(string[] Texto);
       // void ImprimeCierre(HK.CajaCierre cierre, HK.CajaCierre original, System.Collections.Generic.List<HK.MesasCerrada> facturas, System.Collections.Generic.List<HK.MesasCerrada> cerradas);
        void ImprimeComanda(HK.MesasAbierta documento, System.Collections.Generic.List<HK.MesasAbiertasProducto> items);
        void ImprimeCorte(HK.MesasAbierta documento);
        void ImprimeFactura(HK.Factura documento, Pago pago);
        void ImprimeFacturaCopia(HK.Factura doc);
        void ImprimeNotaCredito(HK.NotaDeCredito documento, HK.Pago pago);
        void ImprimeCorteSinMontos(HK.MesasAbierta mesaAbierta);
        void ImprimeOrdenDespacho(HK.Factura documento);
        void ImprimeVale(HK.Vale documento);
        void ImprimirReciboCobro(HK.Pago caja);
        string NumeroRegistro { get; set; }
        double? MontoZ { get; }
        void ReporteMensualIVA(DateTime desde, DateTime hasta);
        void ReporteX();
        void ReporteZ();
        void CerrarPuerto();
    }
}
