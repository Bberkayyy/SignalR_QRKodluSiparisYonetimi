using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.ViewComponents.DefaultComponents;

public class _DefaultReservationComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
