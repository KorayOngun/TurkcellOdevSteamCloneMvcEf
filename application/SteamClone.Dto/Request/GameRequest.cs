using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Request
{
    public class GameRequest : IDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? PublisherId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string About { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        public string? MinimumHardware { get; set; }
        public string? RecommendedHardware { get; set; }
        [Required]
        public string ImageUrl { get; set; } = "https://loremflickr.com/320/240";
        public ICollection<GameCategory> Categories { get; set; } = new HashSet<GameCategory>();
        public ICollection<GameDeveloper> Developers { get; set; } = new HashSet<GameDeveloper>();
    }
}
