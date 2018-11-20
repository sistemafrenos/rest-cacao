using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant
    {
        public Mesonero FindMesonero(string id)
        {
            return data.MesoneroRepository.Find(id);
        }
        public Mesonero GetByCodigoMesonero(string codigo)
        {
            return data.MesoneroRepository.GetFirst(d => d.Codigo == codigo);
        }
        public Mesonero[] GetAllMesoneros(string texto)
        {
            return data.MesoneroRepository.
                GetAsNoTracking(x => x.Codigo.Contains(texto) || x.Nombre.Contains(texto))
                .OrderBy(x => x.Nombre)
                .ToArray();
        }
        public string EliminarMesonero(Mesonero mesonero, bool eliminarAhora)
        {
            data.MesoneroRepository.Delete(mesonero);
            if (eliminarAhora)
                return data.Save();
            return null;
        }
        public string GuardarMesonero(Mesonero mesonero, bool guardarAhora)
        {
            if (data.MesoneroRepository.Find(mesonero.ID) == null)
                data.MesoneroRepository.Insert(mesonero);
            else
                data.MesoneroRepository.Update(mesonero);
            if (guardarAhora)
                return data.Save();
            return null;
        }
        public ReportViews.Receta[] GetRecetas()
        {
            var context = data.GetContext();
            List<ReportViews.Receta> lista = new List<ReportViews.Receta>();
            var items = from plato in context.Productos
                        join platoIngrediente in context.ProductosCompuestos on plato.ID equals platoIngrediente.Producto.ID
                        where plato.HabilitadoParaVentas == true && plato.Activo == true
                        select new 
                        {
                            Departamento = plato.Departamento,
                            Plato = plato.Descripcion,
                            Descripcion = platoIngrediente.Descripcion,
                            Cantidad = platoIngrediente.Cantidad,
                            Costo = platoIngrediente.Costo,
                            TotalCosto = platoIngrediente.TotalCosto
                        };
            var retorno = from x in items
                          orderby x.Departamento, x.Plato
                          select x;
            foreach(var item in retorno)
            {
                lista.Add(new ReportViews.Receta() { Departamento = item.Departamento, Plato = item.Plato, Descripcion = item.Descripcion, Cantidad = item.Cantidad, Costo = item.Costo, TotalCosto = item.TotalCosto });
            }
            return lista.ToArray();
        }
    }
}
