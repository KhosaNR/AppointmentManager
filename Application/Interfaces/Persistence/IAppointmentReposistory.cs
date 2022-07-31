using Application.Iterface.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces.Persistence
{
    public interface IAppointmentReposistory: IGenericRepository<Appointment>
    {
    }
}
