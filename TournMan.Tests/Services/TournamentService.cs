using System;
using System.Collections.Generic;

namespace TournMan.Tests.Services
{
    internal class TournamentService
    {
        private ITournamentRepository tournamentRepository;

        public TournamentService()
        {
        }

        public TournamentService(ITournamentRepository tournamentRepository)
        {
            this.tournamentRepository = tournamentRepository;
        }

        internal void Save(Tournament tournament)
        {
            if (IsValid(tournament))
            {
                tournamentRepository.Save(tournament);
            }
            
        }

        private static bool IsValid(Tournament tournament)
        {
            return !(tournament.StartDate < DateTime.Now | string.IsNullOrEmpty(tournament.Name) | string.IsNullOrEmpty(tournament.Location));
        }

        public List<Tournament> FindAll()
        {
        return tournamentRepository.FindAll();
        }

        internal List<Tournament> FindByDate(DateTime startDate)
        {
            return tournamentRepository.FindByDate(startDate);
        }
    }
}