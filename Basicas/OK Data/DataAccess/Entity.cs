using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HK.BussinessLogic
{
    public class Entity
    {
        public Entity()
        {
            EsNuevo = true;
            ID = Guid.NewGuid().ToString();
        }
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { set; get; }
        [NotMapped]
        public System.Data.Entity.Validation.DbEntityValidationResult ValidationResult { set; get; }
        [NotMapped]
        public bool EsNuevo { set; get; }
    }
}
