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
using SteamClone.Dto.Request;

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

        public async Task<bool> CreateGameAsync(GameRequest game)
        {
            var item = game.ConvertToDb<Game>(_mapper);
            await _repo.CreateAsync(item);
            if (item.Id!=null)
            {
                return true;
            }
            return false;
        }

        public async Task DeleteGameAsync(int id)
        {
            var item = await _repo.GetByIdAsync(id);
            if (item != default)
            {
                await _repo.DeleteAsync(item);
            }
        }

        public IEnumerable<GameDisplayResponse> GetAll()
        {
            return _repo.GetAll().ConvortToDto<GameDisplayResponse>(_mapper);
        }

        public async Task<IEnumerable<GameDisplayResponse>> GetAllAsync()
        {
           return _repo.GetAllAsync().GetAwaiter().GetResult().ConvortToDto<GameDisplayResponse>(_mapper);
        }

       
        public Task<IEnumerable<GameDisplayResponse>> GetByCategoryAsync(int catId)
        {
            throw new NotImplementedException();
        }

        
        public GameDetailsResponse GetGameById(int id)
        {
            var item = _repo.GetById(id).ConvertToDto<GameDetailsResponse>(_mapper);
            
            return item;    
        }

        public async Task<GameDetailsResponse> GetGameByIdAsync(int id)
        {
            return _repo.GetByIdAsync(id).GetAwaiter().GetResult().ConvertToDto<GameDetailsResponse>(_mapper);
        }

        public async Task<GameRequest> GetGameByIdForUpdateAsync(int id)
        {
            return _repo.GetByIdAsync(id).GetAwaiter().GetResult().ConvertToDto<GameRequest>(_mapper);
        }

        public void Update(GameRequest game)
        {
            var item = game.ConvertToDb<Game>(_mapper);
            if (true)
            {
                
            }
            _repo.Update(game.ConvertToDb<Game>(_mapper));  
        }

        public async Task UpdateAsync(GameRequest game)
        {
            var item = game.ConvertToDb<Game>(_mapper);
            
            await _repo.UpdateAsync(item);
        }

    }
}
