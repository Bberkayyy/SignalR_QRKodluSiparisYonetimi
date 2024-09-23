using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR_WebUI.Dtos.RecipeDtos;

namespace SignalR_WebUI.Controllers;

[AllowAnonymous]
public class RecipesController : Controller
{
    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=60&tags=under_30_minutes"),
            Headers =    {{ "x-rapidapi-key", "ff9b850119msh8af7061f39bd390p1c72c5jsneb3f1285ac62" },
                          { "x-rapidapi-host", "tasty.p.rapidapi.com" },
            },
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            ResultRecipeDto? values = JsonConvert.DeserializeObject<ResultRecipeDto>(body);
            return View(values);
        }
    }
}
