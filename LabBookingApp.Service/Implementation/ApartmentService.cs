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
    public class ApartmentService : IApartmentService
    {
        private readonly IRepository<Apartment> _repository;
        public ApartmentService(IRepository<Apartment> repository)
        {
            _repository = repository;
        }
        public void CreateNewApartment(Apartment p)
        {
            _repository.Insert(p);
        }

        public void DeleteApartment(Guid id)
        {
            var apartment = _repository.Get(id);
            _repository.Delete(apartment);
        }

        public List<Apartment> GetAllApartments()
        {
            return _repository.GetAll().ToList();
        }

        public Apartment GetDetailsForApartment(Guid? id)
        {
            return _repository.Get(id);
        }

        public void UpdateExistingApartment(Apartment p)
        {
            _repository.Update(p);
        }
    }
}
