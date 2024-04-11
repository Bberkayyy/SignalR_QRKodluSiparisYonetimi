using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using SignalR_BusinessLayer.Abstract.BusinessEntityInterfaces;
using SignalR_BusinessLayer.Abstract.BusinessInterfaces;
using SignalR_DataAccessLayer.Concrete;
using SignalR_DtoLayer.NotificationDtos;
using SignalR_DtoLayer.ReservationDtos;
using SignalR_DtoLayer.RestaurantTableDtos;
using SignalR_EntityLayer.Entities;

namespace SignalR_Api.Hubs;

public class SignalRHub : Hub
{
    private readonly IStatisticService _statisticService;
    private readonly IReservationService _reservationService;
    private readonly INotificationService _notificationService;
    private readonly IRestaurantTableService _restaurantTableService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;

    public SignalRHub(IStatisticService statisticService, IReservationService reservationService, IMapper mapper, INotificationService notificationService, IRestaurantTableService restaurantTableService, UserManager<AppUser> userManager)
    {
        _statisticService = statisticService;
        _reservationService = reservationService;
        _mapper = mapper;
        _notificationService = notificationService;
        _restaurantTableService = restaurantTableService;
        _userManager = userManager;
    }

    public static int clientCount { get; set; }

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

        var userCount = _userManager.Users.Count();
        await Clients.All.SendAsync("receiveUserCount", userCount);
    }
    public async Task SendProgress()
    {
        var moneyCateAmount = _statisticService.TGetTotalMoneyCaseAmount();
        await Clients.All.SendAsync("receiveTotalMoneyCaseAmount", moneyCateAmount.ToString("0.00") + " ₺");

        var activeOrderCount = _statisticService.TGetActiveOrderCount();
        await Clients.All.SendAsync("receiveActiveOrderCount", activeOrderCount);

        var restaurantTableCount = _statisticService.TGetRestaurantTableCount();
        await Clients.All.SendAsync("receiveRestaurantTableCount", restaurantTableCount);

        var avgProductPriceProgress = _statisticService.TGetAvgProductPrice();
        await Clients.All.SendAsync("receiveAvgProductPriceProgress", avgProductPriceProgress.ToString("0.00"));

        var productCountProgress = _statisticService.TGetProductCount();
        await Clients.All.SendAsync("receiveProductCountProgress", productCountProgress);

        var activeProductCountProgress = _statisticService.TGetActiveProductCount();
        await Clients.All.SendAsync("receiveActiveProductCount", activeProductCountProgress);

        var activeCategoryCountProgress = _statisticService.TGetActiveCategoryCount();
        await Clients.All.SendAsync("receiveActiveCategoryCount", activeCategoryCountProgress);

        var activeRestaurantTableCountProgress = _statisticService.TGetActiveRestaurantTableCount();
        await Clients.All.SendAsync("receiveActiveRestaurantTableCount", activeRestaurantTableCountProgress);
    }
    public async Task GetReservationList()
    {
        IList<GetAllReservationResponseDto> values = _mapper.Map<IList<GetAllReservationResponseDto>>(_reservationService.TGetAll());
        await Clients.All.SendAsync("receiveResevationList", values);
    }
    public async Task SendNotification()
    {
        int value = _notificationService.TGetNotificationCountByStatusFalse();
        await Clients.All.SendAsync("receiveNotificationCountByStatusFalse", value);

        IList<GetAllNotificationByStatusFalseResponseDto> values = _mapper.Map<IList<GetAllNotificationByStatusFalseResponseDto>>(_notificationService.TGetAllNotificationByStatusFalse());
        await Clients.All.SendAsync("receiveNotificationListByStatusFalse", values);
    }
    public async Task GetRestaurantTableStatus()
    {
        IList<GetAllRestaurantTableResponseDto> values = _mapper.Map<IList<GetAllRestaurantTableResponseDto>>(_restaurantTableService.TGetAll());
        await Clients.All.SendAsync("receiveRestaurantTableStatus", values);
    }
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("receiveMessage", user, message);
    }
    public override async Task OnConnectedAsync()
    {
        clientCount++;
        await Clients.All.SendAsync("receiveClientCount", clientCount);
        await base.OnConnectedAsync();
    }
    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        clientCount--;
        await Clients.All.SendAsync("receiveClientCount", clientCount);
        await base.OnDisconnectedAsync(exception);
    }
}
