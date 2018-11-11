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
            List<Tournament> tournaments;
            var connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                tournaments = connection.Query<Tournament>($"SELECT * FROM Tournament.dbo.Tournament where location = '{location}'").ToList();
            }
            return tournaments;
        }

        public List<Tournament> FindByName(string name)
        {
            List<Tournament> tournaments;
            var connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                tournaments = connection.Query<Tournament>($"SELECT * FROM Tournament.dbo.Tournament where name = '{name}'").ToList();
            }
            return tournaments;
        }

        public int Save(Tournament tournament)
        {
            string sql = "Insert into Tournament values (@Name, @Location,@StartDate);";
            var connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine(sql);
                return connection.Execute(sql, tournament);
            }
        }
    }
}
