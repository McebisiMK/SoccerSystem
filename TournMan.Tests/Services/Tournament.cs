using System;

namespace TournMan.Tests.Services
{
    public class Tournament
    {
        private string v1;
        private DateTime dateTime;
        private string v2;

        public Tournament()
        {
        }

        public Tournament(string name, DateTime startDate, string location)
        {
            this.Name = name;
            this.StartDate = startDate;
            this.Location = location;
        }

        public string Name { get; internal set; }
        public string Location { get; internal set; }
        public DateTime StartDate { get; internal set; }
    }
}