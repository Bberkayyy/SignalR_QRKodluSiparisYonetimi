using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR_WebUI.Dtos.OrderDetailDtos;
using SignalR_WebUI.Dtos.OrderDtos;
using SignalR_WebUI.Dtos.ProductDtos;
using SignalR_WebUI.Dtos.RestaurantTableDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class OrderDetailController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public OrderDetailController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/OrderDetails/getallwithrelationships");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultOrderDetailDto>? values = JsonConvert.DeserializeObject<IList<ResultOrderDetailDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateOrderDetail/{name}")]
    public async Task<IActionResult> CreateOrderDetail(string name)
    {
        ViewBag.restaurantTableName = name;
        ViewBag.orderId = await GetOrderId(name);
        ViewBag.productList = await GetProductList();
        return View();
    }
    [HttpPost]
    [Route("CreateOrderDetail/{name}")]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailDto createOrderDetailDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createOrderDetailDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/OrderDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Detail", "OrderDetail", new { area = "Admin", id = createOrderDetailDto.OrderId });
        return View();
    }
    [Route("DeleteOrderDetail/{id}")]
    public async Task<IActionResult> DeleteOrderDetail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/OrderDetails/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "OrderDetail", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateOrderDetail/{name}/{id}")]
    public async Task<IActionResult> UpdateOrderDetail(int id, string name)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/OrderDetails/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateOrderDetailDto? value = JsonConvert.DeserializeObject<UpdateOrderDetailDto>(jsonData);
            ViewBag.restaurantTableName = name;
            ViewBag.orderId = await GetOrderId(name);
            ViewBag.productList = await GetProductList();
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateOrderDetail/{name}/{id}")]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateOrderDetailDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/OrderDetails", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "OrderDetail", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("Detail/{id}")]
    public async Task<IActionResult> Detail(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Orders/getwithrelationships/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            ResultOrderDto? value = JsonConvert.DeserializeObject<ResultOrderDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpGet]
    [Route("DecreaseProductCount/{name}/{id}")]
    public async Task<IActionResult> DecreaseProductCount(int id, string name)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync("http://localhost:20666/api/OrderDetails/decreaseproductcount?id=" + id);
        int orderId = await GetOrderId(name);
        return RedirectToAction("Detail", "OrderDetail", new { area = "Admin", id = orderId });
    }
    [HttpGet]
    [Route("IncreaseProductCount/{name}/{id}")]
    public async Task<IActionResult> IncreaseProductCount(int id, string name)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync("http://localhost:20666/api/OrderDetails/increaseproductcount?id=" + id);
        int orderId = await GetOrderId(name);
        return RedirectToAction("Detail", "OrderDetail", new { area = "Admin", id = orderId });
    }
    private async Task<int> GetOrderId(string name)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync("http://localhost:20666/api/Orders/getwithrelationshipsbyrestauranttablename/" + name);
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        JObject jsonValue = JObject.Parse(jsonData);
        int orderId = (int)jsonValue["id"];
        return orderId;
    }
    private async Task<IList<SelectListItem>> GetProductList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync("http://localhost:20666/api/Products");
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        IList<ResultProductDto>? products = JsonConvert.DeserializeObject<IList<ResultProductDto>>(jsonData);
        IList<SelectListItem>? values = products.Select(x => new SelectListItem
        {
            Text = x.name,
            Value = x.id.ToString(),
        }).ToList();
        return values;
    }
}
