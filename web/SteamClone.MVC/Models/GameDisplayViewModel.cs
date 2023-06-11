using SteamClone.Dto.Response;

namespace SteamClone.MVC.Models
{
    public class GameDisplayViewModel
    {
       public IEnumerable<GameDisplayResponse> Data { get; set; }

        public PagingInfo? Info { get; set; }
    }
}
 