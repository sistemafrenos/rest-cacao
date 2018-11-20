using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant
    {
        // Metodos Para Mesas Cerradas
        public MesasCerrada[] GetByFechasTipoMesasCerradas(DateTime inicio, DateTime final, string tipo)
        {
            IEnumerable<MesasCerrada> consulta;
            switch (tipo)
            {
                case "TICKET":
                    consulta = data.MesaCerradaRepository.GetAsNoTracking(x=> x.Tipo == "TICKET" && x.Fecha >= inicio && x.Fecha <= final);
                    break;
                case "TODO":
                    consulta = data.MesaCerradaRepository.GetDbSet().Where(x => x.Fecha >= inicio && x.Fecha <= final);
                    break;
                default:
                    consulta = data.MesaCerradaRepository.GetAsNoTracking(x => x.Factura != null && x.Fecha >= inicio && x.Fecha <= final);
                    break;
            }
            return consulta.ToArray();
        }
        // Metodos para Mesas Cerradas
        public MesasCerrada CreateMesaCerrada(MesasAbierta mesaAbierta)
        {
            var retorno = new MesasCerrada()
            {
                Apertura = mesaAbierta.Apertura,
                Fecha = DateTime.Today,
                CedulaRif = mesaAbierta.CedulaRif,
                Cierre = DateTime.Now,
                CodigoMesa = mesaAbierta.CodigoMesa,
                NumeroImpresiones = mesaAbierta.NumeroImpresiones,
                Personas = mesaAbierta.Personas,
                RazonSocial = mesaAbierta.RazonSocial,
                Ubicacion = mesaAbierta.Ubicacion,
                Mesonero = mesaAbierta.Mesonero,
                CobraServicio = mesaAbierta.CobraServicio,
                NumeroLote = GetLote()
            };
            foreach (MesasAbiertasProducto item in mesaAbierta.MesasAbiertasProductos.Where(x => x.Cantidad.GetValueOrDefault(0) > 0))
            {
                MesasCerradasProducto newItem = new MesasCerradasProducto()
                {
                    Cantidad = item.Cantidad,
                    Codigo = item.Codigo,
                    Costo = item.Costo,
                    Departamento = item.Departamento,
                    Descripcion = item.Descripcion,
                    Hora = item.Hora,
                    Mesonero = item.Mesonero,
                    NumeroComanda = item.NumeroComanda,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Total = item.Total,
                    ProductoID = item.ProductoID,
                    NumeroLote = retorno.NumeroLote,
                    Anulado = item.Anulado,
                    LlevaInventario = item.LlevaInventario
                };
                retorno.MesasCerradasProductos.Add(newItem);
            }
            retorno.Totalizar();
            return retorno;
        }
        public void InsertMesaCerrada(MesasCerrada mesaCerrada)
        {
            // Completar MesasCerrada
            mesaCerrada.Numero = GetContador("CERRADAS");
            if (mesaCerrada.Tipo != "ANULADA")
                mesaCerrada.Totalizar();
            // Validar MesasCerrada
            if (!data.IsValid(mesaCerrada))
            {
                throw new Exception(data.ValidationErrors(mesaCerrada));
            }
            data.MesaCerradaRepository.Insert(mesaCerrada);
        }
        // Metodos para Facturas
        public Factura CreateFactura(MesasCerrada mesaCerrada)
        {
            Factura retorno = new Factura();
            retorno.Tipo = "FACTURA";
            retorno.Anulado = false;
            retorno.Estatus = "CERRADA";
            retorno.CedulaRif = mesaCerrada.CedulaRif;
            retorno.Email = mesaCerrada.Email;
            retorno.Telefonos = mesaCerrada.Telefonos;
            retorno.RazonSocial = mesaCerrada.RazonSocial;
            retorno.Comentarios = mesaCerrada.Comentarios;
            retorno.Descuentos = mesaCerrada.Descuentos;
            retorno.Direccion = mesaCerrada.Direccion;
            retorno.Fecha = DateTime.Today;
            retorno.NumeroOrden = mesaCerrada.CodigoMesa;
            // Pendiente
            retorno.TasaIva = Parametros.TasaIva;
            retorno.TasaIvaB = Parametros.TasaIvaB;
            //
            foreach (var item in mesaCerrada.MesasCerradasProductos.Where(x => x.Anulado != true && x.Cantidad.GetValueOrDefault(0) > 0))
            {
                DocumentosProducto detalle = new DocumentosProducto()
                {

                    Cantidad = item.Cantidad,
                    Codigo = item.Codigo,
                    Costo = item.Costo,
                    Descripcion = item.Descripcion,
                    Departamento = item.Departamento,
                    ProductoID = item.ProductoID,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Fecha = DateTime.Today,
                    LlevaInventario = item.LlevaInventario
                };
                detalle.Calcular();
                retorno.DocumentosProductos.Add(detalle);
            }
            if (mesaCerrada.CobraServicio == true)
            {
                DocumentosProducto detalle = new DocumentosProducto()
                {

                    Cantidad = 1,
                    Codigo = "SERVICIO",
                    Costo = mesaCerrada.MontoServicio,
                    Descripcion = string.Format("SERVICIO EN {0}",mesaCerrada.Ubicacion),//  data.RestaurantConfig.ConceptoServicio,
                    ProductoID = "SERVICIO",
                    Precio = mesaCerrada.MontoServicio,
                    PrecioConIva = mesaCerrada.MontoServicio,
                    TasaIva = 0,
                    Fecha = DateTime.Today,
                };
                detalle.Calcular();
                retorno.DocumentosProductos.Add(detalle);
            }
            retorno.Calcular();
            return retorno;
        }
        public string ValidarMesaCerrada(MesasCerrada doc)
        {
            if (!data.IsValid(doc))
                return data.ValidationErrors(doc);
            foreach (var item in doc.MesasCerradasProductos)
            {
                if (!data.IsValid(item))
                    return data.ValidationErrors(item);
            }
            return null;
        }
    }
}
