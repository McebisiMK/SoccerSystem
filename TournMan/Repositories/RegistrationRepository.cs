using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using TournMan.Models;

namespace TournMan.Repositories
{
        public class RegistrationRepository : IRegistrationRepository
    {
        List<Registration> registeredTeams;
        private string connectionString = "Data Source=LAPTOP-MCEBISI\\SQLEXPRESS01;Integrated Security=True;Initial Catalog=Tournament";
        public RegistrationRepository() { }

        public List<Registration> FindAll()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "Select * from Tournament.dbo.TournamentRegistration";
                registeredTeams = connection.Query<Registration>(sql).ToList();
            }
            return registeredTeams;
        }

        public int Register(Registration registration)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var sql = "Insert into TournamentRegistration values (@TournamentId, @TeamId, @Amount)";
                return connection.Execute(sql, registration);
            }
        }
    }
}