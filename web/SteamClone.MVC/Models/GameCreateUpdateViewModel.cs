using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;

namespace SteamClone.MVC.Models
{
    public class GameCreateUpdateViewModel
    {
        public GameCreateUpdateRequest Game { get; set; }
        public IEnumerable<CategoryResponse> Categories { get; set; }
        public IEnumerable<PublisherResponse> Publisher { get; set; }
        public IEnumerable<int> SelectedCategories { get; set; }
    }
}
