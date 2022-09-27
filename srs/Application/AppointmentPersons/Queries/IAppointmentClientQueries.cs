using Slot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppointmentsPersons.Queries
{
    public interface IAppointmentClientQueries
    {
        bool PhoneNoHasPendingAppointment(string phoneNo);
    }
}
