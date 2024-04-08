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

public class CartManager : GenericManager<Cart, ICartDal>, ICartService
{
    private readonly IProductDal _productDal;
    public CartManager(ICartDal entityDal, IProductDal productDal) : base(entityDal)
    {
        _productDal = productDal;
    }

    public override Cart TAdd(Cart entity)
    {
        Cart item = base.TGetByFilter(x => x.ProductId == entity.ProductId && x.RestaurantTableId == entity.RestaurantTableId, x => x.Include(x => x.Product));
        if (item is not null)
        {
            item.ProductCount++;
            item.TotalAmount = item.ProductCount * item.Product.Price;
            return base.TUpdate(item);
        }
        else
        {
            decimal productPrice = _productDal.GetByFilter(x => x.Id == entity.ProductId).Price;
            entity.TotalAmount = entity.ProductCount * productPrice;
            return base.TAdd(entity);
        }
    }

    public void TDecreaseProductCount(int id)
    {
        _entityDal.DecreaseProductCount(id);
        Cart values = _entityDal.GetByFilter(x => x.Id == id);
        decimal productPrice = _productDal.GetByFilter(x => x.Id == values.ProductId).Price;
        values.TotalAmount = values.ProductCount * productPrice;
        base.TUpdate(values);
    }

    public IList<Cart> TGetAllCartsWithRelationships()
    {
        return _entityDal.GetAllCartsWithRelationships();
    }

    public IList<Cart> TGetCartListByRestaurantTableId(int restaurantTableId)
    {
        return _entityDal.GetCartListByRestaurantTableId(restaurantTableId);
    }

    public IList<Cart> TGetCartListByRestaurantTableIdWithRelationships(int restaurantTableId)
    {
        return _entityDal.GetCartListByRestaurantTableIdWithRelationships(restaurantTableId);
    }

    public Cart TGetCartWithRelationships(int id)
    {
        return _entityDal.GetCartWithRelationships(id);
    }

    public void TIncreaseProductCount(int id)
    {
        _entityDal.IncreaseProductCount(id);
        Cart values = _entityDal.GetByFilter(x => x.Id == id);
        decimal productPrice = _productDal.GetByFilter(x => x.Id == values.ProductId).Price;
        values.TotalAmount = values.ProductCount * productPrice;
        base.TUpdate(values);
    }
}
