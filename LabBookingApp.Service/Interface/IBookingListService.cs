using LabBookingApp.Domain.Domain;
using LabBookingApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Service.Interface
{
    public interface IBookingListService
    {
        BookingListDto getBookingsInfo(string userId);
        bool deleteBookingFromShoppingCart(string userId, Guid reservationId);
        bool order(string userId);
    }
}
