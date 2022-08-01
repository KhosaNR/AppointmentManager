using Application.Iterface.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    public interface IAppointmentPersonRepository: IGenericRepository<Domain.Entities.AppointmentPerson>
    {
        Task<IEnumerable<Domain.Entities.AppointmentPerson>> GetByLastName(string LastName);
        Task<IEnumerable<Domain.Entities.AppointmentPerson>> GetByPhoneNo(string phoneNo);
        //void SaveChanges();
    }
}
