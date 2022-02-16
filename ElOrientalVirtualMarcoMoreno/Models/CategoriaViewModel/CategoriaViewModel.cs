using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ElOrientalVirtualMarcoMoreno.Models.CategoriaViewModel
{
    public class CategoriaViewModel
    {
        [Display(Name = "Nombre")]
        public int NombreProducto { get; set; }
        [Display(Name = "Precio")]
        public int PrecioProducto { get; set; }
        [Display(Name = "Descripcion")]
        public int DescripcionProducot { get; set; }
        [Display(Name ="Categoría")]
        public int IdCategoria { get; set; }
        [Display(Name = "Imagen")]
        public int RutaProductoImagen { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

    }
}
