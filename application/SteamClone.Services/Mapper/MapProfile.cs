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
            CreateMap<UserLoginRequest, User>();
            CreateMap<User,UserLoginResponse>();
            CreateMap<User,ChangeUserNameRequest>().ReverseMap();
            CreateMap<User, UserDisplayForAdmin>();
            CreateMap<NewUserRequest,User>();
            CreateMap<Game, GameRequest>().ReverseMap();
            CreateMap<GameCommentRequest, GameReview>();

            CreateMap<Developer,DeveloperResponse>();
            
            CreateMap<Category,CategoryResponse>();
            CreateMap<Publisher,PublisherResponse>();   
        }
    }
}
