using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public Tag FindTag(string id)
        {
            return data.TagsRepository.Find(id);
        }
        public Tag[] GetAllEtiquetas(string texto)
        {  
            var x = data.TagsRepository.GetAsNoTracking(
                    d => (d.Descripcion.Contains(texto) ),
                    q => q.OrderBy(d => d.Descripcion)
                    );
            return x.Distinct().ToArray();
        }
        public string VerificarTagDuplicado(Tag current)
        {
            StringBuilder retorno = new StringBuilder();
            {
                var x = (data.TagsRepository.GetFirst(
                d => d.Descripcion.Equals(current.Descripcion) && !d.ID.Equals(current.ID) 
                ));
                if (x != null)
                    retorno.AppendLine("Descripcion Duplicado");
            }
            if (string.IsNullOrEmpty(retorno.ToString()))
                return null;
            return retorno.ToString();
        }
        public string GuardarTag(Tag entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (VerificarTagDuplicado(entity) != null)
                return VerificarTagDuplicado(entity);
            if (FindTag(entity.ID) == null)
            {
                data.TagsRepository.Insert(entity);
            }
            else
            {
                data.TagsRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarTag(Tag Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.TagsRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }

    }
}
