using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.FeatureDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class FeatureController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FeatureController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Features");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultFeatureDto>? values = JsonConvert.DeserializeObject<IList<ResultFeatureDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateFeature")]
    public IActionResult CreateFeature() { return View(); }
    [HttpPost]
    [Route("CreateFeature")]
    public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createFeatureDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Features", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        return View();
    }
    [Route("DeleteFeature/{id}")]
    public async Task<IActionResult> DeleteFeature(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Features/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateFeature/{id}")]
    public async Task<IActionResult> UpdateFeature(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Features/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateFeatureDto? value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateFeature/{id}")]
    public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateFeatureDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Features", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Feature", new { area = "Admin" });
        return View();
    }
}
