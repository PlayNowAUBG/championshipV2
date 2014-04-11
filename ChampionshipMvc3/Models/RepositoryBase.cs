using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models
{
    public class RepositoryBase
    {
        public static PlayNowDataContext DataContext
        {
            get;
            private set;
        }

        public RepositoryBase(PlayNowDataContext initialDataContext)
        {
            DataContext = initialDataContext;
        }
    }
}