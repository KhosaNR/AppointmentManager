using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Appointments.Command
{
    internal interface ICreateAppointmentCommand
    {
        void Execute(Appointment appointment);
    }
}
