using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class DashboardController : Controller
{
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
}
