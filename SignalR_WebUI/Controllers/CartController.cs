using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CartDtos;
using SignalR_WebUI.Dtos.OrderDetailDtos;
using SignalR_WebUI.Dtos.OrderDtos;
using SignalR_WebUI.Dtos.ProductDtos;
using SignalR_WebUI.Dtos.ReservationDtos;
using System.Text;

namespace SignalR_WebUI.Controllers;

[AllowAnonymous]
public class CartController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CartController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int id)
    {
        ViewBag.restaurantTableId = id;
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Carts/getallbytableidwithrelationships?id=" + id);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultCartDto>? values = JsonConvert.DeserializeObject<IList<ResultCartDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    public async Task<IActionResult> DeleteFromCart(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync("http://localhost:20666/api/Carts/" + id);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index");
        return NoContent();
    }
    public async Task<IActionResult> DecreaseProductCount(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync("http://localhost:20666/api/Carts/decreaseproductcount?id=" + id);
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> IncreaseProductCount(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync("http://localhost:20666/api/Carts/increaseproductcount?id=" + id);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public async Task<IActionResult> ComplateOrder(int restaurantTableId, IList<ResultCartDto> cartProducts)
    {

        CreateOrderDto createOrder = new()
        {
            RestaurantTableId = restaurantTableId,
            Description = "Sipariş oluşturuldu."
        };
        ResultOrderDto createdOrder = await CreateOrderAndReturnCreatedOrder(createOrder);


        List<CreateOrderDetailDto> createOrderDetails = new();
        foreach (var item in cartProducts)
        {
            CreateOrderDetailDto createOrderDetail = new()
            {
                OrderId = createdOrder.id,
                ProductId = await GetProductIdByProductName(item.productName),
                ProductCount = item.productCount
            };
            createOrderDetails.Add(createOrderDetail);
        }
        await CreateOrderDetails(createOrderDetails);

        return Redirect("/Default/Index/");
    }
    private async Task<int> GetProductIdByProductName(string productName)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Products");
        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        IList<ResultProductDto>? products = JsonConvert.DeserializeObject<IList<ResultProductDto>>(jsonData);
        return products.FirstOrDefault(x => x.name == productName).id;
    }
    private async Task<ResultOrderDto> CreateOrderAndReturnCreatedOrder(CreateOrderDto createOrderDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createOrderDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Orders", content);
        string value = await responseMessage.Content.ReadAsStringAsync();
        ResultOrderDto? createdOrder = JsonConvert.DeserializeObject<ResultOrderDto>(value);
        return createdOrder;
    }
    private async Task CreateOrderDetails(IList<CreateOrderDetailDto> createOrderDetails)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createOrderDetails);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        await client.PostAsync("http://localhost:20666/api/OrderDetails/addlist", content);
    }
}
