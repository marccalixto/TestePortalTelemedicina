using PortalTeleMedicina.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalTeleMedicina.Dominio.Repositorio
{
    public interface IRepositorioCrud<TKey, TEntity> where TKey : struct where TEntity : EntidadeBase<TKey>
    {
        Task<TEntity> AddAsync(TEntity obj);
        Task<TEntity> DeleteAsync(TKey id);
        Task<TEntity> GetAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> UpdateAsync(TEntity obj);
        Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> criteria);
    }
}
