using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace PortalTeleMedicina.Infra.Repositorio
{
    public class RepositorioContext : DbContext
    {
        public RepositorioContext(DbContextOptions<RepositorioContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer(@"Server=(LocalDb)\\MSSQLLocalDB; Database=TesteMarceloCalixto;Integrated Security=True;");
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new PessoaConfiguration());
            //modelBuilder.ApplyConfiguration(new DependenteConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
