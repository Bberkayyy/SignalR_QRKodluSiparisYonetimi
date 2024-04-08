using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface ICartDal : IGenericDal<Cart>
{
    IList<Cart> GetCartListByRestaurantTableId(int restaurantTableId);
    IList<Cart> GetCartListByRestaurantTableIdWithRelationships(int restaurantTableId);
    IList<Cart> GetAllCartsWithRelationships();
    Cart GetCartWithRelationships(int id);
    void IncreaseProductCount(int id);
    void DecreaseProductCount(int id);
}
