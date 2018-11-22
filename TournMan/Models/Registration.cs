using System;
using Newtonsoft.Json;

namespace TournMan.Models
{
    public class Registration
    {
        public Registration() { }
        public Registration(int tournamentId, int teamId, double amount)
        {
            this.TournamentId = tournamentId;
            this.TeamId = teamId;
            this.Amount = amount;
        }

        [JsonProperty("tournamentId")]
        public int TournamentId { get; set; }
        [JsonProperty("teamId")]
        public int TeamId { get; set; }
        [JsonProperty("amount")]
        public double Amount { get; set; }
    }
}