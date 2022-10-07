using Application.DTOs;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.General.Result;
using Domain.Interfaces.Persistence;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients.Commands
{
    public class UpdateClientCommand : IUpdateClientCommand
    {
        IClientService ClientService;
        IUnitOfWork UnitOfWork;
        IMapper Mapper;

        public UpdateClientCommand(IUnitOfWork unitOfWork, IClientService clientService, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            ClientService = clientService;
            Mapper = mapper;
        }

        public async Task<Results> Execute(ClientDto clientDto)
        {
            var results = new Results();
            try
            {
                var slotId = clientDto.Slots.FirstOrDefault().Id;
                var client = await UnitOfWork.Clients.GetByIdAndSlotId(Guid.Parse(clientDto.Id), slotId);
                Mapper.Map(clientDto, client);
                await ClientService.UpdateClient(client);
                return results;
            }
            catch (Exception ex)
            {
                results.Add(new UnexpectedResult("Something went wrong while trying to create this appointment."));
                return results;
                //Log
            }
        }
    }
}
