using Microsoft.AspNetCore.Mvc;
using SteamClone.Services;

namespace SteamClone.MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        public GameController(IGameService gameService)
        {
                _gameService = gameService;
        }
        public IActionResult Index(int id)
        {
            var data = _gameService.GetGameById(id);
            return View(data);
        }
    }
}
