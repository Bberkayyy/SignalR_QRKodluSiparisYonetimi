using SignalR_BusinessLayer.Abstract.BusinessInterfaces;
using SignalR_DataAccessLayer.Abstract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Concrete;

public class StatisticManager : IStatisticService
{
    private readonly IStatisticDal _statisticDal;

    public StatisticManager(IStatisticDal statisticDal)
    {
        _statisticDal = statisticDal;
    }

    public string? TGetProductNameByMaxPrice()
    {
        return _statisticDal.GetProductNameByMaxPrice();
    }

    public string? TGetProductNameByMinPrice()
    {
        return _statisticDal.GetProductNameByMinPrice();
    }

    public int TGetActiveCategoryCount()
    {
        return _statisticDal.GetActiveCategoryCount();
    }

    public int TGetActiveProductCount()
    {
        return _statisticDal.GetActiveProductCount();
    }

    public int TGetCategoryCount()
    {
        return _statisticDal.GetCategoryCount();
    }

    public int TGetProductCount()
    {
        return _statisticDal.GetProductCount();
    }

    public decimal TGetAvgProductPrice()
    {
        return _statisticDal.GetAvgProductPrice();
    }

    public decimal TGetAvgHamburgerPrice()
    {
        return _statisticDal.GetAvgHamburgerPrice();
    }

    public int TGetTotalOrderCount()
    {
        return _statisticDal.GetTotalOrderCount();
    }

    public int TGetActiveOrderCount()
    {
        return _statisticDal.GetActiveOrderCount();
    }

    public decimal TGetLastOrderPrice()
    {
        return _statisticDal.GetLastOrderPrice();
    }

    public decimal TGetTotalMoneyCaseAmount()
    {
        return _statisticDal.GetTotalMoneyCaseAmount();
    }

    public decimal TGetTodayTotalPrice()
    {
        return _statisticDal.GetTodayTotalPrice();
    }

    public int TGetRestaurantTableCount()
    {
        return _statisticDal.GetRestaurantTableCount();
    }
}
