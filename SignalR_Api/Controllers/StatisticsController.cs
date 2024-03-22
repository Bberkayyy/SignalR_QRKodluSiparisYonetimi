using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR_BusinessLayer.Abstract.BusinessInterfaces;

namespace SignalR_Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticService _statisticService;

    public StatisticsController(IStatisticService statisticService)
    {
        _statisticService = statisticService;
    }
    [HttpGet("categorycount")]
    public IActionResult GetCategoryCount()
    {
        return Ok(_statisticService.TGetCategoryCount());
    }
    [HttpGet("productcount")]
    public IActionResult GetProductCount()
    {
        return Ok(_statisticService.TGetProductCount());
    }
    [HttpGet("activecategorycount")]
    public IActionResult GetActiveCategoryCount()
    {
        return Ok(_statisticService.TGetActiveCategoryCount());
    }
    [HttpGet("activeproductcount")]
    public IActionResult GetActiveProductCount()
    {
        return Ok(_statisticService.TGetActiveProductCount());
    }
    [HttpGet("avgproductprice")]
    public IActionResult GetAvgProductPrice()
    {
        return Ok(_statisticService.TGetAvgProductPrice());
    }
    [HttpGet("productnamebymaxprice")]
    public IActionResult GetProductNameByMaxPrice()
    {
        return Ok(_statisticService.TGetProductNameByMaxPrice());
    }
    [HttpGet("productnamebyminprice")]
    public IActionResult GetProductNameByMinPrice()
    {
        return Ok(_statisticService.TGetProductNameByMinPrice());
    }
    [HttpGet("avghamburgerprice")]
    public IActionResult GetAvgHamburgerPrice()
    {
        return Ok(_statisticService.TGetAvgHamburgerPrice());
    }
    [HttpGet("totalordercount")]
    public IActionResult GetTotalOrderCount()
    {
        return Ok(_statisticService.TGetTotalOrderCount());
    }
    [HttpGet("activeordercount")]
    public IActionResult GetActiveOrderCount()
    {
        return Ok(_statisticService.TGetActiveOrderCount());
    }
    [HttpGet("lastorderprice")]
    public IActionResult GetLastOrderPrice()
    {
        return Ok(_statisticService.TGetLastOrderPrice());
    }
    [HttpGet("totalmoneycaseamount")]
    public IActionResult GetTotalMoneyCaseAmount()
    {
        return Ok(_statisticService.TGetTotalMoneyCaseAmount());
    }
    [HttpGet("todaytotalprice")]
    public IActionResult GetTodayTotalPrice()
    {
        return Ok(_statisticService.TGetTodayTotalPrice());
    }
    [HttpGet("restauranttablecount")]
    public IActionResult GetRestaurantTableCount()
    {
        return Ok(_statisticService.TGetRestaurantTableCount());
    }
}
