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
            var item = _context.Games.Where(x => x.Id == id).Include(g => g.Publisher)
                                                            .Include(g => g.Review)
                                                            .ThenInclude(r=>r.User)
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
            var item = await _context.Games.Where(x => x.Id == id).Include(g => g.Publisher)
                                                                  .Include(g => g.Review)
                                                                  .ThenInclude(r=>r.User)
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
        public override async Task UpdateAsync(Game entity)
        {
            var item = await GetItemForUpdateAsync(entity.Id);
            if (item != default)
            {
                BindValues(item, entity);   
            }
            await _context.SaveChangesAsync();
        }
        public override void Update(Game entity)
        {
            var item =  GetItemForUpdate(entity.Id);
            if (item != default)
            {
                BindValues(item,entity);
            }
             _context.SaveChanges();
        }
        private Game BindValues(Game dbEntity,Game newValues)
        {
            dbEntity.RecommendedHardware = newValues.RecommendedHardware;
            dbEntity.Price = newValues.Price;
            dbEntity.About = newValues.About;
            dbEntity.PublisherId = newValues.PublisherId;
            dbEntity.MinimumHardware = newValues.MinimumHardware;
            dbEntity.Categories = newValues.Categories;
            dbEntity.Developers = newValues.Developers;
            dbEntity.ReleaseDate = newValues.ReleaseDate;
            dbEntity.ImageUrl = newValues.ImageUrl;
            return dbEntity;
        }
        private async Task<Game?> GetItemForUpdateAsync(int id)
        {
            return await _context.Games.Where(x => x.Id == id)
                                       .Include(g => g.Publisher)
                                       .Include(g => g.Categories)
                                       .ThenInclude(c => c.Category)
                                       .Include(g => g.Developers)
                                       .ThenInclude(d => d.Developer)
                                       .FirstOrDefaultAsync();
        }
        private  Game? GetItemForUpdate(int id)
        {
            return  _context.Games.Where(x => x.Id == id)
                                       .Include(g => g.Publisher)
                                       .Include(g => g.Categories)
                                       .ThenInclude(c => c.Category)
                                       .Include(g => g.Developers)
                                       .ThenInclude(d => d.Developer)
                                       .FirstOrDefault();
        }
    }
}
