using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TournMan.Controllers;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;

namespace TournMan {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices (IServiceCollection services) {
            services.AddCors (options => {
                options.AddPolicy ("CorsPolicy",
                    builder => builder.AllowAnyOrigin ()
                    .AllowAnyMethod ()
                    .AllowAnyHeader ()
                    .AllowCredentials ());
            });

            services.AddTransient<ITournamentRepository, TournamentPgRepository> ();
            services.AddTransient<ITeamRepository, TeamPgRepository> ();
            services.AddTransient<IRegistrationRepository, RegistrationRepository> ();

            services.AddTransient<ITournamentService, TournamentService> ();
            services.AddTransient<IRegistrationService, RegistrationService> ();
            services.AddTransient<ITeamService, TeamService> ();

            services.AddMvc ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }
            app.UseCors ("CorsPolicy");
            app.UseMvc ();
        }
    }
}