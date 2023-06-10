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
       
        Task<GameRequest> GetGameByIdForUpdateAsync(int id);
        void Update(GameRequest game);
        Task<int> CreateGameAsync(GameRequest game);
        Task UpdateAsync(GameRequest game);
        IEnumerable<GameDisplayResponse> GetAll();
        
        Task<GameDetailsResponse> GetGameByIdAsync(int id);
       
        Task<IEnumerable<GameDisplayResponse>> GetAllAsync();
        
        Task DeleteGameAsync(int id);
        Task AddCommentAsync(GameCommentRequest comment);

    }
}
