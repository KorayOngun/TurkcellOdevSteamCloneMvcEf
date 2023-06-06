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
    internal class UserRepo : EfRepository<User>, IUserRepo
    {
        private readonly SteamCloneContext _context;
        public UserRepo(SteamCloneContext context) : base(context) 
        {
            _context = context;
        }
    }
}
