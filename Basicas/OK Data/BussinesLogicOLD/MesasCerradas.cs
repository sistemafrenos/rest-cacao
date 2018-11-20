using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace HK
{
}
namespace HK.BussinessLogic
{
    public class MesasCerradas : IDisposable , IUnitOfWork
    {
        public MesasCerrada current;
        private DatosEntities context;
        private GenericRepository<MesasCerrada> mesaCerradaRepository;
        private bool disposed = false;
        public MesasCerradas()
        {
            Clear();
            context = new DatosEntities();
            mesaCerradaRepository = new GenericRepository<MesasCerrada>(context);
        }

        public void Clear()
        {
            current = new MesasCerrada() { Fecha = DateTime.Today };
        }
        public GenericRepository<MesasCerrada> MesaCerradaRepository
        {
            get
            {
                if (this.mesaCerradaRepository == null)
                {
                    this.mesaCerradaRepository = new GenericRepository<MesasCerrada>(context);
                }
                return mesaCerradaRepository;
            }
        }
        public void Load(string id)
        {
            current = mesaCerradaRepository.GetByID(id);
        }
        public void Clone(object OldItem)
        {
            MesasCerrada old = (MesasCerrada)OldItem;
            current = new MesasCerrada() { Fecha = DateTime.Today, CedulaRif = old.CedulaRif, Direccion = old.Direccion, Email = old.Email, RazonSocial = old.RazonSocial, Telefonos = old.Telefonos, Comentarios = old.Comentarios, Mesonero = old.Mesonero, CodigoMesa = old.CodigoMesa, CobraServicio = old.CobraServicio, NumeroImpresiones = old.NumeroImpresiones, Personas = old.Personas, Apertura = old.Apertura, Cierre = old.Cierre, Descuentos = old.Descuentos };
            current.Totalizar();
        }
        public string Save()
        {
            // Completar MesasCerrada
            AsignarNumero();
            if(current.Tipo!="ANULADA")
              this.current.Totalizar();
            // Validar MesasCerrada
            string validacion = IsValid();
            if (!string.IsNullOrEmpty(validacion))
            {
                return validacion;
            }
            if (context.Entry(current).State == EntityState.Detached)
            {
                this.mesaCerradaRepository.Insert(current);
            }
            context.SaveChanges();
            return null;
        }
        public void Delete(object item)
        {
            MesasCerrada oldItem = (MesasCerrada)item;
            mesaCerradaRepository.Delete(oldItem.ID);
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
        public string IsValid()
        {
            var validacion = context.Entry(this.current).GetValidationResult();
            if (!validacion.IsValid)
                OK.ErroresToString(validacion.ValidationErrors.ToArray());
            foreach (var linea in this.current.MesasCerradasProductos)
            {
                var validaLinea = IsValid(linea);
                if (validaLinea != null)
                {
                    return validaLinea;
                }
            }
            return null;
        }
        public string IsValid(MesasCerradasProducto linea)
        {
            var validaLinea = context.Entry(linea).GetValidationResult();
            if (!validaLinea.IsValid)
                return OK.ErroresToString(validaLinea.ValidationErrors.ToArray());
            return null;
        }
        #region extras
        private void AsignarLote()
        {
            var Lote = context.Contadores.FirstOrDefault(x => x.Variable == "LOTE");
            if (Lote == null)
            {
                Lote = new Contador();
                Lote.Valor = 1;
                Lote.Variable = "LOTE";
                if (context.Entry(Lote).State == EntityState.Detached)
                    context.Contadores.Add(Lote);
            }
            current.NumeroLote = Lote.Valor;
        }
        private void AsignarNumero()
        {
            if (string.IsNullOrEmpty(current.Numero))
            {
               
                var Cerradas = context.Contadores.FirstOrDefault(x => x.Variable == "CERRADAS");

                if (Cerradas == null)
                {
                    Cerradas = new Contador();
                    Cerradas.Valor = 0;
                    Cerradas.Variable = "CERRADAS";
                }
                Cerradas.Valor++;
                if (context.Entry(Cerradas).State == EntityState.Detached)
                    context.Contadores.Add(Cerradas);
                current.Numero = Cerradas.Valor.Value.ToString("000000");
            }
        }
        public List<MesasCerrada> GetAll(string texto)
        {
            var x = mesaCerradaRepository.Get(
            d => d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto),
            q => q.OrderBy(d => d.RazonSocial)
            );
            return x.ToList();
        }
        public List<MesasCerrada> GetHoy(string texto)
        {
            DateTime hoy = DateTime.Today;
            var x = mesaCerradaRepository.Get(
            d => ((d.RazonSocial.Contains(texto) || d.Numero == texto || string.IsNullOrEmpty(texto)) && d.Fecha == hoy),
            q => q.OrderBy(d => d.Numero)
            );
            return x.ToList();
        }
        public List<MesasCerrada> GetLapso(DateTime fechaInicio, DateTime fechaFinal)
        {
            var x = mesaCerradaRepository.Get(
            d => (d.Fecha >= fechaInicio && d.Fecha <= fechaFinal && d.Tipo!="ANULADA"),
            q => q.OrderBy(d => d.RazonSocial)
            );
            return x.ToList();
        }
        public List<MesasCerrada> GetLapsoAnuladas(DateTime fechaInicio, DateTime fechaFinal)
        {
            var x = mesaCerradaRepository.Get(
            d => (d.Fecha >= fechaInicio && d.Fecha <= fechaFinal && d.Tipo == "ANULADA"),
            q => q.OrderBy(d => d.RazonSocial)
            );
            return x.ToList();
        }

