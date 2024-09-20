using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.CategoryDtos;

namespace SignalR_WebUI.ViewComponents.MenuComponents;

public class _MenuCategoryFilterComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _MenuCategoryFilterComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMesssage = await client.GetAsync("http://localhost:20666/api/Categories");
        if (responseMesssage.IsSuccessStatusCode)
        {
            string jsonData = await responseMesssage.Content.ReadAsStringAsync();
            IList<ResultCategoryDto>? values = JsonConvert.DeserializeObject<IList<ResultCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
