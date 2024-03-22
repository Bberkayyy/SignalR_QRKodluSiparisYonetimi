using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.ViewComponents.DefaultComponents;

public class _DefaultSliderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
