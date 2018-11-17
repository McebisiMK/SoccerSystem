using System;
using System.Collections.Generic;
using System.Linq;
using TournMan.Models;

namespace TournMan.Repositories {
    public class TournamentListRepository : ITournamentRepository {
        private static List<Tournament> tournaments= new List<Tournament> () {
                new Tournament(1,"Ingqula Entertianment",DateTime.Now.AddMonths(-2),"Mqanduli"),
                new Tournament(2,"OR Thambo",DateTime.Now.AddMonths(3),"Ngqwabeni"),
                new Tournament(3,"Imbizana",DateTime.Now.AddMonths(1),"Bisi"),
                new Tournament(4,"Xy z",DateTime.Now.AddMonths(-5),"EmaDikazini")
             };

        public TournamentListRepository () {
         }
        public List<Tournament> FindAll () {
            return tournaments;
        }

        public List<Tournament> FindByDate (DateTime startDate) {
            return tournaments.Where (a => a.StartDate == startDate).ToList ();
        }

        public List<Tournament> FindById(int tournamentId)
        {
            return tournaments.Where (a => a.Id == tournamentId).ToList ();
        }

        public List<Tournament> FindByLocation (string location) {
            return tournaments.Where (a => a.Location == location).ToList ();
        }

        public List<Tournament> FindByName (string name) {
            return tournaments.Where (a => a.Name == name).ToList ();
        }

        public int Save (Tournament tournament) {
             Console.WriteLine("Saved "+tournament.Name);
            tournaments.Add (tournament);
            return 1;
        }
    }
}