using Domain.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Services
{
    public class ClientService: IClientService, IUserService
    {
        IUnitOfWork uow;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        public async Task BookOneAppointment(Domain.Entities.Client client)
        {
            if (client.Slots.Count != 1)
            {
                throw new Exception($"When creating an appointment, expected 1 slot, received {client.Slots.Count} slots.");
            }
            var clients = await uow.Clients.GetByPhoneNo(client.PhoneNo);
            var existingClient = clients.FirstOrDefault();
            if(existingClient == null)
            {
                await CreateClient(client);
                return;
            }

            var newSlot = client.Slots.First();
            await AddNewAppointmentToExistingClient(existingClient, newSlot);
        }

        public async Task AddNewAppointmentToExistingClient(Domain.Entities.Client existingClient, Domain.Entities.Slot newSlot)
        {
            if (ClientHasPendingAppointment(existingClient))
            {
                //Use Result
                throw new Exception($"Failed! Cannot add new appointment to client {existingClient.Id} due to a pending appointment");
            }

            newSlot.Status = AppointmentStatus.Booked;
            existingClient.AddSlot(newSlot);
            await UpdateClient(existingClient);
        }

        public async Task UpdateClient(Domain.Entities.Client client)
        {
            uow.Clients.Update(client);
            await uow.SaveChangesAsync();
        }

        public async Task CreateClient(Domain.Entities.Client client)
        {
            await uow.Clients.AddAsync(client);
            await uow.SaveChangesAsync();
        }

        public bool ClientHasPendingAppointment(Domain.Entities.Client client)
        {
            return client.Slots.Any(x=>x.Status<AppointmentStatus.Done);
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
