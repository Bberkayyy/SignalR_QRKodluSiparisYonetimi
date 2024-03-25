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
    public CartManager(ICartDal entityDal) : base(entityDal)
    {
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
}
