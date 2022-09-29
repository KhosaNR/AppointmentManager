using Application.DTOs;
using Domain.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.Clients.Queries
{
    public class ClientQueries : IClientQueries
    {
        readonly IUnitOfWork uow;

        public ClientQueries(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public bool PhoneNoHasPendingAppointment(string phoneNo)
        {
            return uow.Clients.GetByPhoneNo(phoneNo).Result
                .Any(x=>x.Slots.Any(a=>a.Status<AppointmentStatus.Done));         
        }
    }
}
