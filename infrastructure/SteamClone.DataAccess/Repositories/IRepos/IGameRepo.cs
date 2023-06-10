using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.IRepos
{
    public interface IGameRepo : IRepo<Game>
    {
        Task AddCommentAsync(GameReview comment);
        Game? GetItemForUpdate(int id);
        Task<Game?> GetItemForUpdateAsync(int id);
    }
}
