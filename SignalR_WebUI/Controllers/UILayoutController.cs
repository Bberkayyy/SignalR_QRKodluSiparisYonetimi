using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers;

public class UILayoutController : Controller
{
    public IActionResult UILayoutIndex()
    {
        return View();
    }
}
