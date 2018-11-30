using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;
using TournMan.Interfaces;

namespace TournMan.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        List<Team> team;
        private string connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";
        public TeamRepository() { }
        public int Save(Team team)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "Insert into Team values (@Name, @Coach,@Captain);";
                return connection.Execute(sql, team);
            }
        }

        public List<Team> FindByName(string name)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM Tournament.dbo.Team where name = '{name}'";
                team = connection.Query<Team>(sql).ToList();
            }
            return team;
        }

        public List<Team> FindByCoach(string coach)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = $"Select * from Tournament.dbo.Team where coach = '{coach}'";
                team = connection.Query<Team>(sql).ToList();
            }
            return team;
        }

        public List<Team> FindAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "SELECT * FROM Tournament.dbo.Team";
                team = connection.Query<Team>(sql).ToList();
            }
            return team;
        }
    }
}