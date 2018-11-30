using System.Collections.Generic;
using TournMan.Models;

namespace TournMan.Interfaces {
    public interface IRegistrationService {
        int Register (Registration registeredTeams);
        List<Registration> FindAll ();
        IEnumerable<RegisteredTeam> RegisteredTeam(string tournamentId);
    }
}