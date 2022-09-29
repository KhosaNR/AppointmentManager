using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IClientService: IUserService
    {
        void BookAppointment(Guid client_Id, DateTime appointmentDate);
        Task BookOneAppointment(Client client);
        bool ClientHasPendingAppointment(Domain.Entities.Client client);
        Task CreateClient(Domain.Entities.Client client);
        Task UpdateClient(Domain.Entities.Client client);
    }
}
