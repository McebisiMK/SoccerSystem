using System.Collections.Generic;
using TournMan.Models;

namespace TournMan.Services {
    public interface IRegistrationService {
        int Register (RegisteredTeams registeredTeams);
        List<RegisteredTeams> FindAll ();

    }
}