using System.Collections.Generic;
using TournMan.Models;

namespace TournMan.Interfaces
{
    public interface ITeamService
    {
        int Save(Team team);
        List<Team> FindByName( string name);
        List<Team> FindByCoach(string coach);
        List<Team> FindAll();
    }
}