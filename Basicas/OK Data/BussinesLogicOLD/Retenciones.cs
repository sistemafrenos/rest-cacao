using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core;


namespace HK.BussinessLogic
{
    public class Retenciones : IDisposable, IUnitOfWork
    {
        public List<Retencion> current;
        private readonly DatosEntities context;
        private GenericRepository<Retencion> itemsRepository;
        private readonly GenericRepository<Tercero> proveedoresRepository;
        private readonly GenericRepository<TercerosMovimiento> cxpRepository;
        private bool disposed;
        public Retenciones()
        {
            context = new DatosEntities();
            itemsRepository = new GenericRepository<Retencion>(context);
            proveedoresRepository = new GenericRepository<Tercero>(context);
            cxpRepository = new GenericRepository<TercerosMovimiento>(context);
            Clear();
        }

        public void Clear()
        {
            current = new List<Retencion>();
        }
        public GenericRepository<Retencion> CompraRepository
        {
            get
            {
                if (itemsRepository == null)
                {
                    itemsRepository = new GenericRepository<Retencion>(context);
                }
                return itemsRepository;
            }
        }
        public void Load(string NumeroRetencion)
        {
            return;
        }
        public void LoadNumero(string numero)
        {
            current = itemsRepository.Get(d => d.Tipo == "RENTENCION IVA" && d.Numero == numero).ToList();
        }
        public void Clone(object OldItem)
        {
            return;
        }
        public string Save()
        {
            string validacion = IsValid();
            if (!string.IsNullOrEmpty(validacion))
                return validacion;
            try
            {
                foreach (var item in current)
                {
                    DescontarCxP(item);
                    if (context.Entry(item).State == EntityState.Detached)
                        itemsRepository.Insert(item);
                }
                string valido = IsValid();
                if (!string.IsNullOrEmpty(valido))
                    return valido;
                context.SaveChanges();
            }
            catch (EntityException x)
            {
                return OK.ManejarException(x);
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException x)
            {
                return OK.ManejarException(x);
            }
            catch (Exception x)
            {
                return OK.ManejarException(x);
            }
            return null;
        }

