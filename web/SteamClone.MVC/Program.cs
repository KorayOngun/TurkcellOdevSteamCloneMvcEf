using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SteamClone.DataAccess;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.DataAccess.Repositories.EfRepo;
using SteamClone.Services;
using SteamClone.Services.Mapper;
using SteamClone.DataAccess.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using SteamClone.MVC.Extension;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var connectionString = builder.Configuration.GetConnectionString("SqlCon");
builder.Services.AddInjections(connectionString);
builder.Services.InitConfig();

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
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
