using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    partial class Administrativo
    {
        public LibroInventario FindLibroInventario(string id)
        {
            return data.LibroInventarioRepository.Find(id);
        }
        private LibroInventario getItemLibroInventario(int mes, int ano, DocumentosProducto prod)
        {
            LibroInventario retorno = data.LibroInventarioRepository.GetFirst(
                                                                        p => p.Mes == mes
                                                                        && p.Ano == ano
                                                                        && p.Codigo == prod.Codigo);
            if (retorno != null)
                return retorno;
            DateTime FechaInventario = Convert.ToDateTime(String.Format("01/{0:00}/{1:0000}", mes, ano));
            LibroInventario UltimoRegistro = data.LibroInventarioRepository.GetLast(
                                                                        p => p.Codigo == prod.Codigo
                                                                        && p.Fecha < FechaInventario);
            if (UltimoRegistro == null)
            {
                UltimoRegistro = new LibroInventario();
                UltimoRegistro.Final = 0;
            }
            retorno = new LibroInventario();
            retorno.Ano = ano;
            retorno.Mes = mes;
            retorno.Codigo = prod.Codigo;
            retorno.Descripcion = prod.Descripcion;
            retorno.Costo = prod.Costo;
            retorno.Fecha = FechaInventario;
            retorno.Inicio = UltimoRegistro.Final;
            retorno.Salidas = 0;
            retorno.Entradas = 0;
            retorno.Autoconsumo = 0;
            retorno.Final = retorno.Inicio;
            return retorno;
        }
        public string EscribirLibroInventarios(Documento doc, bool guardarAhora)
        {  
            if (data.LibroInventarioRepository.GetFirst(d => d.Mes == doc.Fecha.Month && d.Ano == doc.Fecha.Year) == null)
            {
                CrearMes(doc.Fecha.Month, doc.Fecha.Year);
            }
            foreach (var x in doc.DocumentosProductos.Where(x=> x.LlevaInventario))
            {
                var item = getItemLibroInventario(doc.Fecha.Month,
                                        doc.Fecha.Year,
                                        x
                                        );
                if (item != null)
                {
                        item.Entradas += x.Entrada.GetValueOrDefault(0);
                        item.Salidas += x.Salida.GetValueOrDefault(0);
                        item.Calcular();
                        GuardarLibroInventario(item, false);
                }
                if (guardarAhora)
                {
                    data.Save();
                }
            }
            return null;
        }
        private void CrearMes(int mes, int ano)
        {
            DatosEntities data = new DatosEntities();
            foreach (var producto in data.Productos.Where(x => x.LlevaInventario == true && x.Activo == true && x.Existencia>0).ToList())
            {
                DateTime FechaInventario = Convert.ToDateTime(String.Format("01/{0:00}/{1:0000}", mes, ano));
                LibroInventario UltimoRegistro = data.LibroInventarios.Where(
                    p2 => p2.Codigo == producto.Codigo
                  && p2.Fecha < FechaInventario)
                  .OrderByDescending(x=>x.Fecha)
                  .FirstOrDefault();

                if (UltimoRegistro.Final != 0)
                {
                    var newItem = new LibroInventario();
                    newItem.Ano = ano;
                    newItem.Mes = mes;
                    newItem.Codigo = producto.Codigo;
                    newItem.Descripcion = producto.Descripcion;
                    newItem.Costo = producto.Costo;
                    newItem.Fecha = FechaInventario;
                    newItem.Inicio = UltimoRegistro.Final;
                    newItem.Salidas = 0;
                    newItem.Entradas = 0;
                    newItem.Autoconsumo = 0;
                    newItem.Final = newItem.Inicio;
                    data.LibroInventarios.Add(newItem);
                }
            }
            int registros = data.SaveChanges();
        }
        public string GuardarLibroInventario(LibroInventario entity, bool guardarAhora)
        {
            if (!data.IsValid(entity))
                return data.ValidationErrors(entity);
            if (FindLibroInventario(entity.ID) == null)
            {
                data.LibroInventarioRepository.Insert(entity);
            }
            else
            {
                data.LibroInventarioRepository.Update(entity);
            }
            if (guardarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public string EliminarLibroInventario(LibroInventario Registro, Boolean eliminarAhora)
        {
            if (!data.IsValid(Registro))
                return data.ValidationErrors(Registro);
            data.LibroInventarioRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
        public LibroInventario[] GetByMesLibroInventario(int mes, int ano)
        {

            var query = data.LibroInventarioRepository.GetAsQueryable("");
            var datos = query.Where(d => d.Ano == ano && d.Mes == mes)
                        .OrderBy(d=>d.Descripcion).ToArray();
            return datos;
        }
        public string RegistrarDocumento(Documento doc)
        {
            foreach (var x in doc.DocumentosProductos)
            {
                var item = data.LibroInventarioRepository.GetFirst(d => d.Mes == doc.Fecha.Month
                    && d.Ano == doc.Fecha.Year
                    && d.Codigo == x.Codigo);
                if (item != null)
                {
                    if (doc.Tipo == "COMPRA REVERSO")
                        item.Entradas += x.Entrada;
                    if (doc.Tipo == "CARGA" || doc.Tipo == "COMPRA" || doc.Tipo == "NOTA CREDITO")
                        item.Entradas += x.Entrada;
                    if (doc.Tipo == "FACTURA" || doc.Tipo == "DESCARGA")
                        item.Salidas += x.Salida;
                    item.Calcular();
                    if (data.IsValid(item))
                        return data.ValidationErrors(item);
                    data.LibroInventarioRepository.Insert(item);
                }
            }
            return null;
        }
    }
}
