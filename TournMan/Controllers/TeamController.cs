using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;

namespace TournMan.Controllers
{
    [Route("api/[controller]")]
    public class TeamController : Controller
    {
        private ITeamRepository teamRepository;
 
        [HttpGet]
        public List<Team> FindAll()
        {
            var teamService = new TeamService(new TeamRepository());
            return teamService.FindAll();
        }

        [HttpPost]
        public int Post([FromBody] Team team)
        {

            var teamService = new TeamService(new TeamRepository());
            return teamService.Save(team);
        }

        [HttpGet("find/by/name/{name}")]
        public IEnumerable<Team> FindByName(string name)
        {
            var teamService = new TeamService(new TeamRepository());
            return teamService.FindByName(name);
        }

        [HttpPost("find/by/coach")]
        public IEnumerable<Team> FindByCoach([FromBody] string coach)
        {
            var teamService = new TeamService(new TeamRepository());
            return teamService.FindByCoach(coach);
        }
    }
}