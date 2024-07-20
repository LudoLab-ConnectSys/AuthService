using AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<UsuarioRol> UsuarioRol { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UsuarioRol>()
                .HasKey(ur => new { ur.UsuarioId, ur.RolId });

            modelBuilder.Entity<UsuarioRol>()
                .HasOne(ur => ur.Rol)
                .WithMany()
                .HasForeignKey(ur => ur.RolId);

            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Usuario)
                .WithMany()
                .HasForeignKey(i => i.IdUsuario);

            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Usuario)
                .WithMany()
                .HasForeignKey(e => e.IdUsuario);
        }
    }
}