using Domain.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot.Services
{
    internal class UserService: IUserService
    {
        IUnitOfWork uow;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        public void CreateUser(string firstName, string lastName, string phoneNo, DateTime appointmentTime)
        {
        }

        public void CreateUser(User person)
        {
            throw new NotImplementedException();
        }
    }
}
