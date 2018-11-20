using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        // Proveedores
        public Tercero FindProveedor(string id)
        {
            return data.ProveedorRepository.Find(id);
        }
        public Tercero GetByCedulaRifProveedor(string cedulaRif)
        {
            return data.ProveedorRepository.GetFirst(d => d.CedulaRif == cedulaRif && d.Tipo == "PROVEEDOR");
        }
        public Tercero[] GetAllProveedores(string texto)
        {
            var consulta = data.ProveedorRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto))
                            select d);
            }
            consulta = consulta.Where(d => d.Tipo == "PROVEEDOR");
            return consulta.OrderBy(d => d.RazonSocial).ToArray();
        }
        public string VerificarProveedorDuplicado(Tercero current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.ProveedorRepository.GetFirst(
                d => d.RazonSocial.Equals(current.RazonSocial) && !d.ID.Equals(current.ID) && d.Tipo == "PROVEEDOR"
                ));
                if (x != null)
                    retorno.AppendLine("Razon Social duplicada");
            }
            {
                var x = (data.ProveedorRepository.GetFirst(
                d => d.CedulaRif.Equals(current.CedulaRif) && !d.ID.Equals(current.ID) && d.Tipo == "PROVEEDOR"
                ));
                if (x != null)
                    retorno.AppendLine("Cedula Rif Duplicado");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }
        public string GuardarProveedor(Tercero entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (VerificarProveedorDuplicado(entity) != null)
                return VerificarProveedorDuplicado(entity);
            if (FindProveedor(entity.ID) == null)
            {
                entity.Tipo = "PROVEEDOR";
                entity.DiasCredito = 0;
                entity.Activo = true;
                entity.Estatus = "ACTIVO";
                data.ProveedorRepository.Insert(entity);
            }
            else
            {
                data.ProveedorRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarProveedor(Tercero Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.ProveedorRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public List<TercerosMovimiento> GetDocumentosPendientesProveedor(Tercero proveedor)
        {
            throw new NotImplementedException();
        }
    }
}
