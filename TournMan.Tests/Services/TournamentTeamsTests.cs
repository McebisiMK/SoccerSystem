

using System.Collections.Generic;
using NSubstitute;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;
using Xunit;

namespace TournMan.Tests.Services
{
    public partial class TournamentTeams
    {

        [Fact]
        public void Save_GivenTeamDetails_ShouldSaveTeam()
        {
            //Given
            var team = new Team {Name ="Mcebisi FC",Coach ="Mcera", Captain="Lizo",Players=new List<Player>(){}};
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            //When
            teamService.Save(team);
            //Then
            teamRepository.Received(1).Save(team);
        }
    }

}