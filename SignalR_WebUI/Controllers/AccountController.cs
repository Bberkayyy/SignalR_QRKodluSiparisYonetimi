using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SignalR_EntityLayer.Entities;
using SignalR_WebUI.Dtos.IdentityDtos;

namespace SignalR_WebUI.Controllers;
[AllowAnonymous]
[Route("User")]
public class AccountController : Controller
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }
    [Route("Regsiter")]
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    [Route("Regsiter")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
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
            return RedirectToAction("Login", "User");
        return View();
    }
    [HttpGet]
    [Route("Login")]
    public IActionResult Login([FromQuery(Name = "ReturnUrl")] string returnUrl = "/")
    {
        return View(new LoginDto
        {
            ReturnUrl = returnUrl,
        });
    }
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
        if (result.Succeeded)
            return Redirect(loginDto.ReturnUrl ?? "/");
        return View();
    }
    [Route("Logout")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "User");
    }
}
