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
        void Save(Tournament tournament);
        List<Tournament> FindAll();
        List<Tournament> FindByName(string name);
        List<Tournament> FindByLocation(string location);
        List<Tournament> FindByDate(DateTime startDate);
    }

    public class TournamentRepository : ITournamentRepository
    {

        public TournamentRepository()
        {
        }

        public List<Tournament> FindAll()
        {
            List<Tournament> tournaments;
            var connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                tournaments = connection.Query<Tournament>("SELECT * FROM Tournament.dbo.Tournament").ToList();
            }
            return tournaments;
        }

        public List<Tournament> FindByDate(DateTime startDate)
        {
            throw new NotImplementedException();
        }

        public List<Tournament> FindByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public List<Tournament> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Tournament tournament)
        {
            throw new NotImplementedException();
        }
    }
}