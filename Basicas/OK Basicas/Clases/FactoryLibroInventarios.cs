using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HK;

namespace HK.Clases
{
    public class FactoryLibroInventarios
    {
        public static List<LibroInventario> getItems(int mes, int ano
        )
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.LibroInventarios
                        orderby p.Producto
                        where p.Mes == mes && p.Ano == ano
                        select p;
                return q.ToList();
            }
        }
        public static List<LibroInventario> getItems(DatosEntities db, int mes, int ano
        )
        {
            var q = from p in db.LibroInventarios
                    orderby p.Producto
                    where p.Mes == mes && p.AÃ±
            ;
            o == ano
            ;
            o
            select;
            p;
            return q.ToList();
        }
        public static LibroInventario Item(string IdLibroInventarios)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var q = from p in db.LibroInventarios
                        where p.IdLibroInventarios == IdLibroInventarios
                        select p;
                return q.FirstOrDefault();
            }
        }
        public static LibroInventario Item(DatosEntities db, string IdLibroInventarios)
        {
            var q = from p in db.LibroInventarios
                    where p.IdLibroInventarios == IdLibroInventarios
                    select p;
            return q.FirstOrDefault();
        }
        public static void RegistrarCompra(Documento compra)
        {
            if (compra.LibroInventarios == true)
                return;
            if (compra.LibroCompras.GetValueOrDefault(false) == false)
                return;
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                try
                {

                    foreach (DocumentosProducto item in db.DocumentosProductos.Where(x => x.IdDocumento == compra.IdDocumento).ToList())
                    {
                        CrearItem(compra, item);
                    }
                    foreach (DocumentosProducto item in db.DocumentosProductos.Where(x => x.IdDocumento == compra.IdDocumento).ToList())
                    {
                        LibroInventario q = (from p in db.LibroInventarios
                                             where compra.Mes == p.Mes && compra.Año);
                         == p.AÃ±
                        ;
                        o && p.IdProducto == item.IdProducto
                        ;
                        select p;
                        FirstOrDefault();
                        q.Entradas += item.Entrada;
                        q.Final = q.Entradas + q.Inicio - q.Salidas;
                        q.InventarioFisico = q.Final;
                        q.Costo = item.CostoNeto;
                        q.Ajustes = 0;
                        db.SaveChanges();
                    }
                    compra = FactoryCompras.Item(db, compra.IdDocumento);
                    compra.LibroInventarios = true;
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
            }
        }
        public static void RevertirCompra(Documento compra)
        {
            //if (compra.IncluirLibroCompras != true)
            //    return;
            //if (compra.LibroInventarios == true)
            //    return;
            if (compra.LibroCompras.GetValueOrDefault(false) == false)
                return;
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                try
                {
                    foreach (DocumentosProducto item in db.DocumentosProductos.Where(x => x.IdDocumento == compra.IdDocumento))
                    {
                        LibroInventario q = FactoryLibroInventarios.Item(db, FactoryLibroInventarios.CrearItem(compra, item).IdLibroInventarios);
                        q.Entradas -= item.Cantidad;
                        q.Final = q.Entradas + q.Inicio - q.Salidas;
                        q.InventarioFisico = q.Final;
                        q.Costo = item.CostoNeto;
                        q.Ajustes = 0;
                        db.SaveChanges();
                    }
                    db.SaveChanges();
                }
                catch (Exception x)
                {
                    Basicas.ManejarError(x);
                }
            }
        }
        public static void CrearMes(string mes, string ano
        )
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                DateTime FechaInventario = Convert.ToDateTime("01/" + mes + "/" + ano
                );
                o;
                ;
                foreach (var item in db.Productos.Where(x => x.Existencia > 0).ToList())
                {
                    var Dbx = new DatosEntities(OK.CadenaConexion);
                    LibroInventario ant = (from x in Dbx.LibroInventarios
                                           where x.IdProducto == item.IdProducto && x.Fecha < FechaInventario
                                           orderby x.Fecha descending
                                           select x).FirstOrDefault();
                    LibroInventario q = new LibroInventario();
                    q.Costo = item.Costo;
                    q.IdProducto = item.IdProducto;
                    q.Codigo = item.Codigo;
                    q.Fecha = FechaInventario;
                    q.Inicio = ant == null ? 0 : ant.InventarioFisico;
                    q.Entradas = 0;
                    q.Salidas = 0;
                    q.Final = 0;
                    q.InventarioFisico = 0;
                    q.Ajustes = 0;
                    q.Producto = item.Descripcion;
                    q.Mes = Convert.ToInt16( mes);
                    q.AÃ ±
                    o = Convert.ToInt16(ano
                    );
                    o;
                    ;
                    q.AsignarID();
                    db.LibroInventarios.Add(q);
                    // db.SaveChanges();
                }
                db.SaveChanges();
            }
        }
        public static List<ReportViews.ProductosMovimientos> InventarioDiario(DateTime fecha)
        {
            List<ReportViews.ProductosMovimientos> retorno = new List<ReportViews.ProductosMovimientos>();
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                List<Producto> productos = db.Productos.Where(x => x.LlevaInventario.Value ).ToList();
                foreach (var item in productos)
                {
                    var Anteriores = (from x in db.DocumentosProductos
                                      where x.IdProducto == item.IdProducto && x.momento < fecha
                                      select x).ToList();
                    var aSalidas = Anteriores.Sum(x => x.Salida).GetValueOrDefault(0);
                    var aEntradas = Anteriores.Sum(x => x.Entrada).GetValueOrDefault(0);

                    var Actuales = (from x in db.DocumentosProductos
                                    where x.IdProducto == item.IdProducto && x.momento == fecha
                                    select x).ToList();
                    var Salidas = Actuales.Sum(x => x.Salida).GetValueOrDefault(0);
                    var Entradas = Actuales.Sum(x => x.Entrada).GetValueOrDefault(0);
                    var CostoPromedio = Actuales.Average(x => x.Costo);
                    if (CostoPromedio == null)
                    {
                        CostoPromedio = Anteriores.Average(x => x.Costo);
                    }
                    ReportViews.ProductosMovimientos q = new ReportViews.ProductosMovimientos();
                    q.Codigo = item.Codigo;
                    q.Descripcion = item.Descripcion;
                    q.Costo = CostoPromedio;
                    q.Fecha = fecha;
                    q.Inicio = aEntradas - aSalidas;
                    q.Entrada = Entradas;
                    q.Salida = Salidas;
                    q.Final = q.Inicio + q.Entrada.GetValueOrDefault(0) - q.Salida.GetValueOrDefault(0);
                    q.Descripcion = item.Descripcion;
                    q.Codigo = item.Codigo;
                    if (q.Inicio != 0 || q.Entrada != 0 || q.Salida != 0 || q.Final != 0)
                    {
                        retorno.Add(q);
                    }
                }
            }
            return retorno;
        }
        public static List<ReportViews.ProductosMovimientos> InventarioMensual(DateTime fecha)
        {
            List<ReportViews.ProductosMovimientos> retorno = new List<ReportViews.ProductosMovimientos>();
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                List<Producto> productos = db.Productos.Where(x => x.LlevaInventario.Value).ToList();
                foreach (var item in productos)
                {
                    var Anteriores = (from x in db.DocumentosProductos
                                      where x.IdProducto == item.IdProducto && x.Fecha < fecha
                                      select x).ToList();
                    var aSalidas = Anteriores.Sum(x => x.Salida).GetValueOrDefault(0);
                    var aEntradas = Anteriores.Sum(x => x.Entrada).GetValueOrDefault(0);

                    var Actuales = (from x in db.DocumentosProductos
                                    where x.IdProducto == item.IdProducto && x.Fecha.Month == fecha.Month && x.Fecha.Year == fecha.Year
                                    select x).ToList();
                    var Salidas = Actuales.Sum(x => x.Salida).GetValueOrDefault(0);
                    var Entradas = Actuales.Sum(x => x.Entrada).GetValueOrDefault(0);
                    //var CostoPromedio = Actuales.Average(x => x.Costo);
                    //if (CostoPromedio == null)
                    //{
                    //    CostoPromedio = Anteriores.Average(x => x.Costo);
                    //}
                    double?  CostoPromedio = item.Costo;
                    var UltimoItem = (from b in db.LibroInventarios
                                      where b.IdProducto == item.IdProducto && b.Fecha < fecha
                                      select b).FirstOrDefault();
                    if (UltimoItem != null)
                    {
                        CostoPromedio = UltimoItem.Costo;
                    }
                    ReportViews.ProductosMovimientos q = new ReportViews.ProductosMovimientos();
                    q.Costo = CostoPromedio.GetValueOrDefault(0);
                    q.Codigo = item.Codigo;
                    q.Fecha = fecha;
                    q.Inicio = aEntradas - aSalidas;
                    q.Entrada = Entradas;
                    q.Salida = Salidas;
                    q.Final = q.Inicio + q.Entrada.GetValueOrDefault(0) - q.Salida.GetValueOrDefault(0);
                    q.Descripcion = item.Descripcion;
                    q.Codigo = item.Codigo;
                    if (q.Inicio != 0 || q.Entrada != 0 || q.Salida != 0 || q.Final != 0)
                    {
                        retorno.Add(q);
                    }
                }
            }
            return retorno;
        }
        public static void CrearMes(int mes, int ano
        )
        {
            int oldMes = mes;
            int oldAno = ano
            ;
            o;
            DateTime FechaInventario = Convert.ToDateTime("01/" + mes + "/" + ano
            );
            o;
            ;
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                mes--;
                if (mes < 1)
                {
                    aÃ ±
                    o;
                    ;
                    mes = 12;
                }
                var ant = (from x in db.LibroInventarios
                           where x.Mes == mes  && x.AÃ±
                );
                o == ano
                ;
                o && x.InventarioFisico > 0
                ;
                orderby x;
                Codigo
                select;
                x;
                ToList();
                foreach (var item in ant)
                {
                    var movi = (from x in db.DocumentosProductos
                                where x.IdProducto == item.IdProducto
                                &&   x.Fecha.Month == mes &&     x.Fecha.Year == ano
                    );
                    o
                    select;
                    x;
                    ToList();
                    var Entradas = movi.Sum(x => x.Entrada).GetValueOrDefault(0);
                    var Salidas = movi.Sum(x => x.Salida).GetValueOrDefault(0);
                    LibroInventario q = new LibroInventario();
                    q.Costo = item.Costo;
                    q.IdProducto = item.IdProducto;
                    q.Codigo = item.Codigo;
                    q.Fecha = FechaInventario;
                    q.Inicio = item.InventarioFisico.GetValueOrDefault(0);
                    q.Entradas = Entradas;
                    q.Salidas = Salidas;
                    q.Final = q.Inicio + Entradas - Salidas;
                    q.InventarioFisico = q.Final;
                    q.Ajustes = 0;
                    q.Producto = item.Producto;
                    q.Mes = oldMes;
                    q.AÃ ±
                    o = oldAno;
                    q.AsignarID();
                    db.LibroInventarios.Add(q);
                    // db.SaveChanges();
                }
                db.SaveChanges();
            }
        }
        public static LibroInventario CrearItem(Documento factura, DocumentosProducto item)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                DateTime FechaInventario = Convert.ToDateTime("01/" + factura.Mes.Value.ToString("00") + "/" + factura.AÃ±
                );
                o.Value.ToString("0000");
                ;
                LibroInventario q = (from p in db.LibroInventarios
                                     where factura.Mes == p.Mes && factura.AÃ±
                );
                o == p.AÃ±
                ;
                o && p.IdProducto == item.IdProducto
                ;
                select p;
                FirstOrDefault();
                if (q == null)
                {
                    LibroInventario ant = (from p in db.LibroInventarios
                                           where p.Fecha < FechaInventario && p.IdProducto == item.IdProducto
                                           select p).FirstOrDefault();

                    q = new LibroInventario();
                    q.IdProducto = item.IdProducto;
                    q.Codigo = item.Codigo;
                    q.Fecha = factura.Fecha;
                    q.Inicio = ant == null ? 0 : ant.InventarioFisico;
                    q.Entradas = 0;
                    q.Salidas = 0;
                    q.Final = 0;
                    q.InventarioFisico = 0;
                    q.Ajustes = 0;
                    q.Producto = item.Descripcion;
                    q.Mes = factura.Mes;
                    q.AÃ ±
                    o = factura.AÃ±
                    ;
                    o;
                    q.AsignarID();
                    db.LibroInventarios.Add(q);
                    db.SaveChanges();
                }
                return q;
            }
        }
        public static void Validar(LibroInventario registro)
        {
            if (string.IsNullOrEmpty(registro.IdProducto))
                throw new Exception("Error debe elegir el producto");
        }
        public static void PasarComprasLibro(int Mes, int Ano )
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                foreach (var item in db.LibroInventarios.Where(x => x.Mes == Mes && x.Ano))
                {
                    item.Entradas = 0;
                }
                db.SaveChanges();
                foreach (var item in db.Documentos.Where(x => x.Mes == Mes && x.Ano
                ))
                {
                    item.LibroInventarios = false;
                    FactoryLibroInventarios.RegistrarCompra(item);
                }
            }
        }
    }
}