        private void DescontarCxP(Retencion item)
        {
            TercerosMovimiento itemCompra = cxpRepository.GetFirst(d => d.DocumentoID == item.DocumentoAfectadoID);
            itemCompra.Saldo = itemCompra.Saldo - item.MontoRetenido;
            if (itemCompra.Saldo < 0)
                itemCompra.Saldo = 0;
            TercerosMovimiento cxc = new TercerosMovimiento();
            cxc.CodigoVendedor = item.CodigoVendedor;
            cxc.Concepto = string.Format("{0} {1}", item.Tipo, item.Numero);
            cxc.Debito = item.Saldo;
            cxc.Fecha = item.Fecha;
            cxc.DocumentoID = item.ID;
            cxc.Numero = item.Numero;
            cxc.Saldo = item.Saldo;
            cxc.Tipo = item.Tipo;
            cxc.Vence = item.Vence;
            cxpRepository.Insert(cxc);
        }
        public void Delete(object item)
        {
            Retencion oldItem = (Retencion)item;
            oldItem.Anulado = true;
            oldItem.Estatus = "ANULADO";
            try
            {
                context.SaveChanges();
            }
            catch (Exception x)
            {

                throw new Exception(OK.ManejarException(x));
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public string IsValid()
        {
            //var validaTercero = context.Entry(current.Proveedor).GetValidationResult();
            //if (!validaTercero.IsValid)
            //    return OK.ErroresToString(validaTercero.ValidationErrors.ToArray());
            //var validacion = context.Entry(current).GetValidationResult();
            //if (!validacion.IsValid)
            //    OK.ErroresToString(validacion.ValidationErrors.ToArray());
            return null;
        }

        #region extras
        public string AsignarNumero(string ano, string mes)
        {
            return "";// String.Format("{0}{1}00{2}", ano, mes, contadores.GetContador("ComprobanteRetencionIVA"));
        }
        private IEnumerable<Retencion> BaseQuery(string texto)
        {
            return itemsRepository.Get(
            d => d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto),
            q => q.OrderBy(d => d.RazonSocial)
            );
        }
        public List<Retencion> GetAll(string texto)
        {
            return BaseQuery(texto).ToList();
        }
        public List<Retencion> GetHoy(string texto)
        {
            DateTime hoy = DateTime.Today;
            var x = BaseQuery(texto);
            return x.Where(d => d.Fecha == hoy).ToList();
        }
        public List<Retencion> GetAyer(string texto)
        {
            DateTime ayer = DateTime.Today.AddDays(-1);
            var x = itemsRepository.Get(
            d => ((d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto)) && d.Fecha == ayer),
            q => q.OrderBy(d => d.Numero)
            );
            return x.ToList();
        }
        public List<Retencion> GetLapso(DateTime fechaInicio, DateTime fechaFinal, string texto)
        {
            var x = itemsRepository.Get(
            d => ((d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto)) && d.Fecha >= fechaInicio && d.Fecha <= fechaFinal),
            q => q.OrderBy(d => d.RazonSocial)
            );
            return x.ToList();
        }
        public List<Retencion> GetMes(int mes, int ano)
        {
            return GetLapso(
            OK.MonthFirstDay(mes, ano),
            OK.MonthLastDay(mes, ano),
            ""
            );
        }
        public List<Retencion> GetMes(int mes, int ano, string texto)
        {
            var x = itemsRepository.Get(
            d => d.Mes==mes && d.Ano==ano && d.Periodo==texto,
            q => q.OrderBy(d => d.ComprobanteRetencionIVA)
            );
            return x.ToList();
        }
        public List<Retencion> GetEsteMes(string texto)
        {
            DateTime fecha = DateTime.Today;
            return GetLapso(
            OK.MonthFirstDay(fecha.Month, fecha.Year),
            OK.MonthLastDay(fecha.Month, fecha.Year),
            texto
            );
        }
        public List<Retencion> GetMesAnterior(string texto)
        {
            DateTime fecha = DateTime.Today.AddMonths(-1);
            return GetLapso(
            OK.MonthFirstDay(fecha.Month, fecha.Year),
            OK.MonthLastDay(fecha.Month, fecha.Year),
            texto
            );
        }
        #endregion
        public void CrearRetencion(Compra compra,int mes, int ano,string periodo)
        {
            CrearRetencionA(compra, mes,  ano, periodo);
            CrearRetencionB(compra, mes,  ano, periodo);
            CrearRetencionNotaDebito(compra,  ano, periodo);
            CrearRetencionNotaCredito(compra, mes,  ano, periodo);
        }
        private string UltimoComprobante()
        {
            return "";
        }
        private void CrearRetencionA(Compra compra,int mes, int ano,string periodo)
        {
            Retencion registro = new Retencion();
            registro.ComprobanteRetencionIVA = UltimoComprobante();
            registro.ID = compra.ID;
            registro.TasaIva = OK.SystemParameters.TasaIva;
            registro.CedulaRif = compra.CedulaRif;
            registro.FechaComprobante = DateTime.Today;
            registro.Fecha = compra.Fecha;
            registro.RazonSocial =compra.RazonSocial;
            registro.NumeroControl = compra.NumeroControl;
            registro.Numero = compra.Numero;
            registro.PeriodoImpositivo =  string.Format("{0}{1}",mes,ano);
            registro.PorcentajeRetencion = OK.SystemParameters.PorcentajeRetencion;
            registro.Tipo = "01";
            registro.TipoOperacion = "C";
            registro.MontoIva = compra.MontoIva;
            registro.BaseImponible = compra.MontoGravable;
            registro.MontoTotal = compra.MontoTotal;
            registro.MontoExento = compra.MontoSinDerechoCredito.GetValueOrDefault(0);
            registro.Periodo = periodo;
            registro.Calcular();
            current.Add(registro);
        }
        private void CrearRetencionB(Documento compra, int mes, int ano, string periodo)
        {
            Retencion registro = new Retencion();
            registro.ID = compra.ID;
            registro.TasaIva = OK.SystemParameters.TasaIvaB;
            registro.CedulaRif = compra.CedulaRif;
            registro.FechaComprobante = DateTime.Today;
            registro.Fecha = compra.Fecha;
            registro.RazonSocial = compra.RazonSocial;
            registro.NumeroControl = compra.NumeroControl;
            registro.Numero = compra.Numero;
            registro.PeriodoImpositivo = string.Format("{0}{1}",mes,ano);
            registro.PorcentajeRetencion = OK.SystemParameters.PorcentajeRetencion;
            registro.Tipo = "01";
            registro.TipoOperacion = "C";
            registro.MontoIva = compra.MontoIvaB;
            registro.BaseImponible = compra.MontoGravableB;
            registro.MontoTotal = compra.MontoTotal;
            registro.MontoExento = compra.MontoSinDerechoCredito.GetValueOrDefault(0);
          //  registro.NumeroOrden = contadores.GetContador("NumeroDeOperacion");
            registro.Periodo = periodo;
            registro.Calcular();
            current.Add(registro);
        }
        private void CrearRetencionNotaCredito(Documento compra, int mes, int ano, string periodo)
        { 
            //foreach (var notaCredito in notas)
            //{
            //    Retencion registro = new Retencion();
            //    registro.NumeroComprobante = NumeroComprobante;
            //    registro.IdDocumento = compra.IdDocumento;
            //    registro.Alicuota = notaCredito.TasaIva;
            //    registro.CedulaRif = proveedor.CedulaRif;
            //    registro.FechaComprobante = DateTime.Today;
            //    registro.FechaDocumento = notaCredito.Fecha;
            //    registro.NombreRazonSocial = proveedor.RazonSocial;
            //    registro.DocumentoAfectado = notaCredito.DocumentoAfectado;
            //    registro.NumeroControlDocumento = compra.NumeroControl;
            //    // registro.NumeroDocumento = compra.Numero;
            //    registro.NumeroControlDocumento = notaCredito.NumeroControl;
            //    registro.PeriodoImpositivo = PeriodoImpositivo;
            //    registro.PorcentajeRetencion = OK.Parametros.PorcentajeRetencion;
            //    registro.TipoDocumento = "02";
            //    registro.TipoOperacion = "C";
            //    registro.MontoIva = notaCredito.MontoIva * -1;
            //    registro.BaseImponible = notaCredito.MontoGravable * -1;
            //    registro.MontoDocumento = notaCredito.Credito * -1;
            //    registro.MontoExentoIva = notaCredito.MontoSinDerechoCreditoFiscal * -1;
            //    registro.Periodo = Periodo;
            //    registro.NotaCredito = notaCredito.Numero;
            //    registro.NumeroDeOperacion = int.Parse(FactoryContadores.GetContador("NumeroDeOperacion"));
            //    registro.Calcular();
            //    registros.Add(registro);
            //}
        }
        private void CrearRetencionNotaDebito(Documento compra, int ano, string periodo)
        {
            //foreach (var nota in notas)
            //{
            //    Retencion registro = new Retencion();
            //    registro.NumeroComprobante = NumeroComprobante;
            //    registro.IdDocumento = compra.IdDocumento;
            //    registro.Alicuota = nota.TasaIva;
            //    registro.CedulaRif = proveedor.CedulaRif;
            //    registro.FechaComprobante = DateTime.Today;
            //    registro.FechaDocumento = nota.Fecha;
            //    registro.NombreRazonSocial = proveedor.RazonSocial;
            //    registro.DocumentoAfectado = nota.DocumentoAfectado;
            //    registro.NumeroControlDocumento = compra.NumeroControl;
            //    //   registro.NumeroDocumento = compra.Numero;
            //    registro.NumeroControlDocumento = nota.NumeroControl;
            //    registro.PeriodoImpositivo = PeriodoImpositivo;
            //    registro.PorcentajeRetencion = OK.Parametros.PorcentajeRetencion;
            //    registro.TipoDocumento = "01";
            //    registro.TipoOperacion = "C";
            //    registro.MontoIva = nota.MontoIva;
            //    registro.BaseImponible = nota.MontoGravable;
            //    registro.MontoDocumento = nota.Credito;
            //    registro.MontoExentoIva = nota.MontoSinDerechoCreditoFiscal;
            //    registro.Periodo = Periodo;
            //    registro.NotaDebito = nota.Numero;
            //    registro.NumeroDeOperacion = int.Parse(FactoryContadores.GetContador("NumeroDeOperacion"));
            //    registro.Calcular();
            //    registros.Add(registro);
            //}
        }
    }
}
