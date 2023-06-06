﻿using AutoMapper;
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

        public IEnumerable<GameDisplayResponse> GetAll()
        {
            return _repo.GetAll().ConvortToDto<GameDisplayResponse>(_mapper);
        }

        public Task<IEnumerable<GameDisplayResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
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

        public Task<GameDetailsResponse> GetGameByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(GameUpdateRequest game)
        {

            _repo.Update(game.ConvertToDb<Game>(_mapper));  
        }

        public async Task UpdateAsync(GameUpdateRequest game)
        {
           await _repo.UpdateAsync(game.ConvertToDb<Game>(_mapper));
        }
    }
}
