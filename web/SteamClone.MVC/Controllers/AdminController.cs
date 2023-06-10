using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteamClone.Services;

namespace SteamClone.MVC.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var data =  await _userService.GetAllUserForAdminAsync();
            return View(data);
        }
        public async Task<IActionResult> Details(int id = 0)
        {
            var data = await _userService.GetUserDetailsForAdminAsync(id);
            return View(data);
        }
        
    }
}
