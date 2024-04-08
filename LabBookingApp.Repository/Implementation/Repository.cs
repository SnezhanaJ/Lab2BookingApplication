using LabBookingApp.Domain.Domain;
using LabBookingApp.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private DbSet<T> entities;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            entities = _context.Set<T>();
        }
        public void Delete(T entity)
        {
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T Get(Guid? id)
        {
            if (typeof(T) == typeof(Reservation))
            {
                return entities.Include("Apartment").SingleOrDefault(u => u.Id == id);
            }
            return entities.SingleOrDefault(u => u.Id == id);
        }
        /*      public T Get(Guid? id)
              {
                  if (typeof(T) == typeof(Reservation))
                  {
                      var reservation = entities.SingleOrDefault(u => u.Id == id);
                      if (reservation != null)
                      {
                          return entities.Include("Apartment").SingleOrDefault(u => u.Id == id);
                      }
                      return reservation;
                  }
                  return entities.SingleOrDefault(u => u.Id == id);
              }*/


        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Reservation))
            {
                return entities.Include("Apartment").AsEnumerable();
            }
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            entities.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entities.Update(entity);
            _context.SaveChanges();
        }
    }
}
