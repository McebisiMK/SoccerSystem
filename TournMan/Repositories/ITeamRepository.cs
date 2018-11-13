using System;
using System.Data.SqlClient;
using Dapper;
using TournMan.Models;

namespace TournMan.Repositories
{
    public interface ITeamRepository
    {
        int Save(Team team);
    }

    public class TeamRepository : ITeamRepository
    {
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
    }
}