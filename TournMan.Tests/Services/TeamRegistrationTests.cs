using System;
using System.Collections.Generic;
using NSubstitute;
using TournMan.Repositories;
using TournMan.Models;
using TournMan.Services;
using Xunit;
using FluentAssertions;
using TournMan.Interfaces;

namespace TournMan.Tests.Services
{
    public class TeamRegistrationTests
    {
        [Fact]
        public void Register_GivenAnExistingTeam_ShouldRegisterTeam()
        {
            //Given
            var registration = new Registration(2, 2, 500.00);
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = new RegistrationService(registrationRepository);

            //When
            registrationService.Register(registration);

            //Then
            registrationRepository.Received(1).Register(registration);
        }

        [Fact]
        public void Register_GivenAmountIsLessThanZero_ShouldNotRegiterTeam()
        {
            //Given
            var registration = new Registration(2, 2, -500.00);
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = new RegistrationService(registrationRepository);

            //When
            registrationService.Register(registration);

            //Then
            registrationRepository.DidNotReceive().Register(registration);
        }

        [Fact]
        public void FindAll_GivenThereAreRegisteredTeam_ShouldReturnRegisteredTeams()
        {
            //Given
            var registrationRepository = Substitute.For<IRegistrationRepository>();
            var registrationService = new RegistrationService(registrationRepository);
            var registration = new List<Registration>()
            {
                new Registration(1, 1, 500.00),
                new Registration(2, 2, 500.00),
                new Registration(3, 3, 500.00),
                new Registration(4, 4, 500.00)
            };
            registrationRepository.FindAll().Returns(registration);

            //When
            var results = registrationService.FindAll();

            //Then
            results.Should().BeEquivalentTo(registration);
        }
    }
}