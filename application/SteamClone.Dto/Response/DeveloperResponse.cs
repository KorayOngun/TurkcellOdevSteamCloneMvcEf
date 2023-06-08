using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Dto.Response
{
    public class DeveloperResponse : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
