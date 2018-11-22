using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;

namespace TournMan.Controllers {
    [Route ("api/[controller]")]
    public class RegistrationController : Controller {
        private IRegistrationService registrationService;
        public RegistrationController(IRegistrationService registrationService)
        {
            this.registrationService = registrationService;
        }

        [HttpGet]
        public IEnumerable<RegisteredTeams> Get () {
            return registrationService.FindAll ();
        }

        [HttpPost]
        public int Post ([FromBody] RegisteredTeams registeredTeams) {
            return registrationService.Register (registeredTeams);
        }
    }
}