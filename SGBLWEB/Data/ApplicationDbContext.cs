using Microsoft.EntityFrameworkCore;
using SGBLWEB.Models;

namespace SGBLWEB.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IUsuario> Usuarios { get; set; }
        // Añade otros DbSets aquí según tus necesidades, por ejemplo:
        // public DbSet<Libro> Libros { get; set; }
        // public DbSet<Categoria> Categorias { get; set; }
        // public DbSet<Autor> Autores { get; set; }
        // public DbSet<Prestamo> Prestamos { get; set; }
        // public DbSet<Reporte> Reportes { get; set; }
    }
}

