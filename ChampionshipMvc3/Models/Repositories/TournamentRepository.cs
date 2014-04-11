using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class TournamentRepository : ITournamentRepository
    {
        public void AddNewTournament(Tournament tournament)
        {
            RepositoryBase.DataContext.Tournaments.InsertOnSubmit(tournament);
            SaveChanges();
        }

        public Tournament GetModel()
        {
            return new Tournament();
        }

        public ICollection<Tournament> GetAllTournaments()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}