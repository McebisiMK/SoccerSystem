using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;

namespace TournMan.Repositories
{
    public interface ITeamRepository
    {
        int Save(Team team);
        List<Team> FindByName(string name);
        List<Team> FindByCoach(string coach);
    }

    public class TeamRepository : ITeamRepository
    {
        List<Team> team;
        private string connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";
        public TeamRepository() { }
        public int Save(Team team)
        {
            string sql = "Insert into Team values (@Name, @Coach,@Captain);";
            using (var connection = new SqlConnection(connectionString))
            {
                Console.WriteLine(sql);
                return connection.Execute(sql, team);
            }
        }

        public List<Team> FindByName(string name)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                team = connection.Query<Team>($"SELECT * FROM Tournament.dbo.Team where name = '{name}'").ToList();
            }
            return team;
        }

        public List<Team> FindByCoach(string coach)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                team = connection.Query<Team>($"Select * from Tournament.dbo.Team where coach = '{coach}'").ToList();
            }
            return team;
        }
    }
}