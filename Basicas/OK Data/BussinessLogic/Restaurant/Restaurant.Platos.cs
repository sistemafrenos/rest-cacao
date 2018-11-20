using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant
    {
        // Metodos Para Manejo de Platos
        public Producto FindPlato(string id)
        {
            return data.PlatosRepository.Find(id);
        }
        public Producto GetByCodigoPlato(string codigo)
        {
            return data.PlatosRepository.GetFirst(d => d.Codigo == codigo);
        }
        public Producto[] GetAllPlatos(string texto = null, string departamento = null)
        {
            texto = texto.ToUpper();
            var consulta = data.ProductoRepository.GetAsNoTracking(d => d.Activo == true && d.HabilitadoParaVentas == true);
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
        public Salon[] GetDepartamentos()
        {
            List<Salon> salones = new List<Salon>();
            var query = data.PlatosRepository.GetAsNoTracking(d => d.Departamento != null).Select(x => x.Departamento).Distinct();
            foreach (var item in query)
            {
                salones.Add(new Salon() { Ubicacion = item });
            }
            return salones.ToArray();
        }
        public string GuardarPlato(Producto Plato, bool guardarAhora)
        {
            if (!data.IsValid(Plato))
                return "Error.! Datos incompletos";
            if (data.PlatosRepository.Find(Plato.ID) == null)
                data.PlatosRepository.Insert(Plato);
            else
                data.PlatosRepository.Update(Plato);
            if (guardarAhora)
                return data.Save();
            return null;
        }
        public string GuardarPlatoInsumo(ProductosCompuesto item, bool guardarAhora)
        {
            if (data.ProductoCompuestoRepository.Find(item.ID) == null)
                data.ProductoCompuestoRepository.Insert(item);
            else
                data.ProductoCompuestoRepository.Update(item);
            if (guardarAhora)
                return data.Save();
            return null;
        }
        public string EliminarPlato(Producto Plato, bool borrarAhora)
        {
            data.PlatosRepository.Delete(Plato);
            if (borrarAhora)
                return data.Save();
            return null;
        }
        public string GetContadorCodigoPlato(string ubicacion)
        {
            if (string.IsNullOrEmpty(ubicacion))
                return null;
            return string.Format("{0}{1}", ubicacion[0], GetContador(ubicacion).Substring(3, 3));
        }
        public Producto[] GetAllInsumos(string texto = null, string departamento = null)
        {
            texto = texto.ToUpper();
            var consulta = data.ProductoRepository.GetAsNoTracking(d => d.Activo == true && d.HabilitadoParaVentas == false && d.HabilitadoParaCompras == true);
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
        public Producto ClonePlato(object OldItem)
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
    }
}
