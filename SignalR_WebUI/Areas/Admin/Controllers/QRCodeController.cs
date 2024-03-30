using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.RestaurantTableDtos;

namespace SignalR_WebUI.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]")]
public class QRCodeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public QRCodeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    [Route("Index")]
    public async Task<IActionResult> Index()
    {
        ViewBag.restaurantTables = await GetRestaurantTableList();
        return View();
    }
    [HttpPost]
    [Route("Index")]
    public async Task<IActionResult> Index(string value)
    {
        using (MemoryStream memoryStream = new())
        {
            QRCodeGenerator generateQrCode = new();
            QRCodeGenerator.QRCode contentQrCode = generateQrCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.H);
            using (Bitmap qrImage = contentQrCode.GetGraphic(10))
            {
                qrImage.Save(memoryStream, ImageFormat.Png);
                ViewBag.qrImage = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
            }
            ViewBag.restaurantTables = await GetRestaurantTableList();
        }
        return View();
    }
    private async Task<IList<SelectListItem>> GetRestaurantTableList()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage resposeMessage = await client.GetAsync("http://localhost:20666/api/RestaurantTables");
        string jsonData = await resposeMessage.Content.ReadAsStringAsync();
        IList<ResultRestaurantTableDto>? restaurantTables = JsonConvert.DeserializeObject<IList<ResultRestaurantTableDto>>(jsonData);
        IList<SelectListItem>? values = restaurantTables.Select(x => new SelectListItem
        {
            Text = x.name,
            Value = x.name
        }).ToList();
        return values;
    }
}
