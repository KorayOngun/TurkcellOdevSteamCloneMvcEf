using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Entities.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string UserMail { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Role { get; set; }
        public ICollection<GameReview> Reviews { get; set; } = new HashSet<GameReview>();  
    }
}