        public void CreateMesaCerrada(MesasAbierta mesaAbierta)
        {   
            current = new MesasCerrada()
            { 
                Apertura = mesaAbierta.Apertura,
                Fecha=DateTime.Today,
                CedulaRif = mesaAbierta.CedulaRif, 
                Cierre = DateTime.Now, 
                CodigoMesa = mesaAbierta.CodigoMesa,
                NumeroImpresiones = mesaAbierta.NumeroImpresiones,
                Personas = mesaAbierta.Personas,
                RazonSocial = mesaAbierta.RazonSocial,
                Ubicacion = mesaAbierta.Ubicacion,
                Mesonero = mesaAbierta.Mesonero,
                CobraServicio = mesaAbierta.CobraServicio
            };
            AsignarLote();
            foreach (MesasAbiertasProducto item in mesaAbierta.MesasAbiertasProductos)
            {
                MesasCerradasProducto newItem = new MesasCerradasProducto()
                {
                    Cantidad = item.Cantidad,
                    Codigo = item.Codigo,
                    Comentario = item.Comentario,
                    Costo = item.Costo,
                    Departamento = item.Departamento,
                    Descripcion = item.Descripcion,
                    EnviarComanda = item.EnviarComanda,
                    Hora = item.Hora,
                    Mesonero = item.Mesonero,
                    NumeroComanda = item.NumeroComanda,
                    Precio = item.Precio,
                    PrecioConIva = item.PrecioConIva,
                    TasaIva = item.TasaIva,
                    Total = item.Total,
                    ProductoID=item.ProductoID,
                    NumeroLote = current.NumeroLote,
                    Anulado= item.Anulado
                };
                
                current.MesasCerradasProductos.Add(newItem);
            }
            current.Totalizar();
        }

        #endregion

        public List<MesasCerrada> GetLote(int numero)
        {
            var x = mesaCerradaRepository.Get(
            d => d.NumeroLote == numero,
            q => q.OrderBy(d => d.Numero)
            );
            return x.ToList();
        }
        public List<MesasCerrada> GetLote(int numero, string Tipo)
        {
            var x = mesaCerradaRepository.Get(
            d => d.NumeroLote == numero && d.Tipo == Tipo,
            q => q.OrderBy(d => d.Numero)
            );
            return x.ToList();
        }



        public List<Resumen> VentasxPlatos(DateTime desde, DateTime hasta)
        {
            var sinAnular = context.MesasCerradasProductos.Where(x => x.Anulado == null);
            var porFecha = sinAnular.Where(item => item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta);
            var items = from item in porFecha
                        orderby item.Descripcion
                        group item by item.Descripcion
                            into ventaxDescripcion
                            select new Resumen
                            {
                                Descripcion = ventaxDescripcion.Key,
                                Bolivares = ventaxDescripcion.Sum(x => x.Cantidad * x.Precio),
                                Cantidad = ventaxDescripcion.Sum(x => x.Cantidad)
                            };
            return items.ToList();
        }
        public List<Resumen> VentasxDepartamentos(DateTime desde, DateTime hasta)
        {
            var sinAnular = context.MesasCerradasProductos.Where(x => x.Anulado == null);
            var porFecha = sinAnular.Where(item => item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta);
            var items = from item in porFecha
                        orderby item.Departamento
                        group item by item.Departamento
                            into ventaxDescripcion
                            select new Resumen
                            {
                                Descripcion = ventaxDescripcion.Key,
                                Bolivares = ventaxDescripcion.Sum(x => x.Cantidad * x.Precio),
                                Cantidad = ventaxDescripcion.Sum(x => x.Cantidad)
                            };
            return items.ToList();
        }
        public List<Resumen> ConsumoxProductos(DateTime desde, DateTime hasta)
        {
            var sinAnular = context.MesasCerradasProductos.Where(x => x.Anulado == null);
            var porFecha = sinAnular.Where(item => item.MesasCerrada.Fecha.Value >= desde && item.MesasCerrada.Fecha.Value <= hasta);
            var items = from item in porFecha
                        orderby item.Descripcion
                        join itemInsumo in context.ProductosCompuestos on item.ProductoID equals itemInsumo.Producto.ID
                        select new
                        {
                            Descripcion = itemInsumo.Descripcion,
                            Cantidad = itemInsumo.Cantidad * item.Cantidad,
                            Costo = itemInsumo.Cantidad * itemInsumo.Costo
                        };
            var itemsResumen = from item in items
                        orderby item.Descripcion
                        group item by item.Descripcion
                            into ConsumoxDescripcion
                            select new Resumen
                            {
                                Descripcion = ConsumoxDescripcion.Key,
                                Bolivares = ConsumoxDescripcion.Sum(x => x.Cantidad * x.Costo),
                                Cantidad = ConsumoxDescripcion.Sum(x => x.Cantidad)
                            };
            return itemsResumen.ToList();
        }
    } 
}

