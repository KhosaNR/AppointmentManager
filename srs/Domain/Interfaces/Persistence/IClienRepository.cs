using Domain.Entities;
using Domain.Interfaces.Persistence;

namespace Domain.Interfaces.Persistence
{
    public interface IClientRepository: IGenericRepository<Domain.Entities.Client>
    {
        Task<IEnumerable<Domain.Entities.Client>> GetByLastName(string LastName);
        Task<IEnumerable<Domain.Entities.Client>> GetByPhoneNo(string phoneNo);
        Task<IEnumerable<Client>> GetAllWithRelatedAsync();
        Task<Client> GetByIdAndSlotId(Guid Id, Guid slotId);
        Task<Client> GetByLastNameAndPhoneNo(string lastName, string phoneNo);
        //void SaveChanges();
    }
}
