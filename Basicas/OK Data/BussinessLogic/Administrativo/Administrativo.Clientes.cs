using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        public Tercero FindCliente(string id)
        {
            var Item = data.ClienteRepository.Find(id);
            return Item;
        }
        public Tercero GetByCedulaCliente(string cedula)
        {
            return data.ClienteRepository.GetFirst(d => d.CedulaRif == cedula && d.Tipo == "CLIENTE");
        }
        public Tercero[] GetAllClientes(string texto)
        {
            var consulta = data.ClienteRepository.GetAsQueryable("");
            if (!string.IsNullOrEmpty(texto))
            {
                consulta = (from d in consulta
                            where (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto))
                            select d);
            }
            consulta = consulta.Where(d => d.Tipo == "CLIENTE");
            return consulta.OrderBy(d => d.RazonSocial).ToArray();
        }
        private string PrepararCliente(Documento documento)
        {
            Tercero cliente = data.ClienteRepository.GetFirst(d => d.CedulaRif == documento.CedulaRif && d.Tipo=="CLIENTE");
            {
                if (cliente == null)
                {
                    cliente = new Tercero("CLIENTE");
                }
                cliente.CedulaRif = documento.CedulaRif;
                cliente.RazonSocial = documento.RazonSocial;
                cliente.Direccion = documento.Direccion;
                cliente.Telefonos = documento.Telefonos;
                cliente.Email = documento.Email;
                string erroresCliente = GuardarCliente(cliente, false);
                if (erroresCliente != null)
                    return erroresCliente;
                documento.Tercero = cliente;
            }
            return null;
        }
        public string GuardarCliente(Tercero entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            //if (VerificarClienteDuplicado(entity) != null)
            //    return VerificarClienteDuplicado(entity);
            if (FindCliente(entity.ID) == null)
            {
                entity.Tipo = "CLIENTE";
                entity.TipoPrecio = "PRECIO 1";
                entity.Activo = true;
                entity.Estatus = "ACTIVO";
                data.ClienteRepository.Insert(entity);
            }
            else
            {
                data.ClienteRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarCliente(Tercero Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.ClienteRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string VerificarClienteDuplicado(Tercero current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.ClienteRepository.GetFirst(
                d => d.RazonSocial.Equals(current.RazonSocial) && !d.ID.Equals(current.ID) && d.Tipo == "CLIENTE"
                ));
                if (x != null)
                    retorno.AppendLine("Razon Social duplicada");
            }
            {
                var x = (data.ClienteRepository.GetFirst(
                d => d.CedulaRif.Equals(current.CedulaRif) && !d.ID.Equals(current.ID) && d.Tipo == "CLIENTE"
                ));
                if (x != null)
                    retorno.AppendLine("Cedula Rif Duplicado");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }


    }
}
