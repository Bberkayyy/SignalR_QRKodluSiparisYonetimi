using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Areas.Admin.ViewComponents.LayoutComponents;

public class _AdminLayoutHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
