﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CartDtos;
using SignalR_WebUI.Dtos.CategoryDtos;
using SignalR_WebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalR_WebUI.Controllers;

[AllowAnonymous]
public class MenuController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MenuController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index(int id)
    {
        ViewBag.restaurantTableId = id;
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
    [HttpPost]
    public async Task<IActionResult> AddToCart([FromBody] CreateCartDto createCartDto)
    {
        //ajax ile gelen ProductId ve RestaurantTableId değerleri dto sınıfındaki aynı isimli property lere atanıyor.
        HttpClient client = _httpClientFactory.CreateClient();
        string jsonData = JsonConvert.SerializeObject(createCartDto);
        StringContent content = new(jsonData, Encoding.UTF8, "application/json");
        HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:20666/api/Carts", content);
        if (responseMessage.IsSuccessStatusCode)
        {
            return RedirectToAction("Index");
        }
        return Json(createCartDto);
    }
}
