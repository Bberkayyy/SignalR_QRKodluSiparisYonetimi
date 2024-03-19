using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CategoryDtos;
using SignalR_WebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class ProductController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Products/getallwithcategory");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultProductsWithCategoriesDto>? values = JsonConvert.DeserializeObject<IList<ResultProductsWithCategoriesDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct()
    {
        ViewBag.categories = await GetCategoryList();
        return View();
    }
    [HttpPost]
    [Route("CreateProduct")]
    public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createProductDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [Route("DeleteProduct/{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Products/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Products/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateProductDto? value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
            ViewBag.categoriesForUpdate = await GetCategoryList();
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateProduct/{id}")]
    public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateProductDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Products", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        return View();
    }
    private async Task<IList<SelectListItem>> GetCategoryList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync("http://localhost:20666/api/Categories");
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        IList<ResultCategoryDto>? categories = JsonConvert.DeserializeObject<IList<ResultCategoryDto>>(jsonData);
        IList<SelectListItem>? values = categories.Select(x => new SelectListItem
        {
            Text = x.name,
            Value = x.id.ToString()
        }).ToList();
        return values;
    }
}
