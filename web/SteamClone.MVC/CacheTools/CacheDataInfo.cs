using SteamClone.Dto.Response;

namespace SteamClone.MVC.CacheTools
{
    public class CacheDataInfo
    {
        public IEnumerable<GameDisplayResponse> Games { get; set; }
        public DateTime CacheTime { get; set; }
    }
}
