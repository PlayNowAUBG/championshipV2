using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.Repositories;
using ChampionshipMvc3.Models.DataContext;
using System.IO;
using ChampionshipMvc3.Models.ViewModels;
using ChampionshipMvc3.Common;

namespace ChampionshipMvc3.Controllers
{

    public class PlayfieldController : Controller
    {
        private const string locationString = "~/Images/";
        private IPlayfieldRepository playfieldRepository;
        private IOwnerPlayfieldRepository ownerRepository;
        private IScheduleRepository scheduleRepository;
        private IReservationRepository reservationRepository;

        public PlayfieldController()
        {
            playfieldRepository = new PlayfieldRepository();
            scheduleRepository = new ScheduleRepository();
            reservationRepository = new ReservationRepository();
            ownerRepository = new OwnerPlayfieldRepository();
        }

        
        public ActionResult Details(Guid id)
        {
            var playfield = playfieldRepository.GetPlayfieldById(id);
            return View("PlayfieldDetails", playfield);
        }

        
        public ActionResult CreateOwnerPlayfield()
        {
            return View("CreateOwnerPlayfieldView", ownerRepository.GetModel());
        }

       
        [HttpPost]
        public ActionResult CreateOwnerPlayfield(PlayfieldOwner ownerModel)
        {
            if (ModelState.IsValid)
            {
                ownerModel.OwnerPlayfieldID = Guid.NewGuid();
                ownerRepository.AddNewOwner(ownerModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddNewPlayfield()
        {
            PlayfieldViewModel viewModel = new PlayfieldViewModel();

            List<PlayfieldOwner> listOfOwners = ownerRepository.GetAllOwners().ToList();

            viewModel.ownersSelectList = new List<SelectListItem>();
            for(int index = 0; index < listOfOwners.Count; index++)
            {
                SelectListItem currentItem = new SelectListItem();
                currentItem.Text = listOfOwners[index].Name;
                currentItem.Value = listOfOwners[index].OwnerPlayfieldID.ToString();

                viewModel.ownersSelectList.Add(currentItem);
            }

             
            return View("AddNewPlayfieldView", viewModel);
        }

        [HttpPost]
        public ActionResult AddNewPlayfield(PlayfieldViewModel playfieldViewModel, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {
                Playfield playfieldModel = playfieldViewModel.playfieldModel;

                playfieldModel.PLayfieldID = Guid.NewGuid();

                PlayfieldOwner playfieldOwner = ownerRepository.GetOwnerById(playfieldViewModel.SelectedId);

                Schedule playfieldSchedule = new Schedule();
                scheduleRepository.AddNewSchedule(playfieldSchedule, playfieldModel.PlayfieldOwner.StartHour, playfieldModel.PlayfieldOwner.EndHour);
                playfieldModel.Schedule = playfieldSchedule;

                playfieldRepository.AddNewPlayfield(playfieldModel);
                
            }

            SaveToServer(files);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult SearchPlayfieldsByCity(string city)
        {
            IList<PlayfieldOwner> playfieldsResult = playfieldRepository.GetAllPlayfieldsByCity(city);

            return View("PlayfieldOwnerResult", playfieldsResult);
        }

        [HttpPost]
        public ActionResult SearchPlayfieldsByName(string name)
        {
            IList<PlayfieldOwner> playfieldResult = playfieldRepository.GetAllPlayfieldsByName(name);
            return View("PlayfieldOwnerResult", playfieldResult);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ReservePlayfield(decimal hourInterval, Guid hourId, Guid dayId)
        {
            //Schedule schedule = scheduleRepository.GetScheduleByDayId(dayId);
            //Day day = scheduleRepository.GetDayById(dayId);
            //Playfield playfield = playfieldRepository.GetPlayfieldByScheduleId(schedule.ScheduleID);
            //Reservation reservation = new Reservation();

            //reservation.ReservationID = Guid.NewGuid();
            //reservation.DayName = day.DayName;
            //reservation.StartHour = hourInterval;
            //reservation.EndHour = hourInterval + 1.0m;
            //reservation.isApproved = false;
            //reservation.Playfield = playfield;
            //reservation.ReservationDate = DateTime.Now;
            

            //reservationRepository.AddNewReservation(reservation);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SuccessReservation()
        {
            return View("SuccessReservation");
        }

        //
        // POST: /Playfield/Delete/5

        private void SaveToServer(HttpPostedFileBase[] files)
        {
            foreach (var singleFile in files)
            {
                var fileName = Path.GetFileName(singleFile.FileName);
                singleFile.SaveAs(Server.MapPath(locationString + singleFile.FileName));
            }

            //string location = locationString + fileViewModel.File.FileName;
            //fileViewModel.File.SaveAs(Server.MapPath(location));
        }
    }
}
