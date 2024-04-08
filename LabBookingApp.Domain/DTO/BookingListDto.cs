using LabBookingApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Domain.DTO
{
    public class BookingListDto
    {
        public List<BookReservation> allReservations {  get; set; }
        public int totalPrice { get; set; }
    }
}
