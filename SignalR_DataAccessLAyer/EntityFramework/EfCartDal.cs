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

public class EfCartDal : GenericRepository<Cart>, ICartDal
{
    public EfCartDal(BaseContext context) : base(context)
    {
    }

    public void DecreaseProductCount(int id)
    {
        Cart value = GetByFilter(x => x.Id == id);
        value.ProductCount--;
        _context.SaveChanges();
    }

    public IList<Cart> GetAllCartsWithRelationships()
    {
        IList<Cart> values = GetAll(include: x => x.Include(x => x.Product).Include(x => x.RestaurantTable));
        return values;
    }

    public IList<Cart> GetCartListByRestaurantTableId(int restaurantTableId)
    {
        IList<Cart> values = _context.Carts.Where(x => x.RestaurantTableId == restaurantTableId).ToList();
        return values;
    }

    public IList<Cart> GetCartListByRestaurantTableIdWithRelationships(int restaurantTableId)
    {
        IList<Cart> values = _context.Carts.Include(x => x.Product).Include(x => x.RestaurantTable).Where(x => x.RestaurantTableId == restaurantTableId).ToList();
        return values;
    }

    public Cart GetCartWithRelationships(int id)
    {
        Cart value = GetByFilter(x => x.Id == id, x => x.Include(x => x.Product).Include(x => x.RestaurantTable));
        return value;
    }

    public void IncreaseProductCount(int id)
    {
        Cart value = GetByFilter(x => x.Id == id);
        value.ProductCount++;
        _context.SaveChanges();
    }
}
