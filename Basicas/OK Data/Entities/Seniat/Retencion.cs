using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class Retencion : Documento
    {
        [NotMapped]
        public string PeriodoImpositivo { set; get; }
        [NotMapped]
        public string TipoOperacion { set; get; }
        [NotMapped]
        public string Periodo { set; get; }
        public override void Calcular()
        {
            this.MontoRetenido = 
                   (this.MontoSujetoRetencion * this.PorcentajeRetencion / 100) 
                  - this.Sustraendo.GetValueOrDefault(0);
        }
    }
}
