using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using SteamClone.Dto.Response;
using SteamClone.MVC.Extension;
using SteamClone.MVC.Models;
using SteamClone.Services;

namespace SteamClone.MVC.Controllers
{
    public class WishListController : Controller
    {
        private readonly IGameService _gameService;
        public WishListController(IGameService gameService)
        {
            _gameService = gameService;
        }
        public IActionResult Index()
        {
            var data = getWishList().WishList;

            return View(data);
        }
        
        public async Task<IActionResult> AddWishList(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game!=default)
            {
                var item = new WishListItem { Id = game.Id, ImageUrl = game.ImageUrl, Name = game.Name, Price = game.Price };
                WishListCollection wishList = getWishList();
                var result = wishList.AddOrIncrease(item);
                saveToSession(wishList);
                if (result == 0 )
                {
                    return Json(new {result =result, message = "game added to your wishlist" });
                }
                if (result == 1)
                {
                    return Json(new { result = result, message = "increased number of games" }); ;
                }
            }
            return Json(new { message = ":<(" });
        }
        
        public async Task<IActionResult> Clear()
        {
            var data = getWishList();
            data.Clear();
            saveToSession(data);
            return RedirectToAction("Index","Home");
        }


        private WishListCollection getWishList()
        {
            return HttpContext.Session.GetJson<WishListCollection>("WishList") ?? new WishListCollection();
        }

        private void saveToSession(WishListCollection wishList)
        {
            HttpContext.Session.SetJson("WishList", wishList);
        }

    }
}
