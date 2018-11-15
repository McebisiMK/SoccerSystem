using System;
using System.Collections.Generic;
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

        public List<Team> FindAll()
        {
            return teamRepository.FindAll();
        }

        public List<Team> FindByName(string name)
        {
            return teamRepository.FindByName(name);
        }
        public List<Team> FindByCoach(string coach)
        {
            return teamRepository.FindByCoach(coach);
        }
        private static bool IsValid(Team team)
        {
            return !(string.IsNullOrEmpty(team.Name) | string.IsNullOrEmpty(team.Coach) | string.IsNullOrEmpty(team.Captain));
        }
    }
}