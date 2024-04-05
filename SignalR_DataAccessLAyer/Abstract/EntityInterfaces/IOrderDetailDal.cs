using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Abstract.EntityInterfaces;

public interface IOrderDetailDal : IGenericDal<OrderDetail>
{
    IList<OrderDetail> GetAllOrderDetailsWithRelationships();
    OrderDetail GetOrderDetailWithRelationships(int id);
    OrderDetail GetOrderDetailWithRelationshipsByOrderId(int orderId);
}
