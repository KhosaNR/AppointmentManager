 using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        ISlotRepository Slots { get; }
        Task<int> SaveChangesAsync();
    }
}
