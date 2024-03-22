using SignalR_DataAccessLayer.Abstract.Interfaces;
using SignalR_DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Repositories;

public class StatisticDal : IStatisticDal
{
    private readonly BaseContext _context;

    public StatisticDal(BaseContext context)
    {
        _context = context;
    }

    public int GetActiveCategoryCount()
    {
        return _context.Categories.Where(x => x.Status == true).Count();
    }

    public int GetActiveProductCount()
    {
        return _context.Products.Where(x => x.Status == true).Count();
    }

    public decimal GetAvgHamburgerPrice()
    {
        return _context.Products.Where(x => x.CategoryId == (_context.Categories.Where(x => x.Name == "Hamburger").Select(x => x.Id).FirstOrDefault())).Average(x => x.Price);
    }

    public int GetCategoryCount()
    {
        return _context.Categories.Count();
    }

    public int GetProductCount()
    {
        return _context.Products.Count();
    }

    public string? GetProductNameByMaxPrice()
    {
        return _context.Products.Where(x => x.Price == (_context.Products.Max(x => x.Price))).Select(x => x.Name).FirstOrDefault();
    }

    public string? GetProductNameByMinPrice()
    {
        return _context.Products.Where(x => x.Price == (_context.Products.Min(x => x.Price))).Select(x => x.Name).FirstOrDefault();
    }

    public decimal GetAvgProductPrice()
    {
        return _context.Products.Average(x => x.Price);
    }

    public int GetTotalOrderCount()
    {
        return _context.Orders.Count();
    }

    public int GetActiveOrderCount()
    {
        return _context.Orders.Where(x => x.Status == true).Count();
    }

    public decimal GetLastOrderPrice()
    {
        return _context.Orders.OrderByDescending(x => x.Id).Take(1).Select(x => x.TotalPrice).FirstOrDefault();
    }

    public decimal GetTotalMoneyCaseAmount()
    {
        return _context.MoneyCases.Select(x => x.TotalAmount).FirstOrDefault();
    }

    public decimal GetTodayTotalPrice()
    {
        return _context.Orders.Where(x => x.Date.Date == DateTime.Today).Sum(x => x.TotalPrice);
    }

    public int GetRestaurantTableCount()
    {
        return _context.RestaurantTables.Count();
    }
}
