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


        public ICollection<PlayfieldOwner> GetAllOwners()
        {
            return RepositoryBase.DataContext.PlayfieldOwners.ToList();
        }


        public PlayfieldOwner GetCurrentOwnerByUserId(Guid userId)
        {
            //TO DO: IMPLEMENT USER LOGIC HERE

            return RepositoryBase.DataContext.PlayfieldOwners
                .Where(owner => owner.Name == "Ria").FirstOrDefault();
        }


        public PlayfieldOwner GetOwnerById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}