using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;
using TournMan.Interfaces;

namespace TournMan.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        List<Tournament> tournaments;
        private string connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";

        public TournamentRepository()
        {
        }

        public List<Tournament> FindAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var Sql = "SELECT * FROM Tournament.dbo.Tournament";
                tournaments = connection.Query<Tournament>(Sql).ToList();
            }
            return tournaments;
        }

        public List<Tournament> FindByDate(DateTime startDate)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = $"select * from tournament where startdate = '{startDate}'";
                return connection.Query<Tournament>(sql).ToList();
            }
        }

        public List<Tournament> FindById(int tournamentId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM Tournament.dbo.Tournament where id = '{tournamentId}'";
                tournaments = connection.Query<Tournament>(sql).ToList();
            }
            return tournaments;
        }

        public List<Tournament> FindByLocation(string location)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM Tournament.dbo.Tournament where location = '{location}'";
                tournaments = connection.Query<Tournament>(sql).ToList();
            }
            return tournaments;
        }

        public List<Tournament> FindByName(string name)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM Tournament.dbo.Tournament where name = '{name}'";
                tournaments = connection.Query<Tournament>(sql).ToList();
            }
            return tournaments;
        }

        public int Save(Tournament tournament)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "Insert into Tournament values (@Name, @Location,@StartDate)";
                return connection.Execute(sql, tournament);
            }
        }
    }
}