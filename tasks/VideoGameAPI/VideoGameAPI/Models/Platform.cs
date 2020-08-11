using System;
using System.Collections.Generic;
using System.Text;

namespace VideoGameAPI.Models
{
    class Platform
    {
        public Platform()
        {
            Games = new HashSet<Game>();
        }
        public int PlatformId { get; set; }
        public string PlatformName { get; set; }

        public ICollection<Game> Games { get; set; }
    }
}
