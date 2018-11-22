using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;

namespace TournMan.Repositories
{
    public interface IRegistrationRepository
    {
        int Register(RegisteredTeams registeredTeams);
        List<RegisteredTeams> FindAll();
    }

    public class RegistrationRepository : IRegistrationRepository
    {
        List<RegisteredTeams> registeredTeams;
        private string connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";
        public RegistrationRepository() { }

        public List<RegisteredTeams> FindAll()
        {
           //var sql = "Select * from Tournament.dbo.RegisteredTeams";
            using (var connection = new SqlConnection(connectionString))
            {
                registeredTeams = connection.Query<RegisteredTeams>("Select * from Tournament.dbo.RegisteredTeams").ToList();
            }
            return registeredTeams;
        }

        public int Register(RegisteredTeams registeredTeams)
        {
            string sql = "Insert into RegisteredTeams values (@TeamId, @Name, @Coach, @RegisteredDate, @Amount)";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Execute(sql, registeredTeams);
            }
        }
    }
}