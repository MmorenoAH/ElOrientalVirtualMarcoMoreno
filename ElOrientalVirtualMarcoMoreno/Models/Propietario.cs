using System;
using System.ComponentModel.DataAnnotations;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class Propietario
    {
        [Key]
        public int IdPropietario { get; set; }
        [Required]
        [StringLength(50)]
        public string NombrePropietario { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCeacion { get; set; } = DateTime.Now;

    }
}
