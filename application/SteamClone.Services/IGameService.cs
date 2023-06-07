using SteamClone.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SteamClone.Entities.Entities;
using SteamClone.Dto.Request;

namespace SteamClone.Services
{
    public interface IGameService 
    {
        GameDetailsResponse GetGameById(int id);
        Task<GameCreateUpdateRequest> GetGameByIdForUpdateAsync(int id);
        void Update(GameCreateUpdateRequest game);
        Task<bool> CreateGameAsync(GameCreateUpdateRequest game);
        Task UpdateAsync(GameCreateUpdateRequest game);
        IEnumerable<GameDisplayResponse> GetAll();
        
        Task<GameDetailsResponse> GetGameByIdAsync(int id);
       
        Task<IEnumerable<GameDisplayResponse>> GetAllAsync();
        Task<IEnumerable<GameDisplayResponse>> GetByCategoryAsync(int catId);

    }
}
