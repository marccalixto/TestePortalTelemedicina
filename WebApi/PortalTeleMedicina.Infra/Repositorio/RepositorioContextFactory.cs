using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PortalTeleMedicina.Infra.Repositorio
{
    public class RepositorioContextFactory : IDesignTimeDbContextFactory<RepositorioContext>
    {
        public RepositorioContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositorioContext>();
            return new RepositorioContext(optionsBuilder.Options);
        }
    }
}
