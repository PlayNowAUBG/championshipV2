using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IOwnerPlayfieldRepository
    {
        void AddNewOwner(PlayfieldOwner owner);
        PlayfieldOwner GetModel();
        ICollection<PlayfieldOwner> GetAllOwners();
        PlayfieldOwner GetCurrentOwnerByUserId(Guid userId);
        PlayfieldOwner GetOwnerById(Guid id);
        void SaveChanges();
    }
}