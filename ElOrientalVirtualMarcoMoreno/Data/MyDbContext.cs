using ElOrientalVirtualMarcoMoreno.Models;
using Microsoft.EntityFrameworkCore;

namespace ElOrientalVirtualMarcoMoreno.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Producto { get; set; }
        
        public DbSet<Categoria> Categoria {get; set; }

        public DbSet<ModuloVirtual> ModuloVirtual { get; set; }

        public DbSet<Files> Files { get; set; }
    }
}
