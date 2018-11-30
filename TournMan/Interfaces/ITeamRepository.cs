using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;

namespace TournMan.Interfaces
{
    public interface ITeamRepository
    {
        int Save(Team team);
        List<Team> FindByName(string name);
        List<Team> FindByCoach(string coach);
        List<Team> FindAll();
    }
}