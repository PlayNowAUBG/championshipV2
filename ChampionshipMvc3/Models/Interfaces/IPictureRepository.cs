using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IPictureRepository
    {
        IList<Picture> GetAllPictures();
        Picture GetPictureById(Guid picId);
        void AddNewPicture(Picture pic);
        void SaveChanges();
    }
}