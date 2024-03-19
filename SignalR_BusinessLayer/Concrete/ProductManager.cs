using Microsoft.EntityFrameworkCore;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class ProductManager : GenericManager<Product, IProductDal>, IProductService
{
    public ProductManager(IProductDal entityDal) : base(entityDal)
    {
    }

    public Product TGetProductWithCategory(int id)
    {
        return _entityDal.GetProductWithCategory(id);
    }

    public IList<Product> TGetAllProductsWithCategories()
    {
        return _entityDal.GetAllProductsWithCategories();
    }
}
