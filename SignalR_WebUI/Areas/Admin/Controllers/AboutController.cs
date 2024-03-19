using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.AboutDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class AboutController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AboutController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Abouts");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultAboutDto>? values = JsonConvert.DeserializeObject<IList<ResultAboutDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateAbout")]
    public IActionResult CreateAbout() { return View(); }
    [HttpPost]
    [Route("CreateAbout")]
    public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createAboutDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Abouts", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "About", new { area = "Admin" });
        return View();
    }
    [Route("DeleteAbout/{id}")]
    public async Task<IActionResult> DeleteAbout(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Abouts/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "About", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateAbout/{id}")]
    public async Task<IActionResult> UpdateAbout(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Abouts/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateAboutDto? value = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateAbout/{id}")]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateAboutDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Abouts", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "About", new { area = "Admin" });
        return View();
    }
}
