using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.RestaurantTableDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class RestaurantTableController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public RestaurantTableController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
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
    [HttpGet]
    [Route("CreateRestaurantTable")]
    public IActionResult CreateRestaurantTable() { return View(); }
    [HttpPost]
    [Route("CreateRestaurantTable")]
    public async Task<IActionResult> CreateRestaurantTable(CreateRestaurantTableDto createRestaurantTableDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createRestaurantTableDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/RestaurantTables", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "RestaurantTable", new { area = "Admin" });
        return View();
    }
    [Route("DeleteRestaurantTable/{id}")]
    public async Task<IActionResult> DeleteRestaurantTable(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/RestaurantTables/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "RestaurantTable", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateRestaurantTable/{id}")]
    public async Task<IActionResult> UpdateRestaurantTable(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/RestaurantTables/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateRestaurantTableDto? value = JsonConvert.DeserializeObject<UpdateRestaurantTableDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateRestaurantTable/{id}")]
    public async Task<IActionResult> UpdateRestaurantTable(UpdateRestaurantTableDto updateRestaurantTableDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateRestaurantTableDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/RestaurantTables", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "RestaurantTable", new { area = "Admin" });
        return View();
    }
    [Route("TableListByStatus")]
    public async Task<IActionResult> TableListByStatus()
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
