using System;
using System.Collections.Generic;
using System.Linq;
using HK;

namespace HK.Clases
{
    public class FactoryCuentasxCobrar
    {
        public static void ActualizarSaldos()
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var lista = ((from p in db.TercerosMovimientos
                              select p.IdTercero).Distinct()).ToList();
                foreach (var item in lista)
                {
                    var cliente = (from xx in db.Terceros
                                   where xx.IdTercero == item
                                   select xx).FirstOrDefault();
                    if (cliente != null)
                    {
                        cliente.FacturasPendientes = cliente.TercerosMovimientos.Where(x => x.Saldo > 0).Count();
                        cliente.SaldoPendiente = cliente.TercerosMovimientos.Where(x => x.Saldo > 0).Sum(x => x.Saldo);
                        cliente.SaldoPendiente = cliente.SaldoPendiente.GetValueOrDefault(0) - cliente.Anticipos.GetValueOrDefault(0);
                    }
                }
                db.SaveChanges();
            }
        }
        public static List<TercerosMovimiento> DocumentosPendientes(DatosEntities db, string IdCliente)
        {
            var items = from x in db.TercerosMovimientos
                        where x.IdTercero == IdCliente && x.Saldo > 0
                        select x;
            return items.ToList();
        }
        public static List<TercerosMovimiento> Movimientos(DatosEntities db, string IdCliente, DateTime Desde, DateTime Hasta)
        {
            var items = from x in db.TercerosMovimientos
                        where x.IdTercero == IdCliente && x.Fecha.Value >= Desde && x.Fecha.Value <= Hasta
                        select x;
            return items.ToList();
        }
        public static List<TercerosMovimiento> Movimientos(DatosEntities db, DateTime Desde, DateTime Hasta)
        {
            var items = from x in db.TercerosMovimientos
                        where x.Fecha.Value >= Desde && x.Fecha.Value <= Hasta
                        select x;
            return items.ToList();
        }
        public static double? SaldoPendiente(string IdCliente)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var items = from x in db.TercerosMovimientos
                            where x.IdTercero == IdCliente && x.Saldo > 0
                            select x;
                return items.Sum(x => x.Saldo);
            }
        }
        public static bool RegistrarMovimiento(Factura factura)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                TercerosMovimiento movimiento = new TercerosMovimiento();
                //      movimiento.Cuenta = factura.CodigoCuenta;
                //      movimiento.DescripcionCuenta = factura.DescripcionCuenta;
                //      movimiento.Concepto = string.Format("{0}-{1}", factura.CodigoCuenta, factura.DescripcionCuenta);
                movimiento.Debito = factura.MontoTotal;
                movimiento.Fecha = factura.Fecha;
                movimiento.AsignarID();
                movimiento.Numero = factura.Numero;
                movimiento.Saldo = factura.Saldo;
                movimiento.Tipo = "FACTURA";
                //movimiento.Vence = factura.Fecha.Value.AddDays((double)cliente.DiasCredito.GetValueOrDefault(30));
                ////     movimiento.DescuentoProntoPago = factura.DescuentoProntoPago;
                //movimiento.Comentarios = factura.Comentarios;
                //cliente.TercerosMovimientos.Add(movimiento);
                //cliente.SaldoPendiente = cliente.SaldoPendiente.GetValueOrDefault(0) + movimiento.Debito;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                    return false;
                }
            }
            return true;
        }
        public static bool RegistrarMovimiento(MesasCerrada factura)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                TercerosMovimiento movimiento = new TercerosMovimiento();
                //      movimiento.Cuenta = factura.CodigoCuenta;
                //      movimiento.DescripcionCuenta = factura.DescripcionCuenta;
                //      movimiento.Concepto = string.Format("{0}-{1}", factura.CodigoCuenta, factura.DescripcionCuenta);
                movimiento.Debito = factura.MontoTotal;
                movimiento.Fecha = factura.Apertura.Value.Date;
                movimiento.AsignarID();
                movimiento.Numero = factura.Numero;
                movimiento.Saldo = factura.MontoTotal;
                movimiento.Tipo = "CUENTA";
                //movimiento.Vence = factura.Apertura.Value.AddDays((double)cliente.DiasCredito);
                // movimiento.DescuentoProntoPago = factura.DescuentoProntoPago;
                // movimiento.Comentarios = factura.Comentarios;
                //cliente.TercerosMovimientos.Add(movimiento);
                //cliente.SaldoPendiente = cliente.SaldoPendiente.GetValueOrDefault(0) + movimiento.Debito;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                    return false;
                }
            }
            return true;
        }
        public static bool RegistrarMovimiento(Retencion retencion)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                TercerosMovimiento movimiento = new TercerosMovimiento() { Concepto = string.Format("NOTA CREDIDO POR RETENCION IVA"), Credito = retencion.MontoIvaRetenido, Fecha = retencion.FechaComprobante };
                movimiento.AsignarID();
                movimiento.Numero = retencion.NumeroComprobante;
                movimiento.Saldo = null;
                movimiento.Tipo = "RETENCION IVA";
                movimiento.Vence = null;
                movimiento.DescuentoProntoPago = null;
                //cliente.TercerosMovimientos.Add(movimiento);
                //cliente.SaldoPendiente = cliente.SaldoPendiente.GetValueOrDefault(0) - movimiento.Credito;
                //TercerosMovimiento itemFactura = (from x in cliente.TercerosMovimientos
                //                                  where x.Numero == retencion.NumeroDocumento
                //                                  select x).FirstOrDefault();
                //if (itemFactura != null)
                //    if (itemFactura.Saldo > movimiento.Credito)
                //    {
                //        itemFactura.Saldo = itemFactura.Saldo - movimiento.Credito;
                //    }
                try
                {
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                    return false;
                }
                return true;
            }
        }

        public static void AgregarItem(Documento factura)
        {
            if (factura.Saldo.GetValueOrDefault(0) <= 0)
                return;
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                TercerosMovimiento nuevo = new TercerosMovimiento();
                nuevo.Comentarios = "";
                nuevo.Concepto = "FACTURA CREDITO:" + factura.Numero;
                nuevo.Debito = factura.Saldo;
                ;
                nuevo.Fecha = factura.Fecha;
                nuevo.AsignarID();
                nuevo.Numero = factura.Numero;
                nuevo.Saldo = factura.Saldo;
                nuevo.Tipo = "FACTURA";
                nuevo.IdDocumento = factura.IdDocumento;
                nuevo.Vence = nuevo.Fecha.Value.AddDays(30);
                nuevo.CodigoVendedor = factura.CodigoVendedor;
                nuevo.Vendedor = factura.Vendedor;
                //cliente.TercerosMovimientos.Add(nuevo);
                //cliente.CodigoVendedor = factura.CodigoVendedor;
                //cliente.Vendedor = factura.Vendedor;
                //cliente.FacturasPendientes = cliente.TercerosMovimientos.Where(x => x.Saldo > 0).Count();
                //cliente.SaldoPendiente = cliente.TercerosMovimientos.Where(x => x.Saldo > 0).Sum(x => x.Saldo);
                //cliente.SaldoPendiente = cliente.SaldoPendiente.GetValueOrDefault(0) - cliente.Anticipos.GetValueOrDefault(0);
                db.SaveChanges();
            }
        }
    }
}


