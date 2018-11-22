using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;


namespace TournMan.Controllers
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private IRegistrationRepository registrationRepository;

         [HttpGet]
        public IEnumerable<RegisteredTeams> Get()
        {
            var registrationService = new RegistrationService(new RegistrationRepository());
            return registrationService.FindAll();
        }

        [HttpPost]
        public int Post([FromBody] RegisteredTeams registeredTeams)
        {
            var service = new RegistrationService(new RegistrationRepository());
            return service.Register(registeredTeams);
        }
    }
}