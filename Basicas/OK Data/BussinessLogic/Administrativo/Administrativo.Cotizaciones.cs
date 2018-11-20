using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public Cotizacion FindCotizacion(string id)
        {
            return data.CotizacionRepository.Find(id);
        }
        public Cotizacion CrearCotizacion(Documento doc)
        {
            Cotizacion retorno = new Cotizacion();
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
            retorno.Calcular();
            return retorno;
        }
        public void EliminarCotizacion(Cotizacion doc, bool eliminarAhora)
        {
            data.CotizacionRepository.Delete(doc);
            if (eliminarAhora)
            {
                data.Save();
            }
        }
        public Cotizacion[] GetAllCotizaciones(string texto)
        {
            var consulta = data.CotizacionRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto) || d.Numero==texto)
                            select d);
            }
            consulta = consulta.Where(d => d.Tipo == "COTIZACION");
            return consulta.OrderBy(d => d.Fecha).ToArray();
        }
        public string GuardarCotizacion(Cotizacion doc)
        {
            doc.Tipo = "COTIZACION";
            doc.Vence = doc.Fecha.AddDays(0);
            doc.Numero = GetContador("COTIZACION");
            doc.Calcular();
            string result = ValidarDocumento(doc);
            if (result != null)
                return result;
            result = PrepararCliente(doc);
            if (result != null)
                return result;
            if (data.CotizacionRepository.Find(doc.ID) == null)
                data.CotizacionRepository.Insert(doc);
            else
                data.CotizacionRepository.Update(doc);
            return data.Save();
        }

    }
}
