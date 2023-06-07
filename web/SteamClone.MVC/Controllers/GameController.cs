using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SteamClone.MVC.Models;
using SteamClone.Services;

namespace SteamClone.MVC.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameService _gameService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        public GameController(IGameService gameService, ICategoryService categoryService,IPublisherService publisherService)
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
        public async Task<IActionResult> Create()
        {
            GameCreateUpdateViewModel model = new GameCreateUpdateViewModel();
            model.Categories = await _categoryService.GetCategoriesAsync();
            model.Publisher = await _publisherService.GetAllPublisherAsync();
            return View(model);
        }
        
        public async Task<IActionResult> Update(int id)
        {
            
            var data = await _gameService.GetGameByIdForUpdateAsync(id);
         
            return View(data);
        }
       
    }
}
