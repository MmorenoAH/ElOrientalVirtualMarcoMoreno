using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class ModuloVirtual
    {
        [Key]
        public int IdModulo { get; set; }
        [ForeignKey("Propietaro")]
        public string IdPropietario { get; set; }
        [ForeignKey("IdPropietario")]
        public virtual Propietario Propietario { get; set; }

        [Required]
        [StringLength(500)]
        public string DescripcionModulo { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }=DateTime.Now;
        

    }
}
