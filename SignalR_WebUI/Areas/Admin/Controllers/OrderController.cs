using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CategoryDtos;
using SignalR_WebUI.Dtos.OrderDtos;
using SignalR_WebUI.Dtos.RestaurantTableDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]")]
public class OrderController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Orders/getallwithrelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultOrderDto>? values = JsonConvert.DeserializeObject<IList<ResultOrderDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateOrder")]
    public async Task<IActionResult> CreateOrder()
    {
        ViewBag.restaurantTables = await GetRestaurantTableList();
        return View();
    }
    [HttpPost]
    [Route("CreateOrder")]
    public async Task<IActionResult> CreateOrder(CreateOrderDto createOrderDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createOrderDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Orders", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Order", new { area = "Admin" });
        return View();
    }
    [Route("DeleteOrder/{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Orders/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Order", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateOrder/{id}")]
    public async Task<IActionResult> UpdateOrder(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Orders/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateOrderDto? value = JsonConvert.DeserializeObject<UpdateOrderDto>(jsonData);
            value.Date = DateTime.Parse(value.Date.ToString("dd MMM yyyy HH:mm"));
            ViewBag.restaurantTablesForUpdate = await GetRestaurantTableList();
            ViewBag.orderStatus = await GetOrderStatus(id);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateOrder/{id}")]
    public async Task<IActionResult> UpdateOrder(UpdateOrderDto updateOrderDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateOrderDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Orders", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Order", new { area = "Admin" });
        return View();
    }
    private async Task<IList<SelectListItem>> GetRestaurantTableList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync("http://localhost:20666/api/RestaurantTables");
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        IList<ResultRestaurantTableDto>? restaurantTables = JsonConvert.DeserializeObject<IList<ResultRestaurantTableDto>>(jsonData);
        IList<SelectListItem>? values = restaurantTables.Select(x => new SelectListItem
        {
            Text = x.name,
            Value = x.id.ToString(),
        }).ToList();
        return values;
    }
    private async Task<IList<SelectListItem>> GetOrderStatus(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync($"http://localhost:20666/api/Orders/{id}");
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        UpdateOrderDto? order = JsonConvert.DeserializeObject<UpdateOrderDto>(jsonData);
        List<SelectListItem>? value = new()
        {
            new SelectListItem{Text = "Aktif",Value=true.ToString(), Selected = order.Status},
            new SelectListItem{Text = "Ödeme Alındı",Value=false.ToString(), Selected = !order.Status}
        };
        return value;
    }
}