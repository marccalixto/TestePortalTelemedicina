using System.Threading;
using System.Threading.Tasks;

namespace PortalTeleMedicina.Dominio.Repositorio
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
    }
}
