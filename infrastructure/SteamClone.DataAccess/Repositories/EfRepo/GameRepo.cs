using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.EfRepo
{
    public class GameRepo : EfRepository<Game>, IGameRepo
    {
        private readonly SteamCloneContext _context;

        public GameRepo(SteamCloneContext context) : base(context)
        {
            _context = context;
        }
        public override Game GetById(int id)
        {
            var item = _context.Games.AsNoTracking().Where(x => x.Id == id).Include(g => g.Publisher)
                                                            .Include(g => g.Review)
                                                            .ThenInclude(r => r.User)
                                                            .Include(g => g.Categories)
                                                            .ThenInclude(c => c.Category)
                                                            .Include(g => g.Developers)
                                                            .ThenInclude(d => d.Developer)
                                                            .FirstOrDefault();
            foreach (var user in item.Review)
            {
                user.User.UserPassword = null;
            }
            return item;
        }


        public async override Task<Game> GetByIdAsync(int id)
        {
            var item = await _context.Games.AsNoTracking().Where(x => x.Id == id).Include(g => g.Publisher)
                                                                  .Include(g => g.Review)
                                                                  .ThenInclude(r => r.User)
                                                                  .Include(g => g.Categories)
                                                                  .ThenInclude(c => c.Category)
                                                                  .Include(g => g.Developers)
                                                                  .ThenInclude(d => d.Developer)
                                                                  .FirstOrDefaultAsync();
            foreach (var user in item.Review)
            {
                user.User.UserPassword = null;
            }
            return item;
        }

        public async Task<Game?> GetItemForUpdateAsync(int id)
        {
            return await _context.Games.Where(x => x.Id == id)
                                       .Include(g => g.Publisher)
                                       .Include(g => g.Categories)
                                       .ThenInclude(c => c.Category)
                                       .Include(g => g.Developers)
                                       .ThenInclude(d => d.Developer)
                                       .FirstOrDefaultAsync();
        }
        public Game? GetItemForUpdate(int id)
        {
            return _context.Games.Where(x => x.Id == id)
                                       .Include(g => g.Publisher)
                                       .Include(g => g.Categories)
                                       .ThenInclude(c => c.Category)
                                       .Include(g => g.Developers)
                                       .ThenInclude(d => d.Developer)
                                       .FirstOrDefault();
        }

        public async Task AddCommentAsync(GameReview comment)
        {
            GameReview gameReview = new GameReview
            {
                GameId = comment.GameId,
                UserId = comment.UserId,
                Review = comment.Review,
            };
            await _context.GameReview.AddAsync(gameReview);
            await _context.SaveChangesAsync();
        }

        public override bool IsExistAsync(int id)
        {
            if (_context.Games.Where(x=>x.Id==id).Count()==1)
            {
                return true;
            }
            return false;
        }
    }
}
