using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class PlayfieldRepository : IPlayfieldRepository
    {
        public void AddNewPlayfield(Playfield playfield)
        {
            RepositoryBase.DataContext.Playfields.InsertOnSubmit(playfield);
            SaveChanges();
        }

        public Playfield GetModel()
        {
            return new Playfield();
        }

        public ICollection<Playfield> GetAllPlayfields()
        {
            return RepositoryBase.DataContext.Playfields.ToList();
        }

        public Playfield GetPlayfieldById(Guid id)
        {
            Playfield playfield = RepositoryBase.DataContext.Playfields
                                    .Where(p => p.PLayfieldID == id).FirstOrDefault();
            return playfield;
        }

        public Playfield GetPlayfieldByScheduleId(Guid scheduleId)
        {
            Playfield playfield = RepositoryBase.DataContext.Playfields
                                        .Where(p => p.ScheduleID == scheduleId)
                                        .FirstOrDefault();
            return playfield;
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }




        public Schedule GetPlayfieldSchedule(Guid userId)
        {
            return null;
        }


        public IList<Playfield> GetPlayfieldsByOwner(Guid ownerId)
        {
            return RepositoryBase.DataContext.Playfields
                .Where(p => p.OwnerPlayfieldID == ownerId)
                .ToList();
        }



        public IList<PlayfieldOwner> GetAllPlayfieldsByCity(string city)
        {
            return RepositoryBase.DataContext.PlayfieldOwners
                .Where(p => p.City.ToLower() == city.ToLower())
                .ToList();
        }


        public IList<PlayfieldOwner> GetAllPlayfieldsByName(string name)
        {
            return RepositoryBase.DataContext.PlayfieldOwners
                .Where(p => p.Name.ToLower() == name.ToLower())
                .ToList();
        }


        public IList<Playfield> GetAllPlayfieldsByOwner(Guid ownerId)
        {
            return RepositoryBase.DataContext.Playfields
                .Where(p => p.OwnerPlayfieldID == ownerId)
                .ToList();
        }
    }
}