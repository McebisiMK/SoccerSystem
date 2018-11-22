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
        int Register(Registration registeredTeams);
        List<Registration> FindAll();
    }

    public class RegistrationRepository : IRegistrationRepository
    {
        List<Registration> registeredTeams;
        private string connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";
        public RegistrationRepository() { }

        public List<Registration> FindAll()
        {
           //var sql = "Select * from Tournament.dbo.RegisteredTeams";
            using (var connection = new SqlConnection(connectionString))
            {
                registeredTeams = connection.Query<Registration>("Select * from Tournament.dbo.TournamentRegistration").ToList();
            }
            return registeredTeams;
        }

        public int Register(Registration registration)
        {
            string sql = "Insert into TournamentRegistration values (@TournamentId, @TeamId, @Amount)";
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Execute(sql, registration);
            }
        }
    }
}