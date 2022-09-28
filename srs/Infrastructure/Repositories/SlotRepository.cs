using Domain.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Enums;

namespace Infrastructure.Repositories
{
    public class SlotRepository : GenericRepository<Slot>, ISlotRepository
    {
        public SlotRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Slot GetByDateTime(DateTime appointmentDate)
        {
            return _context.Slots.Where(x => DateTime.Compare((DateTime)x.AppointmentDate, appointmentDate)==0).FirstOrDefault();
        }

        public bool AppointmentExists(DateTime appointmentDate)
        {
            return  _context.Slots.Any(x => DateTime.Compare((DateTime)x.AppointmentDate, appointmentDate) == 0);
        }

        public async Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate)
        {
            return await _context.Slots
                .Where(
                x =>
                x.Status < AppointmentStatus.Cancelled &&
                DateTime.Compare((DateTime)x.AppointmentDate, startDate) >= 0 &&
                DateTime.Compare((DateTime)x.AppointmentDate, startDate.AddDays(8)) < 0)
                .Select(x=> (DateTime) x.AppointmentDate)
                //.Where(
                //x =>
                //DateTime.Compare(x,startDate) >= 0 &&
                //DateTime.Compare(x,startDate.AddDays(7)) < 0
                //)
                .ToListAsync();
        }
    }
}
