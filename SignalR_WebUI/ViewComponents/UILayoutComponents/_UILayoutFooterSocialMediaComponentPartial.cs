using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.SocialMediaDtos;

namespace SignalR_WebUI.ViewComponents.UILayoutComponents;

public class _UILayoutFooterSocialMediaComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutFooterSocialMediaComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/SocialMedias");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultSocialMediaDto> values = JsonConvert.DeserializeObject<IList<ResultSocialMediaDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
