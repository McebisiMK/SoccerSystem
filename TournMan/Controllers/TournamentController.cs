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
    public class TournamentController : Controller {
        private ITournamentService service;

        public TournamentController (ITournamentService service) {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Tournament> Get () {
            return this.service.FindAll ();
        }

        [HttpGet ("find/by/name/{name}")]
        public IEnumerable<Tournament> FindByName (string name) {
            return this.service.FindByName (name);
        }

        [HttpGet ("find/by/id/{id}")]
        public IEnumerable<Tournament> FindById (int id) {
            return this.service.FindById (id);
        }

        [HttpPost ("find/by/location")]
        public IEnumerable<Tournament> FindByLocation ([FromBody] string location) {
            return this.service.FindByLocation (location);
        }

        [HttpGet ("{year}/{month}/{day}")]
        public List<Tournament> Get (int year, int month, int day) {
            var date = new DateTime (year, month, day);
            return this.service.FindByDate (date);
        }

        [HttpPost]
        public void Post ([FromBody] Tournament tournament) {
            this.service.Save (tournament);
        }

        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}