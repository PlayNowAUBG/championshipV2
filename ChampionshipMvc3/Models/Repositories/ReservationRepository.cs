using ChampionshipMvc3.Models.DataContext;
using ChampionshipMvc3.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChampionshipMvc3.Models.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public void AddNewReservation(Reservation reservation)
        {
            RepositoryBase.DataContext.Reservations.InsertOnSubmit(reservation);
            SaveChanges();
        }

        public Reservation GetModel()
        {
            return new Reservation();
        }

        public ICollection<Reservation> GetAllReservations()
        {
            return RepositoryBase.DataContext.Reservations.ToList();
        }

        public void SaveChanges()
        {
            RepositoryBase.DataContext.SubmitChanges();
        }


        public ICollection<Reservation> GetAllUnapprovedReservations()
        {
            throw new NotImplementedException();
        }


        public Reservation GetReservationById(Guid reservationId)
        {
            return RepositoryBase.DataContext.Reservations
                .Where(r => r.ReservationID == reservationId)
                .FirstOrDefault();
        }

        public void ApproveReservation(Guid reservationId)
        {
            throw new NotImplementedException();
            this.SaveChanges();
        }


        public ICollection<Reservation> GetPlayfieldReservations(Guid playfieldId)
        {
            return RepositoryBase.DataContext.Reservations
                .Where(r => r.PlayfieldID == playfieldId)
                .ToList();
        }
    }
}