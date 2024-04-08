using LabBookingApp.Domain.Identity;

namespace LabBookingApp.Domain.Domain

{
    public class BookingList : BaseEntity
    {
        public string? userId { get; set; }
        public BookingApplicationUser? BookingUser { get; set; }
        public virtual ICollection<BookReservation>? Reservations { get; set; }
    }
}
