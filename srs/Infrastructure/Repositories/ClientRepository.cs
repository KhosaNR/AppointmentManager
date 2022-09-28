using Domain.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ClientRepository: GenericRepository<Domain.Entities.Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context): base(context)
        { }

        public async Task<IEnumerable<Domain.Entities.Client>> GetByLastName(string LastName)
        {
            return await _context.Clients.Where(x=> x.LastName == LastName).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Client>> GetByPhoneNo(string phoneNo)
        {
            return await _context.Clients.Where(x => x.PhoneNo == phoneNo).ToListAsync();
        }
    }

}
