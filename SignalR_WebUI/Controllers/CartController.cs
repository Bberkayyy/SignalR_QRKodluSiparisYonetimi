using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CartDtos;
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

    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Carts/getallbytableidwithrelationships?id=4");
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
}
