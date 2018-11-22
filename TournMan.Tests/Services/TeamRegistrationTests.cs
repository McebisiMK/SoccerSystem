using System;
using System.Collections.Generic;
using NSubstitute;
using TournMan.Repositories;
using TournMan.Models;
using TournMan.Services;
using Xunit;
using FluentAssertions;

namespace TournMan.Tests.Services
{
    public class TeamRegistrationTests
    {
        [Fact]
        public void Register_GivenAnExistingTeam_ShouldRegisterTeam()
        {
            //Given
            var RegisteringTeam = new RegisteredTeams(1, "Mcera FC", "Coach", DateTime.Now.AddMonths(1), 500.00);
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = new RegistrationService(registrationRepository);

            //When
            registrationService.Register(RegisteringTeam);

            //Then
            registrationRepository.Received(1).Register(RegisteringTeam);
        }

        [Fact]
        public void Register_GivenAmountIsLessThanZero_ShouldNotRegiterTeam()
        {
            //Given
            var RegisteringTeam = new RegisteredTeams(1, "Mcera FC", "Coach", DateTime.Now.AddMonths(1), -500.00);
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = new RegistrationService(registrationRepository);

            //When
            registrationService.Register(RegisteringTeam);

            //Then
            registrationRepository.DidNotReceive().Register(RegisteringTeam);
        }

        [Fact]
        public void FindAll_GivenThereAreRegisteredTeam_ShouldReturnRegisteredTeams()
        {
            //Given
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = new RegistrationService(registrationRepository);
            var registeredTeams = new List<RegisteredTeams>()
            {
                new RegisteredTeams(1, "Mcera FC", "Mcera", DateTime.Now.AddMonths(1), 500.00),
                new RegisteredTeams(2, "Lizo FC", "Lizo", DateTime.Now.AddDays(1), 500.00),
                new RegisteredTeams(3, "Mbu FC", "Mbu", DateTime.Now.AddMonths(1), 500.00),
                new RegisteredTeams(4, "Lake FC", "Coach", DateTime.Now.AddDays(1), 500.00)
            };
            registrationRepository.FindAll().Returns(registeredTeams);

            //When
            var results = registrationService.FindAll();

            //Then
            results.Should().BeEquivalentTo(registeredTeams);
        }
    }
}