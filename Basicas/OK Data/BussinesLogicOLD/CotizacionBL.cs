using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HK;

namespace HK
{
    public partial class Cotizacion
    {
        [NotMapped]
        public virtual string TipoPrecio { set; get; }
        public void AsignarNumero(DatosEntities context)
        {
                int valor = 0;
                var maximo = context.Cotizaciones.Max(x => x.Numero);
                int.TryParse(maximo, out valor);
                valor++;
                this.Numero = valor.ToString("000000");
        }
        public void ActualizarPrecios()
        { 
        }
        public void AsignarID()
        {
            this.IdCotizacion = this.IdCotizacion == null ?
                Guid.NewGuid().ToString() :
                this.IdCotizacion;
        }
    }
    public class CotizacionBL
    {
        
        #region Atributos
        DatosEntities db;
        public Cotizacion cotizacion { set; get; }
        #endregion
        #region constructor
        public CotizacionBL()
        {
            cotizacion = new Cotizacion();
            cotizacion.IdCotizacion = Guid.NewGuid().ToString();
            cotizacion.Fecha = DateTime.Today;
            cotizacion.CedulaRif= OK.CedulaRif("0");
            cotizacion.RazonSocial = "CONTADO";
            cotizacion.Direccion = OK.parametros.Ciudad;
            cotizacion.Totalizar();
            db = new DatosEntities(OK.CadenaConexion);
        }
        #endregion  
        #region metodos
        public bool Load(string id)
        {
            cotizacion = db.Cotizaciones.FirstOrDefault(x=>x.IdCotizacion==id);
            return cotizacion!=null;
        }
        public string Validate()
        {
            ClienteBL ClienteBL = new HK.ClienteBL(cotizacion.CedulaRif);
            if (!ClienteBL.cliente.Activo.Value)
            {
                return "Cliente inactivo";
            }
            ClienteBL.cliente.CedulaRif = cotizacion.CedulaRif;
            ClienteBL.cliente.RazonSocial = cotizacion.RazonSocial;
            string errorescliente = ClienteBL.Validate();
            if(errorescliente!=null)
            {
                return errorescliente;
            }
            if(!db.Entry(cotizacion).GetValidationResult().IsValid)
            {
                var errores = db.Entry(cotizacion).GetValidationResult().ValidationErrors.ToList();;
                return OK.ListToString(errores);
            }
            cotizacion.Totalizar();
            return null;
        }
        public string Save()
        {
            string validacion = Validate();
            if(validacion!=null)
            {
                return validacion;
            }
            ClienteBL ClienteBL = new HK.ClienteBL(cotizacion.CedulaRif);
            if (!ClienteBL.cliente.Activo.Value)
            {
                return "Cliente inactivo";
            }
            ClienteBL.cliente.CedulaRif = cotizacion.CedulaRif;
            ClienteBL.cliente.RazonSocial = cotizacion.RazonSocial;
            ClienteBL.cliente.Direccion = cotizacion.Direccion;
            ClienteBL.cliente.Email = cotizacion.Email;
            ClienteBL.Save();
            foreach (var p in cotizacion.CotizacionesProductos)
            {
                if (p.IdCotizacionProductos == null)
                {
                    p.IdCotizacionProductos = Guid.NewGuid().ToString();
                }
            }
            Cotizacion temp = db.Cotizaciones.FirstOrDefault(x => x.IdCotizacion == cotizacion.IdCotizacion);
            if (temp == null)
            {
                cotizacion.Numero = cotizacion.Numero == null ? NextNumber() : cotizacion.Numero;
                db.Cotizaciones.Add(cotizacion);
            }
            try
            {
                db.SaveChanges();
            }
            catch( Exception x)
            {
                return x.Message;
            }
            return null;
        }
        private string NextNumber()
        {
            int valor = 0;
            var maximo = db.Cotizaciones.Max(x=> x.Numero);
            int.TryParse(maximo,out valor);
            valor++;
            return valor.ToString("000000");
        }
        public void Delete()
        {
            DatosEntities db = new DatosEntities(OK.CadenaConexion);
            Cotizacion temp = db.Cotizaciones.FirstOrDefault(x => x.IdCotizacion == cotizacion.IdCotizacion);
            if (temp == null)
                return;
            db.Cotizaciones.Remove(temp);
            try
            {
                db.SaveChanges();
            }
            catch { }
        }
        public static List<Cotizacion> GetAll(string texto)
        {
            List<Cotizacion> lista;
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                lista = (from p in db.Cotizaciones
                         where (p.RazonSocial.Contains(texto) || texto.Length == 0)
                         orderby p.Fecha
                         select p).ToList();
            }
            return lista;
        }
        public static List<Cotizacion> GetAll(string texto, string filtro)
        {
            System.Linq.IOrderedQueryable<Cotizacion> lista;
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                lista = (from p in db.Cotizaciones.AsNoTracking()
                         where (p.RazonSocial.Contains(texto) || texto.Length == 0)
                         orderby p.Fecha
                         select p);
                int mes = DateTime.Today.Month;
                int año = DateTime.Today.Year;
                switch(filtro)
                {
                    case "AYER":
                        lista.Where(x => x.Fecha.Value == DateTime.Today.AddDays(- 1));
                        break;
                    case "HOY":
                        lista.Where(x => x.Fecha.Value == DateTime.Today);
                        break;
                    case "ESTE MES":
                        lista.Where(p=> p.Fecha.Value.Month == mes && p.Fecha.Value.Year == año );
                        break;
                    case "MES ANTERIOR":
                        if (DateTime.Today.Month == 1)
                        {
                            mes = 12;
                            año = año--;
                        }
                        lista.Where(p=> p.Fecha.Value.Month == mes && p.Fecha.Value.Year == año );
                        break;
                }
                return lista.ToList();
            }
        }
        #endregion
        #region Metodos Adicionales
        public void ActualizarPrecios()
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                foreach (var registroDetalle in cotizacion.CotizacionesProductos)
                {
                    Producto producto = db.Productos.FirstOrDefault(p => p.IdProducto == registroDetalle.IdProducto);
                    if (producto != null)
                    {
                        switch (cotizacion.TipoPrecio)
                        {
                            case "PRECIO 1":
                                registroDetalle.Precio = producto.Precio;
                                registroDetalle.PrecioConIva = producto.PrecioConIva;
                                registroDetalle.ExistenciaAnterior = producto.Existencia;
                                break;
                            case "PRECIO 2":
                                registroDetalle.Precio = producto.Precio2;
                                registroDetalle.PrecioConIva = producto.PrecioConIva2;
                                registroDetalle.ExistenciaAnterior = producto.Existencia;
                                break;
                            default:
                                registroDetalle.Precio = producto.Precio;
                                registroDetalle.PrecioConIva = producto.PrecioConIva;
                                registroDetalle.ExistenciaAnterior = producto.Existencia;
                                break;
                        }
                        registroDetalle.Calcular();
                    }
                }
                cotizacion.Totalizar();
            }
        }
        #endregion
    }
}
