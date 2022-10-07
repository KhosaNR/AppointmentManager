using Domain.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Utilities;

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
            return await LoadAllWithRelatedAndConditionAsync<Client>(c=>c.PhoneNo==phoneNo,p => p.Slots);
            //return await _context.Clients.Where(x => x.PhoneNo == phoneNo)
            //    .ToListAsync();
        }

        public async Task<IEnumerable<Client>> GetAllWithRelatedAsync()
        {
            return await _context.Set<Client>().Include(p => p.Slots).ToListAsync();
        }

        public async Task<Client> GetByIdAndSlotId(Guid Id, Guid slotId)
        {
            return await _context.Set<Client>().Include(p => p.Slots).Where(x => x.Slots.Any(s => s.Id == slotId)).FirstOrDefaultAsync();
            //return await LoadAllWithRelatedAndConditionAsync<Client>(c =>
            //c.Id == Id
            //&& c.Slots.Any(s => s.Id == slotId), p => p.Slots);
        }
    }

}
