using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_BusinessLayer.Abstract.BusinessInterfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DtoLayer.ReservationDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Hubs;

public class SignalRHub : Hub
{
    private readonly IStatisticService _statisticService;
    private readonly IReservationService _reservationService;
    private readonly IMapper _mapper;

    public SignalRHub(IStatisticService statisticService, IReservationService reservationService, IMapper mapper)
    {
        _statisticService = statisticService;
        _reservationService = reservationService;
        _mapper = mapper;
    }

    public async Task SendStatistics()
    {
        var categoryCount = _statisticService.TGetCategoryCount();
        await Clients.All.SendAsync("receiveCategoryCount", categoryCount);

        var productCount = _statisticService.TGetProductCount();
        await Clients.All.SendAsync("receiveProductCount", productCount);

        var activeCategoryCount = _statisticService.TGetActiveCategoryCount();
        await Clients.All.SendAsync("receiveActiveCategoryCount", activeCategoryCount);

        var activeProductCount = _statisticService.TGetActiveProductCount();
        await Clients.All.SendAsync("receiveActiveProductCount", activeProductCount);

        var avgProductPrice = _statisticService.TGetAvgProductPrice();
        await Clients.All.SendAsync("receiveAvgProductPrice", avgProductPrice.ToString("0.00") + " ₺");

        var productNameByMaxPrice = _statisticService.TGetProductNameByMaxPrice();
        await Clients.All.SendAsync("receiveProductNameByMaxPrice", productNameByMaxPrice);

        var productNameByMinPrice = _statisticService.TGetProductNameByMinPrice();
        await Clients.All.SendAsync("receiveProductNameByMinPrice", productNameByMinPrice);

        var avgHamburgerPrice = _statisticService.TGetAvgHamburgerPrice();
        await Clients.All.SendAsync("receiveAvgHamburgerPrice", avgHamburgerPrice.ToString("0.00") + " ₺");

        var totalOrderCount = _statisticService.TGetTotalOrderCount();
        await Clients.All.SendAsync("receiveTotalOrderCount", totalOrderCount);

        var activeOrderCount = _statisticService.TGetActiveOrderCount();
        await Clients.All.SendAsync("receiveActiveOrderCount", activeOrderCount);

        var lastOrderPrice = _statisticService.TGetLastOrderPrice();
        await Clients.All.SendAsync("receiveLastOrderPrice", lastOrderPrice.ToString("0.00") + " ₺");

        var totalMoneyCaseAmount = _statisticService.TGetTotalMoneyCaseAmount();
        await Clients.All.SendAsync("receiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00") + " ₺");

        var totalTodayPrice = _statisticService.TGetTodayTotalPrice();
        await Clients.All.SendAsync("receiveTotalTodayPrice", totalTodayPrice.ToString("0.00") + " ₺");

        var restaurantTableCount = _statisticService.TGetRestaurantTableCount();
        await Clients.All.SendAsync("receiveRestaurantTableCount", restaurantTableCount);
    }
    public async Task SendProgress()
    {
        var moneyCateAmount = _statisticService.TGetTotalMoneyCaseAmount();
        await Clients.All.SendAsync("receiveTotalMoneyCaseAmount", moneyCateAmount.ToString("0.00") + " ₺");

        var activeOrderCount = _statisticService.TGetActiveOrderCount();
        await Clients.All.SendAsync("receiveActiveOrderCount", activeOrderCount);

        var restaurantTableCount = _statisticService.TGetRestaurantTableCount();
        await Clients.All.SendAsync("receiveRestaurantTableCount", restaurantTableCount);
    }
    public async Task GetReservationList()
    {
        IList<GetAllReservationResponseDto> values = _mapper.Map<IList<GetAllReservationResponseDto>>(_reservationService.TGetAll());
        await Clients.All.SendAsync("receiveResevationList", values);
    }
}
