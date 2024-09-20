using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.ProductDtos;

namespace SignalR_WebUI.ViewComponents.DefaultComponents;

public class _DefaultOurMenuComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultOurMenuComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Products/getlast9withcategory");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultProductsWithCategoriesDto>? values = JsonConvert.DeserializeObject<IList<ResultProductsWithCategoriesDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
