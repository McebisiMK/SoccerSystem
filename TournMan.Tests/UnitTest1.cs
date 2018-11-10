using System;
using NSubstitute;
using Xunit;

namespace TournMan.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Save_GivenNewTournament_ShouldSave()
        {
            //Given
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths(1), Location = "Mqanduli" };
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
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths(-1), Location = "Mqanduli" };
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
            var tournament = new Tournament { Name = "", StartDate = DateTime.Now.AddMonths(1), Location = "Mqanduli" };
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
            var tournament = new Tournament { Name = "Municapal Tournament", StartDate = DateTime.Now.AddMonths(1), Location = "" };
            var tournamentRepository = Substitute.For<ITournamentRepository>();
            var tournamentService = new TournamentService(tournamentRepository);
            //When
            tournamentService.Save(tournament);
            //Then
            tournamentRepository.DidNotReceive().Save(tournament);
        }

    }
}
