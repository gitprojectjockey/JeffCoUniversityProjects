using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace JeffCoUniversity.Data.Core.Repositories
{
    public interface ITitanRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
       
    }
}