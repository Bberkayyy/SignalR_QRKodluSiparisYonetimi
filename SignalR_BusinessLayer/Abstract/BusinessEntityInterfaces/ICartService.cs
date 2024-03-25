using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;

public interface ICartService : IGenericService<Cart>
{
    IList<Cart> TGetCartListByRestaurantTableId(int restaurantTableId);
    IList<Cart> TGetCartListByRestaurantTableIdWithRelationships(int restaurantTableId);
    IList<Cart> TGetAllCartsWithRelationships();
    Cart TGetCartWithRelationships(int id);
}
