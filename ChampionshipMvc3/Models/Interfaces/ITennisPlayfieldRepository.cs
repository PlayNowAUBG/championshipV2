using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface ITennisPlayfieldRepository
    {
        void AddNewPlayfield(TennisPlayfield playfield);
        ICollection<TennisPlayfield> GetAllPlayfields();
        TennisPlayfield GetModel();
        
        IList<TennisPlayfield> GetPlayfieldsByOwner(Guid ownerId);
        TennisPlayfield GetPlayfieldById(Guid id);
        TennisPlayfield GetPlayfieldByScheduleId(Guid scheduleId);
        IList<TennisPlayfieldOwner> GetAllPlayfieldsByCity(string city);
        IList<TennisPlayfieldOwner> GetAllPlayfieldsByName(string name);
        IList<TennisPlayfield> GetAllPlayfieldsByOwner(Guid ownerId);

        void SaveChanges();
    }
}