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
            var service = new TournamentService(new TournamentListRepository());
            return service.FindAll();
        }


        // GET api/values/5
        [HttpGet("find/by/name/{name}")]
        public IEnumerable<Tournament> FindByName(string name)
        {

            Console.WriteLine(name +" Is the name");
            var service = new TournamentService(new TournamentListRepository());
            return service.FindByName(name);
        }

        [HttpPost("find/by/location")]
        public IEnumerable<Tournament> FindByLocation([FromBody]string location)
        {
            var service = new TournamentService(new TournamentListRepository());
            return service.FindByLocation(location);
        }

        [HttpGet("{year}/{month}/{day}")]
        public List<Tournament> Get(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);
            var service = new TournamentService(new TournamentListRepository());
            return service.FindByDate(date);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Tournament tournament)
        {
             Console.WriteLine("Saving... \n");
             Console.WriteLine("Saving..."+tournament.Name);
            var service = new TournamentService(new TournamentListRepository());
            service.Save(tournament);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
