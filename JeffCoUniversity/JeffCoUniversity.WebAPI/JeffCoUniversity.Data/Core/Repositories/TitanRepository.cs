using JeffCoUniversity.Data.Core.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace JeffCoUniversity.Data.Core.Repositories
{
    public abstract class TitanRepository<TEntity> : ITitanRepository<TEntity> where TEntity : class
    {
        private readonly TitanDbContext _context;
        public TitanRepository(TitanDbContext context)
        {
            _context = context;
        }

        #region Get
        public async Task<TEntity> Get(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> SingleOrDefault(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync(); ;
        }

        #endregion

        #region Add
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        #endregion

        #region Update
        public void Update(TEntity entity)
        {
            _context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry<TEntity>(entity).State = EntityState.Modified;
            }
        }
        #endregion

        #region Delete
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        #endregion
    }
}
