using Microsoft.EntityFrameworkCore;
using PortalTeleMedicina.Dominio.Repositorio;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PortalTeleMedicina.Infra.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RepositorioContext _Context;

        public UnitOfWork(RepositorioContext context) { _Context = context; }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return _Context.SaveChangesAsync();
        }
        public Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            _Context.ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);

            return Task.CompletedTask;
        }
    }
}
