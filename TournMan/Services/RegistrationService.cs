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

        public int Register(Registration registration)
        {
            if (IsValid(registration))
            {
                return registrationRepository.Register(registration);
            }
            return 0;
        }

        private bool IsValid(Registration registeringTeams)
        {
            return !(registeringTeams.Amount < 0);
        }
    }
}