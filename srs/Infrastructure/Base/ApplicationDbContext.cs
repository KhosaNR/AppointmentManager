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

        public DbSet<AppointmentPerson> AppointmentPersons { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        //public DbSet<User> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ...
            modelBuilder.ApplyConfiguration(new AppointmentTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentPersonTypeConfiguration());
            // Other entities' configuration ...
        }


    }
}