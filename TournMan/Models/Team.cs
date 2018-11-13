using System.Collections.Generic;
using Newtonsoft.Json;
using TournMan.Models;

namespace TournMan.Models
{
    public class Team
    {
        public Team() { }
        public Team(string name, string coach, string captain)
        {
            this.Coach = coach;
            this.Captain = captain;
            this.Name = name;
        }
        [JsonProperty("coach")]
        public string Coach { get; set; }

        [JsonProperty("captain")]
        public string Captain { get; set; }

        [JsonProperty("name")]
        public string Name { get; internal set; }
    }
}