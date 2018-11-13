using System;
using TournMan.Models;
using TournMan.Repositories;

namespace TournMan.Services
{
    public class TeamService : ITeamService
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
            if (IsValid(team))
            {
                return this.teamRepository.Save(team);
            }
            return 0;
        }

        private static bool IsValid(Team team)
        {
            return !(string.IsNullOrEmpty(team.Name) | string.IsNullOrEmpty(team.Coach) | string.IsNullOrEmpty(team.Captain));
        }
    }
}