using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.ContactDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]")]
public class ContactController : Controller
{

    private readonly IHttpClientFactory _httpClientFactory;

    public ContactController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Contacts");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultContactDto>? values = JsonConvert.DeserializeObject<IList<ResultContactDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateContact")]
    public IActionResult CreateContact() { return View(); }
    [HttpPost]
    [Route("CreateContact")]
    public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createContactDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Contacts", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        return View();
    }
    [Route("DeleteContact/{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Contacts/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateContact/{id}")]
    public async Task<IActionResult> UpdateContact(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Contacts/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateContactDto? value = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateContact/{id}")]
    public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateContactDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Contacts", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Contact", new { area = "Admin" });
        return View();
    }
}
