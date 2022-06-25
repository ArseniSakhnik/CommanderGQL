using System.Collections.Generic;
using CommanderGQL.Models;
using Microsoft.EntityFrameworkCore;

namespace CommanderGQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Platform>().HasData(new List<Platform>
            {
                new()
                {
                    Id = 1,
                    Name = ".NET 5",
                    LicenseKey = "1234"
                },
                new()
                {
                    Id = 2,
                    Name = "Docker",
                    LicenseKey = null
                },
                new()
                {
                    Id = 3,
                    Name = "Windows",
                    LicenseKey = "42342"
                },
            });

            builder.Entity<Command>().HasData(new List<Command>
            {
                new()
                {
                    Id = 1,
                    HowTo = "Build a project",
                    CommandLine = "dotnet build",
                    PlatformId = 1
                },
                new()
                {
                    Id = 2,
                    HowTo = "Run a project",
                    CommandLine = "dotnet run",
                    PlatformId = 2
                },
                new()
                {
                    Id = 3,
                    HowTo = "Start a docker compose file",
                    CommandLine = "docker compose up -d",
                    PlatformId = 2
                },
                new()
                {
                    Id = 4,
                    HowTo = "Stop docker compose file",
                    CommandLine = "docker-compose stop",
                    PlatformId = 2,
                }
            });

            base.OnModelCreating(builder);
        }
    }
}