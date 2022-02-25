using KOS.Entities;
using System.Linq.Expressions;

namespace KOS.Core.Repositories;

public interface IGenericRepository<TEntity> where TEntity : class, IEntity
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Remove(TEntity entity);
    IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> expression = null);
    Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null);
    TEntity Get(Expression<Func<TEntity, bool>> expression);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    int SaveChanges();
    Task<int> SaveChangesAsync();
    IQueryable<TEntity> Query();
}