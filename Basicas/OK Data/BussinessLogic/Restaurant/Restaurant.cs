using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant:Administrativo
    {
        private RestaurantConfig restaurantconfig;
        public RestaurantConfig RestaurantConfig
        {
            get
            {
                if (restaurantconfig == null)
                {
                    restaurantconfig = new BussinessLogic.RestaurantConfig();
                }
                return restaurantconfig;
            }
        }
        // Metodos para Grupos y Productos
        public void RegistrarSalidas(Documento doc)
        {
            foreach (var item in doc.DocumentosProductos)
            {
                var prod = data.ProductoRepository.Find(item.ProductoID);
                if (prod != null)
                {
                    if (prod.LlevaInventario == true)
                    {
                        item.Inicio = prod.Existencia.GetValueOrDefault(0);
                        item.Final = item.Inicio - item.Salida.GetValueOrDefault(0);
                        prod.Existencia = prod.Existencia.GetValueOrDefault(0) - item.Salida;
                    }
                }
            }
        }
        // Metodos para Lotes
        private int GetLote()
        {
            var Lote = data.ContadorRepository.GetFirst(x => x.Variable == "LOTE");
            if (Lote == null)
            {
                Lote = new Contador();
                Lote.Valor = 1;
                Lote.Variable = "LOTE";
                data.ContadorRepository.Insert(Lote);
            }
            return Lote.Valor.GetValueOrDefault(0);
        }
        // Resumenes
        public Resumen[] cerradasProductosAnulados(DateTime desde, DateTime hasta)
        {
            var items = from item in data.context.MesasCerradasProductos.Where(x => x.Anulado == true)
                        where item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta
                        group item by item.Descripcion into anuladosxProducto
                        select new Resumen
                        {
                            Descripcion = anuladosxProducto.Key,
                            Cantidad = anuladosxProducto.Sum(d => d.Cantidad),
                            Bolivares = anuladosxProducto.Sum(d => d.Precio * d.Cantidad)
                        };
            return items.ToArray();
        }
        public Resumen[] rpDiarios(DateTime desde, DateTime hasta)
        {
            var sinAnular = data.context.MesasCerradasProductos.Where(x => x.Anulado == null && x.Precio==0);
            var porFecha = sinAnular.Where(item => item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta);
            var items = from item in porFecha
                        group item by item.Descripcion into grupo
                        select new Resumen
                        {
                            Descripcion = grupo.Key,
                            Bolivares = grupo.Sum(x => x.Cantidad * x.Precio),
                            Cantidad = grupo.Sum(x => x.Cantidad)
                        };
            return items.ToArray();
        }
        public Resumen[] cerradasVentasxUbicacion(DateTime desde, DateTime hasta)
        {
            var sinAnular = data.context.MesasCerradasProductos.Where(x => x.Anulado == null);
            var porFecha = sinAnular.Where(item => item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta);
            var items = from item in porFecha
                        group item by item.MesasCerrada.Ubicacion into grupo
                        select new Resumen
                        {
                            Descripcion = grupo.Key,
                            Bolivares = grupo.Sum(x => x.Cantidad * x.Precio),
                            Cantidad = grupo.Sum(x => x.Cantidad)
                        };
            return items.ToArray();
        }
        public Resumen[] cerradasVentasxDepartamento(DateTime desde, DateTime hasta)
        {
            var items = from item in data.context.MesasCerradasProductos.Where(x=>x.Anulado!=true)
                        where item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta
                        group item by item.Departamento into grupo
                        select new Resumen
                        {
                            Descripcion = grupo.Key,
                            Cantidad = grupo.Sum(d => d.Cantidad),
                            Bolivares = grupo.Sum(d => d.Precio * d.Cantidad)
                        };
            return items.ToArray();
        }
        public Resumen[] cerradasVentasxProducto(DateTime desde, DateTime hasta)
        {
            var items = from item in data.context.MesasCerradasProductos.Where(x => x.Anulado != true)
                        where item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta
                        group item by item.Descripcion into grupo
                        select new Resumen
                        {
                            Descripcion = grupo.Key,
                            Cantidad = grupo.Sum(d => d.Cantidad),
                            Bolivares = grupo.Sum(d => d.Precio * d.Cantidad)
                        };
            return items.ToArray();
        }
        public IQueryable cerradasMesasAnuladas(DateTime desde, DateTime hasta)
        {
            var items = from d in data.context.MesasCerradas
                        where d.Fecha >= desde && d.Fecha <= hasta && d.Tipo == "ANULADA"
                        select new 
                        {
                            Numero = d.Numero,
                            CedulaRif = d.CedulaRif,
                            RazonSocial = d.RazonSocial,
                            MontoTotal = d.MontoTotal,
                            Saldo = d.Saldo
                        };
             return items;
        }


        public Resumen[] VentasxMesonero(DateTime desde, DateTime hasta)
        {
            var items = from item in data.context.MesasCerradasProductos.Where(x => x.Anulado == true)
                        where item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta
                        group item by item.Mesonero into grupo
                        select new Resumen
                        {
                            Descripcion = grupo.Key,
                            Cantidad = grupo.Sum(d => d.Cantidad),
                            Bolivares = grupo.Sum(d => d.Precio * d.Cantidad)
                        };
            return items.ToArray();
        }
        public Resumen[] VentasUbicacion(DateTime desde, DateTime hasta)
        {
            var items = from item in data.context.MesasCerradasProductos.Where(x => x.Anulado == true)
                        where item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta
                        group item by item.MesasCerrada.Ubicacion into grupo
                        select new Resumen
                        {
                            Descripcion = grupo.Key,
                            Cantidad = grupo.Sum(d => d.Cantidad),
                            Bolivares = grupo.Sum(d => d.Precio * d.Cantidad)
                        };
            return items.ToArray();
        }
        public bool GuardarProductoInsumo(Producto producto, ProductosCompuesto insumo)
        {
            if(!data.IsValid(insumo))
            {
                return false;
            }

            producto = data.ProductoRepository.Find(producto.ID);
            
            if (insumo.Producto == null)
            {
                producto.ProductosCompuestos.Add(insumo);
              //  data.ProductoCompuestoRepository.dbSet.Add(insumo);
                
            }
            else
            {
                data.ProductoCompuestoRepository.Update(insumo);
            }

            data.Save();
            return true;
        }
    }
}
