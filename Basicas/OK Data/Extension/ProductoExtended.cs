using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public static class ProductoExtended
    {
        public static double? CalcularPrecio(double? costo, double? utilidad)
        {
            try
            {
                if (OK.SystemParameters.CalculoPrecios == "SOBRE COSTOS")
                {
                    return (double)Decimal.Round((decimal)(costo + (costo * utilidad / 100)), 2);
                }
                else
                {

                    return (double)Decimal.Round((decimal)(costo / (1 - (utilidad / 100))), 2);
                }
            }
            catch
            {
                return 0;
            }
        }
        public static double? CalcularUtilidad(double? costo, double? precio)
        {
            try
            {
                if (precio == 0 || costo == 0)
                    return 0;
                if (OK.SystemParameters.CalculoPrecios == "SOBRE COSTOS")
                {
                    return ((precio / costo) - 1) * 100;
                }
                else
                {
                    return ((precio - costo) * 100) / precio;
                }

            }
            catch
            {
                return 0;
            }
        }
        public static double? PrecioConIva(double? precio, double? TasaIva)
        {
            return precio.GetValueOrDefault(0) + (precio.GetValueOrDefault(0) * TasaIva.GetValueOrDefault(0) / 100);
        }
        public static double? PrecioBase(double? precioConIva, double? TasaIva)
        {
            //(double)Decimal.Round((decimal)(precioConIva.GetValueOrDefault(0) / (1 + (TasaIva.GetValueOrDefault(0) / 100))), 2);
            return precioConIva.GetValueOrDefault(0) / (1 + (TasaIva.GetValueOrDefault(0) / 100));
        }
    }
}
