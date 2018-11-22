 using Microsoft.EntityFrameworkCore;
 using TournMan.Models;

 namespace TournMan.Models {
     public class PgContext : DbContext {
         public PgContext () { }
         public PgContext (DbContextOptions<PgContext> options) : base (options) { }
         protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
             optionsBuilder.UseNpgsql ("User ID=postgres;Password=lizo90;Server=localhost;Port=5432;Database=dbtest");
         }
         public DbSet<Tournament> Tournament { get; set; }
     }
 }