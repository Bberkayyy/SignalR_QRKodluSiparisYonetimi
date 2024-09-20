using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers;

[AllowAnonymous]
public class ErrorController : Controller
{
    public IActionResult NotFound404()
    {
        return View();
    }
}
