using Domain.Entities;
using Domain.General.Result;
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
        Task BookOneAppointmentAsync(Client client, Results results);
        bool ClientHasPendingAppointment(Domain.Entities.Client client);
        Task CreateClient(Domain.Entities.Client client);
        Task UpdateClient(Domain.Entities.Client client);
    }
}
