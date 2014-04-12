using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class OwnerPlayfieldRepository : IOwnerPlayfieldRepository
    {
        public void AddNewOwner(PlayfieldOwner owner)
        {
            RepositoryBase.DataContext.PlayfieldOwners.InsertOnSubmit(owner);
            SaveChanges();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }



        public PlayfieldOwner GetModel()
        {
            return new PlayfieldOwner();
        }


        public IList<PlayfieldOwner> GetAllOwners()
        {
            return RepositoryBase.DataContext.PlayfieldOwners.ToList();
        }


        public PlayfieldOwner GetCurrentOwnerByUserId(Guid userId)
        {
            return RepositoryBase.DataContext.PlayfieldOwners
                .Where(o => o.UserId == userId)
                .FirstOrDefault();
        }


        public PlayfieldOwner GetOwnerById(Guid id)
        {
            return RepositoryBase.DataContext.PlayfieldOwners
                .Where(o => o.OwnerPlayfieldID == id)
                .FirstOrDefault();
        }


        public void UpdatePlayfieldOwner(Guid ownerId, Guid userId)
        {
            PlayfieldOwner currentOwner = RepositoryBase.DataContext.PlayfieldOwners
                .Where(owner => owner.OwnerPlayfieldID == ownerId)
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
    }
}