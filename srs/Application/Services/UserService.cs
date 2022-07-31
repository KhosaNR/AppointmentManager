using Application.Interfaces.Persistence;
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
        IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            var existingUser = userRepository.GetExistingByPhoneNoAsync(user.PhoneNo);
            if(existingUser != null)
            {
                throw new Exception($"User with phone number {user.PhoneNo} already exists");
            }
            userRepository.AddAsync(user);
        }
    }
}
