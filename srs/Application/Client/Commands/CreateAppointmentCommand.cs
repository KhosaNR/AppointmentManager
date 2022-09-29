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
using AutoMapper;

namespace Application.Client.Commands
{
    public class CreateAppointmentCommand : ICreateClientCommand
    {
        //This does not look right.
        ISlotRepository SlotRepository;
        IClientRepository ClientRepository;
        IClientService ClientService;

        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public CreateAppointmentCommand(ISlotRepository slotRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork, ClientService ClientService, IMapper mapper)
        {
            SlotRepository = slotRepository;
            ClientRepository = clientRepository;
            UnitOfWork = unitOfWork;
            this.ClientService = ClientService;
            Mapper = mapper;
        }

        public CreateAppointmentCommand(IUnitOfWork unitOfWork, IClientService ClientService,IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            this.ClientService = ClientService;
            Mapper = mapper;
        }

        public async Task Execute(ClientDto client)
        {
            var person = Mapper.Map<Domain.Entities.Client>(client);
            await ClientService.BookOneAppointment(person);
        }
    }
}
