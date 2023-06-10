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
            seedCategoriesIfNoExist(context);
            seedUsersIfNoExist(context);
            seedDevelopersIfNoExist(context) ;
        }

        private static void seedPublisherIfNoExist(SteamCloneContext context)
        {
            if (!context.Publishers.Any())
            {
                List<Publisher> publishers = new List<Publisher>
                {
                    new(){Name="Rockstar Games"},
                    new(){Name="Electronic Arts"},
                    new(){Name="Ubisoft"},
                    new(){Name="Sony Interecative Entertainment"},
                };
                context.Publishers.AddRange(publishers);
                context.SaveChanges();
            }            
        }
        private static void seedCategoriesIfNoExist(SteamCloneContext context)
        {
            if (!context.Categories.Any())
            {
                List<Category> categories = new List<Category>
                {
                   new(){Name="single player"},
                   new(){Name="multi player"},
                   new(){Name="co-op"}
                };
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }
        }
        private static void seedUsersIfNoExist(SteamCloneContext context)
        {
            if (!context.User.Any())
            {
                List<User> users = new List<User>
                {
                  new(){UserMail="koray@mail",UserName="koray",UserPassword="1234",Role="Admin"},
                  new(){UserMail="ahmet@mail",UserName="ahmet",UserPassword="1234"},
                };
                context.User.AddRange(users);
                context.SaveChanges();
            }
        }
        private static void seedDevelopersIfNoExist(SteamCloneContext context)
        {
            if (!context.Developer.Any())
            {
                List<Developer> developers = new List<Developer>
                {
                    new(){Name="Rockstar Games"},
                    new(){Name="Electronic Arts"},
                    new(){Name="Ubisoft"},
                    new(){Name="Sony Interecative Entertainment"},
                };
                context.Developer.AddRange(developers);
                context.SaveChanges();
            }
        }
        
    }
}
