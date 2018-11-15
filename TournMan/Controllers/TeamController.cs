using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;

namespace TournMan.Controllers {
    [Route ("api/[controller]")]
    public class TeamController : Controller {
        private ITeamRepository teamRepository;

        [HttpGet]
        public List<Team> FindAll() {
            var teamService = new TeamService (new TeamListRepository ());
            return teamService.FindAll ();
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] Team team) {
            
            var teamService = new TeamService (new TeamListRepository ());
            teamService.Save (team);
        }

        [HttpPost ("find/by/name")]
        public IEnumerable<Team> FindByName ([FromBody] string name) {
            var teamService = new TeamService (new TeamListRepository ());
            return teamService.FindByName (name);
        }

        [HttpPost ("find/by/coach")]
        public IEnumerable<Team> FindByCoach ([FromBody] string coach) {
            var teamService = new TeamService (new TeamListRepository ());
            return teamService.FindByCoach (coach);
        }
    }
}