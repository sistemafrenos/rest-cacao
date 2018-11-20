using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        // Documentos
        public string ValidarDocumento(Documento doc)
        {
            if (!data.IsValid(doc))
                return data.ValidationErrors(doc);
            foreach (var item in doc.DocumentosProductos)
            {
                if (!data.IsValid(item))
                    return data.ValidationErrors(item);
            }
            return null;
        }
        public T CloneDocumento<T>(T OldItem) where T : Documento, new()
        {
            T documento = new T();
            documento.Fecha = OldItem.Fecha;
            documento.CedulaRif = OldItem.CedulaRif;
            documento.CodigoVendedor = OldItem.CodigoVendedor;
            documento.Comentarios = OldItem.Comentarios;
            documento.Direccion = OldItem.Direccion;
            documento.Email = OldItem.Email;
            documento.Estatus = OldItem.Estatus;
            documento.RazonSocial = OldItem.RazonSocial;
            documento.TasaIva = OldItem.TasaIva;
            documento.Telefonos = OldItem.Telefonos;
            documento.Tipo = OldItem.Tipo;
            documento.TipoPrecio = OldItem.TipoPrecio;
            documento.Vendedor = OldItem.Vendedor;
            foreach (var detalle in OldItem.DocumentosProductos.ToList())
            {
                DocumentosProducto x = new DocumentosProducto();
                x.Cantidad = detalle.Cantidad;
                x.Codigo = detalle.Codigo;
                x.Costo = detalle.Costo;
                x.CostoIva = detalle.CostoIva;
                x.CostoNeto = detalle.CostoNeto;
                x.Departamento = detalle.Departamento;
                x.Descripcion = detalle.Descripcion;
                x.Fecha = DateTime.Today;
                x.Iva = detalle.Iva;
                x.Precio = detalle.Precio;
                x.Precio2 = detalle.Precio2;
                x.PrecioConIva = detalle.PrecioConIva;
                x.PrecioConIva2 = detalle.PrecioConIva2;
                x.ProductoID = detalle.ProductoID;
                x.TasaIva = detalle.TasaIva;
                x.Total = detalle.Total;
                x.UnidadMedida = detalle.UnidadMedida;
                documento.DocumentosProductos.Add(x);
            }
            data.context.Entry(documento).State = System.Data.Entity.EntityState.Detached;
            return documento;
        }
        public Documento[] GetDocumentos(DateTime desde, DateTime hasta)
        {
            var query = data.DocumentosRepository.GetAsQueryable("");
            query = query
                    .Where(x => x.Fecha >= desde && x.Fecha <= hasta)
                    .OrderBy(d => d.Fecha);
            return query.ToArray();
        }
        public Documento[] GetDocumentos(string texto, string tipo, DateTime desde, DateTime hasta)
        {
            var query = data.DocumentosRepository.GetAsQueryable("");
            if (tipo != null)
                query = query.Where(x => x.Tipo == tipo);
            query = query.Where(x => x.Fecha >= desde && x.Fecha <= hasta);
            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(d => (d.RazonSocial.Contains(texto) || d.Numero == texto));
            }
            query = query.OrderBy(d => d.Numero);
            return query.ToArray();
        }
        public Documento[] GetDocumentos(string texto, string tipo, string lapso)
        {
            var query = data.DocumentosRepository.GetAsQueryable("");
            if (tipo != null)
                query = query.Where(x => x.Tipo == tipo);
            switch (lapso)
            {
                case "HOY":
                    query = query.Where(x => x.Fecha == DateTime.Today);
                    break;
                case "AYER":
                    DateTime ayer = DateTime.Today.AddDays(-1);
                    query = query.Where(x => x.Fecha == ayer);
                    break;
                case "ESTE MES":
                    {
                        var desde = OK.MonthFirstDay(DateTime.Today.Month, DateTime.Today.Year);
                        var hasta = OK.MonthLastDay(DateTime.Today.Month, DateTime.Today.Year);
                        query = query.Where(x => x.Fecha >= desde && x.Fecha <= hasta);
                        break;
                    }
                case "MES ANTERIOR":
                    {
                        DateTime fecha = DateTime.Today.AddMonths(-1);
                        var desde = OK.MonthFirstDay(fecha.Month, fecha.Year);
                        var hasta = OK.MonthLastDay(fecha.Month, fecha.Year);
                        query = query.Where(x => x.Fecha >= desde && x.Fecha <= hasta);
                    }
                    break;
            }
            if (!string.IsNullOrEmpty(texto))
            {
                query = query.Where(d => (d.RazonSocial.Contains(texto) || d.Numero == texto));
            }
            query = query.OrderBy(d => d.Numero);
            try
            {
                var items = query.ToArray();
            }
            catch (Exception x)
            {
                string s = x.Message;
            }
            return query.ToArray();
        }
        public void ActualizarPrecios(Documento doc)
        {
            foreach (var registroDetalle in doc.DocumentosProductos)
            {
                Producto producto = FindProducto(registroDetalle.ProductoID);
                if (producto != null)
                {
                    switch (doc.TipoPrecio)
                    {
                        case "PRECIO 1":
                            registroDetalle.Precio = producto.Precio;
                            registroDetalle.PrecioConIva = producto.PrecioConIva;
                            break;
                        case "PRECIO 2":
                            registroDetalle.Precio = producto.Precio2;
                            registroDetalle.PrecioConIva = producto.PrecioConIva2;
                            break;
                        default:
                            registroDetalle.Precio = producto.Precio;
                            registroDetalle.PrecioConIva = producto.PrecioConIva;
                            break;
                    }
                    registroDetalle.Calcular();
                }
            }
            doc.Calcular();
        }
        public Documento CrearDocumento(Documento doc)
        {
            Documento retorno = new Documento();
            retorno.Anulado = false;
            retorno.CedulaRif = doc.CedulaRif;
            retorno.Email = doc.Email;
            retorno.Telefonos = doc.Telefonos;
            retorno.RazonSocial = doc.RazonSocial;
            retorno.Comentarios = doc.Comentarios;
            retorno.Descuentos = doc.Descuentos;
            retorno.Direccion = doc.Direccion;
            retorno.Fecha = DateTime.Today;
            foreach (var item in doc.DocumentosProductos)
            {
                DocumentosProducto detalle = new DocumentosProducto()
                {

                    Cantidad = item.Cantidad,
                    Codigo = item.Codigo,
                    Costo = item.Costo,
                    CostoIva = item.CostoIva,
                    Descripcion = item.Descripcion,
                    Departamento = item.Departamento,
                    ProductoID = item.ProductoID,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Fecha = DateTime.Today,
                };
                detalle.Calcular();
                retorno.DocumentosProductos.Add(detalle);
            }
            retorno.Calcular();
            return retorno;
        }
    }
}
