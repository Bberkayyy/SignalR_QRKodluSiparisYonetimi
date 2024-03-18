using Microsoft.EntityFrameworkCore.Query;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;

    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public About TAdd(About entity)
    {
        return _aboutDal.Add(entity);
    }

    public About TDelete(About entity)
    {
        return _aboutDal.Delete(entity);
    }

    public IList<About> TGetAll(Expression<Func<About, bool>>? predicate = null, Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null)
    {
        return _aboutDal.GetAll(predicate, include);
    }

    public About TGetByFilter(Expression<Func<About, bool>> predicate, Func<IQueryable<About>, IIncludableQueryable<About, object>>? include = null)
    {
        return _aboutDal.GetByFilter(predicate, include);

    }

    public About TUpdate(About entity)
    {
        return _aboutDal.Update(entity);
    }
}
