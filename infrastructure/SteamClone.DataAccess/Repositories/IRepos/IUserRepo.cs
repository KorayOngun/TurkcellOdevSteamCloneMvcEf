using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.IRepos
{
    public interface IUserRepo : IRepo<User>
    {
        Task<User> Login(User user);
        Task<bool> SignIn(User user);
    }
}
