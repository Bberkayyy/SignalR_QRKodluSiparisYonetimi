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

public class EfOrderDal : GenericRepository<Order>, IOrderDal
{
    public EfOrderDal(BaseContext context) : base(context)
    {
    }

    public void ChangeStatusToFalse(int id)
    {
        Order value = GetByFilter(x => x.Id == id);
        value.Status = false;
        MoneyCase? moneyCase = _context.MoneyCases.FirstOrDefault();
        moneyCase.TotalAmount += value.TotalPrice;
        _context.SaveChanges();
    }

    public IList<Order> GetAllOrderWithRelationships()
    {
        return GetAll(include: x => x.Include(x => x.RestaurantTable));
    }

    public Order GetOrderWithRelationships(int id)
    {
        return GetByFilter(x => x.Id == id, x => x.Include(x => x.RestaurantTable));
    }

    public Order GetOrderWithRelationshipsByRestaurantTableName(string name)
    {
        return GetByFilter(x => x.RestaurantTable.Name == name, x => x.Include(x => x.RestaurantTable));
    }
}
