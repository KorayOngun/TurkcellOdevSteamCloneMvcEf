using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories.EfRepo
{
    public class CategoryRepo : EfRepository<Category>, ICategoryRepo
    {
        private readonly SteamCloneContext _context;
        public CategoryRepo(SteamCloneContext context):base(context) 
        {
            _context = context;
        }

        public async Task<bool> IsExistAsync(int id)
        {
            if (await _context.Categories.FindAsync(id) != default)
            {
                return true;
            }
            return false;
        }
    }
}
