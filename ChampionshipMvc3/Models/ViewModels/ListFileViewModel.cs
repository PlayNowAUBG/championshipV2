using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.ViewModels
{
    public class ListFileViewModel
    {
        public IList<FileViewModel> Files { get; set; }
    }
}