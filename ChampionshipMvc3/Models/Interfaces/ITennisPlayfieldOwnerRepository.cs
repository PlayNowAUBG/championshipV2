using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface ITennisPlayfieldOwnerRepository
    {
        void AddNewOwner(TennisPlayfieldOwner owner);
        TennisPlayfieldOwner GetModel();
        IList<TennisPlayfieldOwner> GetAllOwners();
        TennisPlayfieldOwner GetCurrentOwnerByUserId(Guid userId);
        TennisPlayfieldOwner GetOwnerById(Guid id);
        void UpdatePlayfieldOwner(Guid ownerId, Guid userId);
        Guid GetUserId(string userName);
        void SaveChanges();
    }
}
