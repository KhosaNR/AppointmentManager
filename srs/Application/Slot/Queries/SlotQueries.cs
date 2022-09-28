using Application.DTOs;
using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Slot.Queries
{
    public class SlotQueries : ISlotQueries
    {
        readonly IUnitOfWork uow;

        public SlotQueries(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public SlotDto GetByTime(DateTime appointmentDate)
        {
            var slot = uow.Slots.GetByDateTime(appointmentDate);
            if(slot == null) { return null; }
            return new SlotDto { 
                CancellationReason = slot.CancellationReason,
                Id = slot.Id,
                SlotDate = (DateTime)slot.AppointmentDate,
                Status = slot.Status
            };
        }

        public bool SlotExists(DateTime appointmentDate)
        {
            return uow.Slots.AppointmentExists(appointmentDate);
        }

        public async Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate)
        {
            return await uow.Slots.GetForWeek(startDate);
        }
    }
}
