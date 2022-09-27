using Domain.Interfaces.Persistence;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentPersons.Command;
using Domain.Services;
using Slot.Services;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<ICreateAppointmentPersonCommand, CreateAppointmentCommand>();
            services.AddTransient<IAppointmentPersonService, AppointmentPersonService> ();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
