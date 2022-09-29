using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Clients.Queries
{
    public interface IClientQueries
    {
        bool PhoneNoHasPendingAppointment(string phoneNo);
    }
}
