using SteamClone.Dto;
using SteamClone.Dto.Request;
using SteamClone.Dto.Response;

namespace SteamClone.MVC.Models
{

    public interface IGameViewModel
    {
        public GameRequest Game { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }
        public IEnumerable<PublisherResponse> Publisher { get; set; }
        public IEnumerable<DeveloperResponse> Developers { get; set; }
    } 
    public class GameCreateViewModel : IGameViewModel
    {
        public GameRequest Game { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }
        public IEnumerable<PublisherResponse> Publisher { get; set; }
        public IEnumerable<DeveloperResponse> Developers { get; set; }
    }
    public class GameUpdateViewModel : IGameViewModel
    {
        public  GameRequest Game { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }
        public IEnumerable<PublisherResponse> Publisher { get; set; }
        public IEnumerable<DeveloperResponse> Developers { get; set; }
    }
}
