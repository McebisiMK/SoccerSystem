using System;
using Newtonsoft.Json;

namespace TournMan.Models
{
    public class RegisteredTeams
    {
        public RegisteredTeams() { }
        public RegisteredTeams(int teamId, string name, string coach, DateTime registeredDate, double amount)
        {
            this.TeamId = teamId;
            this.Name = name;
            this.Coach = coach;
            this.RegisteredDate = registeredDate;
            this.Amount = amount;
        }

        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("coach")]
        public string Coach { get; set; }
        [JsonProperty("registeredDate")]
        public DateTime RegisteredDate { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}