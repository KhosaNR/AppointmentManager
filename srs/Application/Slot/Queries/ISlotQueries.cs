using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Slots.Queries
{
    public interface ISlotQueries
    {
        SlotDto GetByTime(DateTime appointmentDate);
        bool SlotExists(DateTime appointmentDate);
        Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate);
        Task<bool> SlotExistsAsync(string slotId);
    }
}
