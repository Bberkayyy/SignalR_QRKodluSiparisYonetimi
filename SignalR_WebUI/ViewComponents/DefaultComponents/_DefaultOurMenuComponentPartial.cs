using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.ViewComponents.DefaultComponents;

public class _DefaultOurMenuComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
