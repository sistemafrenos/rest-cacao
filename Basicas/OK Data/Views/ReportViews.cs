using System;
using System.Collections.Generic;
using System.Linq;

namespace HK
{
    
    public class ReportViews
    {
        #region Objetos
        public class ProductosAnulados
        {
            public string producto { set; get; }
            public string comentario { set; get; }
            public double? cantidad { set; get; }
            public double? bolivares { set; get; }
        }
        public class ComprasxProducto
        {
            public string Codigo { set; get; }
            public string Descripcion { set; get; }
            public string Departamento { set; get; }
            public DateTime? Fecha { set; get; }
            public double? VentasUnidades { set; get; }
            public double? VentasBolivares { set; get; }
        }
        public class VentasxProducto
        {
            public string Codigo { set; get; }
            public string Descripcion { set; get; }
            public string Departamento { set; get; }
            public DateTime? Fecha { set; get; }
            public double? VentasUnidades { set; get; }
            public double? VentasBolivares { set; get; }
        }
        public class TotalxFormaPago
        {
            string formaPago;

            public string FormaPago
            {
                get
                {
                    return formaPago;
                }
                set
                {
                    formaPago = value;
                }
            }
            double bolivares = 0;

            public double Bolivares
            {
                get
                {
                    return bolivares;
                }
                set
                {
                    bolivares = value;
                }
            }
        }
        public class Valores
        {
            string variable;

            public string Variable
            {
                get
                {
                    return variable;
                }
                set
                {
                    variable = value;
                }
            }
            double? valor = 0;

            public double? Valor
            {
                get
                {
                    return valor;
                }
                set
                {
                    valor = value;
                }
            }
        }
        public class TotalxDia
        {
            public int? Facturas { set; get; }
            public DateTime? Fecha { set; get; }
            public string Mesonero { set; get; }
            public Double? Bolivares { set; get; }
            public Double? Promedio { set; get; }
            public Double? MontoGravable { set; get; }
            public Double? MontoExento { set; get; }
            public Double? MontoIva { set; get; }
            public Double? MontoTotal { set; get; }
        }

