 using System;
 using Microsoft.EntityFrameworkCore.Design;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;
 using Microsoft.Extensions.DependencyInjection;
 using Microsoft.Extensions.Logging;
 using Microsoft.Extensions.Options;
 using TournMan.Models;

 namespace TournMan.Repositories {
     public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PgContext> {

         public DesignTimeDbContextFactory () { }

         public DesignTimeDbContextFactory (IConfiguration configuration) {
             Configuration = configuration;
         }

         public PgContext CreateDbContext (string[] args) {
             var builder = new DbContextOptionsBuilder<PgContext> ();
             builder.UseNpgsql ("User ID=postgres;Password=lizo90;Server=localhost;Port=5432; Integrated Security=true");
             return new PgContext (builder.Options);
         }

         public IConfiguration Configuration { get; }
     }
 }