using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IPlayfieldRepository
    {
        void AddNewPlayfield(Playfield playfield);
        ICollection<Playfield> GetAllPlayfields();
        Playfield GetModel();
        Schedule GetPlayfieldSchedule(Guid userId);
        IList<Playfield> GetPlayfieldsByOwner(Guid ownerId);
        Playfield GetPlayfieldById(Guid id);
        Playfield GetPlayfieldByScheduleId(Guid scheduleId);
        IList<PlayfieldOwner> GetAllPlayfieldsByCity(string city);
        IList<PlayfieldOwner> GetAllPlayfieldsByName(string name);
        IList<Playfield> GetAllPlayfieldsByOwner(Guid ownerId);

        void SaveChanges();
    }
}