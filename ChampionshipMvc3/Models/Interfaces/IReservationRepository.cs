using ChampionshipMvc3.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Interfaces
{
    public interface IReservationRepository
    {
        void AddNewReservation(Reservation reservation);
        Reservation GetModel();
        ICollection<Reservation> GetAllReservations();
        ICollection<Reservation> GetAllUnapprovedReservations();
        Reservation GetReservationById(Guid reservationId);
        void ApproveReservation(Guid reservationId);
        void SaveChanges();
    }
}