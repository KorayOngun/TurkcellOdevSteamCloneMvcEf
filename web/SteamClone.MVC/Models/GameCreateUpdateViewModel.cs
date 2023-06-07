using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;

namespace SteamClone.MVC.Models
{
    public class GameCreateUpdateViewModel
    {
        public GameCreateUpdateRequest Game { get; set; }
        public ICollection<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();   
        public IEnumerable<PublisherResponse> Publisher { get; set; }
        
        
    }
}
