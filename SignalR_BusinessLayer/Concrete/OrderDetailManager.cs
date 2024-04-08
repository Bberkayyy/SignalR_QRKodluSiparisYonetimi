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

public class OrderDetailManager : GenericManager<OrderDetail, IOrderDetailDal>, IOrderDetailService
{
    private readonly IOrderDal _orderDal;
    private readonly IProductDal _productDal;
    public OrderDetailManager(IOrderDetailDal entityDal, IOrderDal orderDal, IProductDal productDal) : base(entityDal)
    {
        _orderDal = orderDal;
        _productDal = productDal;
    }
    public override OrderDetail TAdd(OrderDetail entity)
    {
        Product product = _productDal.GetByFilter(x => x.Id == entity.ProductId);
        entity.UnitPrice = product.Price;
        entity.TotalPrice = entity.ProductCount * entity.UnitPrice;
        Order order = _orderDal.GetByFilter(x => x.Id == entity.OrderId);
        order.TotalPrice += entity.TotalPrice;
        return base.TAdd(entity);
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

    public IList<OrderDetail> TGetAllOrderDetailWithRelationshipsByOrderId(int orderId)
    {
        return _entityDal.GetAllOrderDetailWithRelationshipsByOrderId(orderId);
    }
}