        public class TotalPagos
        {
            public string Tipo { set; get; }
            public double? Monto { set; get; }
        }
        public class CierreDeCaja
        {
            public DateTime fecha { set; get; }
            public string numero { set; get; }
            public string razonSocial { set; get; }
            public string cedulaRif { set; get; }
            public double? contado { set; get; }
            public double? credito { set; get; }
            public double? cobros { set; get; }
        }
        public class Receta : ProductosCompuesto
        {
            public string Departamento { set; get; }
            public string Plato { set; get; }
        }
        public class ComprasxGrupo
        {
            public string Departamento { set; get; }
            public double CostoProductosVendidos { set;
                get; }
            public double ProductosVendidos { set;
                get; }
            public double MontoProductosVendidos { set;
                get; }
        }
        public class VentasxDepartamento
        {
            public string Departamento { set; get; }
            public double? CostoProductosVendidos { set; get; }
            public double? ProductosVendidos { set; get; }
            public double? MontoProductosVendidos { set; get; }
        }
        public class ComsumoProductos
        {
            public string Producto { set; get; }
            public double? Cantidad { set; get; }
            public double? Costo { set; get; }
        }
        public class FacturaPago : Factura
        {
            public double? Deposito { get; set; }
            public double? Tarjetas { get; set; }
            // public double? Credito { get; set; }
        }
        #region CxP
        public class CxP_ProveedoresMovimiento : TercerosMovimiento
        {
            public long? Dias { set; get; }
            public string RazonSocial { set; get; }
            public string CuentaCorriente { set; get; }
            public string Banco { set; get; }
            public string Rif { set; get; }
            public string Email { set; get; }
        }
        public static List<CxP_ProveedoresMovimiento> CxP_ListadoVencimientosFecha(DateTime fecha)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Saldo > 0 && item.Vence <= fecha
                                                       orderby item.Vence
                                                       select new CxP_ProveedoresMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Saldo = item.Saldo,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();
                foreach (var item in lista)
                {
                    item.Dias = Utilitatios.DateTimeExtension.DateDiff(Utilitatios.DateInterval.Day, item.Vence.Value, fecha);
                }
                return lista.ToList();
            }
        }
        public static List<CxP_ProveedoresMovimiento> CxP_ListadoGeneral()
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Saldo > 0
                                                       orderby item.Vence
                                                       select new CxP_ProveedoresMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Saldo = item.Saldo,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();
                foreach (var item in lista)
                {
                    item.Dias = Utilitatios.DateTimeExtension.DateDiff(Utilitatios.DateInterval.Day, item.Vence.Value, DateTime.Today);
                }
                return lista.ToList();
            }
        }
        public static List<CxP_ProveedoresMovimiento> CxP_ListadoPagosxLapso(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Credito > 0 && item.Fecha >= desde && item.Fecha <= hasta
                                                       orderby item.Vence
                                                       select new CxP_ProveedoresMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Credito = item.Credito,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();

                return lista.ToList();
            }
        }
        public static List<CxP_ProveedoresMovimiento> CxP_ProveedoresMovimientoLapso(DateTime desde, DateTime hasta, Tercero proveedore)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Fecha >= desde && item.Fecha <= hasta
                                                       orderby item.Fecha
                                                       select new CxP_ProveedoresMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Credito = item.Credito,
                                                       Debito = item.Debito,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();
                //if (proveedore != null ? proveedore.ID != null : false)
                //{
                //    lista = lista.Where(item => item.TerceroID == proveedore.ID).ToList();
                //}
                return lista.ToList();
            }
        }
        #endregion
        #region CxC
        public class CxC_TercerosMovimiento : TercerosMovimiento
        {
            public long? Dias { set; get; }
            public string RazonSocial { set; get; }
            public string CuentaCorriente { set; get; }
            public string Banco { set; get; }
            public string Rif { set; get; }
            public string Email { set; get; }
        }
        public static List<CxC_TercerosMovimiento> CxC_ListadoVencimientosFecha(DateTime fecha)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Saldo > 0 && item.Vence <= fecha
                                                       orderby item.Vence
                                                       select new CxC_TercerosMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Saldo = item.Saldo,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();
                foreach (var item in lista)
                {
                    item.Dias = Utilitatios.DateTimeExtension.DateDiff(Utilitatios.DateInterval.Day, item.Vence.Value, fecha);
                }
                return lista.ToList();
            }
        }
        public static List<CxC_TercerosMovimiento> CxC_ListadoGeneral()
        {
            using (var db = new DatosEntities())
            {
                var result = new List<CxC_TercerosMovimiento>();

                var lista = from item in db.TercerosMovimientos
                                where item.Saldo > 0
                                orderby item.Vence
                                select item;
                foreach (var item in lista.ToList())
                {
                    var newItem = new CxC_TercerosMovimiento()
                   {
                        Fecha = item.Fecha,
                        Vence = item.Vence,
                        Tipo = item.Tipo,
                        Concepto = item.Concepto,
                        Saldo = item.Saldo,
                        RazonSocial = item.Tercero.RazonSocial,
                        Numero = item.Numero,
                        Dias =  Utilitatios.DateTimeExtension.DateDiff(Utilitatios.DateInterval.Day, item.Vence.Value, DateTime.Today)
                    };
                    result.Add(newItem);
                }
                return result.ToList();
            }
        }
        public static List<CxC_TercerosMovimiento> CxC_ListadoCobrosxLapso(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Credito > 0 && item.Fecha >= desde && item.Fecha <= hasta
                                                       orderby item.Vence
                                                       select new CxC_TercerosMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Credito = item.Credito,
                                                       Debito = item.Debito,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();

                return lista.ToList();
            }
        }
        public static List<CxC_TercerosMovimiento> CxC_TercerosMovimientoLapso(DateTime desde, DateTime hasta, Tercero cliente)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from item in db.TercerosMovimientos
                                                       where item.Fecha >= desde && item.Fecha <= hasta
                                                       orderby item.Fecha
                                                       select new CxC_TercerosMovimiento
                                                       {
                                                       Fecha = item.Fecha,
                                                       Vence = item.Vence,
                                                       Tipo = item.Tipo,
                                                       Concepto = item.Concepto,
                                                       Credito = item.Credito,
                                                       Debito = item.Debito,
                                                       RazonSocial = item.Tercero.RazonSocial,
                                                       Numero = item.Numero
                                                       }).ToList();
                //if (cliente != null ? cliente.ID != null : false)
                //{
                //    lista = lista.Where(item => item.TerceroID == cliente.ID).ToList();
                //}
                return lista.ToList();
            }
        }
        #endregion
        #endregion
    }
}
