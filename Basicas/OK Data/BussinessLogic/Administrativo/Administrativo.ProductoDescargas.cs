using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        public string GuardarDescarga(DocumentosProducto descarga)
        {
            ProductoDescarga documento = new ProductoDescarga();
            documento.Mes = documento.Fecha.Month;
            documento.Ano = documento.Fecha.Year;
            documento.Vence = documento.Fecha;
            documento.CedulaRif = "V000000000";
            documento.RazonSocial = "ÏNTERNO";
            documento.Calcular();
            documento.Numero = GetContador(documento.Tipo);
            documento.DocumentosProductos.Add(descarga);
            documento.Calcular();
            string result = ValidarDocumento(documento);
            if (result != null)
                return result;
            if (data.DescargaRepository.Find(descarga.ID) == null)
                data.DescargaRepository.Insert(documento);
            else
                data.DescargaRepository.Update(documento);
            ProcesarInventarios(documento,false);
            result = EscribirLibroInventarios(documento, false);
            if (result != null)
                return result;
            return data.Save();
        }
    }
}
