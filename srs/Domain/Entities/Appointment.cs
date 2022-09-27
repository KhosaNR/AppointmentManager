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
    public class Appointment : BaseEntity
    {
        //public string AppointmentCode { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public Guid Person_Id { get; set; }
        public  readonly TimeSpan AppointmentDuration = TimeSpan.FromMinutes(30);

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
