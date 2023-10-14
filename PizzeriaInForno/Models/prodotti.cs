namespace PizzeriaInForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("prodotti")]
    public partial class prodotti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prodotti()
        {
            dettagli = new HashSet<dettagli>();
        }

        [Key]
        public int idProdotti { get; set; }

        [Required]
        [StringLength(50)]
        public string nomeProdotto { get; set; }

        [Required]
        public string ingredienti { get; set; }

        public int prezzoProdotto { get; set; }

        public int tempoConsegna { get; set; }

        [Required]
        public string fotoProdotto { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dettagli> dettagli { get; set; }
    }
}
