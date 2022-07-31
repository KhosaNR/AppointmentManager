using Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AppointmentPersons.Queries
{
    public class AppointmentPersonQuery:IAppointmentPersonQuery
    {
        IAppointmentPersonRepository AppointmentPersonRepository;
        public AppointmentPersonQuery(IAppointmentPersonRepository appointmentPersonRepository)
        {
            AppointmentPersonRepository = appointmentPersonRepository;
        }

        public Task<Domain.Entities.AppointmentPerson> GetById(string id)
        {
            return AppointmentPersonRepository.GetById(Guid.Parse(id));
        }
    }
}
