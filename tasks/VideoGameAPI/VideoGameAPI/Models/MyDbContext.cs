using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameAPI.Models
{
    class MyDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source = VideoGameDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Platform>().HasData(new Platform { PlatformId = 1, PlatformName = "PlayStation 4" });
            builder.Entity<Platform>().HasData(new Platform { PlatformId = 2, PlatformName = "XBox One" });
            builder.Entity<Platform>().HasData(new Platform { PlatformId = 3, PlatformName = "PC" });
            builder.Entity<Platform>().HasData(new Platform { PlatformId = 4, PlatformName = "VR" });
            builder.Entity<Platform>().HasData(new Platform { PlatformId = 5, PlatformName = "Switch" });

            builder.Entity<Game>().HasData(new Game { GameId = 1, GameName = "Marvel's Spiderman", Developer = "Insomniac Games", Publisher = "Sony Interactive Entertainment", ReleaseDate = new DateTime(2017, 09, 07), PlatformId = 1 });
            builder.Entity<Game>().HasData(new Game { GameId = 2, GameName = "Beat Saber", Developer = "Beat Games", Publisher = "Beat Games", ReleaseDate = new DateTime(2019, 05, 21), PlatformId = 4 });
            builder.Entity<Game>().HasData(new Game { GameId = 3, GameName = "Forza Motorsport 7", Developer = "Turn 10 Studios", Publisher = "Microsoft Studios", ReleaseDate = new DateTime(2017, 10, 03), PlatformId = 2 });
            builder.Entity<Game>().HasData(new Game { GameId = 4, GameName = "Counter-Strike: Global Offensive", Developer = "Hidden Path Entertainment", Publisher = "Valve", ReleaseDate = new DateTime(2012, 08, 21), PlatformId = 3 });
            builder.Entity<Game>().HasData(new Game { GameId = 5, GameName = "Animal Crossing: New Horizons", Developer = "Nintendo EPD", Publisher = "Nintendo", ReleaseDate = new DateTime(2020, 03, 20), PlatformId = 5 });

        }
    }
}
