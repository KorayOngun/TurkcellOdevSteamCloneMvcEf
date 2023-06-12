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
        public GameService(IGameRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddCommentAsync(GameCommentRequest comment)
        {
            var control = await _repo.GetByIdAsync(comment.GameId);
            if (!control.Review.Any(r => r.UserId == comment.UserId))
            {
                var item = comment.ConvertToDb<GameReview>(_mapper);
                await _repo.AddCommentAsync(item);
            }
        }

        public async Task<int> CreateGameAsync(GameRequest game)
        {
            var item = game.ConvertToDb<Game>(_mapper);
            await _repo.CreateAsync(item);
            if (item.Id != default)
            {
                return item.Id;
            }
            return 0;
        }

        public async Task DeleteGameAsync(int id)
        {
            var condition =  _repo.IsExistAsync(id);
            if (condition)
            {
                var item = await _repo.GetByIdAsync(id);
                await _repo.DeleteAsync(item);
            }
        }

        public IEnumerable<GameDisplayResponse> GetAll()
        {
            return _repo.GetAll().ConvortToDto<GameDisplayResponse>(_mapper);
        }

        public async Task<IEnumerable<GameDisplayResponse>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();
            var result = data.ConvortToDto<GameDisplayResponse>(_mapper);
            return result;
        }


        public async Task<GameDetailsResponse> GetGameByIdAsync(int id)
        {
            if (_repo.IsExistAsync(id))
            {
                var data = await _repo.GetByIdAsync(id);
                var result = data.ConvertToDto<GameDetailsResponse>(_mapper);
                return result;
            }
            return default;
        }

        public async Task<GameRequest> GetGameByIdForUpdateAsync(int id)
        {
            if (_repo.IsExistAsync(id))
            {
                var data = await _repo.GetByIdAsync(id);
                var result = data.ConvertToDto<GameRequest>(_mapper);
                return result;
            }
            return default;
        }

        public async Task<ICollection<GameDisplayResponse>> GetGameByName(string name)
        {
            var data  = await _repo.GetAllWithPredicateAsync(g=>g.Name.Contains(name));
            var result = data.ConvortToDto<GameDisplayResponse>(_mapper).ToList();
            return result;
        }

        public async Task UpdateAsync(GameRequest game)
        {
            if (_repo.IsExistAsync(game.Id))
            {
                var item = await _repo.GetItemForUpdateAsync(game.Id);
                BindValues(item, game.ConvertToDb<Game>(_mapper));
                await _repo.UpdateAsync(item);
            }
        }
        private void BindValues(Game dbEntity, Game newValues)
        {
            dbEntity.Name = newValues.Name;
            dbEntity.RecommendedHardware = newValues.RecommendedHardware;
            dbEntity.Price = newValues.Price;
            dbEntity.About = newValues.About;
            dbEntity.PublisherId = newValues.PublisherId;
            dbEntity.MinimumHardware = newValues.MinimumHardware;
            dbEntity.Categories = newValues.Categories;
            dbEntity.Developers = newValues.Developers;
            dbEntity.ReleaseDate = newValues.ReleaseDate;
            dbEntity.ImageUrl = newValues.ImageUrl;
        }

    }
}
