 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IAppointmentPersonRepository AppointmentPeople { get; }
        IAppointmentReposistory Appointments { get; }
        Task<int> SaveChangesAsync();
    }
}
