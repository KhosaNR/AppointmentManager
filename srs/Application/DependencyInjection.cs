using Domain.Interfaces.Persistence;
using Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Client.Commands;
using Domain.Services;
using Application.Services;
using Application.Slot.Commands;
using Application.DTOs.Mapping;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddTransient<ICreateSlotCommand, CreateSlotCommand>();
            services.AddTransient<IClientService, ClientService> ();
            services.AddTransient<IUserService, UserService>();
            services.AddAutoMapper(typeof(ClientProfile));
            services.AddAutoMapper(typeof(SlotProfile));
            return services;
        }
    }
}
