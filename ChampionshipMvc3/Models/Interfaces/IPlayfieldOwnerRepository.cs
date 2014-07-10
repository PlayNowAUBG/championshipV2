using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IPlayfieldOwnerRepository
    {
        void AddNewOwner(PlayfieldOwner owner);
        PlayfieldOwner GetModel();
        IList<PlayfieldOwner> GetAllOwners();
        PlayfieldOwner GetCurrentOwnerByUserId(Guid userId);
        PlayfieldOwner GetOwnerById(Guid id);

        void UpdatePlayfieldOwner(Guid ownerId, Guid userId);
        Guid GetUserId(string userName);
        void SaveChanges();
    }
}