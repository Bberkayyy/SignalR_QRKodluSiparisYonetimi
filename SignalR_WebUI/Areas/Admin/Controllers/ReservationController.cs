using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.ReservationDtos;
using System.Text;

namespace SignalR_WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]")]
public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Reservations");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultReservationDto>? values = JsonConvert.DeserializeObject<IList<ResultReservationDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    [HttpGet]
    [Route("CreateReservation")]
    public IActionResult CreateReservation() { return View(); }
    [HttpPost]
    [Route("CreateReservation")]
    public async Task<IActionResult> CreateReservation(CreateReservationDto createReservationDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createReservationDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Reservations", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });
        return View();
    }
    [Route("DeleteReservation/{id}")]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.DeleteAsync($"http://localhost:20666/api/Reservations/{id}");
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("UpdateReservation/{id}")]
    public async Task<IActionResult> UpdateReservation(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Reservations/{id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            UpdateReservationDto? value = JsonConvert.DeserializeObject<UpdateReservationDto>(jsonData);
            return View(value);
        }
        return View();
    }
    [HttpPost]
    [Route("UpdateReservation/{id}")]
    public async Task<IActionResult> UpdateReservation(UpdateReservationDto updateReservationDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(updateReservationDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PutAsync("http://localhost:20666/api/Reservations", content);
        if (responseMessage.IsSuccessStatusCode)
            return RedirectToAction("Index", "Reservation", new { area = "Admin" });
        return View();
    }
    [HttpGet]
    [Route("approved/{id}")]
    public async Task<IActionResult> ReservationStatusApproved(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync("http://localhost:20666/api/Reservations/approved?id=" + id);
        return RedirectToAction("Index", "Reservation", new { area = "Admin" });
    }
    [HttpGet]
    [Route("cancelled/{id}")]
    public async Task<IActionResult> ReservationStatusCancelled(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        await client.GetAsync("http://localhost:20666/api/Reservations/cancelled?id=" + id);
        return RedirectToAction("Index", "Reservation", new { area = "Admin" });
    }
}
