using Domain.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface ISlotRepository: IGenericRepository<Slot>
    {
        bool AppointmentExists(DateTime appointmentDate);
        Slot GetByDateTime(DateTime appointmentDate);
        Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate);
    }
}
