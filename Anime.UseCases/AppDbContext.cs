using System.IO;
using DomainModel.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.Configuration;

namespace DomainServices
{
    public class AppDbContext: IdentityDbContext<User>
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        
        
        public DbSet<Anime> Anime { get; set; }
        public DbSet<AnimeRating> AnimeRatings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<FollowedAnime> FollowedAnime { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext> 
    { 
        public AppDbContext CreateDbContext(string[] args) 
        { 
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../WebApplication/DbSettings.json").Build(); 
            var builder = new DbContextOptionsBuilder<AppDbContext>(); 
            var connectionString = configuration.GetConnectionString("DbConnection"); 
            builder.UseNpgsql(connectionString); 
            return new AppDbContext(builder.Options); 
        } 
    }
}