using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public NotaEntrega FindNotaDeEntrega(string id)
        {
            return data.NotaEntregaRepository.Find(id);
        }
        public void EliminarNotaEntrega(NotaEntrega doc, bool eliminarAhora)
        {
            data.NotaEntregaRepository.Delete(doc);
            if (eliminarAhora)
            {
                data.Save();
            }
        }
        public NotaEntrega[] GetAllNotasDeEntrega(string texto)
        {
            var consulta = data.NotaEntregaRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto) || d.Numero == texto)
                            select d);
            }
            consulta = consulta.Where(d => d.Tipo == "NOTA ENTREGA");
            return consulta.OrderBy(d => d.Fecha).ToArray();
        }
        public string GuardarNotaDeEntrega(NotaEntrega doc)
        {
            doc.Tipo = "NOTA ENTREGA";
            doc.Vence = doc.Fecha.AddDays(0);
            doc.Numero = GetContador("NOTA ENTREGA");
            doc.Calcular();
            string result = ValidarDocumento(doc);
            if (result != null)
                return result;
            result = PrepararCliente(doc);
            if (result != null)
                return result;
            if (data.NotaEntregaRepository.Find(doc.ID) == null)
                data.NotaEntregaRepository.Insert(doc);
            else
                data.NotaEntregaRepository.Update(doc);
            return data.Save();
        }
        public NotaEntrega CrearNotaDeEntrega(Cotizacion doc)
        {
            NotaEntrega retorno = new NotaEntrega();
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
                };
                detalle.Calcular();
                retorno.DocumentosProductos.Add(detalle);
            }
            retorno.Calcular();
            return retorno;
        }
    }
}
