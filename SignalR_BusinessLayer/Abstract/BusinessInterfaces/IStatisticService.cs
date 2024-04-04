using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR_BusinessLayer.Abstract.BusinessInterfaces;

public interface IStatisticService
{
    int TGetCategoryCount();
    int TGetProductCount();
    int TGetActiveCategoryCount();
    int TGetActiveProductCount();
    decimal TGetAvgProductPrice();
    string? TGetProductNameByMaxPrice();
    string? TGetProductNameByMinPrice();
    decimal TGetAvgHamburgerPrice();
    int TGetTotalOrderCount();
    int TGetActiveOrderCount();
    decimal TGetLastOrderPrice();
    decimal TGetTotalMoneyCaseAmount();
    decimal TGetTodayTotalPrice();
    int TGetRestaurantTableCount();
    int TGetActiveRestaurantTableCount();
}
