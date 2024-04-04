using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR_EntityLayer.Entities;
using SignalR_WebUI.Dtos.IdentityDtos;

namespace SignalR_WebUI.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class SettingsController : Controller
{
    private readonly UserManager<AppUser> _userManager;

    public SettingsController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [Route("Index")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
        EditUserDto editUserDto = new EditUserDto
        {
            Name = user.Name,
            Surname = user.Surname,
            Mail = user.Email,
            Username = user.UserName
        };
        return View(editUserDto);
    }
    [Route("Index")]
    [HttpPost]
    public async Task<IActionResult> Index(EditUserDto editUserDto)
    {
        if (editUserDto.Password == editUserDto.ConfirmPassword)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = editUserDto.Name;
            user.Surname = editUserDto.Surname;
            user.Email = editUserDto.Mail;
            user.UserName = editUserDto.Username;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, editUserDto.Password);
            await _userManager.UpdateAsync(user);
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }
        return View();
    }
}
