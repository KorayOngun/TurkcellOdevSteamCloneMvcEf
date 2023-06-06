using Microsoft.EntityFrameworkCore;
using SteamClone.DataAccess.Data;
using Microsoft.Extensions.DependencyInjection;
using SteamClone.DataAccess;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.Services;
using SteamClone.Services.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var connectionString = builder.Configuration.GetConnectionString("SqlCon");
builder.Services.AddDbContext<SteamCloneContext>(optionsAction => optionsAction.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped<IGameRepo, GameRepo>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using var scope = app.Services.CreateScope();
var service = scope.ServiceProvider;
var context = service.GetRequiredService<SteamCloneContext>();
context.Database.EnsureCreated();
DbSeeding.Seed(context);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
