using Application.DTOs;
using Application.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppointmentPerson.Command
{
    internal interface IAppointmentPersonCommand
    {
        void SaveAppointmentPerson(Domain.Entities.AppointmentPerson appointmentPerson);
    }
}
