using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IUserService
    {
        void CreateUser(string firstName, string lastName, string PhoneNo, DateTime appointmentTime);
    }
}
