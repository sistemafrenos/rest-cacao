using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Core;

namespace HK.BussinessLogic
{
    public class RetencionesISLR : IDisposable, IUnitOfWork
    {
        public RetencionISLR current;
        private readonly DatosEntities context;
        private GenericRepository<RetencionISLR> itemsRepository;
        private readonly GenericRepository<Tercero> proveedoresRepository;
        private readonly GenericRepository<TercerosMovimiento> cxpRepository;
        private bool disposed;
        public RetencionesISLR()
        {
            context = new DatosEntities();
            itemsRepository = new GenericRepository<RetencionISLR>(context);
            proveedoresRepository = new GenericRepository<Tercero>(context);
            cxpRepository = new GenericRepository<TercerosMovimiento>(context);
            Clear();
        }

        public void Clear()
        {
            current = new RetencionISLR();
            current.Anulado = false;
            current.Estatus = "ABIERTA";
            current.Fecha = DateTime.Today;
            current.Mes = current.Fecha.Month;
            current.Ano = current.Fecha.Year;
            current.TasaIva = OK.SystemParameters.TasaIva;
            current.TasaIvaB = OK.SystemParameters.TasaIvaB;
            current.Tipo = "RETENCION ISLR";
        }
        public GenericRepository<RetencionISLR> CompraRepository
        {
            get
            {
                if (itemsRepository == null)
                {
                    itemsRepository = new GenericRepository<RetencionISLR>(context);
                }
                return itemsRepository;
            }
        }
        public void Load(string id)
        {
            current = itemsRepository.Find(id);
        }
        public void LoadNumero(string numero)
        {
            current = itemsRepository.GetFirst(d => d.Tipo == "RENTENCION ISLR" && d.Numero == numero);
        }
        public void Clone(object OldItem)
        {
            RetencionISLR old = (RetencionISLR)OldItem;
            //current = (RetencionISLR)old.Clone();
        }
        public string Save()
        {
            //  AsignarNumero();
            current.Ano = current.Fecha.Year;
            current.Mes = current.Fecha.Month;
            current.Hora = DateTime.Now;
            string validacion = IsValid();
            if (!string.IsNullOrEmpty(validacion))
                return validacion;
            try
            {
                DescontarCxP();
                if (context.Entry(current).State == EntityState.Detached)
                    itemsRepository.Insert(current);
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

        private void DescontarCxP()
        {
            TercerosMovimiento itemCompra = cxpRepository.GetFirst(d => d.DocumentoID == current.DocumentoAfectadoID);
            itemCompra.Saldo = itemCompra.Saldo - current.MontoRetenido;
            if (itemCompra.Saldo < 0)
                itemCompra.Saldo = 0;
            TercerosMovimiento cxc = new TercerosMovimiento();
            cxc.CodigoVendedor = current.CodigoVendedor;
            cxc.Concepto = string.Format("{0} {1}", current.Tipo, current.Numero);
            cxc.Debito = current.Saldo;
            cxc.Fecha = current.Fecha;
            cxc.DocumentoID = current.ID;
            cxc.Numero = current.Numero;
            cxc.Saldo = current.Saldo;
            cxc.Tipo = current.Tipo;
            cxc.Vence = current.Vence;
            cxpRepository.Insert(cxc);
        }
        public void Delete(object item)
        {
            RetencionISLR oldItem = (RetencionISLR)item;
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
            var validaTercero = context.Entry(current.Tercero).GetValidationResult();
            if (!validaTercero.IsValid)
                return OK.ErroresToString(validaTercero.ValidationErrors.ToArray());
            var validacion = context.Entry(current).GetValidationResult();
            if (!validacion.IsValid)
                OK.ErroresToString(validacion.ValidationErrors.ToArray());
            return null;
        }

        #region extras
        private void AsignarNumero()
        {
            if (current.Numero == null)
            {
                int valor = 0;
                var maximo = context.Documentos.Where(x => x.Tipo == current.Tipo).Max(x => x.Numero);
                int.TryParse(maximo, out valor);
                valor++;
              //  current.Numero = String.Format("{0}{1}00{2}", current.Ano, current.Mes, contadores.GetContador("ComprobanteISLR"));
            }
        }
        private IEnumerable<RetencionISLR> BaseQuery(string texto)
        {
            return itemsRepository.Get(
            d => d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto),
            q => q.OrderBy(d => d.RazonSocial)
            );
        }
        public List<RetencionISLR> GetAll(string texto)
        {
            return BaseQuery(texto).ToList();
        }
        public List<RetencionISLR> GetHoy(string texto)
        {
            DateTime hoy = DateTime.Today;
            var x = BaseQuery(texto);
            return x.Where(d => d.Fecha == hoy).ToList();
        }
        public List<RetencionISLR> GetAyer(string texto)
        {
            DateTime ayer = DateTime.Today.AddDays(-1);
            var x = itemsRepository.Get(
            d => ((d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto)) && d.Fecha == ayer),
            q => q.OrderBy(d => d.Numero)
            );
            return x.ToList();
        }
        public List<RetencionISLR> GetLapso(DateTime fechaInicio, DateTime fechaFinal, string texto)
        {
            var x = itemsRepository.Get(
            d => ((d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto)) && d.Fecha >= fechaInicio && d.Fecha <= fechaFinal),
            q => q.OrderBy(d => d.RazonSocial)
            );
            return x.ToList();
        }
        public List<RetencionISLR> GetMes(int mes, int ano)
        {
            return GetLapso(
            OK.MonthFirstDay(mes, ano),
            OK.MonthLastDay(mes, ano),
            ""
            );
        }
        public List<RetencionISLR> GetEsteMes(string texto)
        {
            DateTime fecha = DateTime.Today;
            return GetLapso(
            OK.MonthFirstDay(fecha.Month, fecha.Year),
            OK.MonthLastDay(fecha.Month, fecha.Year),
            texto
            );
        }
        public List<RetencionISLR> GetMesAnterior(string texto)
        {
            DateTime fecha = DateTime.Today.AddMonths(-1);
            return GetLapso(
            OK.MonthFirstDay(fecha.Month, fecha.Year),
            OK.MonthLastDay(fecha.Month, fecha.Year),
            texto
            );
        }
        #endregion
        public void CrearRetencionISLR(Compra compra)
        {
            RetencionISLR registro = new RetencionISLR();
            registro.DocumentoAfectadoID = compra.ID;
            registro.CedulaRif = compra.CedulaRif;
            registro.Fecha = DateTime.Today;
            registro.MontoTotal = compra.MontoTotal;
            registro.RazonSocial = compra.RazonSocial;
            registro.DocumentoAfectado = compra.Numero;
            registro.PorcentajeRetencion = OK.SystemParameters.PorcentajeRetencion;
            registro.BaseImponible = compra.MontoGravable;
            registro.Direccion = compra.Direccion;
            registro.MontoSujetoRetencion = registro.BaseImponible;
            registro.MontoRetenido = registro.BaseImponible * 0.02;
            registro.PorcentajeRetencion = 2;
            registro.NumeroControl = compra.NumeroControl;
            registro.MontoIva = compra.MontoIva.GetValueOrDefault(0) + compra.MontoIvaB.GetValueOrDefault(0);
            registro.Sustraendo = 0;
            registro.MontoExento = compra.MontoSinDerechoCredito.GetValueOrDefault(0);
        }

        public void LoadIdCompra(string p)
        {
            var item = itemsRepository.GetFirst(d => d.DocumentoAfectadoID == p);
            if (item != null)
                current = item;
        }
    }
}
