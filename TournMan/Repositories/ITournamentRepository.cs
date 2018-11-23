using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;

namespace TournMan.Repositories
{
    public interface ITournamentRepository
    {
        int Save(Tournament tournament);
        List<Tournament> FindAll();
        List<Tournament> FindByName(string name);
        List<Tournament> FindByLocation(string location);
        List<Tournament> FindByDate(DateTime startDate);
        List<Tournament> FindById(int tournamentId);
    }
}
