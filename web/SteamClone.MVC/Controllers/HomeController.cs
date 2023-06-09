using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.Dto.Response;
using SteamClone.MVC.CacheTools;
using SteamClone.MVC.Models;
using SteamClone.Services;
using System.Diagnostics;

namespace SteamClone.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGameService _gameService;
        private readonly IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger,IGameService gameService, IMemoryCache cache)
        {
            _logger = logger;
            _gameService = gameService;
            _cache = cache; 
        }

        public async Task<IActionResult> Index()
        {

            var data = await GetGameMemCacheOrDb();   
            return View(data);
        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private async Task<IEnumerable<GameDisplayResponse>> GetGameMemCacheOrDb()
        {
           
            if (!_cache.TryGetValue("homeData", out CacheDataInfo cacheDataInfo))
            {
                var options = new MemoryCacheEntryOptions()
                                  .SetSlidingExpiration(TimeSpan.FromMinutes(12))
                                  .SetPriority(CacheItemPriority.Normal);
                cacheDataInfo = new CacheDataInfo
                {
                    CacheTime = DateTime.Now,
                    Games =  _gameService.GetAllAsync().GetAwaiter().GetResult()
                };

                _cache.Set("homeData", cacheDataInfo, options);
            }
            _logger.LogInformation($"{cacheDataInfo.CacheTime.ToLongTimeString()} anındaki cache'i görmektesiniz");
            return cacheDataInfo.Games;

        }
    }
}