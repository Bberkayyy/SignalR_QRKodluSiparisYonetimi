using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_DataAccessLayer.Abstract.EntityInterfaces;
using SignalR_EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class OrderManager : GenericManager<Order, IOrderDal>, IOrderService
{
    private readonly IRestaurantTableDal _restaurantTableDal;
    public OrderManager(IOrderDal entityDal, IRestaurantTableDal restaurantTableDal) : base(entityDal)
    {
        _restaurantTableDal = restaurantTableDal;
    }

    public override Order TAdd(Order entity)
    {
        RestaurantTable restaurantTable = _restaurantTableDal.GetByFilter(x => x.Id == entity.RestaurantTableId);
        restaurantTable.Status = true;
        return base.TAdd(entity);
    }
    public Order TGetOrderWithRelationshipsByRestaurantTableName(string name)
    {
        return _entityDal.GetOrderWithRelationshipsByRestaurantTableName(name);
    }

    public IList<Order> TGetAllOrderWithRelationships()
    {
        return _entityDal.GetAllOrderWithRelationships();
    }

    public Order TGetOrderWithRelationships(int id)
    {
        return _entityDal.GetOrderWithRelationships(id);
    }

    public void TChangeStatusToFalse(int id)
    {
        Order order = _entityDal.GetByFilter(x => x.Id == id);
        RestaurantTable restaurantTable = _restaurantTableDal.GetByFilter(x => x.Id == order.RestaurantTableId);
        restaurantTable.Status = false;
        _entityDal.ChangeStatusToFalse(id);
    }
}
