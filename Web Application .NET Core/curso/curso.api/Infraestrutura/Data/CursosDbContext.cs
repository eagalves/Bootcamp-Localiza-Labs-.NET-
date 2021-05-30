// CONFIGURACAO DO ENTITY FRAMEWORK, RESUMINDO CONFIGURACAO DO BANCO DE DADOS
using curso.api.Business.Entities;
using curso.api.Infraestrutura.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace curso.api.Infraestrutura.Data
{
    public class CursosDbContext : DbContext
    {
        public CursosDbContext(DbContextOptions<CursosDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Usuario> Usuario { get; set; }
                
    }
}
