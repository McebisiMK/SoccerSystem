using System.Collections.Generic;
using TournMan.Models;

namespace TournMan.Services {
    public interface IRegistrationService {
        int Register (Registration registeredTeams);
        List<Registration> FindAll ();

    }
}