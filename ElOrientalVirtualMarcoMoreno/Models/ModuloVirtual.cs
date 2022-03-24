using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class ModuloVirtual
    {
        [Key]
        public int IdModulo { get; set; }
        [Required]
        [Display(Name ="Usuario")]
        public string IdPropietario { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string NombrePropietario { get; set; }

        [Required]
        [StringLength(500)]
        public string DescripcionModulo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }=DateTime.Now;
        

    }
}
