using Domain.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.General.Result;

namespace Application.Services
{
    public class ClientService: IClientService, IUserService
    {
        IUnitOfWork uow;

        public ClientService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        public async Task BookOneAppointmentAsync(Client client, Results results)
        {
            if (client.Slots.Count != 1)
            {
                results.Add(new InvalidResult($"When creating an appointment, expected 1 slot, received {client.Slots.Count} slots."));
                return;
            }
            var clients = await uow.Clients.GetByPhoneNo(client.PhoneNo);
            var existingClient = clients.FirstOrDefault();
            if(existingClient == null)
            {
                await CreateClient(client);
                new SuccessResult<Client>(client);
                return;
            }

            var newSlot = client.Slots.First();
            var bookingResult = existingClient.BookNewAppointment(newSlot,false);
            results.Add(bookingResult);
            if (!results.IsOk()) return;
            await UpdateClient(existingClient);
        }

        public async Task UpdateClient(Client client)
        {
            uow.Clients.Update(client);
            await uow.SaveChangesAsync();
        }

        public async Task CreateClient(Client client)
        {
            await uow.Clients.AddAsync(client);
            await uow.SaveChangesAsync();
        }

        public bool ClientHasPendingAppointment(Client client)
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
            var Client = new Client
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
