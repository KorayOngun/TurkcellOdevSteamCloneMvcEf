using Microsoft.EntityFrameworkCore;
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
    public class UserRepo : EfRepository<User>, IUserRepo
    {
        private readonly SteamCloneContext _context;
        public UserRepo(SteamCloneContext context) : base(context) 
        {
            _context = context;
        }

        public override bool IsExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Login(User user)
        {
            var data =await _context.User.AsNoTracking().Where(u=>u.UserName==user.UserName && u.UserPassword == user.UserPassword).FirstOrDefaultAsync();
            return data;
        }

        public async Task<bool> SignIn(User user)
        {
            var data = await _context.User.AsNoTracking().Where(u=>u.UserMail !=  user.UserMail && user.UserName !=u.UserName).FirstOrDefaultAsync();
            if (data==default)
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
