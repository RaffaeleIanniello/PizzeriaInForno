namespace PizzeriaInForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dettagli")]
    public partial class dettagli
    {
        [Key]
        public int idDettagli { get; set; }

        public int fkProdotti { get; set; }

        public int fkOrdini { get; set; }

        public int quantita { get; set; }

        public virtual ordini ordini { get; set; }

        public virtual prodotti prodotti { get; set; }
    }
}
