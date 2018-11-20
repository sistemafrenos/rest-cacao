using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class Compra : Documento
    {
        public Compra()
        {
            LibroCompras = true;
            Tipo = "COMPRA";

        }
        public override void Calcular()
        {
            MontoExento = DocumentosProductos.Where(x => x.TasaIva.GetValueOrDefault(0) == 0).Sum(x => x.Entrada * x.Costo);
            MontoGravable = DocumentosProductos.Where(x => x.TasaIva.Equals(TasaIva)).Sum(x => x.Entrada * x.Costo);
            MontoGravableB = DocumentosProductos.Where(x => x.TasaIva.Equals(TasaIvaB)).Sum(x => x.Entrada * x.Costo);
            Totalizar();
        }
    }
}
