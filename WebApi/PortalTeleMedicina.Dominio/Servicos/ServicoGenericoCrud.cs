using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalTeleMedicina.Dominio.Servicos
{
    public class ServicoGenericoCrud<TKey, TEntity> : IServicoCrud<TKey, TEntity> where TKey : struct where TEntity : EntidadeBase<TKey>
    {
        private readonly IRepositorioCrud<TKey, TEntity> _Repository;
        protected readonly IUnitOfWork _UnitOfWork;

        public ServicoGenericoCrud(IRepositorioCrud<TKey, TEntity> repository, IUnitOfWork unitOfWork)
        {
            _Repository = repository;
            _UnitOfWork = unitOfWork;
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            await _Repository.AddAsync(obj);
            await _UnitOfWork.CommitAsync();
            return obj;
        }
        public virtual async Task<TEntity> DeleteAsync(TKey id)
        {
            await _Repository.DeleteAsync(id);
            await _UnitOfWork.CommitAsync();
            return await _Repository.GetAsync(id);
        }
        public virtual async Task<TEntity> GetAsync(TKey id) => await _Repository.GetAsync(id);
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _Repository.GetAllAsync();
        public virtual async Task<TEntity> UpdateAsync(TEntity obj)
        {
            await _Repository.UpdateAsync(obj);
            await _UnitOfWork.CommitAsync();
            return obj;
        }
        public virtual async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await _Repository.GetByAsync(criteria);
        }
    }
}
