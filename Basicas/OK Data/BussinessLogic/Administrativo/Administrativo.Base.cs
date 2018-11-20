using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public partial class Administrativo : IDisposable
    {
        protected UOW data;
        public Administrativo() 
        { 
            data = new UOW();
        }
        public static string ReadContador(string variable)
        {
            DatosEntities d = new DatosEntities();
            var item = d.Set<Contador>().FirstOrDefault(x => x.Variable == variable);
            if (item == null)
            {
                item = new Contador();
                item.Valor = 1;
                item.Variable = variable;
            }
            return item.Valor.Value.ToString("000000");
        }
        public static string GetContador(string variable)
        {
            DatosEntities d = new DatosEntities();
            var item = d.Set<Contador>().FirstOrDefault(x => x.Variable == variable);
            if (item == null)
            {
                item = new Contador();
                item.Valor = 1;
                item.Variable = variable;
                d.Contadores.Add(item);
                d.SaveChanges();
            }
            else
            {
                item.Valor++;
                d.SaveChanges();
            }
            return item.Valor.Value.ToString("000000");
        }
        public static void SetContador(string variable, int valor)
        {
            DatosEntities d = new DatosEntities();
            var item = d.Set<Contador>().FirstOrDefault(x => x.Variable == variable);
            if (item == null)
            {
                item = new Contador();
                item.Valor = 1;
                item.Variable = variable;
                d.Contadores.Add(item);
                d.SaveChanges();
            }
            item.Valor = valor;
            d.SaveChanges();
            return;
        }
        public Tercero[] GetTercerosConSaldoPendiente(string texto, string tipo)
        {
            var x = data.ClienteRepository.GetAsNoTracking(
            d => (d.RazonSocial.Contains(texto) || d.CedulaRif.Contains(texto)) && d.Tipo.Equals(tipo) ,
            q => q.OrderBy(d => d.RazonSocial)
            );
            return x.ToArray();
        }
        // Configuracion
        public SistemaConfig SistemaConfig
        {
            get { return data.SistemaConfig; }
        }
        public PuntoVentaConfig PuntoVentaConfig
        {
            get { return data.PuntoVentaConfig; }
        }
        public Parametro Parametros
        {
            get { return data.SystemParameters; }
        }
        public string GuardarParametros()
        {
            if (Parametros.TasaIva == Parametros.TasaIvaB)
            {
                return "Las Tasas de Iva A y B no pueden ser iguales";
            }
            if (!data.IsValid(Parametros))
                return data.ValidationErrors(Parametros);
            data.ParametroRepository.Update(Parametros);
            return data.Save();
        }

        // Bancos
        public Banco[] GetAllBancos(string texto)
        {
            var x = data.BancoRepository.GetAsNoTracking(
                    d => (d.Cuenta.Contains(texto) || d.Descripcion.Contains(texto)),
                    q => q.OrderBy(d => d.Descripcion)
                    );
            return x.ToArray();
        }
        public string GuardarCambios()
        {
            return data.Save();
        }
        public void Dispose()
        {
            //
        }
        // Cuentas x Cobrar

        public TercerosMovimiento[] GetCxPProveedor(Tercero proveedor)
        {
            throw new NotImplementedException();
        }
        public Resumen[] facturasVentasxDepartamento(DateTime desde, DateTime hasta)
        {
            var q = from factura in data.context.Documentos
                    join facturaproducto in data.context.DocumentosProductos on factura.ID equals facturaproducto.Documento.ID
                    orderby facturaproducto.Descripcion
                    where factura.Fecha >= desde && factura.Fecha <= hasta
                    group facturaproducto by facturaproducto.Departamento into grupo
                    select new Resumen
                    {
                        Descripcion = grupo.Key,
                        Bolivares = grupo.Sum(x => x.Total),
                        Cantidad = grupo.Sum(x => x.Cantidad)
                    };
            return q.ToArray();
        }
        public Resumen[] facturasVentasxProducto(DateTime desde, DateTime hasta)
        {
            var q = from factura in data.context.Documentos
                    join facturaproducto in data.context.DocumentosProductos on factura.ID equals facturaproducto.Documento.ID
                    orderby facturaproducto.Descripcion
                    where factura.Fecha >= desde && factura.Fecha <= hasta
                    group facturaproducto by facturaproducto.Descripcion into grupo
                    select new Resumen
                    {
                        Descripcion = grupo.Key,
                        Bolivares = grupo.Sum(x => x.Total),
                        Cantidad = grupo.Sum(x => x.Cantidad)
                    };
            return q.ToArray();
        }
        public Pago PagosxFecha(DateTime desde, DateTime hasta)
        {
            Pago result = new Pago();
            var q = from item in data.context.Pagos
                    where item.Fecha >= desde && item.Fecha <= hasta
                    select item;
            result.Cheque = q.Sum(x => x.Cheque);
            result.Credito = q.Sum(x => x.Credito);
            result.Deposito = q.Sum(x => x.Deposito);
            result.Efectivo = q.Sum(x => x.Efectivo);
            result.TarjetaCredito = q.Sum(x => x.TarjetaCredito);
            result.TarjetaDebito = q.Sum(x => x.TarjetaDebito);
            result.Transferencia = q.Sum(x => x.Transferencia);
            return result;
        }

    }
}

