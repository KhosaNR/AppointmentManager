using Domain.Entities;
using Slot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppointmentPersons.Command
{
    public interface ICreateAppointmentPersonCommand
    {
        void Execute(AppointmentPersonDto appointmentPerson);
    }
}
