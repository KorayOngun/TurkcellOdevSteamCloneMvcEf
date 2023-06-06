using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public interface IGameService 
    {
        Game GetById(int id);
        void Update (Game game);
        IEnumerable<GameDisplayResponse> GetAll();
        IEnumerable<GameDisplayResponse> GetByCategory(int catId);

    }
}
