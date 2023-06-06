using AutoMapper;
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
        }
    }
}
