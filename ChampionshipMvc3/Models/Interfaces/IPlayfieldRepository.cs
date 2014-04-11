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
        Playfield GetPlayfieldById(Guid id);
        Playfield GetPlayfieldByScheduleId(Guid scheduleId);
        void SaveChanges();
    }
}