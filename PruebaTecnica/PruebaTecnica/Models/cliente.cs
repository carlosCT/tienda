namespace PruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            pedido = new HashSet<pedido>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idCliente { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string documento { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido> pedido { get; set; }
    }
}
