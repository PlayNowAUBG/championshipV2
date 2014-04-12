﻿using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IOwnerPlayfieldRepository
    {
        void AddNewOwner(OwnerPlayfield owner);
        OwnerPlayfield GetModel();
        ICollection<OwnerPlayfield> GetAllOwners();
        void SaveChanges();
    }
}