namespace PruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("producto")]
    public partial class producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public producto()
        {
            pedido = new HashSet<pedido>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idProducto { get; set; }

        [Required]
        [StringLength(100)]
        public string nombre { get; set; }

        public decimal? precio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pedido> pedido { get; set; }
    }
}
