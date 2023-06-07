using Microsoft.AspNetCore.Mvc;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.MVC.Models;
using SteamClone.Services;
using System.Diagnostics;

namespace SteamClone.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _gameService;
        public HomeController(ILogger<HomeController> logger,IGameService gameService)
        {
            _logger = logger;
            _gameService = gameService;
        }

        public IActionResult Index()
        {
            var data = _gameService.GetAll();   
            return View(data);
        }

     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}