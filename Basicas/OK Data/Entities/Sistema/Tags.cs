namespace HK
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using HK.BussinessLogic;

    public class Tag : Entity
    {
        [MaxLength(40)]
        public string ReferenceID { get; set; }
        [MaxLength(80)]
        public string Descripcion { get; set; }
    }
}
