using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HK.BussinessLogic
{
    public class Resumen
    {
        public Nullable<DateTime> Fecha { set; get; }
        public string Descripcion { set; get; }
        public double? Cantidad { set; get; }
        public double? Bolivares { set; get; }
        public double? Porcentaje { set; get; }
        public double? Comision { set; get; }
    }
    public class ProductosMovimientos
    {
        public DateTime? Fecha { set; get; }
        public string Numero { set; get; }
        public string Concepto { set; get; }
        public string RazonSocial { set; get; }
        public string Codigo { set; get; }
        public string Descripcion { set; get; }
        public double? Costo { set; get; }
        public double? Precio { set; get; }
        public double? Inicio { set; get; }
        public double? Entrada { set; get; }
        public double? Salida { set; get; }
        public double? Final { set; get; }
    }
}
