using Domain.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext DbContext;
        private bool _disposed;

        public UnitOfWork(ApplicationDbContext dbContext, IAppointmentPersonRepository appointmentPeople, IAppointmentRepository appointments)
        {
            DbContext = dbContext;
            AppointmentPeople = appointmentPeople;
            Appointments = appointments;
        }

        public IAppointmentPersonRepository AppointmentPeople { get; }
        public IAppointmentRepository Appointments {get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()//bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
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
                    entityEntry.Property("Id").CurrentValue = Guid.NewGuid();
                    entityEntry.Property("CreatedDate").CurrentValue = DateTime.Now;
                    entityEntry.Property("UpdatedDate").CurrentValue = DateTime.Now;
                }

            }

            return await DbContext.SaveChangesAsync();
        }
    }
}
