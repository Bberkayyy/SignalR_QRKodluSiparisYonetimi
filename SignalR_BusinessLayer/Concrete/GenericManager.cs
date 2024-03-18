using Microsoft.EntityFrameworkCore.Query;
using SignalR_BusinessLayer.Abstract;
using SignalR_DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class GenericManager<TEntity, TEntityDal> : IGenericService<TEntity>
    where TEntity : class
    where TEntityDal : IGenericDal<TEntity>
{
    protected readonly TEntityDal _entityDal;

    public GenericManager(TEntityDal entityDal)
    {
        _entityDal = entityDal;
    }

    public TEntity TAdd(TEntity entity)
    {
        return _entityDal.Add(entity);
    }

    public TEntity TDelete(TEntity entity)
    {
        return _entityDal.Delete(entity);
    }

    public IList<TEntity> TGetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        return _entityDal.GetAll(predicate, include);
    }

    public TEntity TGetByFilter(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        return _entityDal.GetByFilter(predicate, include);
    }

    public TEntity TUpdate(TEntity entity)
    {
        return _entityDal.Update(entity);
    }
}
