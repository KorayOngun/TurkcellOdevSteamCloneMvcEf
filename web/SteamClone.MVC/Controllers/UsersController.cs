using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SteamClone.Dto.Request;
using SteamClone.Services;
using System.Security.Claims;

namespace SteamClone.MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.LoginAsync(request);
                if (result != default)
                {
                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name ,result.UserName),
                        new Claim(ClaimTypes.Email , result.UserMail),
                        new Claim(ClaimTypes.Role ,result.Role),
                    };
                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("index","home");
                }
                ModelState.AddModelError("Login", "Kullanıcı adı veya şifre yanlış");
            }
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
