using Slot.DTOs;
using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Queries
{
    public class AppointmentQueries : IAppointmentQueries
    {
        readonly IUnitOfWork uow;

        public AppointmentQueries(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public SlotDto GetByTime(DateTime appointmentDate)
        {
            var appointment = uow.Appointments.GetByDateTime(appointmentDate);
            if(appointment == null) { return null; }
            return new SlotDto { 
                CancellationReason = appointment.CancellationReason,
                Id = appointment.Id,
                PersonId = appointment.Person_Id,
                SlotDate = (DateTime)appointment.AppointmentDate,
                Status = appointment.Status
            };
        }

        public bool AppointmentExists(DateTime appointmentDate)
        {
            return uow.Appointments.AppointmentExists(appointmentDate);
        }

        public async Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate)
        {
            return await uow.Appointments.GetForWeek(startDate);
        }
    }
}
