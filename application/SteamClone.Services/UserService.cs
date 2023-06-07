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

        public async Task<UserLoginResponse> LoginAsync(UserLoginRequest user)
        {
            var result =  _repo.GetAllWithPredicateAsync(u => u.UserName == user.Name && user.Password == user.Password).GetAwaiter().GetResult().FirstOrDefault();
            if (result != default)
            {
                return result.ConvertToDto<UserLoginResponse>(_mapper);
            }
            return null;
        }

        public async Task<bool> SignUpAsync(NewUserRequest newUser)
        {
            var control = !_repo.GetAllWithPredicateAsync(x => x.UserName == newUser.UserName || x.UserMail == newUser.UserMail).GetAwaiter().GetResult().Any();
            if (control)
            {
                await _repo.CreateAsync(newUser.ConvertToDb<User>(_mapper));
                return true;    
            }
            return false;            
        }
        
    }
}
