using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface ITournamentRepository
    {
        void AddNewTournament(Tournament tournament);
        Tournament GetModel();
        ICollection<Tournament> GetAllTournaments();
        void SaveChanges();
    }
}