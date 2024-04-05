using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class OrderDetailManager : GenericManager<OrderDetail, IOrderDetailDal>, IOrderDetailService
{
    public OrderDetailManager(IOrderDetailDal entityDal) : base(entityDal)
    {
    }

    public OrderDetail TGetOrderDetailWithRelationshipsByOrderId(int orderId)
    {
        return _entityDal.GetOrderDetailWithRelationshipsByOrderId(orderId);
    }

    public IList<OrderDetail> TGetAllOrderDetailsWithRelationships()
    {
        return _entityDal.GetAllOrderDetailsWithRelationships();
    }

    public OrderDetail TGetOrderDetailWithRelationships(int id)
    {
        return _entityDal.GetOrderDetailWithRelationships(id);
    }
}
