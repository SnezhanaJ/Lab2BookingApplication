using LabBookingApp.Domain.Domain;
using LabBookingApp.Domain.DTO;
using LabBookingApp.Repository.Interface;
using LabBookingApp.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Service.Implementation
{
    public class BookingListService : IBookingListService
    {
        private readonly IRepository<BookingList> _bookingListRepository;
        private readonly IUserRepository _userRepository;
        public BookingListService( IRepository<BookingList> bookingListRepository, IUserRepository userRepository)
        {
            _bookingListRepository = bookingListRepository;
            _userRepository = userRepository;
        }

        public bool deleteBookingFromShoppingCart(string userId, Guid reservationId)
        {
            var user = _userRepository.Get(userId);
            var userBookings = user.bookingList;
            var reservation_to_delete = userBookings.Reservations.Where(b=>b.Id== reservationId).FirstOrDefault();
            userBookings.Reservations.Remove(reservation_to_delete);
            _bookingListRepository.Update(userBookings);
            return true;
        }

        public BookingListDto getBookingsInfo(string userId)
        {
            var user = _userRepository.Get(userId);
            var userBookings = user.bookingList;
            var allBookings = userBookings.Reservations.ToList();
      
            var totalPrice = allBookings.Select(x => (x.Reservation.Apartment.Price_per_night * x.Number_of_nights)).Sum();
            var dto = new BookingListDto
        
            {
                allReservations = allBookings,
                totalPrice = totalPrice,
            };
            return dto;
        }

        public bool order(string userId)
        {
            var user = _userRepository.Get(userId);
            var userBookings = user.bookingList;
            userBookings.Reservations.Clear();
            _bookingListRepository.Update(userBookings);
            return true;
        }
    }
}
