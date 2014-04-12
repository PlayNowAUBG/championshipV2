using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class PictureRepository : IPictureRepository
    {
        public IList<Picture> GetAllPictures()
        {
            throw new NotImplementedException();
        }

        public Picture GetPictureById(Guid picId)
        {
            throw new NotImplementedException();
        }

        public void AddNewPicture(DataContext.Picture pic)
        {
            RepositoryBase.DataContext.Pictures.InsertOnSubmit(pic);
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }
    }
}