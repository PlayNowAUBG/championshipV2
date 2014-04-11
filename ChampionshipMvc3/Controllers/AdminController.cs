using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChampionshipMvc3.Controllers
{
    public class AdminController : Controller
    {
        //TODO: Approve refreshes page;
        private const string adminViewName = "AdminView";
        private const string playfieldAdminViewName = "PlayfieldAdminPanel";
        private const string pendingRequests = "_PendingRequests";
        private const string pendingReservations = "_PendingReservations";

        private IPlayerRepository playerRepository;
        private IReservationRepository reservationRepository;


        //
        // GET: /AdminPlayfield/

        public ActionResult Index()
        {
            return View(adminViewName);
        }

        public ActionResult PlayfieldAdminPanel()
        {
            return View(playfieldAdminViewName);
        }

        public ActionResult ApprovePlayer(Guid playerID)
        {
            playerRepository = new PlayerRepository();
            playerRepository.ApprovePlayer(playerID);
            
            return PartialView(pendingRequests, playerRepository.GetAllUnapprovedPlayers());
        }

        public ActionResult PendingRequests()
        {
            playerRepository = new PlayerRepository();
            return PartialView(pendingRequests, playerRepository.GetAllUnapprovedPlayers());
        }

        public ActionResult PendingReservations()
        {
            reservationRepository = new ReservationRepository();
            return PartialView(pendingReservations, reservationRepository.GetAllUnapprovedReservations());
        }

        public ActionResult ApproveReservation(Guid reservationId)
        {
            reservationRepository = new ReservationRepository();
            reservationRepository.ApproveReservation(reservationId);

            return PartialView(pendingReservations, reservationRepository.GetAllUnapprovedReservations());
        }
    }
}
