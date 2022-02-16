using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }     
        [ForeignKey("IdProducto")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }


        [StringLength(100)]
        [Required(ErrorMessage = "El Nombre del Producto es requerido.")]
        public string NombreProducto { get; set; }
        [Required]
        public double PrecioProducto { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage = "La descripcion es requerida.")]
        public string DescripcionProducto { get; set; }
        [StringLength(1000)]
        public string RutaProductoImagen { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
