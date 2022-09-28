using Domain.Interfaces.Persistence;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class UserService: IUserService
    {
        IUnitOfWork uow;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.uow = unitOfWork;
        }

        public void CreateUser(string firstName, string lastName, string phoneNo, DateTime appointmentDate)
        {
        }

        public void CreateUser(User person)
        {
            throw new NotImplementedException();
        }
    }
}
