using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TournMan.Models;

namespace TournMan.Repositories {
    public class TeamPgRepository : ITeamRepository {

        private PgContext dbContext;

        public TeamPgRepository () {
            this.dbContext = new PgContext ();
        }

        public List<Team> FindAll () {
            return this.dbContext.Team.ToList ();
        }

        public List<Team> FindByCoach (string coach) {
            return this.dbContext.Team.Where (a => a.Coach == coach).ToList ();
        }

        public List<Team> FindByName (string name) {
            return this.dbContext.Team.Where (a => a.Name == name).ToList ();
        }

        public int Save (Team team) {
            this.dbContext.Team.Add (team);
            return this.dbContext.SaveChanges ();
        }
    }
}