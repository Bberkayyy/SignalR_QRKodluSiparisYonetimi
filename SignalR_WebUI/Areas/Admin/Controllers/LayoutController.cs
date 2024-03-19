using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Areas.Admin.Controllers;

public class LayoutController : Controller
{
    public IActionResult AdminLayoutIndex()
    {
        return View();
    }
}
