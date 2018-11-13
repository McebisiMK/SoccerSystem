

using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using TournMan.Models;
using TournMan.Repositories;
using TournMan.Services;
using Xunit;

namespace TournMan.Tests.Services
{
    public class TournamentTeams
    {

        [Fact]
        public void Save_GivenTeamDetails_ShouldSaveTeam()
        {
            //Given
            var team = new Team("Mcebisi FC", "Mcera", "Lizo");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            //When
            teamService.Save(team);
            //Then
            teamRepository.Received(1).Save(team);
        }
        [Fact]
        public void Save_GivenTeamWithNoName_ShouldNotSave()
        {
            //Given
            var team = new Team("", "Lizo", "Mcera");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            //When
            teamService.Save(team);
            //Then
            teamRepository.DidNotReceive().Save(team);
        }
        [Fact]
        public void Save_GivenTeamWithNoCoach_ShouldNotSave()
        {
            //Given
            var team = new Team("Lizo FC", "", "Mcera");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            //When
            teamService.Save(team);
            //Then
            teamRepository.DidNotReceive().Save(team);
        }
        [Fact]
        public void Save_GivenTeamWithNoCaptain_ShouldNotSave()
        {
            //Given
            var team = new Team("Lizo FC", "Lizo", "");
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            //When
            teamService.Save(team);
            //Then
            teamRepository.DidNotReceive().Save(team);
        }

        [Fact]
        public void Search_GivenExistingTeamAndSearchByName_ShouldReturnTeam()
        {
            //Given
            var name = "Mcera fc";
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            var team = new List<Team>()
            {
              new Team("Mcera fc","Mcera","Mceraz")
            };
            teamRepository.FindByName(name).Returns(team);

            //When
            var results = teamService.FindByName(name);
            //Then
            results.Should().BeEquivalentTo(team);
        }

        [Fact]
        public void Search_GivenExistingTeamAndSearchByCoach_ShouldReturnTeam()
        {
            //Given
            var coach = "Mcera";
            var teamRepository = Substitute.For<ITeamRepository>();
            var teamService = new TeamService(teamRepository);
            var team = new List<Team>()
            {
                new Team("Mcera fc","Mcera","Mceraz")
            };
            teamRepository.FindByCoach(coach).Returns(team);
            //When
            var results = teamService.FindByCoach(coach);
            //Then
            results.Should().BeEquivalentTo(team);
        }
    }

}