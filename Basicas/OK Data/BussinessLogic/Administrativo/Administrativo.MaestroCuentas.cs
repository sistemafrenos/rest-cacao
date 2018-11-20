using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        // Maestro Cuentas
        public MaestroDeCuenta FindMaestroCuenta(string id)
        {
            return data.MaestroDeCuentaRepository.Find(id);
        }
        public MaestroDeCuenta[] GetAllMaestroCuenta(string texto)
        {
            if (data.MaestroDeCuentaRepository.dbSet.Count() < 1)
            {
                SeedMaestroCuentas();
            }
            return data.MaestroDeCuentaRepository.GetAsNoTracking(
            d => d.Descripcion.Contains(texto) || d.Codigo == texto || string.IsNullOrEmpty(texto),
            q => q.OrderBy(d => d.Codigo)
            ).ToArray();
        }
        public void SeedMaestroCuentas()
        {
            data.MaestroDeCuentaRepository.Insert(new MaestroDeCuenta { Codigo = "01", Descripcion = "MERCANCIAS" });
            data.MaestroDeCuentaRepository.Insert(new MaestroDeCuenta { Codigo = "02", Descripcion = "GASTOS OPERATIVOS" });
            data.MaestroDeCuentaRepository.Insert(new MaestroDeCuenta { Codigo = "03", Descripcion = "PERSONAL" });
            data.MaestroDeCuentaRepository.Insert(new MaestroDeCuenta { Codigo = "04", Descripcion = "IMPUESTOS" });
            data.MaestroDeCuentaRepository.context.SaveChanges();
        }
        public string GuardarMaestroCuentas(MaestroDeCuenta entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (VerificarMaestroCuentas(entity) != null)
                return VerificarMaestroCuentas(entity);
            if (FindCliente(entity.ID) == null)
            {
                data.MaestroDeCuentaRepository.Insert(entity);
            }
            else
            {
                data.MaestroDeCuentaRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string VerificarMaestroCuentas(MaestroDeCuenta current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.MaestroDeCuentaRepository.GetFirst(
                d => d.Codigo.Equals(current.Codigo) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    retorno.AppendLine("Codigo duplicada");
            }
            {
                var x = (data.MaestroDeCuentaRepository.GetFirst(
                d => d.Descripcion.Equals(current.Descripcion) && !d.ID.Equals(current.ID)
                ));
                if (x != null)
                    retorno.AppendLine("Descripcion Duplicada");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }
        public string EliminarMaestroDeCuentas(MaestroDeCuenta registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(registro))
                return data.ValidationErrors(registro);
            data.MaestroDeCuentaRepository.Delete(registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
    }
}
