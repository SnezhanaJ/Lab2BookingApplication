using LabBookingApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Repository.Interface
{
    public interface IUserRepository
    {
        BookingApplicationUser Get(string? id);
        void Delete(BookingApplicationUser entity);
        void Insert(BookingApplicationUser entity);
        void Update(BookingApplicationUser entity);
        IEnumerable<BookingApplicationUser> GetAll();
    }
}
