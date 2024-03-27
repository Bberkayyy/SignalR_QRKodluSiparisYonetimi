using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.DiscountOfDayDtos;
using SignalR_WebUI.Dtos.FeatureDtos;

namespace SignalR_WebUI.ViewComponents.DefaultComponents;

public class _DefaultOfferComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultOfferComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/DiscountOfDays/getallbystatustrue");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultDiscountOfDayDto>? values = JsonConvert.DeserializeObject<IList<ResultDiscountOfDayDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
