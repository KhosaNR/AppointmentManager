using Domain.Entities;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Infrastructure.Base
{
    public class ApplicationDbContext : DbContext
    {
        //public const string DEFAULT_SCHEMA = "scheduling";

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Slot> Slots { get; set; }
        //public DbSet<User> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...
            modelBuilder.ApplyConfiguration(new ClientTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SlotTypeConfiguration());
            // Other entities' configuration ...
        }


    }
}