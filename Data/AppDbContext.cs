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

            base.OnModelCreating(builder);
        }
    }
}