using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChampionshipMvc3.Controllers
{
    public class HomeController : Controller
    {
        private IPlayfieldRepository playfieldRepository;

        public HomeController()
        {
            playfieldRepository = new PlayfieldRepository();
        }

        public ActionResult Index()
        {
            var model = playfieldRepository.GetAllPlayfields();

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PlayfieldDetails()
        {


            return View();
        }
    }
}
