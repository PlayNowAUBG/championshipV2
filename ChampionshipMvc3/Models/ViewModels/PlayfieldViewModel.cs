using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChampionshipMvc3.Models.ViewModels
{
    public class PlayfieldViewModel
    {
        public Playfield playfieldModel { get; set; }
        public ICollection<SelectListItem> ownersSelectList { get; set; }
        public Guid SelectedId { get; set; }
    }
}