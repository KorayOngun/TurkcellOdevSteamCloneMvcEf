﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Entities.Entities
{
    public class Game : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PublisherId { get; set; }
        public Publisher? Publisher { get; set; }
        public decimal Price { get; set; }
        public string About { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? MinimumHardware { get; set; }
        public string? RecommendedHardware { get; set; }
        public string ImageUrl { get; set; } 
        public ICollection<GameDeveloper> Developers { get; set; } = new HashSet<GameDeveloper>();
        public ICollection<GameCategory> Categories { get; set; } = new HashSet<GameCategory>();
        public ICollection<GameReview> Review { get; set; } = new HashSet<GameReview>();

    }
}
