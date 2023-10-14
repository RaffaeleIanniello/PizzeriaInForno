namespace PizzeriaInForno.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordini")]
    public partial class ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ordini()
        {
            dettagli = new HashSet<dettagli>();
        }

        [Key]
        public int idOrdini { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataOrdine { get; set; }

        [Required]
        [StringLength(50)]
        public string indirizzoConsegna { get; set; }

        [Required]
        [StringLength(50)]
        public string evaso { get; set; }

        [Required]
        [StringLength(50)]
        public string notaOrdine { get; set; }

        public int? totaleOrdine { get; set; }

        public int fkUtenti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dettagli> dettagli { get; set; }

        public virtual utenti utenti { get; set; }
    }
}
