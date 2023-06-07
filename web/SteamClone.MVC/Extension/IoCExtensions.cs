using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Services;

namespace SteamClone.MVC.Extension
{
    public static class IoCExtensions
    {   
        public static IServiceCollection AddInjections(this IServiceCollection services, string connectionString) 
        {
            services.AddScoped<IGameRepo, GameRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IPublisherRepo, PublisherRepo>();
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            //IoC
            services.AddDbContext<SteamCloneContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
    }
}
