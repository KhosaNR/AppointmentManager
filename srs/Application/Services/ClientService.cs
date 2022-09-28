using Domain.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClientService: IClientService, IUserService
    {
        IUnitOfWork uow;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        public void BookAppointment(Guid client_Id, DateTime appointmentDate)
        {
            var Client = uow.Clients.GetById(client_Id).Result;
            if (Client == null)
                throw new Exception("Client not found");
            var slot = new Domain.Entities.Slot
            {
                AppointmentDate = appointmentDate,
                Status = Domain.Enums.AppointmentStatus.Booked,
                Person_Id = client_Id,
            };
            Client.AddSlot(slot);
            uow.SaveChangesAsync();
        }

        public void CreateUser(string firstName, string lastName, string PhoneNo, DateTime appointmentDate)
        {
            var Client = new Domain.Entities.Client
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNo = PhoneNo
            };
            Domain.Entities.Slot slot = new()
            {
                AppointmentDate = appointmentDate
            };
            Client.AddSlot(slot);
            uow.Clients.AddAsync(Client);
            uow.SaveChangesAsync();
        }
    }
}
