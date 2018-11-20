using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo : IDisposable
    {
        // Libro de Compras
        public LibroCompra FindLibroCompra(string id)
        {
            return data.LibroCompraRepository.Find(id);
        }
        public string GuardarLibroCompra(LibroCompra entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (FindLibroCompra(entity.ID) == null)
            {
                data.LibroCompraRepository.Insert(entity);
            }
            else
            {
                data.LibroCompraRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarLibroCompra(LibroCompra Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.LibroCompraRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public LibroCompra[] GetByMesLibroCompra(int mes, int ano)
        {
            var x = data.LibroCompraRepository.Get(
            d => d.Ano == ano && d.Mes == mes,
            q => q.OrderBy(d => d.Fecha)
            );
            return x.ToArray();
        }
        public void EscribirLibroDeCompras(int mes, int ano)
        {
            data.GetContext().Database.ExecuteSqlCommand(string.Format("Delete Adm.LibroCompras Where mes={0} and  ano={1}", mes, ano));
            var documentos = data.DocumentosRepository.dbSet.Where(x => (x.Ano == ano && x.Mes == mes) && (x.Tipo == "COMPRA" || x.Tipo == "NOTA DEBITO")).ToList();
            foreach (var x in documentos)
            {
                EscribirLibroDeCompras((Compra)x);
            }
            data.Save();
            return;
        }
        public string EscribirLibroDeCompras(Compra Compra)
        {
            var current = new LibroCompra();
            current.Ano = Compra.Fecha.Year;
            current.CedulaRif = Compra.CedulaRif;
            current.Fecha = Compra.Fecha;
            current.DocumentoID = Compra.ID;
            current.IvaRetenido = null;
            current.Mes = Compra.Fecha.Month;
            current.ComprobanteRetencion = null;
            current.MontoGravable = Compra.MontoGravable;
            current.MontoIva = Compra.MontoIva;
            current.MontoGravableB = Compra.MontoGravableB;
            current.MontoIvaB = Compra.MontoIvaB;
            current.MontoTotal = Compra.MontoTotal;
            current.RazonSocial = Compra.RazonSocial;
            current.TasaIva = OK.SystemParameters.TasaIva;
            current.TasaIvaB = OK.SystemParameters.TasaIvaB;
          //  current.Tipo = Compra.Tipo == "Compra" ? "01" : "02";
            current.MontoExento = Compra.MontoExento;
            current.Numero = Compra.Numero;
            current.NumeroControl = Compra.NumeroControl;
            return GuardarLibroCompra(current, false);
        }
        public void EliminarLibroDeCompras(Compra compra)
        {
            var item  = data.LibroCompraRepository.GetFirst(x => x.DocumentoID== compra.ID);
            if (item != null)
                data.LibroCompraRepository.Delete(item);
        }
        public void EliminarLibroDeCompras(LibroCompra librocompra)
        {
            var item = data.LibroCompraRepository.Find(librocompra.ID);
            if (item != null)
            {
                data.LibroCompraRepository.Delete(item);
                data.Save();
            }
        }
    }

}