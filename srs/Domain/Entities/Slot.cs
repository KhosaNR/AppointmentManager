using Domain.Enums;
using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Slot : BaseEntity
    {
        public DateTime? AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
        public String CancellationReason { get; set; }

        public bool AppoinementTimeForNewAppointmentIsValid()
        {
            return AppointmentDate > DateTime.Now;
        }

        public void Cancel()
        {
            if (!CanEdit()) throw new CannnotEditAppointmentInThisStatusException(Status);
            Status = AppointmentStatus.Cancelled;
            AppointmentDate = null;
        }

        private bool CanEdit()
        {
            return Status!= AppointmentStatus.Cancelled &&
                Status != AppointmentStatus.Done &&
                Status != AppointmentStatus.Missed;
        }
    }
}
