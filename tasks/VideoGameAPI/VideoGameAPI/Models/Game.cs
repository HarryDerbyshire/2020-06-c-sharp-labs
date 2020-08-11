using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameAPI.Models
{
    class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int? PlatformId { get; set; }
        public virtual Platform Platform { get; set; }
    }
}
