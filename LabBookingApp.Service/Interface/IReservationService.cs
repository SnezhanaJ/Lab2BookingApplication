using LabBookingApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Service.Interface
{
    public interface IReservationService
    {
        List<Reservation> GetAllReservations();
        Reservation GetDetailsForReservation(Guid? id);
        void CreateNewReservation(Reservation p);
        void UpdateExistingReservation(Reservation p);
        void DeleteReservation(Guid id);
        void AddToBookings(BookReservation bookReservation, string userId);
    }
}
