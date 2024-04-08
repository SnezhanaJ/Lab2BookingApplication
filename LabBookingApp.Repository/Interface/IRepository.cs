using LabBookingApp.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabBookingApp.Repository.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Get(Guid? id);
        void Delete(T entity);
        void Insert(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
    }
}
