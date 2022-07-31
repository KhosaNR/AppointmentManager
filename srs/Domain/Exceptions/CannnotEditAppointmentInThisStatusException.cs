using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class CannnotEditAppointmentInThisStatusException: Exception
    {
        public CannnotEditAppointmentInThisStatusException(AppointmentStatus status) : base($"Cannot edit an appointment with {status} status.")
        {

        }
    }
}
