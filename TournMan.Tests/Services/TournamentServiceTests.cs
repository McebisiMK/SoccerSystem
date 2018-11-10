using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using Xunit;
using Dapper.Data;
using System.Data.SqlClient;
using Dapper;
using TournMan.Models;
using TournMan.Services;
using TournMan.Repositories;
namespace TournMan.Tests.Services
{
    public class TournamentServiceTests
    {
        [Fact]
        public void Save_GivenNewTournament_ShouldSave()
        {
            //Given
            var tournament = new Tournament ( "Municapal Tournament",DateTime.Now.AddMonths(1), "Mqanduli" );
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            //When
            tournamentService.Save(tournament);
            //Then
            tournamentRepository.Received(1).Save(tournament);
        }

        [Fact]
        public void Save_GivenTournamentDateIsInThePast_ShouldNotSave()
        {
            //Given
            var tournament = new Tournament ("Municapal Tournament", DateTime.Now.AddMonths(-1),  "Mqanduli" );
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            //When
            tournamentService.Save(tournament);
            //Then
            tournamentRepository.DidNotReceive().Save(tournament);
        }

        [Fact]
        public void Save_GivenNoTournamentName_ShouldNotSave()
        {
            //Given
            var tournament = new Tournament ( "",  DateTime.Now.AddMonths(1), "Mqanduli" );
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            //When
            tournamentService.Save(tournament);
            //Then
            tournamentRepository.DidNotReceive().Save(tournament);
        }

        [Fact]
        public void Save_GivenNoTournamentLocation_ShouldNotSave()
        {
            //Given
            var tournament = new Tournament ("Municapal Tournament", DateTime.Now.AddMonths(1), "" );
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            //When
            tournamentService.Save(tournament);
            //Then
            tournamentRepository.DidNotReceive().Save(tournament);
        }

        [Fact]
        public void FindAll_GivenItemsExist_ShouldReturnAll()
        {
            //Given
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            var tournaments = new List<Tournament>() {
                new Tournament ("Tournament 1", DateTime.Now.AddMonths (-2), "Location 1"),
                new Tournament ("Tournament 2", DateTime.Now.AddMonths (2), "Location 2"),
                new Tournament ("Tournament 3", DateTime.Now.AddYears (2), "Location 3")
            };
            tournamentRepository.FindAll().Returns(tournaments);
            //When
            var results = tournamentService.FindAll();
            //Then
            results.Should().BeEquivalentTo(tournaments);
        }

        [Fact]
        public void FindAll_GivenNoItemsExist_ShouldReturnEmptyCollection()
        {
            //Given
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            tournamentRepository.FindAll().Returns(new List<Tournament>());
            //When
            var results = tournamentService.FindAll();
            //Then
            results.Should().BeNullOrEmpty();
        }

        [Fact]
        public void FindByDate_GivenItemsExist_ShouldReturnMatchingItems()
        {
            //Given
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            var tournaments = new List<Tournament>() {
                new Tournament ("Tournament 1", DateTime.Parse ("2018/10/18"), "Location 1"),
                new Tournament ("Tournament 2", DateTime.Parse ("2019/12/25"), "Location 2"),
                new Tournament ("Tournament 3", DateTime.Parse ("2016/01/01"), "Location 3")
            };
            tournamentRepository.FindByDate(Arg.Any<DateTime>()).Returns(tournaments);
            //When
            var results = tournamentService.FindByDate(DateTime.Parse("2018/10/18"));
            //Then
            results.Should().BeEquivalentTo(tournaments);
        }

        [Fact]
        public void Search_GivenExistingTournamentAndSearchByName_ShouldReturnTournament()
        {
            //Given
            var name = "Tournament 1";
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            var tournaments = new List<Tournament>() {
                new Tournament ("Tournament 1", DateTime.Now.AddMonths (-2), "Location 1")
            };
            tournamentRepository.FindByName(name).Returns(tournaments);
            //When
            var results = tournamentService.FindByName(name);
            //Then
            results.Should().BeEquivalentTo(tournaments);

        }

        [Fact]
        public void Search_GivenExistingTournamentAndSearchByLocation_ShouldReturnTournament()
        {
            //Given
            var Location = "Location 1";
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            var tournaments = new List<Tournament>() {
                new Tournament ("Tournament 1", DateTime.Now.AddMonths (-2), "Location 1")
            };
            tournamentRepository.FindByLocation(Location).Returns(tournaments);
            //When
            var results = tournamentService.FindByLocation(Location);
            //Then
            results.Should().BeEquivalentTo(tournaments);
        }

        [Fact]
        public void TestName()
        {
            //Given
            //LAPTOP-MCEBISI\SQLEXPRESS01

            //When

            //Then
        }
    }
}