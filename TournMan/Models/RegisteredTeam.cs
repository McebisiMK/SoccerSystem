using System;
using Newtonsoft.Json;

namespace TournMan.Models
{
    public class RegisteredTeam
    {
        public RegisteredTeam()
        {
        }
        public RegisteredTeam(int id, string coach, string captain, string name, double amount, string tournamentName, string tournamentLocation, DateTime startDate)
        {
            this.Id = id;
            this.Coach = coach;
            this.Captain = captain;
            this.Name = name;
            this.Amount = amount;
            this.TournamentName = tournamentName;
            this.Location = tournamentLocation;
            this.StartDate = startDate;
        }
        [JsonProperty()]
        public int Id { get; set; }

        [JsonProperty()]
        public string Coach { get; set; }

        [JsonProperty()]
        public double Amount { get; set; }
          [JsonProperty()]
        public string Captain { get; set; }
        [JsonProperty()]
        public string Name { get; set; }
        [JsonProperty()]
        public string TournamentName { get; set; }
        [JsonProperty()]
        public string Location { get; set; }
        [JsonProperty()]
        public DateTime StartDate { get; set; }
    }
}