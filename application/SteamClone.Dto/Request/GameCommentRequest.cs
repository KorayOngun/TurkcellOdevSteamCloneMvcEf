using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Request
{
    public class GameCommentRequest : IDto
    {
        public int UserId { get; set; }
        public int GameId { get; set; }
        public string Review { get; set; }
    }
}
