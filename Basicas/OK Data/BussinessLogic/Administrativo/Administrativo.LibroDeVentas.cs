using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo : IDisposable
    {
        // Libro De Ventas
        public LibroVenta FindLibroVenta(string id)
        {
            return data.LibroVentaRepository.Find(id);
        }
        public void EscribirLibroDeVentas(int mes, int ano)
        {
            data.GetContext().Database.ExecuteSqlCommand(string.Format("Delete Adm.LibroVentas Where mes={0} and  ano={1}",mes,ano));
            var documentos = data.DocumentosRepository.dbSet.Where(x=>(x.Ano== ano && x.Mes== mes) && (x.Tipo=="FACTURA" || x.Tipo=="NOTA CREDITO")).ToList();
            foreach(var  x in  documentos )
            {
                EscribirLibroDeVentas(x);
            }
            data.Save();
            return;
        }
        public string EscribirLibroDeVentas(Documento factura)
        {  
            return GuardarLibroVenta(CrearItemLibroDeVentas(factura), false);
        }

        public LibroVenta CrearItemLibroDeVentas(Documento factura)
        {
            LibroVenta current;
            if (string.IsNullOrEmpty(factura.Numero))
                return null;
            current = new LibroVenta();
            current.Ano = factura.Fecha.Year;
            current.CedulaRif = factura.CedulaRif;
            current.Fecha = factura.Fecha;
            current.FacturaID = factura.ID;
            current.IvaRetenido = null;
            current.Mes = factura.Fecha.Month;
            current.Comprobante = null;
            current.FacturaAfectada = factura.DocumentoAfectado;
            current.MontoTotal = factura.MontoTotal;
            current.NumeroZ = factura.NumeroZ;
            current.RazonSocial = factura.RazonSocial;
            current.MaquinaFiscal = factura.MaquinaFiscal;
            current.Factura = factura.Numero;
            current.MontoExento = factura.MontoExento;
            if (factura.CedulaRif[0] == 'V' || factura.CedulaRif[0] == 'E')
            {
                current.MontoGravableNoContribuyentes = factura.MontoGravable;
                current.MontoIvaNoContribuyentes = factura.MontoIva;
                current.TasaIvaNoContribuyentes = factura.TasaIva;
            }
            else
            {
                current.MontoGravableContribuyentes = factura.MontoGravable;
                current.MontoIvaContribuyentes = factura.MontoIva;
                current.TasaIvaContribuyentes = factura.TasaIva;
            }
            if (factura.Tipo == "FACTURA")
            {
                current.TipoOperacion = "01";

            }
            else
            {
                current.TipoOperacion = "02";
                current.MontoExento = current.MontoExento * -1;
                current.MontoGravableContribuyentes = current.MontoGravableContribuyentes * -1;
                current.MontoIvaContribuyentes = current.MontoIvaContribuyentes * -1;
                current.TasaIvaContribuyentes = current.TasaIvaContribuyentes * -1;
                current.MontoGravableNoContribuyentes = current.MontoGravableNoContribuyentes * -1;
                current.MontoIvaNoContribuyentes = current.MontoIvaNoContribuyentes * -1;
                current.TasaIvaNoContribuyentes = current.TasaIvaNoContribuyentes * -1;
                current.MontoTotal = current.MontoTotal * -1;
                current.Factura = null;
                current.NotaCredito = factura.Numero;
            }
            return current;
        }
        public LibroVenta[] GetByMesLibroVentas(int mes, int ano)
        {
            var x = data.LibroVentaRepository.GetAsNoTracking(
            d => d.Ano == ano && d.Mes == mes,
            q => q.OrderBy(d => d.Factura)
            );
            return x.ToArray();
        }
        public LibroVenta[] ResumirLibroVenta(LibroVenta[] detallado)
        {
            List<LibroVenta> libro = new List<LibroVenta>();
            if (detallado.FirstOrDefault() == null)
                return detallado;
            LibroVenta itemActual = null;
            LibroVenta itemInicial = null;
            LibroVenta ultimoItem = null;
            string Inicio = "";
            foreach (LibroVenta item in detallado.OrderBy(x => x.Factura))
            {
                if (itemActual == null)
                {
                    itemActual = item;
                    ultimoItem = item;
                    Inicio = item.Factura;
                    itemActual.Inicio = Inicio;
                    itemActual.Final = Inicio;
                }
                else
                {
                    if (item.NumeroZ == itemActual.NumeroZ && (item.CedulaRif.Substring(0, 1) == "V" || item.CedulaRif.Substring(0, 1) == "E"))
                    {
                        itemActual.MontoIvaContribuyentes = itemActual.MontoIvaContribuyentes + item.MontoIvaContribuyentes;
                        itemActual.MontoTotal = itemActual.MontoTotal + item.MontoTotal;
                        itemActual.MontoExento = itemActual.MontoExento + item.MontoExento;
                        itemActual.MontoGravableContribuyentes = itemActual.MontoGravableContribuyentes + item.MontoGravableContribuyentes;
                        itemActual.RazonSocial = "CONTADO";
                        itemActual.CedulaRif = "V000000000";
                        itemActual.Factura = Inicio + " " + item.Factura;
                        ultimoItem = item;
                        itemActual.Final = item.Factura;
                    }
                    else
                    {
                        if (item.CedulaRif.Substring(0, 1) == "V" || item.CedulaRif.Substring(0, 1) == "E")
                        {
                            libro.Add(itemActual);
                            itemActual = item;
                            itemInicial = item;
                            ultimoItem = item;
                            Inicio = item.Factura;
                            itemActual.Inicio = Inicio;
                            itemActual.Final = Inicio;
                        }
                        else
                        {
                            if (item.ID != itemActual.ID)
                            {
                                libro.Add(itemActual);
                            }
                            libro.Add(item);
                            itemActual = null;
                        }
                    }
                }
            }
            if (itemActual != null)
            {
                libro.Add(itemActual);
            }
            foreach (var item in libro)
            {
                if (item.CedulaRif[0] == 'J' || item.CedulaRif[0] == 'G')
                {
                    item.Inicio = item.Factura;
                    item.Final = item.Factura;
                }
            }
            return libro.ToArray();
        }
        public LibroVenta[] ResumirLibroVentaNumeroZ(LibroVenta[] detallado)
        {
            LibroVenta itemActual = null;
            LibroVenta ultimoItem = null;
            string Inicio = "";
            List<LibroVenta> libro = new List<LibroVenta>();
            foreach (LibroVenta item in detallado)
            {
                if (itemActual == null)
                {
                    itemActual = item;
                    ultimoItem = item;
                    Inicio = item.Factura;
                    itemActual.Inicio = Inicio;
                    itemActual.Final = Inicio;
                }
                else
                {
                    if (item.NumeroZ == itemActual.NumeroZ)
                    {
                        itemActual.MontoExento = itemActual.MontoExento + item.MontoExento;
                        itemActual.MontoTotal = itemActual.MontoTotal + item.MontoTotal;
                        itemActual.MontoGravableContribuyentes = itemActual.MontoGravableContribuyentes.GetValueOrDefault() + item.MontoGravableContribuyentes.GetValueOrDefault();
                        itemActual.MontoGravableNoContribuyentes = itemActual.MontoGravableNoContribuyentes.GetValueOrDefault() + item.MontoGravableNoContribuyentes.GetValueOrDefault();
                        itemActual.MontoIvaContribuyentes = itemActual.MontoIvaContribuyentes.GetValueOrDefault() + item.MontoIvaContribuyentes.GetValueOrDefault();
                        itemActual.MontoIvaNoContribuyentes = itemActual.MontoIvaNoContribuyentes.GetValueOrDefault() + item.MontoIvaNoContribuyentes.GetValueOrDefault();
                        itemActual.TasaIvaContribuyentes = item.TasaIvaContribuyentes;
                        itemActual.TasaIvaNoContribuyentes = item.TasaIvaNoContribuyentes;
                        itemActual.Factura = Inicio + " " + item.Factura;
                        ultimoItem = item;
                        itemActual.Final = item.Factura;
                    }
                    else
                    {
                        if (item.ID != itemActual.ID)
                        {
                            libro.Add(itemActual);
                        }
                        libro.Add(item);
                        itemActual = null;
                    }
                }
            }
            if (itemActual != null)
            {
                libro.Add(itemActual);
            }
            return libro.ToArray();
        }
        public string GuardarLibroVenta(LibroVenta entity, bool guardarAhora)
        {
            try
            {
                if (!data.IsValid(entity))
                    return data.ValidationErrors(entity);
                if (FindLibroVenta(entity.ID) == null)
                {
                    data.LibroVentaRepository.Insert(entity);
                }
                else
                {
                    data.LibroVentaRepository.Update(entity);
                }
                if (guardarAhora)
                {
                    return data.Save();
                }
            }
            catch (Exception x)
            {
                string s = x.Message;
            }
            return null;
        }
        public string EliminarLibroVenta(LibroVenta Registro, Boolean eliminarAhora)
        {
            data.LibroVentaRepository.Delete(Registro);
            if (eliminarAhora)
            {
                return data.Save();
            }
            return null;
        }
    }
}
