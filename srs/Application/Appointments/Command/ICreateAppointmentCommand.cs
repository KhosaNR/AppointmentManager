using Domain.Entities;
using Slot.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot.Appointments.Command
{
    internal interface ICreateAppointmentCommand
    {
        void Execute(SlotDto appointment);
    }
}
