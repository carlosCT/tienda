namespace PruebaTecnica.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int usu_cod { get; set; }

        [Required]
        [StringLength(100)]
        public string usu_nom { get; set; }

        public int car_cod { get; set; }

        public virtual cargo cargo { get; set; }

    
    }
}
