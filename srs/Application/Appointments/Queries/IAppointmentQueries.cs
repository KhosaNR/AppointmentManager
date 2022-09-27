using Slot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Queries
{
    public interface IAppointmentQueries
    {
        SlotDto GetByTime(DateTime appointmentDate);
        bool AppointmentExists(DateTime appointmentDate);
        Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate);
    }
}
