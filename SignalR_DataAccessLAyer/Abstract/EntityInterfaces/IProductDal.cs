using SignalR_EntityLayer.Entities;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface IProductDal : IGenericDal<Product>
{
    IList<Product> GetAllProductsWithCategories();
    Product GetProductWithCategory(int id);
}
