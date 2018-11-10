using System;

namespace TournMan.Tests
{
    public class Tournament
    {
        public Tournament()
        {
        }

        public string Name { get; internal set; }
        public string Location { get; internal set; }
        public DateTime StartDate { get; internal set; }
    }
}