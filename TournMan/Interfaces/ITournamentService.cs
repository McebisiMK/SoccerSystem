using System;
using System.Collections.Generic;
using TournMan.Models;

namespace TournMan.Interfaces {
    public interface ITournamentService {
        int Save (Tournament tournament);
        List<Tournament> FindAll ();
        List<Tournament> FindByDate (DateTime startDate);
        List<Tournament> FindByName (string name);
        List<Tournament> FindByLocation (string location);
        List<Tournament> FindById (int tournamentId);
    }
}