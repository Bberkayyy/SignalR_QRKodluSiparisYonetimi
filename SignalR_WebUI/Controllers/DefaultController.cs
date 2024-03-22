using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
