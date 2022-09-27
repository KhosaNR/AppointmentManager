using Slot.DTOs;
using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.AppointmentsPersons.Queries
{
    public class AppointmentClientQueries : IAppointmentClientQueries
    {
        readonly IUnitOfWork uow;

        public AppointmentClientQueries(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool PhoneNoHasPendingAppointment(string phoneNo)
        {
            return uow.AppointmentPeople.GetByPhoneNo(phoneNo).Result
                .Any(x=>x.Appointments.Any(a=>a.Status<AppointmentStatus.Done));         
        }
    }
}
