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

public class CategoryManager : ICategoryService
{
    private readonly ICategoryDal _categoryDal;

    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public Category TAdd(Category entity)
    {
        return _categoryDal.Add(entity);
    }

    public Category TDelete(Category entity)
    {
        return _categoryDal.Delete(entity);
    }

    public IList<Category> TGetAll(Expression<Func<Category, bool>>? predicate = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        return _categoryDal.GetAll(predicate,include);
    }

    public Category TGetByFilter(Expression<Func<Category, bool>> predicate, Func<IQueryable<Category>, IIncludableQueryable<Category, object>>? include = null)
    {
        return _categoryDal.GetByFilter(predicate,include);
    }

    public Category TUpdate(Category entity)
    {
        return _categoryDal.Update(entity);
    }
}
