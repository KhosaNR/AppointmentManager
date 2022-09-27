using Domain.Interfaces.Persistence;

namespace Domain.Interfaces.Persistence
{
    public interface IAppointmentPersonRepository: IGenericRepository<Domain.Entities.AppointmentPerson>
    {
        Task<IEnumerable<Domain.Entities.AppointmentPerson>> GetByLastName(string LastName);
        Task<IEnumerable<Domain.Entities.AppointmentPerson>> GetByPhoneNo(string phoneNo);
        //void SaveChanges();
    }
}
