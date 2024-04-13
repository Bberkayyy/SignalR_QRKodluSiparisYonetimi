using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SignalR_EntityLayer.Entities;
using SignalR_WebUI.Dtos.IdentityDtos;

namespace SignalR_WebUI.Controllers;
[AllowAnonymous]
public class AccountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(SignInManager<AppUser> signInManager)
    {
        _signInManager = signInManager;
    }
    [HttpGet]
    public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
    {
        return View(new LoginDto
        {
            ReturnUrl = returnUrl,
        });
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
        if (result.Succeeded)
            return Redirect(loginDto.ReturnUrl ?? "/");
        return View();
    }
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }
}
