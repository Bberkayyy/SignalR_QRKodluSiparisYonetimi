using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.FooterInfoDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class FooterInfoController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FooterInfoController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/FooterInfos");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultFooterInfoDto>? values = JsonConvert.DeserializeObject<IList<ResultFooterInfoDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateFooterInfo")]
    public IActionResult CreateFooterInfo() { return View(); }
    [HttpPost]
    [Route("CreateFooterInfo")]
    public async Task<IActionResult> CreateFooterInfo(CreateFooterInfoDto createFooterInfoDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createFooterInfoDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/FooterInfos", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "FooterInfo", new { area = "Admin" });
        return View();
    }
    [Route("DeleteFooterInfo/{id}")]
    public async Task<IActionResult> DeleteFooterInfo(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/FooterInfos/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "FooterInfo", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateFooterInfo/{id}")]
    public async Task<IActionResult> UpdateFooterInfo(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/FooterInfos/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateFooterInfoDto? value = JsonConvert.DeserializeObject<UpdateFooterInfoDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateFooterInfo/{id}")]
    public async Task<IActionResult> UpdateFooterInfo(UpdateFooterInfoDto updateFooterInfoDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateFooterInfoDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/FooterInfos", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "FooterInfo", new { area = "Admin" });
        return View();
    }
}
