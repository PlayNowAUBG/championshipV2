using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
	public class TennisPlayfieldOwnerRepository : ITennisPlayfieldOwnerRepository
	{
        public void AddNewOwner(TennisPlayfieldOwner owner)
        {
            RepositoryBase.DataContext.TennisPlayfieldOwners.InsertOnSubmit(owner);
            this.SaveChanges();
        }

        public TennisPlayfieldOwner GetModel()
        {
            return new TennisPlayfieldOwner();
        }

        public IList<TennisPlayfieldOwner> GetAllOwners()
        {
            return RepositoryBase.DataContext.TennisPlayfieldOwners.ToList();
        }

        public TennisPlayfieldOwner GetCurrentOwnerByUserId(Guid userId)
        {
            var owner = RepositoryBase.DataContext.TennisPlayfieldOwners
                            .Where(o => o.UserId == userId)
                            .FirstOrDefault();
            return owner;
        }

        public TennisPlayfieldOwner GetOwnerById(Guid id)
        {
            var owner = RepositoryBase.DataContext.TennisPlayfieldOwners
                            .Where(o => o.TennisPlayfieldOwnerID == id)
                            .FirstOrDefault();

            return owner;
        }

        public void UpdatePlayfieldOwner(Guid ownerId, Guid userId)
        {
            TennisPlayfieldOwner currentOwner = RepositoryBase.DataContext.TennisPlayfieldOwners
               .Where(owner => owner.TennisPlayfieldOwnerID == ownerId)
               .FirstOrDefault();

            currentOwner.UserId = userId;
            SaveChanges();
        }

        public Guid GetUserId(string userName)
        {
            return RepositoryBase.DataContext.aspnet_Users
               .Where(u => u.UserName == userName)
               .Select(u => u.UserId)
               .FirstOrDefault();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}