using System;
using System.Collections.Generic;
using System.Linq;
using HK.BussinessLogic;

namespace HK
{
    public class Consultas
    {
        public static List<Resumen> ResumenLapsoxVendedor(DateTime desde, DateTime hasta, Vendedor vendedor)
        {
            using (var db = new DatosEntities())
            {
                double Porcentaje = 0; 
                List<Resumen> lista = new List<Resumen>();
                var consulta = from q in db.Documentos.Where(x => x.Tipo == "FACTURA"  || x.Tipo == "TICKET")
                               where (q.Fecha >= desde && q.Fecha <= hasta && (q.Anulado == false || q.Anulado == null))
                               select q;
                if (vendedor.CedulaRif != null)
                {
                    consulta = from q in consulta
                               where q.CodigoVendedor == vendedor.Codigo
                               select q;
                    Porcentaje = vendedor.PorcentajeComision.GetValueOrDefault();
                }
                var consultaDos = (from q in consulta
                                   orderby q.Fecha
                                   group q by new { q.Fecha, q.Vendedor }
                                       into ResumenxFecha
                                       select new Resumen
                                       {
                                           Fecha = ResumenxFecha.Key.Fecha,
                                           Descripcion = ResumenxFecha.Key.Vendedor,
                                           Cantidad = ResumenxFecha.Where(x => x.Tipo == "TICKET").Sum(x => x.MontoTotal),
                                           Bolivares = ResumenxFecha.Where(x => x.Tipo == "FACTURA").Sum(x => x.MontoTotal),
                                           Porcentaje = Porcentaje
                                       }).ToList();
                foreach(var item in consultaDos)
                {
                    item.Comision = (item.Cantidad.GetValueOrDefault()+
                                     item.Bolivares.GetValueOrDefault()
                                     ) * (Porcentaje/100);
                }
                return consultaDos;
            }

        }

