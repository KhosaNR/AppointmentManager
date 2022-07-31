using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.AppointmentPersons.Queries
{
    internal interface IAppointmentPersonQuery
    {
        Task<Domain.Entities.AppointmentPerson> GetById(string id);
    }
}
