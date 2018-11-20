using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        // Productos
        public Producto FindProducto(string id)
        {
            return data.ProductoRepository.Find(id);
        }
        public Producto CloneProducto(object OldItem)
        {
            Producto producto = OK.DeepCopy<Producto>((Producto)OldItem);
            producto.ID = Guid.NewGuid().ToString();
            foreach (var detalle in ((Producto)OldItem).ProductosCompuestos.ToList())
            {
                var x = OK.DeepCopy(detalle);
                x.ID = Guid.NewGuid().ToString();
                x.Producto = null;
                producto.ProductosCompuestos.Add(x);
            }
            return producto;
        }
        public IQueryable<Producto> GetQueryableProductos()
        {
            return data.ProductoRepository.GetDbSet();
        }
        public string SetPrecioProducto(Producto item)
        {
            var prod = FindProducto(item.ID);
            if (prod != null)
            {
                prod.Precio = item.Precio;
                prod.Precio2 = item.Precio2;
                prod.Precio3 = item.Precio3;
                prod.Precio4 = item.Precio4;
                prod.PrecioConIva = item.PrecioConIva;
                prod.PrecioConIva2 = item.PrecioConIva2;
                prod.PrecioConIva3 = item.PrecioConIva3;
                prod.PrecioConIva4 = item.PrecioConIva4;
                data.ProductoRepository.Update(prod);
            }
            return null;
        }
        public string GuardarProducto(Producto entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (VerificarProductoDuplicado(entity) != null)
                return VerificarProductoDuplicado(entity);
            if (FindProducto(entity.ID) == null)
            {
                entity.Activo = true;
                data.ProductoRepository.Insert(entity);
            }
            else
            {
                data.ProductoRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarProducto(Producto Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.ProductoRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string[] GetGruposVentas()
        {
            var datos = data.ProductoRepository.GetDbSet();
            var prod = datos.ToList();
            var retorno = (from x in datos
                           where x.Departamento != null && x.Activo == true && x.HabilitadoParaVentas == true
                           select x.Departamento).Distinct();
            return retorno.ToArray();
        }
        public string[] GetGruposCompras()
        {
            var datos = data.ProductoRepository.GetDbSet();
            var retorno = (from x in datos
                           where x.Departamento != null && x.Activo == true && x.HabilitadoParaCompras == true
                           select x.Departamento).Distinct();
            return retorno.ToArray();
        }
        public Producto[] GetAllProductos(string texto)
        {
            texto = texto.ToUpper();
            var consulta = data.ProductoRepository.GetAsNoTracking(d => d.Activo == true);
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where d.Descripcion.Contains(texto) || d.Codigo.Contains(texto) || d.Departamento.Contains(texto)
                                || d.CodigoBarras == texto
                                || d.CodigoProveedor == texto
                            select d);
            }
            return consulta.OrderBy(d => d.Descripcion).ToArray();
        }
        public Producto[] GetAllProductosVentas(string texto=null, string departamento=null)
        {
            texto = texto.ToUpper();
            var consulta = data.ProductoRepository.Get(d=> d.Activo == true && d.HabilitadoParaVentas == true);
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where  d.Descripcion.Contains(texto) || d.Codigo.Contains(texto) || d.Departamento.Contains(texto)
                                || d.CodigoBarras == texto
                                || d.CodigoProveedor == texto
                            select d);
            }

            if (!string.IsNullOrEmpty(departamento))
            {
                consulta = (from d in consulta
                            where d.Departamento == departamento
                            select d);
            }
            return consulta.OrderBy(d => d.Descripcion).ToArray();
        }
        public Producto[] GetAllProductosSoloVentas(string texto = null, string departamento = null)
        {
            texto = texto.ToUpper();
            var datos = data.ProductoRepository.GetDbSet();
            var consulta = datos.Where(d => d.Activo == true && d.HabilitadoParaVentas == true && d.HabilitadoParaCompras !=true);
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where d.Descripcion.Contains(texto) || d.Codigo.Contains(texto) || d.Departamento.Contains(texto)
                                || d.CodigoBarras == texto
                                || d.CodigoProveedor == texto
                            select d);
            }

            if (!string.IsNullOrEmpty(departamento))
            {
                consulta = (from d in consulta
                            where d.Departamento == departamento
                            select d);
            }
            return consulta.OrderBy(d => d.Descripcion).ToArray();
        }
        public Producto[] GetAllProductosCompras(string texto)
        {
            texto = texto.ToUpper();
            var consulta = data.ProductoRepository.GetAsNoTracking(d => d.Activo == true && d.HabilitadoParaCompras == true);
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where d.Descripcion.Contains(texto) || d.Codigo.Contains(texto) || d.Departamento.Contains(texto)
                                || d.CodigoBarras ==texto
                                || d.CodigoProveedor==texto
                            select d);
            }
            return consulta.OrderBy(d => d.Descripcion).ToArray();
        }
        public Producto[] GetAllProductosSoloCompras(string texto)
        {
            texto = texto.ToUpper();
            var consulta = data.ProductoRepository.GetAsNoTracking(d => d.Activo == true && d.HabilitadoParaCompras == true && d.HabilitadoParaVentas !=true);
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where d.Descripcion.Contains(texto) || d.Codigo.Contains(texto) || d.Departamento.Contains(texto)
                                || d.CodigoBarras == texto
                                || d.CodigoProveedor == texto
                            select d);
            }
            return consulta.OrderBy(d => d.Descripcion).ToArray();
        }
        public string CrearCodigoProducto(string departamento)
        {
            if (string.IsNullOrEmpty(departamento))
                return null;
            if (departamento.Length >= 3)
                return string.Format("{0}{1}", departamento[0], GetContador(departamento.Substring(0, 3)));
            return null;
        }
        public string VerificarProductoDuplicado(Producto current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.ProductoRepository.GetFirst(
                d => d.Descripcion.Equals(current.Descripcion) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    retorno.AppendLine("Descripcion duplicada");
            }
            {
                var x = (data.ProductoRepository.GetFirst(
                d => d.Codigo.Equals(current.Codigo) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    retorno.AppendLine("Codigo Duplicado");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }
        public string ProcesarInventarios(Documento doc,bool guardarAhora)
        {
            foreach (var item in doc.DocumentosProductos.Where(x=> x.LlevaInventario))
            {
                var prod = data.ProductoRepository.Find(item.ProductoID);
                if (prod != null)
                {
                    item.Inicio = prod.Existencia.GetValueOrDefault(0);
                    prod.Existencia = prod.Existencia.GetValueOrDefault(0) - item.Salida.GetValueOrDefault(0) + item.Entrada.GetValueOrDefault(0);
                    item.Final = prod.Existencia;
                    data.ProductoRepository.Update(prod);
                }
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string ProductosActualizarPrecios(Documento doc, bool guardarAhora)
        {
            foreach (var item in doc.DocumentosProductos)
            {
                var prod = data.ProductoRepository.Find(item.ProductoID);
                if (prod != null)
                {
                    if (doc.Tipo == "COMPRA" || doc.Tipo == "CARGA")
                    {
                        prod.Costo = item.CostoNeto;
                        prod.Precio = item.Precio;
                        prod.Precio2 = item.Precio2;
                        prod.Precio3 = item.Precio3;
                        prod.Precio4 = item.Precio4;
                        prod.PrecioConIva = item.PrecioConIva;
                        prod.PrecioConIva2 = item.PrecioConIva2;
                        prod.PrecioConIva3 = item.PrecioConIva3;
                        prod.PrecioConIva4 = item.PrecioConIva4;
                        data.ProductoRepository.Update(prod);
                    }
                }
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public void ProductosCalcularExistencias()
        {
            var Productos = data.ProductoRepository.Get(x => x.LlevaInventario == true).ToList();
            var movimientos = data.DocumentoProductosRepository.GetAsNoTracking(x => x.Entrada != null || x.Salida != null);
            foreach (var item in Productos)
            {
                double? Existen = movimientos.Where(x => x.ProductoID == item.ID && x.Entrada!=null).Sum(x => x.Entrada)
                                - movimientos.Where(x => x.ProductoID == item.ID && x.Salida!=null).Sum(x => x.Salida);
                if (Existen.GetValueOrDefault() != item.Existencia)
                {
                    item.Existencia = Existen;
                    data.ProductoRepository.Update(item);
                }
            }
            data.Save();
        }
        public Producto[] GetAllProductos(string departamento, string proveedor)
        {
            var items = data.ProductoRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty( departamento ))
                items = items.Where(x => x.Departamento == departamento);
            if (!string.IsNullOrEmpty(  proveedor ))
                items = items.Where(x => x.UltimoProveedor == proveedor);
            return items.ToArray();
        }
        public Resumen[] ProductosComprasxGrupo(DateTime desde, DateTime hasta)
        {
            var q = from factura in data.context.Documentos
                    join facturaproducto in data.context.DocumentosProductos on factura.ID equals facturaproducto.Documento.ID
                    orderby facturaproducto.Departamento
                    where factura.Fecha >= desde && factura.Fecha <= hasta && factura.Tipo == "COMPRA"
                    group facturaproducto by facturaproducto.Departamento
                        into ventaxGrupo
                        select new Resumen
                        {   
                            Descripcion = ventaxGrupo.Key,
                            Bolivares = ventaxGrupo.Sum(x => x.Entrada * x.CostoNeto),
                            Cantidad = ventaxGrupo.Sum(x => x.Entrada)
                        };
            return q.ToArray();
        }
        public Resumen[] ProductosComprasxProducto(DateTime desde, DateTime hasta)
        {
            var q = from factura in data.context.Documentos
                    join facturaproducto in data.context.DocumentosProductos on factura.ID equals facturaproducto.Documento.ID
                    orderby facturaproducto.Descripcion
                    where factura.Fecha >= desde && factura.Fecha <= hasta && factura.Tipo == "COMPRA"
                    group facturaproducto by facturaproducto.Descripcion
                        into ventaxGrupo
                        select new Resumen
                        {
                            Descripcion = ventaxGrupo.Key,
                            Bolivares = ventaxGrupo.Sum(x => x.Entrada * x.CostoNeto),
                            Cantidad = ventaxGrupo.Sum(x => x.Entrada)
                        };
            return q.ToArray();
        }
        public ProductosMovimientos[] MovimientosProductosLapso(DateTime desde, DateTime hasta, string ID)
        {
            ProductosMovimientos[] movimientos = 
                (from doc in data.context.Documentos
                    join docProducto in data.context.DocumentosProductos on doc.ID equals docProducto.Documento.ID
                    where
                         doc.Fecha >= desde
                        && doc.Fecha <= hasta
                        && (docProducto.Salida > 0 || docProducto.Entrada > 0)
                        && docProducto.ProductoID == ID
                    orderby docProducto.Fecha
                    select new ProductosMovimientos
                    {
                        Fecha = doc.Fecha,
                        Numero = doc.Numero,
                        RazonSocial = doc.RazonSocial,
                        Concepto = doc.Tipo,
                        Codigo = docProducto.Codigo,
                        Descripcion = docProducto.Descripcion,
                        Costo = docProducto.Costo,
                        Precio = docProducto.Precio,
                        Entrada = docProducto.Entrada,
                        Inicio = docProducto.Inicio,
                        Salida = docProducto.Salida,
                        Final = docProducto.Final
                    }).ToArray();
            return movimientos;
        }
    }
}
