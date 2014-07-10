using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class TennisPlayfieldRepository : ITennisPlayfieldRepository
    {
        public void AddNewPlayfield(TennisPlayfield playfield)
        {
            throw new NotImplementedException();
        }

        public ICollection<TennisPlayfield> GetAllPlayfields()
        {
            throw new NotImplementedException();
        }

        public TennisPlayfield GetModel()
        {
            throw new NotImplementedException();
        }

        public Schedule GetPlayfieldSchedule(Guid userId)
        {
            throw new NotImplementedException();
        }

        public IList<TennisPlayfield> GetPlayfieldsByOwner(Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public TennisPlayfield GetPlayfieldById(Guid id)
        {
            throw new NotImplementedException();
        }

        public TennisPlayfield GetPlayfieldByScheduleId(Guid scheduleId)
        {
            throw new NotImplementedException();
        }

        public IList<TennisPlayfieldOwner> GetAllPlayfieldsByCity(string city)
        {
            return RepositoryBase.DataContext.TennisPlayfieldOwners
                .Where(owner => owner.City.ToLower() == city.ToLower())
                .ToList();
        }

        public IList<TennisPlayfieldOwner> GetAllPlayfieldsByName(string name)
        {
            return RepositoryBase.DataContext.TennisPlayfieldOwners
                .Where(owner => owner.Name.ToLower() == name.ToLower())
                .ToList();
        }

        public IList<TennisPlayfield> GetAllPlayfieldsByOwner(Guid ownerId)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}