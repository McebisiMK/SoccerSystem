using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Interfaces;

namespace TournMan.Controllers {
    [Route ("api/[controller]")]
    public class TournamentController : Controller {
        private ITournamentService Tournamentservice;

        public TournamentController (ITournamentService Tournamentservice) {
            this.Tournamentservice = Tournamentservice;
        }

        [HttpGet]
        public IEnumerable<Tournament> FindAll () {
            return Tournamentservice.FindAll ();
        }

        [HttpGet ("find/by/name/{name}")]
        public IEnumerable<Tournament> FindByName (string name) {
            return Tournamentservice.FindByName (name);
        }

        [HttpGet ("find/by/id/{id}")]
        public IEnumerable<Tournament> FindById (int id) {
            return Tournamentservice.FindById (id);
        }

        [HttpPost ("find/by/location")]
        public IEnumerable<Tournament> FindByLocation ([FromBody] string location) {
            return Tournamentservice.FindByLocation (location);
        }

        [HttpGet ("{year}/{month}/{day}")]
        public IEnumerable<Tournament> FindByDate (int year, int month, int day) {
            var date = new DateTime (year, month, day);
            return Tournamentservice.FindByDate (date);
        }

        [HttpPost]
        public void Save ([FromBody] Tournament tournament) {
            Tournamentservice.Save (tournament);
        }

        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}