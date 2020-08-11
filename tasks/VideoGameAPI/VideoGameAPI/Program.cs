using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoGameAPI.Models;

namespace VideoGameAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Game> games = new List<Game>();
            List<Platform> platforms = new List<Platform>();

           using (var db = new MyDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                games = db.Games.Include("Platform").ToList();
                games.ForEach(game => Console.WriteLine($"{game.GameId}: {game.GameName} was released on {game.ReleaseDate} by {game.Publisher} for {game.Platform.PlatformName}"));
            }
        }
    }
}
