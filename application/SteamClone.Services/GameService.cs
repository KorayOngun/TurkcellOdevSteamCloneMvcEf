using AutoMapper;
using SteamClone.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamClone.Services.Extension;
using System.Text.Json;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities.Entities;

namespace SteamClone.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepo _repo;
        private readonly IMapper _mapper;
        public GameService(IGameRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IEnumerable<GameDisplayResponse> GetAll()
        {
            return _repo.GetAll().ConvortToDto<GameDisplayResponse>(_mapper);
        }

        public IEnumerable<GameDisplayResponse> GetByCategory(int catId)
        {
            return _repo.GamesByCategory(catId).ConvortToDto<GameDisplayResponse>(_mapper);
        }

        public GameDetailsResponse GetGameById(int id)
        {
            var item = _repo.GetById(id).ConvertToDto<GameDetailsResponse>(_mapper);
            
            return item;    
        }

        public void Update(Game game)
        {
            _repo.Update(game);  
        }
    }
}
