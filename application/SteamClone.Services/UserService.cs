using AutoMapper;
using AutoMapper.Configuration.Annotations;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using SteamClone.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task ChangeUserName(ChangeUserNameRequest changeUserNameRequest)
        {
            var result = await _repo.Login(new User {UserName=changeUserNameRequest.UserName,UserPassword=changeUserNameRequest.UserPassword });
            if (result != default)
            {
                var item = _repo.GetById(result.Id);
                item.UserName = changeUserNameRequest.NewUserName;
                await _repo.UpdateAsync(item);
            }
        }
        public async Task<IEnumerable<UserDisplayForAdmin>> GetAllUserForAdminAsync()
        {
            var data = await _repo.GetUserForAdmin();
            return data.ConvortToDto<UserDisplayForAdmin>(_mapper).ToList();
        }
        public async Task<UserDisplayForAdmin> GetUserDetailsForAdminAsync(int id)
        {
            var data = await _repo.GetUserDetailsForAdmin(id);
            return data.ConvertToDto<UserDisplayForAdmin>(_mapper);
        }


        public async Task<UserDisplayForAdmin> GetUserIdByEmailsAsync(string mail)
        {
            var data = await _repo.GetAllWithPredicateAsync(u => u.UserMail == mail);
            return data.FirstOrDefault().ConvertToDto<UserDisplayForAdmin>(_mapper);
        }

        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest user)
        {
            var _user = user.ConvertToDb<User>(_mapper);
            var result = await _repo.Login(_user);
            return result.ConvertToDto<UserLoginResponse>(_mapper); 
        }
        public async Task<bool> SignUpAsync(NewUserRequest newUser)
        {
            var _newUser = newUser.ConvertToDb<User>(_mapper);
            if (await _repo.SignUp(_newUser))
            {
                return true;    
            }
            return false;            
        }

    }
}
