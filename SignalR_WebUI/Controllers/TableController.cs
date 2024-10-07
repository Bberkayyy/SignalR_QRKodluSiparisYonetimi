using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.RestaurantTableDtos;

namespace SignalR_WebUI.Controllers;

[AllowAnonymous]
public class TableController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TableController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> TableList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/RestaurantTables");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultRestaurantTableDto>? values = JsonConvert.DeserializeObject<IList<ResultRestaurantTableDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
