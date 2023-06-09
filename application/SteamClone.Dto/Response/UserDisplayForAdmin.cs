﻿using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Response
{
    public class UserDisplayForAdmin : IDto
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string UserName { get; set; }
        public ICollection<GameReview> Reviews { get; set; } = new HashSet<GameReview>();
    }
}

