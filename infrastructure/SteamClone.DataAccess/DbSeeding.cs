using SteamClone.DataAccess.Data;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess
{
    public static class DbSeeding
    {
        public static void Seed(SteamCloneContext context)
        {
            seedPublisherIfNoExist(context);

        }

        private static void seedPublisherIfNoExist(SteamCloneContext context)
        {
            if (!context.Publishers.Any())
            {
                Publisher publisher = new()
                {
                    Name = "Rockstar Games"
                };
                context.Publishers.Add(publisher);
                context.SaveChanges();
            }            
        }
    }
}
