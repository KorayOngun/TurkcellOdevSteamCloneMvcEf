using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using SteamClone.MVC.Models;
using SteamClone.Services;

namespace SteamClone.MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IDeveloperService _developerService;
        public GameController(IGameService gameService, ICategoryService categoryService, IPublisherService publisherService, IDeveloperService developerService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _developerService = developerService;
        }
        public IActionResult Index(int id)
        {
            var data = _gameService.GetGameById(id);
            return View(data);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Create()
        {
            GameCreateUpdateViewModel model = new GameCreateUpdateViewModel();
            model.Categories = await _categoryService.GetCategoriesAsync();
            model.Publisher = await _publisherService.GetAllPublisherAsync();
            model.Developers = await _developerService.GetAllDevelopersAsync();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(IFormCollection formValue, GameCreateUpdateViewModel model)
        {
            
            
                GameCreateUpdateRequest data = Control(formValue, model);
                var result = await _gameService.CreateGameAsync(data);
                if (result)
                {
                    TempData["gameAdd"] = "oyun eklendi";
                }
            
            return RedirectToAction(nameof(Create));

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            GameCreateUpdateViewModel model = new();
            model.Game = await _gameService.GetGameByIdForUpdateAsync(id);
            model.Categories = await _categoryService.GetCategoriesAsync();
            model.Publisher = await _publisherService.GetAllPublisherAsync();
            model.Developers = await _developerService.GetAllDevelopersAsync();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(IFormCollection form, GameCreateUpdateViewModel model)
        {
            GameCreateUpdateRequest data = Control(form, model);
            await _gameService.UpdateAsync(data);
            return RedirectToAction(nameof(Index), routeValues: new { id = model.Game.Id });
        }
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteGameAsync(id);
            return RedirectToAction("index", "home");
        }
        private GameCreateUpdateRequest Control(IFormCollection form, GameCreateUpdateViewModel model)
        {
            List<string> formCategories = form["categories"].ToList();
            List<string> formDevelopers = form["developers"].ToList();
            if (!form["categories"].IsNullOrEmpty())
            {
               model.Game.Categories = new List<GameCategory>();
            }
            if (!form["developers"].IsNullOrEmpty())
            {
                model.Game.Developers = new List<GameDeveloper>();
            }
            foreach (var item in formCategories)
            {
                model.Game.Categories.Add(new GameCategory { CategoryId = Convert.ToInt16(item) , GameId = model.Game.Id });
            }
            foreach (var item in formDevelopers)
            {
                model.Game.Developers.Add(new GameDeveloper { DeveloperId = Convert.ToInt16(item), GameId = model.Game.Id });
            }
            return model.Game;
        }

    }
}
