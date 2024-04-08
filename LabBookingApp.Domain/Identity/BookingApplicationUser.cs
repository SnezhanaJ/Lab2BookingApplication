using LabBookingApp.Domain.Domain;
using Microsoft.AspNetCore.Identity;

namespace LabBookingApp.Domain.Identity
{
    public class BookingApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Reservation>? Reservations { get; set; }
        public  BookingList bookingList { get; set; }
     /*   public Guid? BookingListId { get; set; }
        public virtual BookingList bookingList { get; set; }*/
    }
}
