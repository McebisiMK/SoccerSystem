using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TournMan.Models;

namespace TournMan.Repositories {
    public class TournamentPgRepository : ITournamentRepository {

        private PgContext dbContext;

        public TournamentPgRepository () {
            this.dbContext = new PgContext ();
        }
        public List<Tournament> FindAll () {
            return this.dbContext.Tournament.ToList ();
        }

        public List<Tournament> FindByDate (DateTime startDate) {
            return this.dbContext.Tournament.Where (a => a.StartDate == startDate).ToList ();
        }

        public List<Tournament> FindById (int tournamentId) {
            return this.dbContext.Tournament.Where (a => a.Id == tournamentId).ToList ();
        }

        public List<Tournament> FindByLocation (string location) {
            return this.dbContext.Tournament.Where (a => a.Location == location).ToList ();
        }

        public List<Tournament> FindByName (string name) {
            return this.dbContext.Tournament.Where (a => a.Name == name).ToList ();
        }

        public int Save (Tournament tournament) {
            this.dbContext.Tournament.Add (tournament);
            return 1;
        }
    }
}