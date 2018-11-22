using System;
using System.Collections.Generic;
using TournMan.Models;
using TournMan.Repositories;

namespace TournMan.Services
{
    public class RegistrationService: IRegistrationService
    {
        private IRegistrationRepository registrationRepository;

        public RegistrationService(IRegistrationRepository registrationRepository)
        {
            this.registrationRepository = registrationRepository;
        }

        public List<Registration> FindAll()
        {
            return registrationRepository.FindAll();
        }

        public int Register(Registration registeredTeams)
        {
            if (IsValid(registeredTeams))
            {
                return registrationRepository.Register(registeredTeams);
            }
            return 0;
        }

        private bool IsValid(Registration registeringTeams)
        {
            return !(registeringTeams.Amount < 0);
        }
    }
}