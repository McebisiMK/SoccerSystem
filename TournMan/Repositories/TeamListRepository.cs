using System.Collections.Generic;
using System.Linq;
using TournMan.Models;

namespace TournMan.Repositories {
    public class TeamListRepository : ITeamRepository {
        private static List<Team> teams=  new List<Team> () {
                new Team ("Yizo-Yizo FC", "Malume", "Mbush"),
                new Team ("Top Guys FC", "Onke", "TV"),
                new Team ("Amasela FC", "Mcera", "Mcera"),
                new Team ("Morning Chiefs", "John", "Mqi")
            };

        public TeamListRepository () {
           
        }
        public List<Team> FindAll () {
            return teams;
        }

        public List<Team> FindByCoach (string coach) {
            return FindAll ().Where (a => a.Coach == coach).ToList ();
        }

        public List<Team> FindByName (string name) {
            return teams.Where (a => a.Name == name).ToList ();
        }

        public int Save (Team team) {
            teams.Add(team);
            return 1;
        }
    }
}