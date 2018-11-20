using Microsoft.EntityFrameworkCore;
using TournMan.Models;

namespace TournMan.Repositories
{
    public class PgContext : DbContext
    {
        public PgContext(DbContextOptions<PgContext> options) : base(options) { }

        DbSet<Tournament> Tournament {get;set;}

        // DbQuery 
    }
}