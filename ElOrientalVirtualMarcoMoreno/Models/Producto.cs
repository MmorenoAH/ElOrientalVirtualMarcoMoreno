using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElOrientalVirtualMarcoMoreno.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public int IdModulo { get; set; }
        [ForeignKey("IdModulo")]
        public virtual ModuloVirtual ModuloVirtual { get; set; }

        [ForeignKey("Categoria")]
        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

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
        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; } = DateTime.Now;


    }
}
