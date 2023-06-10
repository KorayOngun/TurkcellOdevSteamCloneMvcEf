using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Repositories
{
    public class PublisherRepo : EfRepository<Publisher>, IPublisherRepo
    {
        private readonly SteamCloneContext _context;
        public PublisherRepo(SteamCloneContext context):base(context) 
        {
                _context = context;
        }

        public override bool IsExistAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
