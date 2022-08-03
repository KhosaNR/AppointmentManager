using Application.Interfaces.Persistence;
using Domain.Entities;
using Infrastructure.Base;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IAppointmentPersonRepository, AppointmentPersonRepository>();
            services.AddTransient<IAppointmentRepository, AppointmentRepository> ();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(opt => opt
                .UseSqlServer("Server=(LOCAL)\\SQL2017; Database=AppoinmentMaker;Trusted_Connection=True;User Id=sa;Password=Mypassword1;"));
            return services;
        }
    }
}
