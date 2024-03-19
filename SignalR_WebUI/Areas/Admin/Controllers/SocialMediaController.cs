using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.SocialMediaDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]")]
public class SocialMediaController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public SocialMediaController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/SocialMedias");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultSocialMediaDto>? values = JsonConvert.DeserializeObject<IList<ResultSocialMediaDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateSocialMedia")]
    public IActionResult CreateSocialMedia() { return View(); }
    [HttpPost]
    [Route("CreateSocialMedia")]
    public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/SocialMedias", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        return View();
    }
    [Route("DeleteSocialMedia/{id}")]
    public async Task<IActionResult> DeleteSocialMedia(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/SocialMedias/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateSocialMedia/{id}")]
    public async Task<IActionResult> UpdateSocialMedia(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/SocialMedias/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateSocialMediaDto? value = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateSocialMedia/{id}")]
    public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/SocialMedias", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "SocialMedia", new { area = "Admin" });
        return View();
    }
}
