using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}
