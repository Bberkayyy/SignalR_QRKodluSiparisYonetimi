using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.FooterInfoDtos;

namespace SignalR_WebUI.ViewComponents.UILayoutComponents;

public class _UILayoutFooterDetailComponenPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _UILayoutFooterDetailComponenPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/FooterInfos");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultFooterInfoDto>? values = JsonConvert.DeserializeObject<IList<ResultFooterInfoDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
