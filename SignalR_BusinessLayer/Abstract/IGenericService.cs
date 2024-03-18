using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract;

public interface IGenericService<TEntity> where TEntity : class
{
    TEntity TAdd(TEntity entity);
    TEntity TDelete(TEntity entity);
    TEntity TUpdate(TEntity entity);
    IList<TEntity> TGetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
    TEntity TGetByFilter(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
}
