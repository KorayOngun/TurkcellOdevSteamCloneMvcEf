﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Entities.Entities
{
    public class GameCategory : IEntity
    {
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int GameId { get; set; }
        public Game? Game { get; set; }
    }
}
