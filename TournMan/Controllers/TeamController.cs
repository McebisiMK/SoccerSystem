using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;

namespace TournMan.Controllers {
    [Route ("api/[controller]")]
    public class TeamController : Controller {
        private ITeamService teamService;

        public TeamController (ITeamService teamService) {
            this.teamService = teamService;
        }

        [HttpGet]
        public List<Team> FindAll () {
            return teamService.FindAll ();
        }

        [HttpPost]
        public int Post ([FromBody] Team team) {
            return teamService.Save (team);
        }

        [HttpGet ("find/by/name/{name}")]
        public IEnumerable<Team> FindByName (string name) {
            return teamService.FindByName (name);
        }

        [HttpPost ("find/by/coach")]
        public IEnumerable<Team> FindByCoach ([FromBody] string coach) {
            return teamService.FindByCoach (coach);
        }
    }
}