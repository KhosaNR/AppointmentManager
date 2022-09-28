﻿using Domain.Interfaces.Persistence;

namespace Domain.Interfaces.Persistence
{
    public interface IClientRepository: IGenericRepository<Domain.Entities.Client>
    {
        Task<IEnumerable<Domain.Entities.Client>> GetByLastName(string LastName);
        Task<IEnumerable<Domain.Entities.Client>> GetByPhoneNo(string phoneNo);
        //void SaveChanges();
    }
}