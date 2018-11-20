using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo
    {
        public string GuardarCarga(DocumentosProducto carga, Tercero proveedor)
        {
            if (proveedor == null)
                throw new Exception("Debe asignar un proveedor valido");
            ProductoCarga documento = new ProductoCarga();
            documento.Mes = documento.Fecha.Month;
            documento.Ano = documento.Fecha.Year;
            documento.Vence = documento.Fecha;
            documento.CedulaRif = proveedor.CedulaRif;
            documento.RazonSocial = proveedor.RazonSocial;
            documento.Tercero = proveedor;
            documento.Numero = GetContador(documento.Tipo);
            documento.DocumentosProductos.Add(carga);
            documento.Calcular();
            string result = ValidarDocumento(documento);
            if (result != null)
                return result;
            if (data.CargaRepository.Find(carga.ID) == null)
                data.CargaRepository.Insert(documento);
            else
                data.CargaRepository.Update(documento);
            ProcesarInventarios(documento,false);
            ProductosActualizarPrecios(documento,false);
            EscribirLibroInventarios(documento,false);
            return data.Save();
        }
    }
}
