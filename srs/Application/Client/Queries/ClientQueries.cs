using Application.DTOs;
using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Entities;
using AutoMapper;

namespace Application.Clients.Queries
{
    public class ClientQueries : IClientQueries
    {
        readonly IUnitOfWork uow;
        IMapper Mapper;

        public ClientQueries(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            Mapper = mapper;
        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            
            var Clients = await uow.Clients.GetAllWithRelatedAsync();
            var clientDtoList = Mapper.Map<IEnumerable<ClientDto>>(Clients);
            return clientDtoList;

        }

        public bool PhoneNoHasPendingAppointment(string phoneNo)
        {
            return uow.Clients.GetByPhoneNo(phoneNo).Result
                .Any(x=>x.Slots.Any(a=>a.Status<AppointmentStatus.Done));         
        }
    }
}
