using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public interface IUserService
    {
        Task<UserLoginResponse> LoginAsync(UserLoginRequest user);   
        Task<bool> SignUpAsync(NewUserRequest newUser);
        Task<IEnumerable<UserDisplayForAdmin>> GetAllUserForAdminAsync();
        Task<UserDisplayForAdmin> GetUserIdByEmailsAsync(string mail);
        Task ChangeUserName(ChangeUserNameRequest changeUserNameRequest);
        Task<UserDisplayForAdmin> GetUserDetailsForAdminAsync(int id);
    }
}
