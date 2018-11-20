using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HK;

namespace HK.Clases
{
    public class FactoryCompras
    {
        public static Documento Item(string id)
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var item = (from x in db.Documentos
                            where (x.IdDocumento == id)
                            select x).FirstOrDefault();
                return item;
            }
        }
        public static Documento Item(DatosEntities db, string id)
        {
            var item = (from x in db.Documentos
                        where (x.IdDocumento == id)
                        select x).FirstOrDefault();
            return item;
        }
        public static Documento Item(DatosEntities db , string numero, string cedulaRif)
        {
            var item = (from x in db.Documentos
                        where (x.Numero == numero && x.CedulaRif == cedulaRif)
                        select x).FirstOrDefault();
            return item;
        }
        public static List<Documento> getComprasEspera(DatosEntities db, string texto)
        {
            var mFacturas = (from x in db.Documentos
                             orderby x.IdDocumento
                             where (x.Estatus == "ESPERA")
                             select x).ToList();
            return mFacturas;
        }
        public static void PasarComprasLibro()
        {
            using (DatosEntities db = new DatosEntities(OK.CadenaConexion))
            {
                var x = (from p in db.Documentos
                         where p.LibroCompras == false && p.Tipo == "COMPRA"
                         select p).ToList();
                foreach (var item in x)
                {
                    if (!FactoryLibroCompras.Existe(item))
                    {
                        FactoryLibroCompras.EscribirItem(item);
                    }
                }
            }
        }
        public static Documento ReversarCompra(Documento registro)
        {
            using (var tempDb = new DatosEntities(OK.CadenaConexion))
            {
                Documento x = FactoryCompras.Item(tempDb, registro.IdDocumento);
                if (x != null)
                {
                    registro.Tipo = "DEVOLUCION";
                    FactoryCompras.InventarioDevolver(x);
                    FactoryLibroCompras.EliminarItem(x);
                    FactoryCuentasxPagar.ReversarMovimiento(x);
                    FactoryCajasChica.ReversarItem(x);
                    Documento nuevo = new Documento();
                    nuevo.AÃ ±
                    o = registro.AÃ±
                    ;
                    o;
                    nuevo.CedulaRif = registro.CedulaRif;
                    nuevo.CodigoCuenta = registro.CodigoCuenta;
                    nuevo.Comentarios = registro.Comentarios;
                    nuevo.DescripcionCuenta = registro.DescripcionCuenta;
                    nuevo.Descuentos = registro.Descuentos;
                    nuevo.Direccion = registro.Direccion;
                    nuevo.Estatus = registro.Estatus;
                    nuevo.Fecha = registro.Fecha;
                    nuevo.LibroCompras = false;
                    nuevo.LibroInventarios = false;
                    nuevo.Mes = registro.Mes;
                    nuevo.MontoExento = registro.MontoExento;
                    nuevo.MontoGravable = registro.MontoGravable;
                    nuevo.MontoGravableB = registro.MontoGravableB;
                    nuevo.MontoImpuestosLicores = registro.MontoImpuestosLicores;
                    nuevo.MontoIva = registro.MontoIva;
                    nuevo.MontoIvaB = registro.MontoIvaB;
                    nuevo.MontoSinDerechoCredito = registro.MontoSinDerechoCredito;
                    nuevo.MontoTotal = registro.MontoTotal;
                    nuevo.Numero = x.Numero;
                    nuevo.NumeroControl = x.NumeroControl;
                    nuevo.RazonSocial = x.RazonSocial;
                    nuevo.TasaIva = registro.TasaIva;
                    nuevo.TasaIvaB = registro.TasaIvaB;
                    nuevo.Vence = registro.Vence;
                    nuevo.AsignarID();
                    nuevo.Tipo = "COMPRA";
                    foreach (var item in registro.DocumentosProductos)
                    {
                        var nuevoItem = new DocumentosProducto();
                        nuevoItem.Cantidad = item.Cantidad;
                        nuevoItem.Entrada = item.Entrada;
                        nuevoItem.Codigo = item.Codigo;
                        nuevoItem.CodigoProveedor = item.CodigoProveedor;
                        nuevoItem.Costo = item.Costo;
                        nuevoItem.CostoIva = item.CostoIva;
                        nuevoItem.CostoNeto = item.CostoNeto;
                        nuevoItem.Departamento = item.Departamento;
                        nuevoItem.Descripcion = item.Descripcion;
                        nuevoItem.Inicio = item.Inicio;
                        nuevoItem.Final = item.Final;
                        nuevoItem.IdDocumentoProducto = null;
                        nuevoItem.IdProducto = item.IdProducto;
                        nuevoItem.ImpuestoLicores = item.ImpuestoLicores;
                        nuevoItem.Iva = item.Iva;
                        nuevoItem.Precio = item.Precio;
                        nuevoItem.Precio2 = item.Precio2;
                        nuevoItem.PrecioConIva = item.PrecioConIva;
                        nuevoItem.PrecioConIva2 = item.PrecioConIva2;
                        nuevoItem.TasaIva = item.TasaIva;
                        nuevoItem.Total = item.Total;
                        nuevoItem.UnidadMedida = item.UnidadMedida;
                        nuevoItem.Utilidad = item.Utilidad;
                        nuevoItem.Utilidad2 = item.Utilidad2;
                        nuevo.DocumentosProductos.Add(nuevoItem);
                    }
                    tempDb.Documentos.Remove(x);
                    tempDb.SaveChanges();
                    return nuevo;
                }
                else
                    return registro;
            }

        }
        public static void InventarioDevolver(Documento registro)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                foreach (DocumentosProducto item in registro.DocumentosProductos)
                {
                    Producto p = db.Productos.Where(x => x.IdProducto == item.IdProducto).FirstOrDefault();
                    if (p != null)
                    {
                        if (p.LlevaInventario.Value)
                        {
                            p.Existencia = p.Existencia.GetValueOrDefault(0) - item.Entrada;
                        }
                    }
                }
                db.SaveChanges();
            }
        }
        public static List<Documento> ComprasSinRetencion(Tercero proveedor)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                var items  = from x in db.Documentos
                             where x.ComprobanteRetencion == null && x.CedulaRif == proveedor.CedulaRif
                             select x;
                return items.ToList();
            }
        }
        internal static object getComprasProveedor(DatosEntities db, string Texto)
        {
            var items = from x in db.Documentos
                        where x.ComprobanteRetencion == null && x.CedulaRif == Texto
                        && x.Estatus != "ABIERTA"
                        select x;
            return items.ToList();
        }
        public static void Inventario(Documento registro)
        {
            using (var db = new DatosEntities(OK.CadenaConexion))
            {
                List<DocumentosProducto> items = (from x in db.DocumentosProductos
                                                  where x.IdDocumento == registro.IdDocumento
                                                  select x).ToList();
                foreach (DocumentosProducto item in items)
                {
                    Producto p = db.Productos.Where(x => x.IdProducto == item.IdProducto).FirstOrDefault();
                    if (p != null)
                    {
                        p.Costo = Basicas.Round(item.CostoNeto);
                        if (p.LlevaInventario.GetValueOrDefault(false))
                        {
                            //  FactoryProductos.RegistrarMovimientos(item,p);
                            if (registro.Tipo == "COMPRA" || registro.Tipo == "CARGA")
                                p.Existencia = p.Existencia.GetValueOrDefault(0) + item.Entrada;
                            if (registro.Tipo == "DESCARGA")
                                p.Existencia = p.Existencia.GetValueOrDefault(0) - item.Entrada;

                        }
                        if (p.HabilitadoParaVentas.GetValueOrDefault(true))
                        {
                            p.Precio = Basicas.Round(item.Precio);
                            p.Precio2 = Basicas.Round(item.Precio2);
                            p.PrecioConIva = Basicas.Round(item.PrecioConIva);
                            p.PrecioConIva2 = Basicas.Round(p.PrecioConIva2);
                            //p.Utilidad = item.Utilidad;
                            //p.Utilidad2 = item.Utilidad2;

                        }
                        p.UltimoProveedor = registro.RazonSocial;
                    }
                }
                db.SaveChanges();
            }
        }
    }
}

