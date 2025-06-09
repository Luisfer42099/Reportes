using Microsoft.EntityFrameworkCore;
using Reportes.Models;

namespace Reportes.Data
{
    public class BDContext : DbContext
    {
        public BDContext(DbContextOptions<BDContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Persona> Personas { get; set; }
    }
}
