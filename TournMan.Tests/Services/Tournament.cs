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

        public Tournament(string v1, DateTime dateTime, string v2)
        {
            this.v1 = v1;
            this.dateTime = dateTime;
            this.v2 = v2;
        }

        public string Name { get; internal set; }
        public string Location { get; internal set; }
        public DateTime StartDate { get; internal set; }
    }
}