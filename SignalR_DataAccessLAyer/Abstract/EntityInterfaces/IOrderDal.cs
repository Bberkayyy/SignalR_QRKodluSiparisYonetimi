using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface IOrderDal : IGenericDal<Order>
{
    IList<Order> GetAllOrderWithRelationships();
    Order GetOrderWithRelationships(int id);
    Order GetOrderWithRelationshipsByRestaurantTableName(string name);
    void ChangeStatusToFalse(int id);
}
