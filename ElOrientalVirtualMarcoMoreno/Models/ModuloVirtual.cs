using System;
using System.ComponentModel.DataAnnotations;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class ModuloVirtual
    {
        [Key]
        public int IdModulo { get; set; }
        [Required]
        [StringLength(20)]
        public string IdPropietario { get; set; }
        [Required]
        [StringLength(500)]
        public string DescripcionModulo { get; set; }
        public DateTime FechaCreacion { get; set; }=DateTime.Now;
    }
}
