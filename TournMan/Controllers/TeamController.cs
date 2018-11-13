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

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Team team)
        {
            var teamService = new TeamService(new TeamRepository());
            teamService.Save(team);
        }
    }
}
