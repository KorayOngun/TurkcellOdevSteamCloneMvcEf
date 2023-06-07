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
        public GameController(IGameService gameService, ICategoryService categoryService, IPublisherService publisherService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
            _publisherService = publisherService;
        }
        public IActionResult Index(int id)
        {
            var data = _gameService.GetGameById(id);
            return View(data);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            GameCreateUpdateViewModel model = new GameCreateUpdateViewModel();
            model.Categories = await _categoryService.GetCategoriesAsync();
            model.Publisher = await _publisherService.GetAllPublisherAsync();
            return View(model);
        }
        [HttpPost]
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
        public async Task<IActionResult> Update(int id)
        {

            var game = await _gameService.GetGameByIdForUpdateAsync(id);
            var categories = await _categoryService.GetCategoriesAsync();
            var publishers = await _publisherService.GetAllPublisherAsync();
            GameCreateUpdateViewModel model = new()
            {
                Game = game,
                Categories = categories,
                Publisher = publishers
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(IFormCollection form, GameCreateUpdateViewModel model)
        {

            GameCreateUpdateRequest data = Control(form, model);
            await _gameService.UpdateAsync(data);


            return RedirectToAction(nameof(Index), routeValues: new { id = model.Game.Id });
        }
        private GameCreateUpdateRequest Control(IFormCollection form, GameCreateUpdateViewModel model)
        {
            List<string> formCategories = form["categories"].ToList();
            if (!form["categories"].IsNullOrEmpty())
            {
                foreach (var item in model.Game.Categories)
                {
                    model.Game.Categories.Remove(item);
                }
            }
            foreach (var item in formCategories)
            {
                model.Game.Categories.Add(new GameCategory { CategoryId = Convert.ToInt16(item) , GameId = model.Game.Id });
            }

            return model.Game;
        }

    }
}