        public static List<ReportViews.TotalxDia> VentasDiariasxLapso(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Documentos
                               where (q.Fecha >= desde && q.Fecha <= hasta && q.Anulado == false)
                               group q by q.Fecha
                                   into ventaxDia
                                   select new ReportViews.TotalxDia
                                   {
                                       Fecha = ventaxDia.Key,
                                       Facturas = (int)ventaxDia.Count(),
                                       Promedio = (double)ventaxDia.Average(x => x.MontoTotal),
                                       Bolivares = (double)ventaxDia.Sum(x => x.MontoTotal),
                                       MontoGravable = (double)ventaxDia.Sum(x => x.MontoGravable),
                                       MontoIva = (double)ventaxDia.Sum(x => x.MontoIva),
                                       MontoExento = (double)ventaxDia.Sum(x => x.MontoExento),
                                       MontoTotal = (double)ventaxDia.Sum(x => x.MontoTotal)
                                   };
                return consulta.ToList();
            }
        }
        public static List<ReportViews.ComprasxGrupo> ComprasxGrupo(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var items = from compra in db.Documentos
                            join compraitem in db.DocumentosProductos on compra.ID equals compraitem.Documento.ID
                            join producto in db.Productos on compraitem.ProductoID equals producto.ID
                            where compra.Fecha >= desde && compra.Fecha <= hasta && compra.Tipo == "COMPRA"
                            select new ReportViews.ComprasxGrupo
                            {
                                Departamento = producto.Departamento,
                                MontoProductosVendidos = compraitem.CostoNeto.Value * compraitem.Entrada.Value,
                                ProductosVendidos = compraitem.Entrada.Value
                            };
                var ResumenxProducto = from p in items
                                       group p by p.Departamento
                                           into comprasxGrupo
                                           select new ReportViews.ComprasxGrupo
                                           {
                                               Departamento = comprasxGrupo.Key,
                                               MontoProductosVendidos = comprasxGrupo.Sum(x => x.MontoProductosVendidos),
                                               ProductosVendidos = comprasxGrupo.Sum(x => x.ProductosVendidos)
                                           };
                return ResumenxProducto.Where(x => x.MontoProductosVendidos > 0).ToList();
            }
        }

        public static List<ReportViews.TotalxDia> VentasDiariasxMesonero(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.MesasCerradas
                               where (q.Apertura.Value >= desde && q.Apertura.Value <= hasta)
                               group q by new { q.Apertura, q.Mesonero }
                                   into ventaxDia
                                   select new ReportViews.TotalxDia
                                   {
                                       Fecha = ventaxDia.Key.Apertura.Value,
                                       Mesonero = ventaxDia.Key.Mesonero,
                                       Facturas = (int)ventaxDia.Count(),
                                       Bolivares = (double)ventaxDia.Sum(x => x.MontoTotal)
                                   };
                return consulta.ToList();
            }
        }
        public static List<Documento> LibroDeVentas(DateTime fecha)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Documentos
                               where (q.Fecha.Month >= fecha.Month && q.Fecha.Year <= fecha.Year) && q.Tipo == "FACTURA"
                               orderby q.Numero
                               select q;
                List<Documento> x = consulta.ToList();
                return x;
            }
        }
        public static List<Documento> FacturasDiariasxLapso(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Documentos
                               where (q.Fecha >= desde && q.Fecha <= hasta && q.Anulado == false) && (q.Tipo == "FACTURA")
                               select q;
                return consulta.ToList();
            }
        }
        public static List<Documento> ConsumoDiariosxLapso(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Documentos
                               where (q.Fecha >= desde && q.Fecha <= hasta && q.Anulado == false) && (q.Tipo == "CONSUMO")
                               select q;
                return consulta.ToList();
            }
        }
        public static List<Documento> FacturasDiariasxLapso(DateTime desde, DateTime hasta, Usuario cajero)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Documentos
                               where (q.Fecha >= desde && q.Fecha <= hasta && q.Anulado == false) && (q.Tipo == "FACTURA")
                               select q;
                return consulta.ToList();
            }
        }
        public static List<Vale> ValesDiariosxLapso(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Vales
                               where (q.Fecha.Value >= desde && q.Fecha.Value <= hasta)
                               select q;
                return consulta.ToList();
            }
        }
        public static List<Vale> ValesDiariosxLapso(DateTime desde, DateTime hasta, Usuario cajero)
        {
            using (var db = new DatosEntities())
            {
                var consulta = from q in db.Vales
                               where (q.Fecha.Value >= desde && q.Fecha.Value <= hasta) && q.IdCajero == cajero.ID
                               select q;
                return consulta.ToList();
            }
        }
        public static List<ReportViews.VentasxProducto> VentasxProducto(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var q = from factura in db.Documentos
                        join facturaproducto in db.DocumentosProductos on factura.ID equals facturaproducto.Documento.ID
                        orderby facturaproducto.Descripcion
                        where factura.Fecha >= desde && factura.Fecha <= hasta
                        group facturaproducto by facturaproducto.Descripcion
                            into ventaxGrupo
                            select new ReportViews.VentasxProducto
                            {
                                Descripcion = ventaxGrupo.Key,
                                VentasBolivares = ventaxGrupo.Sum(x => x.Total),
                                VentasUnidades = ventaxGrupo.Sum(x => x.Cantidad)
                            };
                return q.ToList();
            }
        }
        public static List<Documento> VentasLapsoxVendedor(DateTime desde, DateTime hasta, Vendedor vendedor)
        {
         using (var db = new DatosEntities())
            {
                var consulta = from q in db.Documentos.Where(x=>x.Tipo=="FACTURA")
                               where (q.Fecha >= desde && q.Fecha <= hasta && (q.Anulado == false || q.Anulado == null) )
                               orderby q.Numero
                               select q;
                if (vendedor.CedulaRif != null)
                {
                    consulta = from q in consulta
                               where q.CodigoVendedor == vendedor.Codigo
                               orderby q.Numero
                               select q;
                }
                return consulta.ToList();
            }
        }
        public static System.Collections.IEnumerable ResumenVentasTaxis(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var ListaFacturas = from factura in db.Documentos
                                    where factura.Fecha >= desde && factura.Fecha <= hasta && factura.Tipo == "FACTURA"
                                    select factura;
                foreach (var item in ListaFacturas.ToList())
                {
                    Tercero cliente = db.Terceros.Where(x => x.CedulaRif == item.CedulaRif).FirstOrDefault();
                    item.Comentarios = cliente.Categoria;
                }
                var Paso1 = from factura in ListaFacturas.ToList()
                            select new
                            {
                                Categoria = factura.Comentarios,
                                Contado = factura.Saldo > 0 ? factura.MontoTotal - factura.Saldo : factura.MontoTotal,
                                Credito = factura.Saldo
                            };
                var Paso2 = from j in Paso1
                            group j by j.Categoria
                                into ventaxCategoria
                                select new
                                {
                                    Categoria = ventaxCategoria.Key,
                                    Contado = ventaxCategoria.Sum(x => x.Contado),
                                    Credito = ventaxCategoria.Sum(x => x.Credito)
                                };
                return Paso2.ToList();
            }
        }
        public static List<Producto> ExistenciasxProveedor(Tercero proveedore)
        {
            using (var db = new DatosEntities())
            {
                var lista = (from p in db.Productos
                             orderby p.Departamento, p.Descripcion
                             where p.UltimoProveedor == proveedore.RazonSocial
                             select p).ToList();
                return lista;
            }
        }
        public static System.Collections.IEnumerable ChequesEmitidos(DateTime desde, DateTime hasta)
        {
            using (var db = new DatosEntities())
            {
                var lista = from x in db.BancosMovimientos
                            where x.Fecha >= desde && x.Fecha <= hasta
                            select x;

                return lista.ToList();

            }
        }
    }
}
