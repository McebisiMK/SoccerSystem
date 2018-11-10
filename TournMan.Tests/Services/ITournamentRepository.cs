using System.Collections.Generic;

namespace TournMan.Tests.Services
{
    public interface ITournamentRepository
    {
        void Save(Tournament tournament);
        List<Tournament> FindAll();
        List<Tournament> FindByName(string name);
        List<Tournament> FindByLocation(string location);
    }
}