using System;
using TournMan.Models;
using TournMan.Repositories;

namespace TournMan.Services
{
    internal class TeamService : ITeamService
    {
        private ITeamRepository teamRepository;

        public TeamService()
        {
        }

        public TeamService(ITeamRepository teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public int Save(Team team)
        {
            return this.teamRepository.Save(team);
        }
    }
}