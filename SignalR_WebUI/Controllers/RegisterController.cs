using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_EntityLayer.Entities;
using SignalR_WebUI.Dtos.IdentityDtos;

namespace SignalR_WebUI.Controllers;

public class RegisterController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public RegisterController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(RegisterDto registerDto)
    {
        AppUser appUser = new()
        {
            Name = registerDto.Name,
            Surname = registerDto.Surname,
            Email = registerDto.Mail,
            UserName = registerDto.Username,
        };
        IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);
        if (result.Succeeded)
            return RedirectToAction("Index", "Login");
        return View();
    }
}
