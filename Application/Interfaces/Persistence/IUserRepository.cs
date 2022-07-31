using Application.Iterface.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    internal interface IUserRepository : IGenericRepository<User>
    {
        User GetExistingByPhoneNoAsync(string phoneNo);
    }
}
