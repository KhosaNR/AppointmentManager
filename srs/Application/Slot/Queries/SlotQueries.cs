using Application.DTOs;
using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Slots.Queries
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

        public async Task<bool> SlotExistsAsync(string slotId)
        {
            Guid slodGuid;
            bool slotGuidIsValid = Guid.TryParse(slotId, out slodGuid);
            if (!slotGuidIsValid) return false;

            var slot = await uow.Slots.GetById(slodGuid);
            if(slot == null) { return false; }
            return true;
        }

        public async Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate)
        {
            return await uow.Slots.GetForWeek(startDate);
        }
    }
}
