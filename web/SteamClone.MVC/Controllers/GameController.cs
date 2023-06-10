using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using SteamClone.MVC.CacheTools;
using SteamClone.MVC.Models;
using SteamClone.Services;
using System.Diagnostics;
using System.Security.Claims;

namespace SteamClone.MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IDeveloperService _developerService;
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;
        public GameController(IGameService gameService, ICategoryService categoryService, IPublisherService publisherService, IDeveloperService developerService, IMemoryCache cache, IUserService userService)
        {
            _gameService = gameService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _developerService = developerService;
            _cache = cache;
            _userService = userService;
        }
        public async Task<IActionResult> Index(int id)
        {
            var data = await _gameService.GetGameByIdAsync(id);
            return View(data);
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            GameCreateViewModel model = new()
            {
                Categories = await _categoryService.GetCategoriesAsync(),
                Publisher = await _publisherService.GetAllPublisherAsync(),
                Developers = await _developerService.GetAllDevelopersAsync()
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(IFormCollection formValue, GameCreateViewModel model)
        {

            var data = await Control(formValue, model);
            var result = await _gameService.CreateGameAsync(data);
            if (result!=0)
            {
                TempData["gameAdd"] = "oyun eklendi";
                await UpdateCache();
                return RedirectToAction("Index", new { id = result });
            }
            return RedirectToAction(nameof(Create));
        }




        [HttpGet]
        [Authorize(Roles = "Admin")]
        
        public async Task<IActionResult> Update(int id)
        {
            GameUpdateViewModel model = new()
            {
                Game = await _gameService.GetGameByIdForUpdateAsync(id),
                Categories = await _categoryService.GetCategoriesAsync(),
                Publisher = await _publisherService.GetAllPublisherAsync(),
                Developers = await _developerService.GetAllDevelopersAsync()
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(IFormCollection form, GameUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var data = await Control(form, model);
                await _gameService.UpdateAsync(data);
                await UpdateCache();
                return RedirectToAction(nameof(Index), routeValues: new { id = model.Game.Id });
            }
            return RedirectToAction("Index", "Home");
          
        }




        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _gameService.DeleteGameAsync(id);
            await UpdateCache();
            return RedirectToAction("index", "home");
        }

        [Authorize]
        public async Task<IActionResult> AddComment(int gameId,string comment)
        {

          
                var userMail = HttpContext.User.FindFirst(c => c.Type == ClaimTypes.Email).Value;
                var user = await _userService.GetUserIdByEmailsAsync(userMail);
                var userId = user.Id;
                GameCommentRequest commentRequest = new GameCommentRequest
                {
                    GameId = gameId,
                    UserId = userId,
                    Review = comment
                };
                await _gameService.AddCommentAsync(commentRequest);
                return RedirectToAction("Index", "Game", new { id = gameId });


        }


        private  async Task<GameRequest> Control(IFormCollection form, IGameViewModel model)
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
                model.Game.Categories.Add(new GameCategory { CategoryId = Convert.ToInt16(item) });
            }
            foreach (var item in formDevelopers)
            {
                model.Game.Developers.Add(new GameDeveloper { DeveloperId = Convert.ToInt16(item) });
            }
            return model.Game;
        }
        private async Task UpdateCache()
        {
            CacheDataInfo cacheDataInfo;
            var options = new MemoryCacheEntryOptions()
                              .SetSlidingExpiration(TimeSpan.FromMinutes(12))
                              .SetPriority(CacheItemPriority.Normal);
            var games = await _gameService.GetAllAsync();
            cacheDataInfo = new CacheDataInfo
            {
                CacheTime = DateTime.Now,
                Games = games
            };
            _cache.Set("homeData", cacheDataInfo, options);
        }

    }
}
