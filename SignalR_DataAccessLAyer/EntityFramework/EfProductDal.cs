using Microsoft.EntityFrameworkCore;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DataAccessLayer.Repositories;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.EntityFramework;

public class EfProductDal : GenericRepository<Product>, IProductDal
{
    public EfProductDal(BaseContext context) : base(context)
    {
    }

    public IList<Product> GetAllProductsWithCategories()
    {
        IList<Product> products = GetAll(include: x => x.Include(x => x.Category));
        return products;
    }

    public Product GetProductWithCategory(int id)
    {
        Product product = GetByFilter(x => x.Id == id, x => x.Include(x => x.Category));
        return product;
    }
}
