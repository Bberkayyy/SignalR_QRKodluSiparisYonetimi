﻿using Microsoft.AspNetCore.Mvc;

namespace SignalR_WebUI.Controllers;

public class MessageController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
