using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SignalR_DataAccessLayer.Abstract;
using SignalR_DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Repositories;

public class GenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class
{
    protected readonly BaseContext _context;

    public GenericRepository(BaseContext context)
    {
        _context = context;
    }

    public TEntity Add(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Added;
        _context.SaveChanges();
        return entity;
    }

    public TEntity Delete(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Deleted;
        _context.SaveChanges();
        return entity;
    }

    public IList<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        if (predicate is not null)
            queryable = queryable.Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.ToList();
    }

    public TEntity GetByFilter(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
    {
        IQueryable<TEntity> queryable = Query();
        queryable = queryable.Where(predicate);
        if (include is not null)
            queryable = include(queryable);
        return queryable.FirstOrDefault();
    }

    public IQueryable<TEntity> Query() => _context.Set<TEntity>();

    public TEntity Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
        return entity;
    }
}
