using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalR_WebUI.Dtos.OrderDetailDtos;

namespace SignalR_WebUI.Areas.Admin.ViewComponents;

public class _OrderPageSeeOrderComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _OrderPageSeeOrderComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        int restaurantTableId = await GetRestaurantTableId(id);
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/OrderDetails/getallwithrelationshipsbyorderid/" + restaurantTableId);
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultOrderDetailDto>? values = JsonConvert.DeserializeObject<IList<ResultOrderDetailDto>>(jsonData);
            return View(values);
        }
        return View();
    }
    private async Task<int> GetRestaurantTableId(int id)
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:20666/api/Orders/{id}");

        string jsonData = await responseMessage.Content.ReadAsStringAsync();
        JObject value = JObject.Parse(jsonData);
        int restaurantTableId = (int)value["id"];

        return restaurantTableId;
    }
}
