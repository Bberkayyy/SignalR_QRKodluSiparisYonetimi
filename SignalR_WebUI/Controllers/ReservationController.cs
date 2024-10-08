﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.ReservationDtos;
using SignalR_WebUI.Dtos.ValidationErrorDtos;
using System.Text;

namespace SignalR_WebUI.Controllers;

[AllowAnonymous]
public class ReservationController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ReservationController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> MakeReservation(CreateReservationDto createReservationDto)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createReservationDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Reservations", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index", "Default");
        }
        else
        {
            ModelState.Clear();
            var errorContent = await responseMessage.Content.ReadAsStringAsync();
            List<ResultValidationErrorDto>? validationErrors = JsonConvert.DeserializeObject<List<ResultValidationErrorDto>>(errorContent);
            foreach (var error in validationErrors)
            {
                ModelState.AddModelError(error.propertyName, error.errorMessage);
            }
            return View("Index", createReservationDto);
        }
    }
}
