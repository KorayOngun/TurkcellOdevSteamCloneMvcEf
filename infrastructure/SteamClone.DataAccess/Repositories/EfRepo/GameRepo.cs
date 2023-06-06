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
    }
}
