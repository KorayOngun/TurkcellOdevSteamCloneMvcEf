using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.IRepos;
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
            var item = _context.Games.Where(x => x.Id == id).Include(g => g.Publisher)
                                                            .Include(g => g.Review)
                                                            .Include(g => g.Categories)
                                                            .ThenInclude(c => c.Category)
                                                            .FirstOrDefault();
            return item;
        }
        public async override Task<Game> GetByIdAsync(int id)
        {
            var item = await _context.Games.Where(x => x.Id == id).Include(g => g.Publisher)
                                                                  .Include(g => g.Review)
                                                                  .Include(g => g.Categories)
                                                                  .ThenInclude(c => c.Category)
                                                                  .FirstOrDefaultAsync();
            return item;
        }
        public override async Task CreateAsync(Game entity)
        {
            await _context.AddAsync(entity);
            foreach (var item in entity.Categories)
            {
                item.GameId = item.GameId;
            }
            await _context.SaveChangesAsync();  
        }
        public override async Task UpdateAsync(Game entity)
        {
            var item = await ClearEntity(entity);
            await _context.SaveChangesAsync(); 
        }
        private async Task<Game> ClearEntity(Game entity)
        {
            var item = await GetByIdAsync(entity.Id);
            foreach (var cat in item.Categories)
            {
                item.Categories.Remove(cat);
            }
            item.Categories = entity.Categories;
            item.Developers = entity.Developers;
            return item;
        }
    }
}
