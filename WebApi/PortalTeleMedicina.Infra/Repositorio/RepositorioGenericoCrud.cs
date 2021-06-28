using Microsoft.EntityFrameworkCore;
using PortalTeleMedicina.Dominio.Entidades;
using PortalTeleMedicina.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PortalTeleMedicina.Infra.Repositorio
{
    public class RepositorioGenericoCrud
    {
        public RepositorioGenericoCrud()
        {
        }
    }

    public class RepositorioGenericoCrud<TKey, TEntity> : IRepositorioCrud<TKey, TEntity> where TKey : struct where TEntity : EntidadeBase<TKey>
    {
        protected readonly RepositorioContext _Context;
        protected readonly DbSet<TEntity> _DbSet;

        public RepositorioGenericoCrud(RepositorioContext context)
        {
            _Context = context;
            _DbSet = _Context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity obj)
        {
            await _DbSet.AddAsync(obj);
            return obj;
        }
        public async Task<TEntity> DeleteAsync(TKey id)
        {
            var obj = await _DbSet.FirstOrDefaultAsync(o => o.Id.Equals(id));

            if (obj == null) return null;

            _DbSet.Remove(obj);
            return obj;
        }
        public async Task<TEntity> GetAsync(TKey id) => await _DbSet.FirstOrDefaultAsync(o => o.Id.Equals(id));
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Task.FromResult<IEnumerable<TEntity>>(_DbSet);
        public async Task<TEntity> UpdateAsync(TEntity obj)
        {
            if (!await _DbSet.AnyAsync(o => o.Id.Equals(obj.Id))) return null;

            _Context.Entry(obj).State = EntityState.Modified;
            return obj;
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await Task.FromResult<IEnumerable<TEntity>>(_DbSet.AsQueryable().Where(criteria));
        }
    }
}
