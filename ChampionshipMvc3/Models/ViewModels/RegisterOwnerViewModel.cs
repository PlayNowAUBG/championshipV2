using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChampionshipMvc3.Models.ViewModels
{
    public class RegisterOwnerViewModel
    {
        public ICollection<SelectListItem> OwnersSelectList { get; set; }
        public Guid SelectedId { get; set; }
    }
}