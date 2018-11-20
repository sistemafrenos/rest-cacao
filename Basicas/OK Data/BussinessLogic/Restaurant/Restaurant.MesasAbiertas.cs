using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant
    {

        // Metodos Para Mesas Abiertas
        public MesasAbierta FindMesaAbierta(string id)
        {
            return data.MesaAbiertaRepository.Find(id);
        }
        public MesasAbierta GetByCodigoMesaAbierta(string codigoMesa)
        {
            var result = data.MesaAbiertaRepository.dbSet.FirstOrDefault(d => d.CodigoMesa == codigoMesa);
            if (result != null)
            {
                result.EsNuevo = false;
                return result;
            }
            result = new MesasAbierta();
            var mesa = GetByCodigoMesa(codigoMesa);
            if (mesa != null)
            {
                result.CobraServicio = mesa.CobraServicio;
                result.Ubicacion = mesa.Ubicacion;
                result.CodigoMesa = codigoMesa;
            }
            return result;
        }
        public string GuardarMesaAbierta(MesasAbierta entity)
        {
            MesasAbierta newEntity = new MesasAbierta()
            {
                Apertura = entity.Apertura,
                Bloqueada = entity.Bloqueada,
                Descuentos = entity.Descuentos,
                CedulaRif = entity.CedulaRif,
                CobraServicio = entity.CobraServicio,
                CodigoMesa = entity.CodigoMesa,
                Direccion = entity.Direccion,
                Email = entity.Email,
                Estacion = entity.Estacion,
                ImpresaPor = entity.ImpresaPor,
                MesasAbiertasProductos = new List<MesasAbiertasProducto>(),
                Mesonero = entity.Mesonero,
                MesoneroID = entity.MesoneroID,
                MontoExento = entity.MontoExento,
                MontoGravable = entity.MontoGravable,
                MontoIva = entity.MontoIva,
                MontoServicio = entity.MontoServicio,
                MontoTotal = entity.MontoTotal,
                Numero = entity.Numero,
                NumeroImpresiones = entity.NumeroImpresiones,
                Personas = entity.Personas,
                RazonSocial = entity.RazonSocial,
                Telefonos = entity.Telefonos,
                TieneBebidas = entity.TieneBebidas,
                TieneComidas = entity.TieneComidas,
                TieneEventos = entity.TieneEventos,
                TipoPrecio = entity.TipoPrecio,
                Ubicacion = entity.Ubicacion,
                UltimaImpresion = entity.UltimaImpresion
            };
            foreach (var subEntity in entity.MesasAbiertasProductos)
            {
                newEntity.MesasAbiertasProductos.Add(new MesasAbiertasProducto()
                {
                    Alerta = subEntity.Alerta,
                    Anulado = subEntity.Anulado,
                    Cantidad = subEntity.Cantidad,
                    Codigo = subEntity.Codigo,
                    Comentario = subEntity.Comentario,
                    Costo = subEntity.Costo,
                    Departamento = subEntity.Departamento,
                    Descripcion = subEntity.Descripcion,
                    EnviarComanda = subEntity.EnviarComanda,
                    Hora = subEntity.Hora,
                    LlevaInventario = subEntity.LlevaInventario,
                    Mesonero = subEntity.Mesonero,
                    NumeroComanda = subEntity.NumeroComanda,
                    Precio = subEntity.Precio,
                    PrecioConIva = subEntity.PrecioConIva,
                    ProductoID = subEntity.ProductoID,
                    TasaIva = subEntity.TasaIva,
                    Total = subEntity.Total,
                    TotalBase = subEntity.TotalBase
                });
            }
            newEntity.Totalizar();
            if (!data.IsValid(newEntity))
                return data.ValidationErrors(newEntity);
            if (entity.EsNuevo != true)
            {
                try
                {
                    var partialEntity = data.context.MesasAbiertas.FirstOrDefault(x => x.ID == entity.ID);
                    if (partialEntity != null)
                    {
                        data.context.MesasAbiertas.Remove(partialEntity);
                        data.context.SaveChanges();
                    }
                }
                catch (Exception x) {
                    return  OK.ManejarException(x);
                }
            }
            else
            {
                newEntity.Apertura = DateTime.Now;
                newEntity.Numero = GetContador(string.Format("MesaAbierta-{0}", DateTime.Today.ToShortDateString()));
            }
            data.context.MesasAbiertas.Add(newEntity);
            try
            {
                 data.context.SaveChanges();
            }
            catch (Exception ex)
            {
                return OK.ManejarException(ex);
            }
            return null;
        }
        public List<MesasAbiertasProducto> GetMesaProductos(MesasAbierta entity)
        {
            var retorno = new List<MesasAbiertasProducto>();
            foreach (var subEntity in entity.MesasAbiertasProductos)
            {
                retorno.Add(new MesasAbiertasProducto()
                {
                    Alerta = subEntity.Alerta,
                    Anulado = subEntity.Anulado,
                    Cantidad = subEntity.Cantidad,
                    Codigo = subEntity.Codigo,
                    Comentario = subEntity.Comentario,
                    Costo = subEntity.Costo,
                    Departamento = subEntity.Departamento,
                    Descripcion = subEntity.Descripcion,
                    EnviarComanda = subEntity.EnviarComanda,
                    Hora = subEntity.Hora,
                    LlevaInventario = subEntity.LlevaInventario,
                    Mesonero = subEntity.Mesonero,
                    NumeroComanda = subEntity.NumeroComanda,
                    Precio = subEntity.Precio,
                    PrecioConIva = subEntity.PrecioConIva,
                    ProductoID = subEntity.ProductoID,
                    TasaIva = subEntity.TasaIva,
                    Total = subEntity.Total,
                    TotalBase = subEntity.TotalBase
                });
            }
            return retorno;
        }
        public string SepararMesa(MesasAbierta mesa, string mesaNueva, List<MesasAbiertasProducto> productosOriginales, List<MesasAbiertasProducto> productosNuevos)
        {
            string result = null;
            MesasAbierta MesaIzquierda = new MesasAbierta();
            MesaIzquierda.CodigoMesa = mesa.CodigoMesa;
            MesaIzquierda.CobraServicio = mesa.CobraServicio;
            MesaIzquierda.Bloqueada = true;
            MesaIzquierda.Apertura = mesa.Apertura;
            MesaIzquierda.CedulaRif = mesa.CedulaRif;
            MesaIzquierda.Direccion = mesa.Direccion;
            MesaIzquierda.Email = mesa.Email;
            MesaIzquierda.Mesonero = mesa.Mesonero;
            MesaIzquierda.MesoneroID = mesa.MesoneroID;
            MesaIzquierda.Numero = mesa.Numero;
            MesaIzquierda.RazonSocial = mesa.RazonSocial;
            MesaIzquierda.Ubicacion = mesa.Ubicacion;
            foreach (var item in productosOriginales)
            {
                MesaIzquierda.MesasAbiertasProductos.Add(item);
            }
            MesasAbierta MesaDerecha = new MesasAbierta();
            MesaDerecha.CodigoMesa = mesaNueva;
            MesaDerecha.CobraServicio = mesa.CobraServicio;
            MesaDerecha.Bloqueada = true;
            MesaDerecha.Apertura = mesa.Apertura;
            MesaDerecha.CedulaRif = mesa.CedulaRif;
            MesaDerecha.Direccion = mesa.Direccion;
            MesaDerecha.Email = mesa.Email;
            MesaDerecha.Mesonero = mesa.Mesonero;
            MesaDerecha.MesoneroID = mesa.MesoneroID;
            MesaDerecha.Numero = mesa.Numero;
            MesaDerecha.RazonSocial = mesa.RazonSocial;
            MesaDerecha.Ubicacion = mesa.Ubicacion;
            foreach (var item in productosNuevos)
            {
                MesaDerecha.MesasAbiertasProductos.Add(item);
            }
            EliminarMesaAbierta(mesa);
            result = GuardarMesaAbierta(MesaIzquierda);
            if (result != null)
                return result;
            result = GuardarMesaAbierta(MesaDerecha);
            if (result != null)
                return result;
            return data.Save();
        }
        public void EliminarMesaAbierta(MesasAbierta mesa)
        {
            try
            {
                var partialEntity = data.context.MesasAbiertas.FirstOrDefault(x => x.ID == mesa.ID);
                if (partialEntity != null)
                {
                    data.context.MesasAbiertas.Remove(partialEntity);
                    data.context.SaveChanges();
                }
            }
            catch (Exception x)
            {
                string s = OK.ManejarException(x);
            }
        }
        public Mesa[] GetMesasAbiertasSalon(string salon, Mesa[] mesasCache)
        {
            var mesas = mesasCache.Where(d => d.Ubicacion == salon).ToList();
            var items = data.MesaAbiertaRepository.GetAsQueryable(null).ToList();
            foreach (var item in mesas)
            {
                if (mesas.FirstOrDefault(d => d.Codigo == item.Codigo) == null)
                {
                    var nuevo = new Mesa() { Codigo = item.Codigo, CobraServicio = item.CobraServicio };
                    mesas.Add(nuevo);
                }
                var mesaAbierta = items.Where(d => d.CodigoMesa == item.Codigo).FirstOrDefault();
                if (mesaAbierta == null)
                {
                    mesaAbierta = new MesasAbierta();
                }
                item.Apertura = mesaAbierta.Apertura;
                item.Mesonero = mesaAbierta.Mesonero;
                item.NumeroImpresiones = mesaAbierta.NumeroImpresiones;
                item.UltimaImpresion = mesaAbierta.UltimaImpresion;
                item.Monto = mesaAbierta.MontoTotal;
                item.Bloqueada = mesaAbierta.Bloqueada;
                item.TieneBebidas = mesaAbierta.TieneBebidas;
                item.TieneComidas = mesaAbierta.TieneComidas;
                item.RazonSocial = mesaAbierta.RazonSocial;
            }
            var p = from x in mesas
                    orderby x.Codigo
                    select x;
            return p.ToArray();
        }
        public Mesa[] GetMesasAbiertasSalon(string salon)
        {

            var Qmesas = data.MesaRepository.GetAsQueryable(null);
            if (salon != null)
                Qmesas = Qmesas.Where(d => d.Ubicacion == salon);
            var Qitems = data.MesaAbiertaRepository.GetAsQueryable(null);
            if (salon != null)
                Qitems = Qitems.Where(d => d.Ubicacion == salon);
            var mesas = Qmesas.ToList();
            var items = Qitems.ToList();
            foreach (var item in items)
            {
                if (mesas.FirstOrDefault(d => d.Codigo == item.CodigoMesa) == null)
                {
                    var nuevo = new Mesa() { Codigo = item.CodigoMesa, CobraServicio = item.CobraServicio };
                    mesas.Add(nuevo);
                }
            }
            foreach (var item in mesas)
            {
                var mesaAbierta = data.MesaAbiertaRepository.GetFirst(d => d.CodigoMesa == item.Codigo);
                if (mesaAbierta == null)
                {
                    mesaAbierta = new MesasAbierta();
                }
                item.Apertura = mesaAbierta.Apertura;
                item.Mesonero = mesaAbierta.Mesonero;
                item.NumeroImpresiones = mesaAbierta.NumeroImpresiones;
                item.UltimaImpresion = mesaAbierta.UltimaImpresion;
                item.Monto = mesaAbierta.MontoTotal;
                item.Bloqueada = mesaAbierta.Bloqueada;
                item.TieneBebidas = mesaAbierta.TieneBebidas;
                item.TieneComidas = mesaAbierta.TieneComidas;
                item.RazonSocial = mesaAbierta.RazonSocial;
            }
            var p = from x in mesas
                    orderby x.Codigo
                    select x;
            return p.ToArray();
        }
        public string UnirMesas(MesasAbierta mesaAbierta, MesasAbierta nuevaMesaAbierta)
        {
            if (!data.IsValid(nuevaMesaAbierta))
                return data.ValidationErrors(nuevaMesaAbierta);
            foreach (var item in mesaAbierta.MesasAbiertasProductos)
            {
                item.MesasAbierta = null;
                nuevaMesaAbierta.MesasAbiertasProductos.Add(item);
            }
            EliminarMesaAbierta(mesaAbierta);
            return GuardarMesaAbierta(nuevaMesaAbierta);
        }
        public string CambioDeMesa(MesasAbierta mesaAbierta, string nuevoCodigoMesa)
        {
            var mesa = GetByCodigoMesa(nuevoCodigoMesa);
            if (mesa != null)
                mesaAbierta.CobraServicio = mesa.CobraServicio;
            mesaAbierta.CodigoMesa = nuevoCodigoMesa;
            return GuardarMesaAbierta(mesaAbierta);
        }
        public string ValidarMesaAbierta(MesasAbierta doc)
        {
            if (!data.IsValid(doc))
                return data.ValidationErrors(doc);
            foreach (var item in doc.MesasAbiertasProductos)
            {
                if (!data.IsValid(item))
                    return data.ValidationErrors(item);
            }
            return null;
        }
    }
}
