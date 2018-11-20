using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK
{
    public class RetencionISLR : Documento
    {
        public override void Calcular()
        {
            MontoRetenido =
                   (MontoSujetoRetencion * PorcentajeRetencion / 100)
                  - Sustraendo.GetValueOrDefault(0);
        }
    }
}
