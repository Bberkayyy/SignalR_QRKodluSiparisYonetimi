using Microsoft.EntityFrameworkCore;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DataAccessLayer.Repositories;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.EntityFramework;

public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
{
    public EfOrderDetailDal(BaseContext context) : base(context)
    {
    }

    public IList<OrderDetail> GetAllOrderDetailsWithRelationships()
    {
        IList<OrderDetail> orderDetails = GetAll(include: x => x.Include(x => x.Order).ThenInclude(x => x.RestaurantTable).Include(x => x.Product));
        return orderDetails;
    }

    public OrderDetail GetOrderDetailWithRelationships(int id)
    {
        OrderDetail orderDetail = GetByFilter(x => x.Id == id, x => x.Include(x => x.Order).ThenInclude(x => x.RestaurantTable).Include(x => x.Product));
        return orderDetail;
    }

    public OrderDetail GetOrderDetailWithRelationshipsByOrderId(int orderId)
    {
        OrderDetail orderDetail = GetByFilter(x => x.OrderId == orderId, x => x.Include(x => x.Order).ThenInclude(x => x.RestaurantTable).Include(x => x.Product));
        return orderDetail;
    }
}
