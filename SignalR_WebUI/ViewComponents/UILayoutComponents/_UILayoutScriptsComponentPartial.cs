using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.ViewComponents.UILayoutComponents;

public class _UILayoutScriptsComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
