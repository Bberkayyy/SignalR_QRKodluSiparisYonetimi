using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Areas.Admin.ViewComponents.LayoutComponents;

public class _AdminLayoutSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
