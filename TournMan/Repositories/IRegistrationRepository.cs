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
}