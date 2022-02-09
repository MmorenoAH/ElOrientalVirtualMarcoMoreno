utilizando el sistema. ComponentModel. DataAnnotations;

espacio de nombres ElOrientalVirtualMarcoMoreno. Modelos
{
    clase pública Categoria
    {
        [Llave]
        public int IdCategoria { get; poner; }
        [StringLength(100)]
        [Required(ErrorMessage ="El Nombre del Producto es requerido.")]
        public string NombreCategoria { get; poner; }
        [StringLength(500)]
        [Required(ErrorMessage ="La descripcion es requerida.")]
        cadena pública  Descripcion { get; poner; }

    }
}
