using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        public TercerosMovimiento FindCuentaxCobrar(string id)
        {
            return data.TerceroMovimientosRepository.Find(id);
        }
        public TercerosMovimiento FindCuentaxCobrarIdDocumento(string id)
        {
            return data.TerceroMovimientosRepository.GetFirst(x => x.DocumentoID==id);
        }
        public string EscribirCuentaxCobrar(Documento documento)
        {
            if (string.IsNullOrEmpty(documento.Numero))
                return null;
            TercerosMovimiento cxc = new TercerosMovimiento();
            cxc.Numero = GetContador("CxC");
            cxc.CodigoVendedor = documento.CodigoVendedor;
            cxc.Comentarios = documento.DescripcionCuenta;
            cxc.Concepto = string.Format("{0}:{1}", documento.Tipo, documento.Numero);
            cxc.Cuenta = documento.CodigoCuenta;
            if (documento.Tipo == "FACTURA")
            {
                cxc.Credito = 0;
                cxc.Debito = documento.Saldo;
                cxc.Saldo = documento.Saldo;
            }
            if (documento.Tipo == "NOTA CREDITO")
            {
                cxc.Debito = 0;
                cxc.Saldo = 0;
                cxc.Credito = documento.MontoTotal;

            }
            cxc.DescripcionCuenta = documento.DescripcionCuenta;
            cxc.DocumentoAfectado = documento.Numero;
            cxc.DocumentoID = documento.ID;
            cxc.Fecha = documento.Fecha;
            
            cxc.Tipo = documento.Tipo;
            cxc.Vence = documento.Vence;
            cxc.Vendedor = documento.Vendedor;
            cxc.Tercero = documento.Tercero;
            return GuardarCuentaxCobrar(cxc, false);
        }
        public string GuardarCuentaxCobrar(TercerosMovimiento entity, bool guardarAhora)
        {
            try
            {
                if (!data.IsValid(entity))
                    return data.ValidationErrors(entity);
                if (FindCuentaxCobrar(entity.ID) == null)
                {
                    data.TerceroMovimientosRepository.Insert(entity);
                }
                else
                {
                    data.TerceroMovimientosRepository.Update(entity);
                }
                if (guardarAhora)
                {
                    return data.Save();
                }
            }
            catch (Exception x)
            {
                string s = x.Message;
            }
            return null;
        }
        public void ClienteActualizarSaldos(Tercero current)
        {
            current.FacturasPendientes = current.TercerosMovimientos.Where(x => x.Saldo > 0).Count();
            current.SaldoPendiente = current.TercerosMovimientos.Where(x => x.Saldo > 0).Sum(x => x.Saldo);
            current.SaldoPendiente = current.SaldoPendiente.GetValueOrDefault(0) - current.Anticipos.GetValueOrDefault(0);
        }
        public TercerosMovimiento[] ClienteDocumentosPendientes(Tercero current)
        {
            var items = from x in current.TercerosMovimientos
                        where x.Saldo > 0
                        select x;
            return items.ToArray();
        }
        public TercerosMovimiento[] ClienteMovimientosxLapso(Tercero current,DateTime desde, DateTime hasta,string Tipo)
        {
            var items = (from x in current.TercerosMovimientos
                        where x.Fecha>= desde && x.Fecha <= hasta
                        orderby x.Fecha
                        select x).ToArray();
            //if (! string.IsNullOrEmpty(Tipo) && Tipo!="TODOS")
            //{
            //    items = (from x in items
            //            where x.Tipo == Tipo
            //            select x).ToArray();
            //}
            return items;
        }
    }
}
