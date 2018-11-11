using System;
using Newtonsoft.Json;

namespace TournMan.Models
{
    public class Tournament
    {
        public Tournament() { }
        public Tournament(string name, DateTime startDate, string location)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Location = location;
        }

        [JsonProperty("name")]
        public string Name { get; internal set; }
        
        [JsonProperty("location")]
        public string Location { get; internal set; }

        [JsonProperty("startDate")]
        public DateTime StartDate { get; internal set; }
    }
}