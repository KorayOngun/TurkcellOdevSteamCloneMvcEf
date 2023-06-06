using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Entities.Entities
{
    public class Developer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<GameDeveloper> Games { get; set; } = new HashSet<GameDeveloper>();

    }
}
