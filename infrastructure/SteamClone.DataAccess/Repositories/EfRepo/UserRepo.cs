using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<User>> GetUserForAdmin()
        { 
            
            var data = await _context.User.AsNoTracking().Where(x=>x.Role == "Member").Include(x=>x.Reviews)
                .Select(u=>new User
                {
                    Id = u.Id,
                    UserMail = u.UserMail,
                    UserName = u.UserName,
                    Reviews = u.Reviews,
                })
                .ToListAsync();
            return data;
        }
        public async Task<User> GetUserDetailsForAdmin(int id)
        {

            var data = await _context.User.AsNoTracking().Where(x => x.Role == "Member" && x.Id==id).Include(x => x.Reviews)
                .Select(u => new User
                {
                    Id = u.Id,
                    UserMail = u.UserMail,
                    UserName = u.UserName,
                    Reviews = u.Reviews,
                })
                .FirstOrDefaultAsync();
            return data;
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

        public async Task<bool> SignUp(User user)
        {
            var data = await _context.User.AsNoTracking().Where(u=>u.UserMail ==  user.UserMail || user.UserName == u.UserName).ToListAsync();
            if (!data.Any())
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
