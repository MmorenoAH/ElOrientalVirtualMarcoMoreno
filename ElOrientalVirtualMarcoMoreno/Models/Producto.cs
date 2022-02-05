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
        [StringLength()]
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public string Ruta { get; set; }

    }
}
