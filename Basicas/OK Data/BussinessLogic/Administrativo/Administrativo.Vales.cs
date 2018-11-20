using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public Vale FindVale(string id)
        {
            return data.ValesRepository.Find(id);
        }
        public Vale[] GetByLoteVales(string texto)
        {
            var x = data.ValesRepository.GetAsNoTracking(
                    d =>d.NumeroLote.Equals(texto) 
                    );
            return x.ToArray();
        }
        public Vale[] GetByFechaVales(DateTime desde,DateTime hasta)
        {
            var x = data.ValesRepository.GetAsNoTracking( d => d.Fecha>= desde && d.Fecha<= hasta);
            return x.ToArray();
        }
        public string GuardarVale(Vale entity, bool guardarAhora)
        {
            entity.Numero = GetContador("NumeroVale");
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (FindVale(entity.ID) == null)
            {
                entity.Fecha = DateTime.Today;
                data.ValesRepository.Insert(entity);
            }
            else
            {
                data.ValesRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string[] getConceptosVales()
        {
            var q = (from p in data.context.Vales
                     orderby p.Concepto
                     where p.Concepto != null
                     select p.Concepto
            ).Distinct();
            return q.ToArray();
        }
        public void AsignarLote(string numero)
        {
            data.context.Database.ExecuteSqlCommand(string.Format("Update Vales Set NumeroLote={0} Where NumeroLote Is Null", numero));
        }
    }
}
