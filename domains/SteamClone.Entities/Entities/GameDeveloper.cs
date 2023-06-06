using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Entities.Entities
{
    public class GameDeveloper : IEntity
    {
        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }

    }
}
