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
        void Update (GameUpdateRequest game);
        IEnumerable<GameDisplayResponse> GetAll();
        
        Task<GameDetailsResponse> GetGameByIdAsync(int id);
        Task UpdateAsync(GameUpdateRequest game);
        Task<IEnumerable<GameDisplayResponse>> GetAllAsync();
        Task<IEnumerable<GameDisplayResponse>> GetByCategoryAsync(int catId);

    }
}
