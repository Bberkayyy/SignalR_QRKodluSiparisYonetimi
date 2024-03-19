using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Areas.Admin.ViewComponents.LayoutComponents;

public class _AdminLayoutNavbarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
