using System;
using System.ComponentModel.DataAnnotations;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage ="El Nombre de la categoria es requerido.")]
        public string NombreCategoria { get; set; }   
        [StringLength(500)]
        [Required(ErrorMessage ="La descripcion es requerida.")]
        public string DescripcionCategoria { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
