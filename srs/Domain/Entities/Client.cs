using Domain.Enums;
using Domain.General.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        private List<Slot> _Slots = new List<Slot>();
        public void AddSlot(Slot slot)
        {
            _Slots.Add(slot);
        }
        public ICollection<Slot> Slots{ get{return _Slots;} }

        public bool CanBookNewAppointment(bool allowMultiplePendingAppointments=false)
        {
            if (allowMultiplePendingAppointments)
            {
                return true;
            }

            return !Slots.Any(x => x.Status < AppointmentStatus.Done);
        }

        public Result BookNewAppointment(Slot newSlot, bool allowMultiplePendingAppointments)
        {
            if (!CanBookNewAppointment(false))
            {
                return new InvalidResult($"Failed! Cannot add new appointment to client {this.Id} due to a pending appointment");
            }

            newSlot.Status = AppointmentStatus.Booked;
            AddSlot(newSlot);
            return new SuccessResult("");
        }


    }
}
