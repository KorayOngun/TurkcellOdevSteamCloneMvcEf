using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using SteamClone.DataAccess.Repositories;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Services;
using SteamClone.Services.Mapper;

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
            services.AddScoped<IDeveloperRepo, DeveloperRepo>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDeveloperService, DeveloperService>();
            //IoC
            services.AddDbContext<SteamCloneContext>(opt => opt.UseSqlServer(connectionString));

            return services;
        }
        public static IServiceCollection InitConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(12);
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opt =>
            {
                opt.LoginPath = "/Users/Login";
                opt.AccessDeniedPath = "/Users/AccessDenied";
            });
            services.AddMemoryCache();
            return services;
        }
    }
}
