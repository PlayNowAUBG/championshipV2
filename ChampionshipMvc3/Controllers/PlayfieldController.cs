using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChampionshipMvc3.Models.Interfaces;
using ChampionshipMvc3.Models.DataContext;
using System.IO;
using ChampionshipMvc3.Models.ViewModels;
using ChampionshipMvc3.Common;

namespace ChampionshipMvc3.Controllers
{

    public class PlayfieldController : Controller
    {
        private const string locationString = "../../Images/";
        private const string relativePath = "../Images/";
        private IPlayfieldRepository playfieldRepository;
        private IPlayfieldOwnerRepository ownerRepository;
        private IScheduleRepository scheduleRepository;
        private IReservationRepository reservationRepository;
        private IPictureRepository pictureRepository;

        public PlayfieldController(IPlayfieldRepository playfieldRepoParam, IPlayfieldOwnerRepository ownerRepoParam,
                IScheduleRepository scheduleRepoParam, IReservationRepository reservationRepoParam, IPictureRepository pictureRepoParam)
                                    
        {
            playfieldRepository = playfieldRepoParam;
            ownerRepository = ownerRepoParam;
            reservationRepository = reservationRepoParam;
            scheduleRepository = scheduleRepoParam;
            pictureRepository = pictureRepoParam;
        }

        
        public ActionResult Details(Guid id)
        {
            var owner = ownerRepository.GetOwnerById(id);
            return View("OwnerDetails", owner);
        }

        public ActionResult CreatePlayfieldOwner()
        {
            return View("CreateOwnerPlayfieldView", ownerRepository.GetModel());
        }

        [HttpPost]
        public ActionResult CreatePlayfieldOwner(PlayfieldOwner ownerModel, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                Picture newPicture = new Picture();
                newPicture.PictureID = Guid.NewGuid();
                
                ownerModel.PlayfieldOwnerID = Guid.NewGuid();
                newPicture.PlayfieldOwnerID = ownerModel.PlayfieldOwnerID;
                newPicture.Path = locationString + file.FileName;
                pictureRepository.AddNewPicture(newPicture);
                ownerRepository.AddNewOwner(ownerModel);
                SaveToServer(file);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddNewPlayfield()
        {
            PlayfieldViewModel viewModel = new PlayfieldViewModel();

            List<PlayfieldOwner> listOfOwners = ownerRepository.GetAllOwners().ToList();

            viewModel.OwnersSelectList = new List<SelectListItem>();
            for(int index = 0; index < listOfOwners.Count; index++)
            {
                SelectListItem currentItem = new SelectListItem();
                currentItem.Text = listOfOwners[index].Name;
                currentItem.Value = listOfOwners[index].PlayfieldOwnerID.ToString();

                viewModel.OwnersSelectList.Add(currentItem);
            }

             
            return View("AddNewPlayfieldView", viewModel);
        }

        [HttpPost]
        public ActionResult AddNewPlayfield(PlayfieldViewModel playfieldViewModel, HttpPostedFileBase[] files)
        {
            if (ModelState.IsValid)
            {

                Playfield playfieldModel = playfieldViewModel.PlayfieldModel;
                playfieldModel.PLayfieldID = Guid.NewGuid();
                PlayfieldOwner playfieldOwner = ownerRepository.GetOwnerById(playfieldViewModel.SelectedId);
                playfieldModel.PlayfieldOwner = playfieldOwner;
                
                Schedule playfieldSchedule = new Schedule();
                playfieldSchedule.ScheduleID = Guid.NewGuid();
                scheduleRepository.AddNewSchedule(playfieldSchedule, playfieldModel.PlayfieldOwner.StartHour, playfieldModel.PlayfieldOwner.EndHour);
                playfieldModel.Schedule = playfieldSchedule;

                foreach (var file in files)
                {
                    Picture newPicture = new Picture();
                    newPicture.PictureID = Guid.NewGuid();
                    newPicture.PlayfieldId = playfieldModel.PLayfieldID;
                    newPicture.Path = locationString + file.FileName;
                    pictureRepository.AddNewPicture(newPicture);
                }

                playfieldRepository.AddNewPlayfield(playfieldModel);

                SaveToServer(files);
    
            }

            
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

        public ActionResult PlayfieldSchedule(Guid playfieldId)
        {
            Session["playfieldId"] = playfieldId;
            Schedule schedule = scheduleRepository.GetPlayFieldSchedule(playfieldId);

            return View("PlayfieldScheduleView", schedule);
        }

        public ActionResult Reserve()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Reserve(Reservation reservationModel)
        {
            if (ModelState.IsValid)
            {
                reservationModel.PlayfieldID = (Guid)Session["playfieldId"];
                reservationModel.ReservationID = Guid.NewGuid();

                //reservationRepository.AddNewReservation(reservationModel);
            }
            Guid playfieldId = (Guid)Session["playfieldId"];
            return RedirectToAction("PlayfieldSchedule", "Playfield", new { playfieldId = playfieldId });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HttpPost]
        public ActionResult ReservePlayfield(decimal hourInterval, Guid hourId, 
                                                Guid dayId, string name, string phone)
        {
            Schedule schedule = scheduleRepository.GetScheduleByDayId(dayId);
            Day day = scheduleRepository.GetDayById(dayId);
            Playfield playfield = playfieldRepository.GetPlayfieldByScheduleId(schedule.ScheduleID);
            Reservation reservation = new Reservation();

            reservation.ReservationID = Guid.NewGuid();
            reservation.DayName = day.DayName;
            reservation.StartHour = hourInterval;
            reservation.EndHour = hourInterval + 1.0m;
            reservation.Playfield = playfield;
            reservation.ReservationDate = DateTime.Now;
            reservation.Name = name;
            reservation.Phone = phone;

            reservationRepository.AddNewReservation(reservation);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult SuccessReservation()
        {
            return View("SuccessReservation");
        }

        public ActionResult PlayfieldDetails(Guid playfieldId)
        {
            var selectedPlayfield = playfieldRepository.GetPlayfieldById(playfieldId);

            return View(selectedPlayfield);
        }

        //
        // POST: /Playfield/Delete/5

        private void SaveToServer(HttpPostedFileBase[] files)
        {
            foreach (var singleFile in files)
            {
                var fileName = Path.GetFileName(singleFile.FileName);
                singleFile.SaveAs(Server.MapPath(relativePath + singleFile.FileName));
            }

            //string location = locationString + fileViewModel.File.FileName;
            //fileViewModel.File.SaveAs(Server.MapPath(location));
        }

        private void SaveToServer(HttpPostedFileBase file)
        {
            var fileName = Path.GetFileName(file.FileName);
            file.SaveAs(Server.MapPath(relativePath + file.FileName)); 
        }
    }
}
