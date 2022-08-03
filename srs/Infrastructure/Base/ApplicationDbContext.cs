using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Base
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<AppointmentPerson> AppointmentPersons { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<User> Persons { get; set; }

    }
}