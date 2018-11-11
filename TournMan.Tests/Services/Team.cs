using System.Collections.Generic;
using TournMan.Models;

namespace TournMan.Models
{
    public class Team
    {
        public string Coach { get; set; }
        public string Captain { get; set; }
        public List<Player> Players { get; set; }
        public string Name { get; internal set; }
    }
}