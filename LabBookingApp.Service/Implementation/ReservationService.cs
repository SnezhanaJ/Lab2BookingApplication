using LabBookingApp.Domain.Domain;
using LabBookingApp.Repository.Interface;
using LabBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Service.Implementation
{
    public class ReservationService : IReservationService
    {

        private readonly IRepository<Reservation> _reservationsRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<BookingList> _bookingsRepository;
        public ReservationService(IRepository<Reservation> reservationsRepository, IUserRepository userRepository, IRepository<BookingList> bookingsRepository)
        {
            _reservationsRepository = reservationsRepository;
            _userRepository = userRepository;
            _bookingsRepository = bookingsRepository;
        }

        public void AddToBookings(BookReservation bookReservation, string userId)
        {
            var bookingsUser = _userRepository.Get(userId);
            var bookingsListUser = bookingsUser.bookingList;
            if (bookingsListUser.Reservations == null)
            {
                bookingsListUser.Reservations = new List<BookReservation>();
            }
            bookingsListUser.Reservations.Add(bookReservation);
            _bookingsRepository.Update(bookingsListUser);
        }

        public void CreateNewReservation(Reservation p)
        {
            _reservationsRepository.Insert(p);
        }

        public void DeleteReservation(Guid id)
        {
            var reservation = _reservationsRepository.Get(id);
            _reservationsRepository.Delete(reservation);
        }

        public List<Reservation> GetAllReservations()
        {
            return _reservationsRepository.GetAll().ToList();
        }

        public Reservation GetDetailsForReservation(Guid? id)
        {
            return _reservationsRepository.Get(id);
        }

        public void UpdateExistingReservation(Reservation p)
        {
            _reservationsRepository.Update(p);
        }
    }
}
