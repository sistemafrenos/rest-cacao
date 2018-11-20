using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public Usuario FindUsuario(string id)
        {
            return data.UsuarioRepository.Find(id);
        }
        public Usuario GetByClaveUsuario(string clave)
        {
            return data.UsuarioRepository.GetFirst(x => x.Clave == clave);
        }
        public Usuario GetByNombreClaveUsuario(string nombre, string clave)
        {
            return data.UsuarioRepository.GetFirst(x => x.Clave == clave && x.Nombre == nombre);
        }
        public Usuario[] GetAllUsuarios(string texto)
        {
            var x = data.UsuarioRepository.GetAsNoTracking(
                    d => (d.Nombre.Contains(texto)),
                    q => q.OrderBy(d => d.Nombre)
                    );
            return x.ToArray();
        }
        public string EliminarUsuario(Usuario Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.UsuarioRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string GuardarUsuario(Usuario entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (VerificarUsuarioDuplicado(entity) != null)
                return VerificarUsuarioDuplicado(entity);
            if (FindUsuario(entity.ID.ToString()) == null)
            {
                entity.Activo = true;
                data.UsuarioRepository.Insert(entity);
            }
            else
            {
                data.UsuarioRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string VerificarUsuarioDuplicado(Usuario current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.UsuarioRepository.GetFirst(
                d => d.Clave.Equals(current.Clave) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    retorno.AppendLine("Clave duplicada");
            }
            {
                var x = (data.UsuarioRepository.GetFirst(
                d => d.Nombre.Equals(current.Nombre) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    retorno.AppendLine("Cedula Rif Duplicado");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }

        public void CrearUsuario(string p)
        {
            Usuario user = new Usuario();
            user.AccesoMenu = true;
            user.Activo = true;
            user.Cedula = "V0";
            user.CierreDeCaja = true;
            user.Clave = "";
            user.ContarDinero = true;
            user.GenerarNotaCredito = true;
            user.Nombre = "USUARIO";
            user.PuedeAnularMesa = true;
            user.PuedeCambiarMesa = true;
            user.PuedeCambiarPrecios = true;
            user.PuedeCambiarVendedor = true;
            user.PuedeDarConsumoInterno = true;
            user.PuedeDarCreditos = true;
            user.PuedeDividirCuentas = true;
            user.PuedeLiberarMesa = true;
            user.PuedeModificarDescripcion = true;
            user.PuedeModificarProveedores = true;
            user.PuedePedirCorteDeCuenta = true;
            user.PuedeRegistrarPago = true;
            user.PuedeSepararCuentas = true;
            user.ReporteX = true;
            user.ReporteZ = true;
            user.TipoUsuario = "ADMINISTRADOR";
            user.Vale = true;
            GuardarUsuario(user, true);
        }
    }
}
