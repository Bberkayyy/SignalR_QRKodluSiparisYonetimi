using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Areas.Admin.ViewComponents.LayoutComponents;

public class _AdminLayoutFooterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
