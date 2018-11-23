using System.Collections.Generic;
using Newtonsoft.Json;
using TournMan.Models;

namespace TournMan.Models {
    public class Team {
        public Team () { }
        public Team (string name, string coach, string captain) {
            this.Name = name;
            this.Coach = coach;
            this.Captain = captain;
        }

        [JsonProperty ("id")]
        public int Id { get; set; }

        [JsonProperty ("coach")]
        public string Coach { get; set; }

        [JsonProperty ("captain")]
        public string Captain { get; set; }

        [JsonProperty ("name")]
        public string Name { get; internal set; }
    }
}