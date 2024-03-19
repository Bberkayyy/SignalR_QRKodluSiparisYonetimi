using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CategoryDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Categories");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultCategoryDto>? values = JsonConvert.DeserializeObject<IList<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateCategory")]
    public IActionResult CreateCategory() { return View(); }
    [HttpPost]
    [Route("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createCategoryDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Categories", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        return View();
    }
    [Route("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Categories/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Categories/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateCategoryDto? value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateCategoryDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Categories", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        return View();
    }
}
