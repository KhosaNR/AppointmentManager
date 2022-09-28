using Domain.Interfaces.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Services;
using Domain.Services;

namespace Application.Client.Commands
{
    public class CreateAppointmentCommand : ICreateClientCommand
    {
        //This does not look right.
        ISlotRepository SlotRepository;
        IClientRepository ClientRepository;
        IClientService ClientService;

        IUnitOfWork UnitOfWork;

        public CreateAppointmentCommand(ISlotRepository slotRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork, ClientService ClientService)
        {
            SlotRepository = slotRepository;
            ClientRepository = clientRepository;
            UnitOfWork = unitOfWork;
            this.ClientService = ClientService;
        }

        public CreateAppointmentCommand(IUnitOfWork unitOfWork, IClientService ClientService)
        {
            UnitOfWork = unitOfWork;
            this.ClientService = ClientService;
        }

        public void Execute(ClientDto Client)
        {
            Domain.Entities.Client person = new()
            {
                FirstName = Client.FirstName,
                LastName = Client.LastName,
                PhoneNo = Client.PhoneNo,
            };

            SlotDto slotDto = Client.Slots.FirstOrDefault();
            if (slotDto is null)
            {
                //maybe a throw a message saying you cannot add an appointment without a slot?
                return;
            }
            ClientService.CreateUser(Client.FirstName, Client.LastName, Client.PhoneNo, slotDto.SlotDate);
        }
    }
}
