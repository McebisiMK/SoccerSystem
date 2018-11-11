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
    public class TournamentController : Controller
    {
        private ITournamentRepository tournamentRepository;
        // GET api/values
        [HttpGet]
        public IEnumerable<Tournament> Get()
        {
            // return new string[] { "value1", "value2" };
            var service = new TournamentService(new TournamentRepository());
            return service.FindAll();
        }


        // GET api/values/5
        [HttpPost("find/by/name")]
        public IEnumerable<Tournament> FindByName([FromBody]string name)
        {
            var service = new TournamentService(new TournamentRepository());
            return service.FindByName(name);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Tournament tournament)
        {
            var service = new TournamentService(new TournamentRepository());
            service.Save(tournament);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
