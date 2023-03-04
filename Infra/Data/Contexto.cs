using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace Infra.Data
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }


        public DbSet<Produtos> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(Contexto).Assembly);

            base.OnModelCreating(builder);
        }

    }
}
