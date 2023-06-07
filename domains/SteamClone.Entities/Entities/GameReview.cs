using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Entities.Entities
{
    public class GameReview : IEntity
    {
        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? GameId { get; set; }
        public Game? Game { get; set; }
        public string Review { get; set; }
    }
}
