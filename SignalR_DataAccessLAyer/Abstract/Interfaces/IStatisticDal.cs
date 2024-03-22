using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_DataAccessLayer.Abstract.Interfaces;

public interface IStatisticDal
{
    int GetCategoryCount();
    int GetProductCount();
    int GetActiveCategoryCount();
    int GetActiveProductCount();
    decimal GetAvgProductPrice();
    string? GetProductNameByMaxPrice();
    string? GetProductNameByMinPrice();
    decimal GetAvgHamburgerPrice();
    int GetTotalOrderCount();
    int GetActiveOrderCount();
    decimal GetLastOrderPrice();
    decimal GetTotalMoneyCaseAmount();
    decimal GetTodayTotalPrice();
    int GetRestaurantTableCount();
}
