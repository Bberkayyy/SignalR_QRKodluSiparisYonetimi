using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.NotificationDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class NotificationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public NotificationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Notifications");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultNotificationDto>? values = JsonConvert.DeserializeObject<IList<ResultNotificationDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateNotification")]
    public IActionResult CreateNotification() { return View(); }
    [HttpPost]
    [Route("CreateNotification")]
    public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createNotificationDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Notifications", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Notification", new { area = "Admin" });
        return View();
    }
    [Route("DeleteNotification/{id}")]
    public async Task<IActionResult> DeleteNotification(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Notifications/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Notification", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateNotification/{id}")]
    public async Task<IActionResult> UpdateNotification(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Notifications/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateNotificationDto? value = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateNotification/{id}")]
    public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateNotificationDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Notifications", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Notification", new { area = "Admin" });
        return View();
    }
    [Route("ChangeStatusToTrue/{id}")]
    public async Task<IActionResult> ChangeStatusToTrue(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync($"http://localhost:20666/api/Notifications/notificationstatustotrue?id={id}");
        return RedirectToAction("Index", "Notification", new { area = "Admin" });
    }
    [Route("ChangeStatusToFalse/{id}")]
    public async Task<IActionResult> ChangeStatusToFalse(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync($"http://localhost:20666/api/Notifications/notificationstatustofalse?id={id}");
        return RedirectToAction("Index", "Notification", new { area = "Admin" });
    }
}
