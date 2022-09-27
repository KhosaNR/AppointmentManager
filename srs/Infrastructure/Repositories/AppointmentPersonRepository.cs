using Domain.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AppointmentPersonRepository: GenericRepository<AppointmentPerson>, IAppointmentPersonRepository
    {
        public AppointmentPersonRepository(ApplicationDbContext context): base(context)
        { }

        public async Task<IEnumerable<AppointmentPerson>> GetByLastName(string LastName)
        {
            return await _context.AppointmentPersons.Where(x=> x.LastName == LastName).ToListAsync();
        }

        public async Task<IEnumerable<AppointmentPerson>> GetByPhoneNo(string phoneNo)
        {
            return await _context.AppointmentPersons.Where(x => x.PhoneNo == phoneNo).ToListAsync();
        }
    }

}
