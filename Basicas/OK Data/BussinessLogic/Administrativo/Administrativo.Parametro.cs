using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        // Parametros
        public Parametro FindParametro(string id)
        {
            return data.ParametroRepository.Find(id);
        }
        public Parametro GetFirstParametro()
        {
            return data.ParametroRepository.GetFirst();
        }
        public Parametro CloneParametro(object OldItem)
        {
            Parametro Parametro = OK.DeepCopy<Parametro>((Parametro)OldItem);
            Parametro.ID = Guid.NewGuid().ToString();
            return Parametro;
        }
        public string GuardarParametro(Parametro entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (FindParametro(entity.ID) == null)
            {
                data.ParametroRepository.Insert(entity);
            }
            else
            {
                data.ParametroRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarParametro(Parametro Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.ParametroRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
    }
}
