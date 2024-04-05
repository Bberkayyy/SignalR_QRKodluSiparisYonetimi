using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;

public interface IOrderService : IGenericService<Order>
{
    IList<Order> TGetAllOrderWithRelationships();
    Order TGetOrderWithRelationships(int id);
    Order TGetOrderWithRelationshipsByRestaurantTableName(string name);
}
