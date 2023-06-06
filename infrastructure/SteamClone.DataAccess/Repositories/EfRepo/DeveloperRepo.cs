using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.EfRepo
{
    public class DeveloperRepo : EfRepository<Developer>,IDeveloperRepo
    {
        private readonly SteamCloneContext _context;
        public DeveloperRepo(SteamCloneContext context) : base(context) 
        {
            _context = context;
        }
    }
}
