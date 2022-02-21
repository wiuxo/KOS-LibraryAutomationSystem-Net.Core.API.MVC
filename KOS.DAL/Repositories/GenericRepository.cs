using KOS.Core.Repositories;
using KOS.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace KOS.DAL.Repositories
{
    public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly TContext Context;

        public GenericRepository(TContext context)
        {
            Context = context;
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Add(entity).Entity;
        }

        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            return entity;
        }

        public TEntity Remove(TEntity entity)
        {
            Context.Remove(entity);
            return entity;
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? Context.Set<TEntity>().AsNoTracking()
                                      : Context.Set<TEntity>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression == null ? await Context.Set<TEntity>().ToListAsync()
                                      : await Context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().FirstOrDefault(expression);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().AsQueryable().FirstOrDefaultAsync(expression);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }
    }
}
