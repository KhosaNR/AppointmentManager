using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Context: DbContext
    {
        DbSet<Appointment> Appointments { get; set; }   
        DbSet<User> People { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local)\sql2017;Database=AppointmentManager;User Id=sa;Password=Mypassword1;");
        }
    }
}
