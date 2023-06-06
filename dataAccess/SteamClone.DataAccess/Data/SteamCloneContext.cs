using Microsoft.EntityFrameworkCore;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.DataAccess.Data
{
    public class SteamCloneContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameReview> GameReview { get; set; }
        public DbSet<GameCategory> GameCategory { get; set; }
         
        public SteamCloneContext(DbContextOptions options) : base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //----Game
            modelBuilder.Entity<Game>().HasOne(g=>g.Publisher).WithMany(p=>p.Games).HasForeignKey(p=>p.PublisherId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Game>().HasMany(g => g.Developers).WithOne(gd=>gd.Game).HasForeignKey(p=>p.DeveloperId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Game>().HasMany(g=>g.Categories).WithOne(c=>c.Game).HasForeignKey(p=>p.GameId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Game>().HasMany(g => g.Review).WithOne(gr => gr.Game).HasForeignKey(p => p.GameId).OnDelete(DeleteBehavior.Cascade);
            
            //----

            //----User
            modelBuilder.Entity<User>().HasKey("Id");
            modelBuilder.Entity<User>().HasIndex(u=>u.UserMail).IsUnique(true);
            modelBuilder.Entity<User>().HasMany(g => g.Reviews).WithOne(gr => gr.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("Member");
            //----

            modelBuilder.Entity<Developer>().HasMany(d=>d.Games).WithOne(g=>g.Developer).HasForeignKey(p=>p.DeveloperId).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>().HasMany(d=>d.Games).WithOne(g=>g.Category).HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.NoAction);
           
            modelBuilder.Entity<GameDeveloper>().HasKey("DeveloperId", "GameId");

            modelBuilder.Entity<GameCategory>().HasKey("CategoryId", "GameId");

            modelBuilder.Entity<GameReview>().HasKey("UserId", "GameId");
        }
    }
}
