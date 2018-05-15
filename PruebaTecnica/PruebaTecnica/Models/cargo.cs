namespace PruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cargo")]
    public partial class cargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cargo()
        {
            usuario = new HashSet<usuario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int car_cod { get; set; }

        [Required]
        [StringLength(100)]
        public string car_des { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuario> usuario { get; set; }
    }
}
