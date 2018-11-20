using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace HK.BussinesLogic
{
    public class Sugerencias:IDisposable
    {
        public Sugerencia current;
        private DatosEntities context;
        private GenericRepository<Sugerencia> sugerenciaRepository;
        private bool disposed = false;
        public Sugerencias()
        {
            current = new Sugerencia();
            context = new DatosEntities(OK.CadenaConexion);
            sugerenciaRepository = new GenericRepository<Sugerencia>(context);
        }
        public GenericRepository<Sugerencia> SugerenciaRepository
        {
            get
            {
                if (this.sugerenciaRepository == null)
                {
                    this.sugerenciaRepository = new GenericRepository<Sugerencia>(context);
                }
                return sugerenciaRepository;
            }
        }
        public void Load(string id)
        {
            current = sugerenciaRepository.GetByID(id);
        }
        public void LoadCodigo(string codigo)
        {
            current = sugerenciaRepository.Get(x => x.Codigo == codigo).FirstOrDefault();
        }
        public void Clone(object OldItem)
        {
            current = sugerenciaRepository.DeepCopy<Sugerencia>((Sugerencia)OldItem);
        }
        public string IsValid()
        {
            var validar = context.Entry(this.current).GetValidationResult();
            if (!validar.IsValid)
                return OK.ErroresToString(validar.ValidationErrors.ToArray());
            return null;
        }
        public string Save()
        {
            current.AsignarID();
            // Validar Item
            string validacion = IsValid() + IsDuplicate();
            if (!string.IsNullOrEmpty(validacion))
                return validacion;
            if (context.Entry(current).State == EntityState.Detached)
            {
                this.sugerenciaRepository.Insert(current);
            }
            context.SaveChanges();
            return null;
        }
        public void Delete(object item)
        {
            Sugerencia oldItem = (Sugerencia)item;
            sugerenciaRepository.Delete(oldItem.IdPlatoDelDia);
            context.SaveChanges();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public List<Sugerencia> GetAll()
        {
            var x = sugerenciaRepository.Get();
            return x.ToList();
        }
        public string IsDuplicate()
        {
            {
                var x = (sugerenciaRepository.GetFirst(
                d => d.Codigo.Equals(current.Codigo) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    return "Codigo Duplicado";
            }
            return null;
        }
    }
}
