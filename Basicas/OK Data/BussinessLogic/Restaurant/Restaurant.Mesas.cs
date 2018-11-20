using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic.Restaurant
{
    public partial class Restaurant
    {
        // Metodos Para Manejo de Mesas
        public Mesa FindMesa(string id)
        {
            return data.MesaRepository.Find(id);
        }
        public Mesa GetByCodigoMesa(string codigoMesa)
        {
            return data.MesaRepository.GetFirst(d => d.Codigo == codigoMesa);
        }
        public Mesa[] GetAllMesas(string texto)
        {
            var x = data.MesaRepository.Get(
            d => d.Codigo.Contains(texto) || d.Ubicacion.Contains(texto),
            q => q.OrderBy(d => d.Codigo)
            );
            return x.ToArray();
        }
        public Salon[] GetUbicaciones()
        {
            List<Salon> salones = new List<Salon>();
            var query = data.MesaRepository.GetAsNoTracking(d => d.Ubicacion != null).Select(x => x.Ubicacion).Distinct();
            foreach (var item in query)
            {
                salones.Add(new Salon() { Ubicacion = item });
            }
            return salones.ToArray();
        }
        public string[] GetUbicacionesString()
        {
            var retorno = new List<string>();
            foreach (var item in GetUbicaciones())
            {
                retorno.Add(item.Ubicacion );
            }
            return retorno.ToArray();
        }
        public string GuardarMesa(Mesa mesa, bool guardarAhora)
        {
            if (data.MesaRepository.Find(mesa.ID) == null)
                data.MesaRepository.Insert(mesa);
            else
                data.MesaRepository.Update(mesa);
            if (guardarAhora)
                return data.Save();
            return null;
        }
        public string EliminarMesa(Mesa mesa, bool borrarAhora)
        {
            data.MesaRepository.Delete(mesa);
            if (borrarAhora)
                return data.Save();
            return null;
        }
        public string GetContadorCodigoMesa(string ubicacion)
        {
            if (string.IsNullOrEmpty(ubicacion))
                return null;
            return string.Format("{0}{1}", ubicacion[0], GetContador(ubicacion).Substring(3, 3));
        }
    }
}
