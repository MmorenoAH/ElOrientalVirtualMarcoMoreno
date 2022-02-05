using System.ComponentModel.DataAnnotations;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage ="El Nombre del Producto es requerido.")]
        public string Nombre { get; set; }   
        public double Precio { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage ="La descripcion es requerida.")]
        public string Descripcion { get; set; }
        [StringLength(1000)]
        public string Ruta { get; set; }

    }
}
