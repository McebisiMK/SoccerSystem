using System;
using System.Collections.Generic;

namespace TournMan.Tests.Services {
    public interface ITournamentRepository {
        void Save (Tournament tournament);
        List<Tournament> FindAll ();
        List<Tournament> FindByDate (DateTime dateTime);
    }
}