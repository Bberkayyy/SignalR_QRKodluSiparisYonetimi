using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace SignalR_DataAccessLayer.Abstract;

public interface IGenericDal<TEntity> : IQuery<TEntity> where TEntity : class
{
    TEntity Add(TEntity entity);
    TEntity Delete(TEntity entity);
    TEntity Update(TEntity entity);
    IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    TEntity GetByFilter(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
}
