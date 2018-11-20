using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public Vendedor FindVendedor(string id)
        {
            return data.VendedoresRepository.Find(id);
        }
        public Vendedor[] GetAllVendedores(string texto)
        {
            var x = data.VendedoresRepository.GetAsNoTracking(
                    d => (d.Nombre.Contains(texto) || d.CedulaRif.Contains(texto) || texto == ""),
                    q => q.OrderBy(d => d.Nombre)
                    );
            return x.ToArray();
        }
        public string VerificarVendedorDuplicado(Vendedor current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.VendedoresRepository.GetFirst(
                d => d.Nombre.Equals(current.Nombre) && !d.ID.Equals(current.ID) 
                ));
                if (x != null)
                    retorno.AppendLine("Nombre Publicado");
            }
            {
                var x = (data.VendedoresRepository.GetFirst(
                d => d.CedulaRif.Equals(current.CedulaRif) && !d.ID.Equals(current.ID) 
                ));
                if (x != null)
                    retorno.AppendLine("Cedula Duplicada");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }
        public string GuardarVendedor(Vendedor entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (VerificarVendedorDuplicado(entity) != null)
                return VerificarVendedorDuplicado(entity);
            if (FindVendedor(entity.ID) == null)
            {
                entity.PorcentajeComision = 0;
                entity.Activo = true;
                data.VendedoresRepository.Insert(entity);
            }
            else
            {
                data.VendedoresRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarVendedor(Vendedor Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.VendedoresRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public TercerosMovimiento[] GetDocumentosPendientesVendedor(Vendedor vendedor)
        {
            var items = data.TerceroMovimientosRepository
                            .GetAsNoTracking(x => x.Saldo > 0);
            if (vendedor.CedulaRif != null)
            {
                items = from x in items
                        where x.CodigoVendedor == vendedor.Codigo
                        select x;
            }
            var consulta = from q in items
                           orderby q.Tercero, q.Fecha
                           select q;
            return consulta.ToArray();
        }
        public Resumen[]  GetResumenDocumentosPendientesVendedor(Vendedor vendedor)
        {
            
            var items = (data.TerceroMovimientosRepository
                            .GetAsNoTracking(x => x.Saldo > 0)).ToList();
            if (vendedor.CedulaRif != null)
            {
                items = (from x in items
                        where x.CodigoVendedor == vendedor.Codigo
                        select x).ToList();
            }
            var consulta = from q in items
                           group q by q.Tercero
                               into item
                               select new Resumen
                               {
                                   Cantidad = (int)item.Count(),
                                   Descripcion = item.Key.RazonSocial,
                                   Bolivares = (double)item.Sum(x => x.Saldo),
                                   Comision = (double)item.Sum(x => x.Saldo) * vendedor.PorcentajeComision.GetValueOrDefault()
                               };
            return consulta.ToArray();
        }
    }
}
