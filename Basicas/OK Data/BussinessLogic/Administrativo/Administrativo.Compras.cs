using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo : IDisposable
    {
        public Compra FindCompra(string id)
        {
            return data.CompraRepository.Find(id);
        }
        public Compra GetByNumeroCompra(string numero)
        {
            return data.CompraRepository.GetFirst(d => d.Numero == numero && d.Tipo == "COMPRA");
        }
        public Compra[] GetAllCompras(string texto, string status)
        {
            var consulta = data.CompraRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto) || d.Numero == texto)
                            select d);
            }
            consulta = consulta.Where(d=> d.Tipo == "COMPRA");
            if (!string.IsNullOrEmpty(status))
            {
                consulta = consulta.Where(d => d.Estatus == status);
            }
            return consulta.OrderBy(d => d.Fecha).ToArray();
        }
        public Compra[] GetAllComprasSinRetencionIva(string texto)
        {
            var consulta = data.CompraRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto) || d.Numero == texto)
                            select d);
            }
            consulta = consulta.Where(d => d.Tipo == "COMPRA");
            consulta = consulta.Where(x => x.ComprobanteRetencionIVA == null);
            return consulta.ToArray();
        }
        public IQueryable<Compra> GetQueryableCompras()
        {
            return data.CompraRepository.GetAsQueryable("").Where(d=>d.Tipo=="COMPRA");
        }
        public string EliminarCompra(Compra compra)
        {
            compra.Tipo = "COMPRA ANULADA";
            data.CompraRepository.Delete(compra);
            ProcesarInventarios(compra,false);
            if (compra.LibroCompras.GetValueOrDefault())
            {
                EliminarLibroDeCompras(compra);
            }
            string result = EscribirLibroInventarios(compra,false);
            if (result != null)
                return result;
            return data.Save();
        }
        public string GuardarCompra(Compra compra, string Estatus, bool guardarAhora)
        {
            string result = ValidarDocumento(compra);
            if (result != null)
                return result;
            compra.Estatus = Estatus;
            if (FindCompra(compra.ID) == null)
                data.CompraRepository.Insert(compra);
            else
                data.CompraRepository.Update(compra);
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }

        public string ProcesarCompra(Compra compra)
        {
            compra.Ano = compra.Fecha.Year;
            compra.Mes = compra.Fecha.Month;
            string result = GuardarCompra(compra, "CERRADA", false);
            if (result != null)
                return result;
            if (compra.Tipo == "COMPRA")
            {
                result = EscribirLibroDeCompras(compra);
                if (result != null)
                    return result;
            }
            // ProcesarInventarios(compra,false);
            // result = EscribirLibroInventarios(compra,false);
            //if (result != null)
            //    return result;
            return data.Save();
        }

        public ProductosMovimientos[] UltimasCompras(string idProducto, int cantidad)
        {
            var movimientos = (from doc in data.context.Documentos
                               join docProducto in data.context.DocumentosProductos on doc.ID equals docProducto.Documento.ID
                               where docProducto.ProductoID == doc.ID
                               && doc.Tipo == "COMPRA"
                               && docProducto.Entrada > 0
                               && docProducto.ProductoID == idProducto
                               orderby docProducto.momento descending
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
                               });
            return movimientos.Take(cantidad).ToArray();
        }
    }
}
