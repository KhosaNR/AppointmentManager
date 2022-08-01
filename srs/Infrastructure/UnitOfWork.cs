using Application.Interfaces.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext DbContext;

        public UnitOfWork(ApplicationDbContext dbContext, IAppointmentPersonRepository appointmentPeople, IAppointmentReposistory appointments)
        {
            DbContext = dbContext;
            AppointmentPeople = appointmentPeople;
            Appointments = appointments;
        }

        public IAppointmentPersonRepository AppointmentPeople { get; }
        public IAppointmentReposistory Appointments {get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()//bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            //var changeTracker = DbContext.ChangeTracker;

            var entries = DbContext.ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
                e.State == EntityState.Added
                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property("ID").CurrentValue = Guid.NewGuid();
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }

            }

            return DbContext.SaveChangesAsync();
        }
    }
}
