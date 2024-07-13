using Accesodatos.Tablas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Accesodatos.Context
{
    public class ProyectoContext : IdentityDbContext<Usuarios>
    {
        public ProyectoContext(DbContextOptions<ProyectoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Clientes> Clientes { get; set; } = null!;
        public DbSet<Categorias> Categorias { get; set; } = null!;
        public DbSet<Autores> Autores { get; set; } = null!;
        public DbSet<Libros> Libros { get; set; } = null!;
        public DbSet<Editorial> Editorial { get; set; } = null!;
        public DbSet<Prestamos> Prestamos { get; set; } = null!;
        public DbSet<Reportes> Reportes { get; set; } = null!;

    }
}
