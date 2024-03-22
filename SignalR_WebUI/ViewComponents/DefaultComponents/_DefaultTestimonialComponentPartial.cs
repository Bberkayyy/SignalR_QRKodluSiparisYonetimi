using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.TestimonialDtos;

namespace SignalR_WebUI.ViewComponents.DefaultComponents;

public class _DefaultTestimonialComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        HttpClient client = _httpClientFactory.CreateClient();
        HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:20666/api/Testimonials");
        if (responseMessage.IsSuccessStatusCode)
        {
            string jsonData = await responseMessage.Content.ReadAsStringAsync();
            IList<ResultTestimonialDto>? values = JsonConvert.DeserializeObject<IList<ResultTestimonialDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
