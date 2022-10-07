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
using Domain.General.Result;

namespace Application.Clients.Commands
{
    public class CreateClientCommand : ICreateClientCommand
    {
        //This does not look right.
        ISlotRepository SlotRepository;
        IClientRepository ClientRepository;
        IClientService ClientService;

        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public CreateClientCommand(ISlotRepository slotRepository, IClientRepository clientRepository, IUnitOfWork unitOfWork, ClientService ClientService, IMapper mapper)
        {
            SlotRepository = slotRepository;
            ClientRepository = clientRepository;
            UnitOfWork = unitOfWork;
            this.ClientService = ClientService;
            Mapper = mapper;
        }

        public CreateClientCommand(IUnitOfWork unitOfWork, IClientService ClientService,IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            this.ClientService = ClientService;
            Mapper = mapper;
        }

        public async Task<Results> Execute(ClientDto clientDto)
        {
            var results = new Results();
            try
            {
                var client = Mapper.Map<Client>(clientDto);
                await ClientService.BookOneAppointmentAsync(client, results);
                return results;
            }
            catch(Exception ex)
            {
                results.Add(new UnexpectedResult("Something went wrong while trying to create this appointment."));
                return results;
                //Log
            }
        }
    }
}
