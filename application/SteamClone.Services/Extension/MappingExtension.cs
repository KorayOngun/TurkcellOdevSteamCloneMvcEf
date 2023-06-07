using AutoMapper;
using SteamClone.Dto;
using SteamClone.Entities;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services.Extension
{
    public static class MappingExtension
    {
        public static T ConvertToDto<T>(this IEntity entity, IMapper mapper) where T : class,IDto
        {
            return mapper.Map<T>(entity);   
        }
        public static IEnumerable<T> ConvortToDto<T>(this IEnumerable<IEntity> entity, IMapper mapper) where T : class, IDto
        {
            return mapper.Map<IEnumerable<T>>(entity);
     
        }
        public static T ConvertToDb<T>(this IDto dto, IMapper mapper)
        {
            return mapper.Map<T>(dto);  
        }
    }
}
