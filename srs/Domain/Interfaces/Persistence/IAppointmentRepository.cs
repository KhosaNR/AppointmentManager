using Domain.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IAppointmentRepository: IGenericRepository<Appointment>
    {
        bool AppointmentExists(DateTime appointmentDate);
        Appointment GetByDateTime(DateTime appointmentDate);
        Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate);
    }
}
