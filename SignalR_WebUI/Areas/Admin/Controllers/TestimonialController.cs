using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.TestimonialDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]

public class TestimonialController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public TestimonialController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Testimonials");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultTestimonialDto>? values = JsonConvert.DeserializeObject<IList<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateTestimonial")]
    public IActionResult CreateTestimonial() { return View(); }
    [HttpPost]
    [Route("CreateTestimonial")]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createTestimonialDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Testimonials", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        return View();
    }
    [Route("DeleteTestimonial/{id}")]
    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Testimonials/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateTestimonial/{id}")]
    public async Task<IActionResult> UpdateTestimonial(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Testimonials/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateTestimonialDto? value = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateTestimonial/{id}")]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Testimonials", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        return View();
    }
}
