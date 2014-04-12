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
        public void AddNewOwner(OwnerPlayfield owner)
        {
            RepositoryBase.DataContext.OwnerPlayfields.InsertOnSubmit(owner);
            SaveChanges();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }

       

        public OwnerPlayfield GetModel()
        {
            return new OwnerPlayfield();
        }


        public ICollection<OwnerPlayfield> GetAllOwners()
        {
            return RepositoryBase.DataContext.OwnerPlayfields.ToList();
        }
    }
}