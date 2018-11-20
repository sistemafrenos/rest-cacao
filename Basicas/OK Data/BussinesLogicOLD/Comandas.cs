using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HK
{
    public partial class Evento
    {
        public void AsignarID()
        {
            this.IdEvento = this.IdEvento == null ?
                Guid.NewGuid().ToString() :
                this.IdEvento;
        }
    }
}
namespace HK.BussinesLogic
{
    public class Eventos
    {
        public Evento current;
        private DatosEntities context;
        private GenericRepository<Evento> eventoRepository;
        private bool disposed = false;
        public Eventos()
        {
            current = new Evento();
            context = new DatosEntities(OK.CadenaConexion);
            eventoRepository = new GenericRepository<Evento>(context);
        }
        public GenericRepository<Evento> EventoRepository
        {
            get
            {
                if (this.eventoRepository == null)
                {
                    this.eventoRepository = new GenericRepository<Evento>(context);
                }
                return eventoRepository;
            }
        }
        public void Load(string id)
        {
            current = EventoRepository.GetByID(id);
        }
        public void Clone(object OldItem)
        {
            current = EventoRepository.DeepCopy<Evento>((Evento)OldItem);
        }
        public string IsValid()
        {
            var validaEvento = context.Entry(this.current).GetValidationResult();
            if (!validaEvento.IsValid)
                return OK.ErroresToString(validaEvento.ValidationErrors.ToArray());
            return null;
        }
        public string Save()
        {
            current.AsignarID();
            // Validar Item
            string validacion = IsValid();
            if (validacion != null)
                return validacion;
            if (context.Entry(current).State == EntityState.Detached)
            {
                this.EventoRepository.Insert(current);
            }
            context.SaveChanges();
            return null;
        }
        public void Delete(object item)
        {
            Evento oldItem = (Evento)item;
            EventoRepository.Delete(oldItem.IdEvento);
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
        public List<Evento> GetAll(string texto)
        {
            var x = EventoRepository.Get(
                 d => d.Modulo.Contains(texto) || d.Mesa.Contains(texto),
                 q => q.OrderBy(d => d.Fecha)
                );
            return x.ToList();
        }
        public List<Evento> GetLapso( DateTime inicio,DateTime final)
        {
            DateTime hoy = DateTime.Today;
            var x = eventoRepository.Get(
                 d => (d.Fecha>=inicio && d.Fecha<=final),
                 q => q.OrderBy(d => d.Hora)
                );
            return x.ToList();
        }
        public List<Evento> GetHoy()
        {
            DateTime hoy = DateTime.Today;
            var x = eventoRepository.Get(
                 d => (d.Fecha == hoy),
                 q => q.OrderBy(d => d.Hora)
                );
            return x.ToList();
        }
        public void Create(MesasAbierta mesaAbierta, string concepto, string modulo, string tipo, string comentarios)
        {
            current = new Evento();
            current.Hora = DateTime.Now;
            current.Fecha = DateTime.Today;
            current.Dia = DateTime.Today;
            current.NumeroImpresiones = mesaAbierta.NumeroImpresiones;
            current.Descripcion = concepto;
            current.Modulo = modulo;
            current.Tipo = tipo;
            current.Usuario = mesaAbierta.Mesonero;
            current.Mesonero = mesaAbierta.Mesonero;
            current.Mesa = mesaAbierta.CodigoMesa;
            current.TieneEventos = mesaAbierta.TieneEventos;
            current.Comentario = comentarios;
            Save();
        }
    }
}
