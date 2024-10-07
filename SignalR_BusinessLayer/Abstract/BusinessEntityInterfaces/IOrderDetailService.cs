using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;

public interface IOrderDetailService : IGenericService<OrderDetail>
{
    IList<OrderDetail> TAddRange(IList<OrderDetail> entityList);
    IList<OrderDetail> TGetAllOrderDetailsWithRelationships();
    OrderDetail TGetOrderDetailWithRelationships(int id);
    OrderDetail TGetOrderDetailWithRelationshipsByOrderId(int orderId);
    IList<OrderDetail> TGetAllOrderDetailWithRelationshipsByOrderId(int orderId);
    void TIncreaseProductCount(int id);
    void TDecreaseProductCount(int id);
}
