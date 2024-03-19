using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.DiscountOfDayDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class DiscountOfDayController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DiscountOfDayController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/DiscountOfDays");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultDiscountOfDayDto>? values = JsonConvert.DeserializeObject<IList<ResultDiscountOfDayDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateDiscountOfDay")]
    public IActionResult CreateDiscountOfDay() { return View(); }
    [HttpPost]
    [Route("CreateDiscountOfDay")]
    public async Task<IActionResult> CreateDiscountOfDay(CreateDiscountOfDayDto createDiscountOfDayDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createDiscountOfDayDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/DiscountOfDays", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "DiscountOfDay", new { area = "Admin" });
        return View();
    }
    [Route("DeleteDiscountOfDay/{id}")]
    public async Task<IActionResult> DeleteDiscountOfDay(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/DiscountOfDays/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "DiscountOfDay", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateDiscountOfDay/{id}")]
    public async Task<IActionResult> UpdateDiscountOfDay(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/DiscountOfDays/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateDiscountOfDayDto? value = JsonConvert.DeserializeObject<UpdateDiscountOfDayDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateDiscountOfDay/{id}")]
    public async Task<IActionResult> UpdateDiscountOfDay(UpdateDiscountOfDayDto updateDiscountOfDayDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateDiscountOfDayDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/DiscountOfDays", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "DiscountOfDay", new { area = "Admin" });
        return View();
    }
}
