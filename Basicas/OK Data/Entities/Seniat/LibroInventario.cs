namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public partial class LibroInventario : Entity
    {
        [MaxLength(40)]
        [Required(ErrorMessage = "Es requerido el codigo del producto")]
        public string Codigo { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Es requerido la descripcion del producto")]
        public string Descripcion { get; set; }
        public Nullable<DateTime> UltimaEdicion { get; set; }
        public Nullable<double> Inicio { get; set; }
        public Nullable<double> Entradas { get; set; }
        public Nullable<double> Salidas { get; set; }
        public Nullable<double> Autoconsumo { get; set; }
        public Nullable<double> Final { get; set; }
        public Nullable<double> Costo { get; set; }
        public Nullable<int> Mes { get; set; }
        public Nullable<int> Ano { get; set; }
        public Nullable<DateTime> Fecha { get; set; }
        public void Calcular()
        {
            this.Final = this.Inicio.GetValueOrDefault(0)
                + this.Entradas.GetValueOrDefault(0)
                - this.Salidas.GetValueOrDefault(0)
                - this.Autoconsumo.GetValueOrDefault(0);
        }
    }
}
