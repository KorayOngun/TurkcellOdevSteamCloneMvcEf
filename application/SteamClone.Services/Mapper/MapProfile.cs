using AutoMapper;
using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Game, GameDisplayResponse>();
            CreateMap<Game,GameDetailsResponse>();
            CreateMap<User,UserLoginResponse>();
            CreateMap<NewUserRequest,User>();
            CreateMap<Game,GameCreateUpdateRequest>();
            CreateMap<GameCreateUpdateRequest, Game>();
            CreateMap<Category,CategoryResponse>();
            CreateMap<Publisher,PublisherResponse>();   
        }
    }
}
