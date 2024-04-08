using LabBookingApp.Domain.Identity;
using LabBookingApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private DbSet<BookingApplicationUser> entites;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
            entites = context.Set<BookingApplicationUser>();
        }
        public void Delete(BookingApplicationUser entity)
        {
            entites.Remove(entity);
            _context.SaveChanges();
        }

        public BookingApplicationUser Get(string? id)
        {
            return entites.
                Include(z => z.bookingList).
                Include("bookingList.Reservations").
                Include("bookingList.Reservations.Reservation").
                Include("bookingList.Reservations.Reservation.Apartment").
                SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<BookingApplicationUser> GetAll()
        {
            return entites.AsEnumerable();
        }

        public void Insert(BookingApplicationUser entity)
        {
            entites.Add(entity);
            _context.SaveChanges();
        }

        public void Update(BookingApplicationUser entity)
        {
            entites.Update(entity);
            _context.SaveChanges();
        }
    }
}
