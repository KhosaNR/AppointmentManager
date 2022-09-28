using Domain.Interfaces.Persistence;
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
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ISlotRepository, SlotRepository> ();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<ApplicationDbContext>(opt => opt
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AppointmentManager_0;Trusted_Connection=True;MultipleActiveResultSets=true"));
            services.AddTransient<ApplicationDbContext>();
            return services;
        }

        //public static IWebApplicationBuilder AddInfrastructure(this IWebApplicationBuilder builder)
        //{
        //    return builder;
        //}
    }
}
