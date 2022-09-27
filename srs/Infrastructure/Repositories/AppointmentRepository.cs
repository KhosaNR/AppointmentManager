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
    public class AppointmentRepository : GenericRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Appointment GetByDateTime(DateTime appointmentDate)
        {
            return _context.Appointments.Where(x => DateTime.Compare((DateTime)x.AppointmentDate, appointmentDate)==0).FirstOrDefault();
        }

        public bool AppointmentExists(DateTime appointmentDate)
        {
            return  _context.Appointments.Any(x => DateTime.Compare((DateTime)x.AppointmentDate, appointmentDate) == 0);
        }

        public async Task<IEnumerable<DateTime>> GetForWeek(DateTime startDate)
        {
            return await _context.Appointments
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
