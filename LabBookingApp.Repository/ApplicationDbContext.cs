
using LabBookingApp.Domain.Domain;
using LabBookingApp.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabBookingApp.Repository
{
    public class ApplicationDbContext : IdentityDbContext<BookingApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<BookingList> Bookings { get; set; }
        public virtual DbSet<BookReservation> BookReservations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingList>()
                .HasOne(bl => bl.BookingUser)
                .WithOne(bu => bu.bookingList)
                .HasForeignKey<BookingList>(bl => bl.userId);

            // Additional configurations...

            base.OnModelCreating(modelBuilder);
        }
    }
}
