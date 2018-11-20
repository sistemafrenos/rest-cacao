using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using HK;
using HK.Clases;
using HK.BussinessLogic;

namespace HK
{

    public class Reportes
    {
        public static void ImprimirCotizacionTickera(Cotizacion Cotizacione)
        {
            if (Cotizacione == null)
                return;
            Parametro Empresa = OK.SystemParameters;
            LPrintWriter p = new LPrintWriter();
            p.WriteLine(Empresa.Empresa);
            p.WriteLine(Empresa.EmpresaRif);
            p.WriteLine(Empresa.EmpresaDireccion);
            p.WriteLine(Empresa.EmpresaTelefonos);
            p.WriteLine("================================================================================");
            //    1234567890123456789012345678901234567890
            p.WriteLine(Basicas.PrintFix("COTIZACION", 80, 3));
            p.WriteLine("================================================================================");
            p.WriteLine(Basicas.PrintFix(" Fecha:" + Cotizacione.Fecha.ToShortDateString(), 80, 2));
            p.WriteLine(Basicas.PrintFix("Numero:" + Cotizacione.Numero, 80, 2));
            p.WriteLine(Cotizacione.RazonSocial);
            p.WriteLine(Cotizacione.CedulaRif);
            p.WriteLine(Cotizacione.Direccion);
            p.WriteLine("================================================================================");
            foreach (var Item in Cotizacione.DocumentosProductos)
            {
                if (Item.Cantidad == 1)
                {
                    p.Write(Basicas.PrintFix(Item.Descripcion, 12, 1));
                    p.Write(Basicas.PrintFix(Item.Descripcion, 49, 1));
                    p.WriteLine(Basicas.PrintNumero(Item.Total, 8));
                }
                else
                {
                    p.WriteLine(Basicas.PrintFix(Item.Descripcion, 40, 1));
                    p.Write(Basicas.PrintNumero(Item.Cantidad, 6) + " x ");
                    p.Write(Basicas.PrintNumero(Item.Precio, 8));
                    p.WriteLine(Basicas.PrintNumero(Item.Total, 8));
                }
            }
            p.WriteLine("================================================================================");
            p.WriteLine(Basicas.PrintFix("    EXENTO:" + Basicas.PrintNumero(Cotizacione.MontoExento, 8), 15, 2));
            p.WriteLine(Basicas.PrintFix("  GRAVABLE:" + Basicas.PrintNumero(Cotizacione.MontoGravable, 8), 18, 2));
            p.WriteLine(Basicas.PrintFix("DESCUENTOS:" + Basicas.PrintNumero(Cotizacione.Descuentos, 8), 18, 2));
            p.WriteLine(Basicas.PrintFix("       IVA:" + Basicas.PrintNumero(Cotizacione.MontoIva, 8), 15, 2));
            p.WriteLine(Basicas.PrintFix("     TOTAL:" + Basicas.PrintNumero(Cotizacione.MontoTotal, 8), 15, 2));
            p.WriteLine("================================================================================");
            p.WriteLine(Empresa.NotaPieCotizacion);
            p.WriteLine(" ");
            p.WriteLine(".");
            p.WriteLine(" ");
            p.WriteLine(".");
            p.WriteLine(" ");
            p.WriteLine(".");
            p.WriteLine(" ");
            p.WriteLine(".");
            p.WriteLine(" ");
            p.Flush();
        }
    }
}
